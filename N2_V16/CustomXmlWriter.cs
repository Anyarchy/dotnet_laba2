using N2_V16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace N2_V16
{
    static class CustomXmlWriter
    {
        public static void WriteData()
        {
            var lorries = new List<Lorry>()
            {
                new Lorry("brand1", new DateTime(2017, 7, 20), "number1", "cipher1", 250, new DateTime(2020, 12, 20)),
                new Lorry("brand2", new DateTime(2018, 3, 19), "number2", "cipher2", 300, new DateTime(2021, 10, 23)),
                new Lorry("brand3", new DateTime(2019, 2, 2), "number3", "cipher3", 150, new DateTime(2019, 3, 15)),
                new Lorry("brand4", new DateTime(2018, 5, 4), "number4", "cipher4", 250, new DateTime(2020, 6, 2)),
                new Lorry("brand5", new DateTime(2019, 3, 2), "number5", "cipher5", 100, new DateTime(2022, 2, 20)),
                new Lorry("brand1", new DateTime(2018, 2, 17), "number6", "cipher5", 250, new DateTime(2020, 1, 18)),
                new Lorry("brand1", new DateTime(2016, 10, 3), "number7", "cipher5", 200, new DateTime(2018, 4, 17))
            };
            var moreLorries = new List<Lorry>()
            {
                new Lorry("brand1", new DateTime(2017, 7, 20), "number1", "cipher1", 250, new DateTime(2020, 12, 20)),
                new Lorry("brand2", new DateTime(2018, 3, 19), "number2", "cipher2", 300, new DateTime(2021, 10, 23)),
                new Lorry("brand3", new DateTime(2019, 2, 2), "number3", "cipher3", 150, new DateTime(2019, 3, 15)),
            };
            WriteLorries(lorries, Program.LorriesPath);
            WriteLorries(moreLorries, Program.MoreLorriesPath);

            WriteTaxis();
            WriteAutoParks();
        }

        private static void WriteLorries(List<Lorry> lorries, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                writer.WriteStartElement("lorries");

                foreach (Lorry lorry in lorries)
                {
                    writer.WriteStartElement("lorry");
                    writer.WriteElementString("brand", lorry.Brand);
                    writer.WriteElementString("releaseDate", lorry.ReleaseDate.ToString());
                    writer.WriteElementString("stateNumber", lorry.StateNumber);
                    writer.WriteElementString("autoParkCipher", lorry.AutoParkCipher);
                    writer.WriteElementString("loadCapacity", lorry.LoadCapacity.ToString());
                    writer.WriteElementString("majorRepairDate", lorry.MajorRepairDate.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        private static void WriteTaxis()
        {
            var taxis = new List<Taxi>()
            {
                new Taxi("brand1", DateTime.Now.AddMonths(-13), "number8", "cipher1", 4),
                new Taxi("brand2", DateTime.Now.AddMonths(-12), "number9", "cipher2", 8),
                new Taxi("brand3", DateTime.Now.AddMonths(-7), "number10", "cipher3", 5),
                new Taxi("brand4", DateTime.Now.AddMonths(-1), "number11", "cipher1", 2),
                new Taxi("brand4", DateTime.Now.AddMonths(-9), "number12", "cipher4", 4),
                new Taxi("brand4", DateTime.Now.AddMonths(-3), "number13", "cipher1", 4)
            };

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(Program.TaxisPath, settings))
            {
                writer.WriteStartElement("taxis");

                foreach (Taxi taxi in taxis)
                {
                    writer.WriteStartElement("taxi");
                    writer.WriteElementString("brand", taxi.Brand);
                    writer.WriteElementString("releaseDate", taxi.ReleaseDate.ToString());
                    writer.WriteElementString("stateNumber", taxi.StateNumber);
                    writer.WriteElementString("autoParkCipher", taxi.AutoParkCipher);
                    writer.WriteElementString("seatingCapacity", taxi.SeatingCapacity.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        private static void WriteAutoParks()
        {
            var autoParks = new List<AutoPark>()
            {
                new AutoPark("auto park1", "address1", 350, "cipher1"),
                new AutoPark("auto park2", "address2", 500, "cipher2"),
                new AutoPark("auto park3", "address3", 300, "cipher3"),
                new AutoPark("auto park4", "address4", 120, "cipher4"),
                new AutoPark("auto park5", "address5", 520, "cipher5"),
                new AutoPark("auto park6", "address6", 100, "cipher6"),
                new AutoPark("auto park7", "address7", 50, "cipher7")
            };

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(Program.AutoParkPath, settings))
            {
                writer.WriteStartElement("autoParks");

                foreach (AutoPark autoPark in autoParks)
                {
                    writer.WriteStartElement("autoPark");
                    writer.WriteElementString("name", autoPark.Name);
                    writer.WriteElementString("totalArea", autoPark.TotalArea.ToString());
                    writer.WriteElementString("address", autoPark.Address);
                    writer.WriteElementString("cipher", autoPark.Cipher);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
    }
}
