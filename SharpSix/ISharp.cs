namespace SharpSix
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISharp
    {
        string Name { get; }

        string Greeting { get; }

        double GetPercentage(double partial, double whole);

        double GetSquareRoot(double target);

        string GetCustomerStreetAddressById(int id);

        string GetExceptionMessage(ErrorSeverity severity);

        string SortString(string target);

        Dictionary<Guid, string> GetProducts();

        Customer GetCustomerById(int id, bool throwException);

        Task<Customer> GetCustomerByIdAsync(int id);

        LinkedList<int> GetCustomerIds();
    }
}