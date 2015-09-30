namespace SharpSix
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Threading.Tasks;

    public class OldSharp : ISharp
    {
        public OldSharp()
        {
            this.Name = "NoName";
        }

        public OldSharp(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string Greeting
        {
            get
            {
                return "Hello " + this.Name;
            }
        }

        public double GetPercentage(double partial, double whole)
        {
            return partial / whole * 100;
        }

        public double GetSquareRoot(double target)
        {
            return Math.Sqrt(target);
        }

        public string GetCustomerStreetAddressById(int id)
        {
            var customerStore = new CustomerStore();
            var customer = customerStore.GetById(id);
            string address;

            if (customer == null || customer.Address == null)
            {
                address = null;
            }
            else
            {
                address = customer.Address.Street;
            }

            return address;
        }

        public string GetExceptionMessage(ErrorSeverity severity)
        {
            return String.Format(CultureInfo.InvariantCulture, "A {0} error has occurred", severity);
        }

        public string SortString(string target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }

            var targetToSort = target.ToCharArray();
            Array.Sort(targetToSort);

            return new string(targetToSort);
        }

        public Dictionary<Guid, string> GetProducts()
        {
            return new Dictionary<Guid, string>
                       {
                           { new Guid("00000000-0000-0000-0000-000000000001"), "Book" },
                           { new Guid("00000000-0000-0000-0000-000000000002"), "Magazine" },
                           { new Guid("00000000-0000-0000-0000-000000000003"), "The blue stuff" }
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
            catch (ArgumentException)
            {
                if (throwException)
                {
                    throw;
                }
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
                Logger.LogAsync(ex.Message).GetAwaiter().GetResult();
            }

            return customer;
        }

        public LinkedList<int> GetCustomerIds()
        {
            var list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            return list;
        }
    }
}