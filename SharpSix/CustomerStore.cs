namespace SharpSix
{
    using System;
    using System.Threading.Tasks;

    public class CustomerStore
    {
        public Customer GetById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(FormattableString.Invariant($"ID must be greater than 0, but was {id}"));
            }

            Customer customer;
            switch (id)
            {
                case 1:
                    customer = new Customer("Omego2K", new Address("4 Crinan St.", "London", "England"));
                    break;
                case 2:
                    customer = new Customer("Beyonce", null);
                    break;
                default:
                    customer = null;
                    break;

            }

            return customer;
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            var task = new Task<Customer>(()=> this.GetById(id));
            task.Start();

            return task;
        }
    }
}