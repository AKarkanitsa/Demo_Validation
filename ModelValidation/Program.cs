using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation 
{
    internal class Program
    {
        static Customer CreateCustomer(int customerID, string firstName, string lastName)
        {
            Customer customer = new Customer(customerID, firstName, lastName);
            var context = new ValidationContext(customer);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(customer, context, results, true))
            {
                Console.WriteLine("Failed to create User object");
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
               return null;
            }
            else
            {
                Console.WriteLine($"The Customer object was successfully created.");
                return new Customer(customerID, firstName, lastName);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Creating a Customer:");
            Customer customer = CreateCustomer(1,"I", "");           
        }
    }
}