using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation
{
    internal class Customer 
    {
            public Customer(int customerId, string firstName, string lastName)
            {
                this.CustomerId = customerId;
                this.FirstName = firstName;
                this.LastName = lastName;
            }

            [Required(ErrorMessage = "Customer last name not provided")]
            [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Invalid length of the last name")]    
            public string LastName { get; set; }

            [Required(ErrorMessage = "Customer first not provided")]
            [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Invalid length of the first name")]
            public string FirstName { get; set; }

            public string EmailAddress { get; set; }

            [Range(1, 10000)]
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

            public bool Validate()
            {
                var isValid = true;

                if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
                if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

                return isValid;
            }

            public override string ToString()
            {
                return FullName;
            }

        }
}
