using System;

namespace N2_V16.Models
{
    /// <summary>
    /// class Taxi that inherits class Car
    /// </summary>
    class Taxi : Car
    {
        /// <summary>
        /// seating capacity of taxi
        /// </summary>
        public int SeatingCapacity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand">taxi brand</param>
        /// <param name="releaseDate">taxi release date</param>
        /// <param name="stateNumber">taxi state number</param>
        /// <param name="autoParkCipher">taxi auto park cipher</param>
        /// <param name="seatingCapacity">taxi seating capacity</param>
        public Taxi(string brand, DateTime releaseDate, string stateNumber, string autoParkCipher, int seatingCapacity)
            // calling base constructor
            : base(brand, releaseDate, stateNumber, autoParkCipher)
        {
            SeatingCapacity = seatingCapacity;
        }

        /// <summary>
        /// overriding ToString method to get object fields in a string
        /// </summary>
        /// <returns>object fields separated by coma</returns>
        public override string ToString()
        {
            return "Car: " + base.ToString() + $", Seating capacity: {SeatingCapacity}";
        }
    }
}
