using System.ComponentModel.DataAnnotations;
using SelfValidation;

Console.WriteLine("Test Customer 1");
Validate(new Customer(0, "Tom", "Cruse"));
Console.WriteLine("Test Customer 2");
Validate(new Customer(-5, "Tom", "Cruse"));
Console.WriteLine("Test Customer 3");
Validate(new Customer(1, "T", "Cruse"));

void Validate(Customer customer)
{
    var results = new List<ValidationResult>();
    var context = new ValidationContext(customer);
    if (!Validator.TryValidateObject(customer, context, results, true))
    {
        foreach (var error in results)
        {
            Console.WriteLine(error.ErrorMessage);
        }
    }
    else
        Console.WriteLine("Customer has been validated");
    Console.WriteLine();
}