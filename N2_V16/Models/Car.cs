using System;

namespace N2_V16.Models
{
    /// <summary>
    /// base abstract class for transport
    /// </summary>
    abstract class Car
    {
        /// <summary>
        /// brand
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// release date of a car
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// state number
        /// </summary>
        public string StateNumber { get; set; }
        /// <summary>
        /// cipher of an auto park the car relates to
        /// </summary>
        public string AutoParkCipher { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public Car()
        {

        }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="brand">car brand</param>
        /// <param name="releaseDate">car release date</param>
        /// <param name="stateNumber">car state number</param>
        /// <param name="autoParkCipher">car auto park cipher</param>
        protected Car(string brand, DateTime releaseDate, string stateNumber, string autoParkCipher)
        {
            Brand = brand;
            ReleaseDate = releaseDate;
            StateNumber = stateNumber;
            AutoParkCipher = autoParkCipher;
        }

        /// <summary>
        /// overriding ToString method to get object fields in a string
        /// </summary>
        /// <returns>object fields separated by coma</returns>
        public override string ToString()
        {
            return $"Brand: {Brand}, Release date: {ReleaseDate.ToShortDateString()}, StateNumber: {StateNumber}, AutoParkCipher: {AutoParkCipher}"; 
        }
    }
}
