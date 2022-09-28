using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SelfValidation
{
    internal class Customer : IValidatableObject
    {
        public Customer(int customerId, string firstName, string lastName)
        {
            this.CustomerId = customerId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string EmailAddress { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(FirstName))
                errors.Add(new ValidationResult("First Name not provided"));

            if (FirstName.Length < 2 || FirstName.Length > 20)
                errors.Add(new ValidationResult("Invalid length of the first name"));

            if (CustomerId < 0 || CustomerId > 10000)
                errors.Add(new ValidationResult("Invalid customer ID"));

            return errors;
        }

        public int CustomerId { get; private set; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
