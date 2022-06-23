using System;

namespace N2_V16.Models
{
    /// <summary>
    /// class Lorry that inherits class Car
    /// </summary>
    class Lorry : Car
    {
        /// <summary>
        /// load capacity
        /// </summary>
        public double LoadCapacity { get; set; }
        /// <summary>
        /// major repair date
        /// </summary>
        public DateTime MajorRepairDate { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public Lorry()
        {

        }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="brand">lorry brand</param>
        /// <param name="releaseDate">lorry release date</param>
        /// <param name="stateNumber">lorry state number</param>
        /// <param name="autoParkCipher">lorry auto park cipher</param>
        /// <param name="loadCapacity">lorry load capacity</param>
        /// <param name="majorRepairDate">lorry major repair date</param>
        public Lorry(string brand, DateTime releaseDate, string stateNumber, string autoParkCipher, double loadCapacity, DateTime majorRepairDate)
            // calling base constructor
            : base(brand, releaseDate, stateNumber, autoParkCipher)
        {
            LoadCapacity = loadCapacity;
            MajorRepairDate = majorRepairDate;
        }

        /// <summary>
        /// overriding ToString method to get object fields in a string
        /// </summary>
        /// <returns>object fields separated by coma</returns>
        public override string ToString()
        {
            return "Lorry: " + base.ToString() + $", Load capacity: {LoadCapacity}, Major repair date: {MajorRepairDate.ToShortDateString()}";
        }

        /// <summary>
        /// overriding method to compare two objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if objects are equal, otherwise - false</returns>
        public override bool Equals(object obj)
        {
            var item = obj as Lorry;

            if (item == null)
            {
                return false;
            }

            return Brand.Equals(item.Brand) &&
                   ReleaseDate.Equals(item.ReleaseDate) &&
                   StateNumber.Equals(item.StateNumber) &&
                   AutoParkCipher.Equals(item.AutoParkCipher) &&
                   LoadCapacity.Equals(item.LoadCapacity) &&
                   MajorRepairDate.Equals(item.MajorRepairDate);
        }

        /// <summary>
        /// method to get hashcode of the object
        /// </summary>
        /// <returns>hashcode of the object</returns>
        public override int GetHashCode()
        {
            return Brand.GetHashCode() ^
                  ReleaseDate.GetHashCode() ^
                  StateNumber.GetHashCode() ^
                  AutoParkCipher.GetHashCode() ^
                  LoadCapacity.GetHashCode() ^
                  MajorRepairDate.GetHashCode();
        }
    }
}
