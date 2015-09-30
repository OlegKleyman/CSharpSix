namespace SharpSix
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static System.Math;

    public class NewSharp : ISharp
    {
        public NewSharp()
        {
        }

        public NewSharp(string name)
        {
            this.Name = name;
        }

        public string Name { get; } = "NoName";

        public string Greeting => "Hello " + this.Name;

        public double GetPercentage(double partial, double whole) => partial / whole * 100;

        public double GetSquareRoot(double target) => Sqrt(target);

        public string GetCustomerStreetAddressById(int id)
        {
            var customerStore = new CustomerStore();
            var customer = customerStore.GetById(id);

            return customer?.Address?.Street;
        }

        public string GetExceptionMessage(ErrorSeverity severity)
            => FormattableString.Invariant($"A {severity} error has occurred");

        public string SortString(string target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var targetToSort = target.ToCharArray();
            Array.Sort(targetToSort);

            return new string(targetToSort);
        }

        public Dictionary<Guid, string> GetProducts()
        {
            return new Dictionary<Guid, string>
                       {
                           [new Guid("00000000-0000-0000-0000-000000000001")] = "Book",
                           [new Guid("00000000-0000-0000-0000-000000000002")] = "Magazine",
                           [new Guid("00000000-0000-0000-0000-000000000003")] = "The blue stuff"
                       };
        }

        public Customer GetCustomerById(int id, bool throwException)
        {
            var customerStore = new CustomerStore();

            Customer customer = null;

            try
            {
                customer = customerStore.GetById(id);
            }
            catch (ArgumentException) when(!throwException)
            {
            }

            return customer;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customerStore = new CustomerStore();

            Customer customer = null;

            try
            {
                customer = await customerStore.GetByIdAsync(id);
            }
            catch (ArgumentException ex)
            {
                await Logger.LogAsync(ex.Message);
            }

            return customer;
        }

        public LinkedList<int> GetCustomerIds()
        {
            var list = new LinkedList<int> {1, 2, 3};
            
            return list;
        }
    }
}