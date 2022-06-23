using N2_V16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace N2_V16
{
    class Program
    {
        public static readonly string AutoParkPath = "AutoPark.xml";
        public static readonly string LorriesPath = "Lorries.xml";
        public static readonly string MoreLorriesPath = "MoreLorries.xml";
        public static readonly string TaxisPath = "Taxis.xml";
        static void Main(string[] args)
        {
            CustomXmlWriter.WriteData();

            XmlDocument doc = new XmlDocument();
            doc.Load(LorriesPath);

            foreach (XmlNode node in doc.DocumentElement)
            {
                string brand = node["brand"].InnerText;
                DateTime releaseDate = DateTime.Parse(node["releaseDate"].InnerText);
                string stateNumber = node["stateNumber"].InnerText;
                string autoParkCipher = node["autoParkCipher"].InnerText;
                double loadCapacity = double.Parse(node["loadCapacity"].InnerText);
                DateTime majorRepairDate = DateTime.Parse(node["majorRepairDate"].InnerText);

                Console.WriteLine($"Lorry {brand}; Release date: {releaseDate.ToShortDateString()}; State number: {stateNumber}; Cipher: {autoParkCipher};" +
                    $"Load capacity: {loadCapacity}; Major repair date: {majorRepairDate.ToShortDateString()}");
            }

            XDocument xmlDoc = XDocument.Load(LorriesPath);
            Console.WriteLine(new string('-', 40));
            foreach (XElement lorryElement in xmlDoc.Element("lorries").Elements("lorry"))
            {
                XElement brandAttribute = lorryElement.Element("brand");
                XElement releaseDateAttribute = lorryElement.Element("releaseDate");
                XElement stateNumberAttribute = lorryElement.Element("stateNumber");
                XElement autoParkAttribute = lorryElement.Element("autoParkCipher");
                XElement loadCapacityAttribute = lorryElement.Element("loadCapacity");
                XElement majorRepairDateAttribute = lorryElement.Element("majorRepairDate");

                Console.WriteLine("Brand: " + brandAttribute?.Value);
                Console.WriteLine("Release date: " + releaseDateAttribute?.Value);
                Console.WriteLine("State number: " + stateNumberAttribute?.Value);
                Console.WriteLine("Auto park cipher: " + autoParkAttribute?.Value);
                Console.WriteLine("Load capacity: " + loadCapacityAttribute?.Value);
                Console.WriteLine("Major repair date: " + majorRepairDateAttribute?.Value);
                Console.WriteLine(new string('-', 40));
            }

            XDocument xmlTaxDoc = XDocument.Load(TaxisPath);
            XDocument xmlMoreLDoc = XDocument.Load(MoreLorriesPath);
            XDocument xmlAutoParkDoc = XDocument.Load(AutoParkPath);

            Console.WriteLine("Taxis\n" + new string('-', 40));
            foreach (XElement taxiElement in xmlTaxDoc.Element("taxis").Elements("taxi"))
            {
                XElement brandAttribute = taxiElement.Element("brand");
                XElement releaseDateAttribute = taxiElement.Element("releaseDate");
                XElement stateNumberAttribute = taxiElement.Element("stateNumber");
                XElement autoParkAttribute = taxiElement.Element("autoParkCipher");
                XElement seatingCapacityAttribute = taxiElement.Element("seatingCapacity");

                Console.WriteLine("Brand: " + brandAttribute?.Value);
                Console.WriteLine("Release date: " + releaseDateAttribute?.Value);
                Console.WriteLine("State number: " + stateNumberAttribute?.Value);
                Console.WriteLine("Auto park cipher: " + autoParkAttribute?.Value);
                Console.WriteLine("Seating capacity: " + seatingCapacityAttribute?.Value);
                Console.WriteLine(new string('-', 40));
            }

            // +-+-+-+-+-+-+ [1] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tList of lorries load capacities ordered by load capacity");
            var querySorted = xmlDoc.Descendants("lorry").Select(l => l.Element("loadCapacity").Value).OrderBy(l => l.Trim());
            foreach (var s in querySorted)
            {
                Console.WriteLine(s);
            }

            // +-+-+-+-+-+-+ [2] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tFilter by a brand name");
            var queryDate = xmlDoc.Root.Elements("lorry")
                            .Where(b => b.Element("brand").Value.EndsWith("2"));
            Console.WriteLine(queryDate.FirstOrDefault().Element("brand").Value);

            // +-+-+-+-+-+-+ [3] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tLorries from auto park with cipher5");
            var items = xmlDoc.Root.Elements("lorry")
                        .Where(xe => xe.Element("autoParkCipher").Value == "cipher5")
                        .Select(xe => new Lorry
                        {
                            Brand = xe.Element("brand").Value,
                            ReleaseDate = DateTime.Parse(xe.Element("releaseDate").Value)
                        });

            foreach (var item in items)
            {
                Console.WriteLine(item.Brand + " " + item.ReleaseDate.ToShortDateString());
            }

            // +-+-+-+-+-+-+ [4] +-+-+-+-+-+-+ \\

            Console.WriteLine("\t\tSelect with filter");
            var q4 = xmlAutoParkDoc.Root.Elements("autoPark")
                     .Where(xe => double.Parse(xe.Element("totalArea").Value) >= 150);
            foreach (var item in q4)
            {
                Console.WriteLine(item.Element("name").Value + " with " + item.Element("totalArea").Value + " area");
            }

            // +-+-+-+-+-+-+ [5] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tCreating anonymous object");
            var q5 = xmlDoc.Root.Elements("lorry")
                                .Where(b => b.Element("brand").Value.EndsWith("1"))
                                .Select(b => new { brand = b.Element("brand").Value });
            foreach (var item in q5)
            {
                Console.WriteLine(item);
            }


            // +-+-+-+-+-+-+ [6] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tCreating anonymous object with filter and sort");
            var q6 = xmlDoc.Root.Elements("lorry")
                               .Where(b => DateTime.Parse(b.Element("releaseDate").Value).Year >= 2018)
                               .Select(b => new { brand = b.Element("brand").Value, releaseDate = b.Element("releaseDate").Value })
                               .OrderByDescending(l => l.releaseDate)
                               .ThenBy(l => l.brand);
            foreach (var item in q6)
            {
                Console.WriteLine(item);
            }

            //// +-+-+-+-+-+-+ [7] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tMax aggregate function using where filter");
            // get all lorries which have max load capacity
            var max = xmlDoc.Root.Elements("lorry").Max(l => l.Element("loadCapacity").Value);
            var q7 = xmlDoc.Root.Elements("lorry").Where(l => l.Element("loadCapacity").Value == max);
            foreach (var item in q7)
            {
                Console.WriteLine(item.Element("brand").Value);
            }

            //// +-+-+-+-+-+-+ [8] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tSkip");
            var q8 = xmlDoc.Root.Elements("lorry").OrderByDescending(l => l.Element("loadCapacity").Value)
                            .Skip(2);
            foreach (var item in q8)
            {
                Console.WriteLine(item.Element("brand").Value);
            }

            Console.WriteLine("\t\tSkipWhile & Take");
            var q8_1 = xmlDoc.Root.Elements("lorry").SkipWhile(l => l.Element("stateNumber").Value == "number2")
                              .Take(3);
            foreach (var item in q8_1)
            {
                Console.WriteLine(item.Element("brand").Value);
            }

            // +-+-+-+-+-+-+ [9] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tTakeWhile");
            var q9 = xmlTaxDoc.Root.Elements("taxi")
                                   .OrderByDescending(l => l.Element("seatingCapacity").Value)
                                   .TakeWhile(t => int.Parse(t.Element("seatingCapacity").Value) >= 5);
            foreach (var item in q9)
            {
                Console.WriteLine(item.Element("brand").Value);
            }
            // +-+-+-+-+-+-+ [10] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tCount aggregate function with filter");
            var count = xmlTaxDoc.Root.Elements("taxi")
                                   .OrderByDescending(l => l.Element("seatingCapacity").Value)
                                   .Skip(2)
                                   .Count();
            Console.WriteLine("Count = " + count);

            // +-+-+-+-+-+-+ [11] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tFirst or default");
            var first = xmlTaxDoc.Root.Elements("taxi").
                 FirstOrDefault(t => 
                 int.Parse(t.Element("seatingCapacity").Value) >= 3 && 
                 int.Parse(t.Element("seatingCapacity").Value) <= 5);

            Console.WriteLine(first?.Element("brand")?.Value);
            // +-+-+-+-+-+-+ [12] +-+-+-+-+-+-+ \\
            Console.WriteLine("Top 2 auto parks with the smallest total area");
            var q12 = xmlAutoParkDoc.Root.Elements("autoPark")
                                         .TakeLast(2)
                                         .OrderByDescending(t => t.Element("totalArea").Value);
            foreach (var item in q12)
            {
                Console.WriteLine(item.Element("totalArea").Value);
            }
            // +-+-+-+-+-+-+ [13] +-+-+-+-+-+-+ \\
            // select lorries that were repaired more than year ago
            // with capacity less than 300
            var q13 = xmlDoc.Root.Elements("lorry")
                                        .Where(l => int.Parse(l.Element("loadCapacity").Value) <= 300
                                        && DateTime.Now.Subtract(DateTime.Parse(l.Element("majorRepairDate").Value)).Days >= 365);
                                        
            foreach (var item in q13)
            {
                Console.WriteLine(item.Element("loadCapacity").Value + " " +item.Element("majorRepairDate").Value);
            }

            // +-+-+-+-+-+-+ [14] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tGroup by");
            var q14 = xmlDoc.Root.Elements("lorry").GroupBy(l => l.Element("autoParkCipher").Value);
            foreach (var item in q14)
            {
                foreach (var i in item)
                {
                    Console.WriteLine(i.Element("brand").Value);
                }
                Console.WriteLine();
            }
            // +-+-+-+-+-+-+ [15] +-+-+-+-+-+-+ \\
            Console.WriteLine("\t\tBrand starts with bra & order by");
            var q15 = xmlDoc.Root.Elements("lorry").Where(l => l.Element("brand").Value.StartsWith("bra")).OrderBy(l => l.Element("brand").Value);
            foreach (var item in q15)
            {
                Console.WriteLine(item.Element("brand").Value);
            }

        }
    }
}
