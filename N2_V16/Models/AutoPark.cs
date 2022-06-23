namespace N2_V16.Models
{
    /// <summary>
    /// an auto park
    /// </summary>
    class AutoPark
    {
        /// <summary>
        /// name of auto park
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// address of auto park
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// total area of auto park
        /// </summary>
        public decimal TotalArea { get; set; }
        /// <summary>
        /// cipher of auto park
        /// </summary>
        public string Cipher { get; set; }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="name">auto park name</param>
        /// <param name="address">auto park address</param>
        /// <param name="totalArea">auto park total area</param>
        /// <param name="cipher">auto park cipher</param>
        public AutoPark(string name, string address, decimal totalArea, string cipher)
        {
            Name = name;
            Address = address;
            TotalArea = totalArea;
            Cipher = cipher;
        }

        /// <summary>
        /// overriding ToString method to get object name
        /// </summary>
        /// <returns>auto park name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
