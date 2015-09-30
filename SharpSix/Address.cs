namespace SharpSix
{
    public class Address
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public Address(string street, string city, string country)
        {
            this.Street = street;
            this.City = city;
            this.Country = country;
        }
    }
}