using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataModel
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Name must be alphanumeric.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Range(18, 98, ErrorMessage = "Age must be between 18 and 98.")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^(IT|HR|Finance|QA)$", ErrorMessage = "Department must be IT, HR, Finance, or QA.")]
        public string Department { get; set; }
    }
}
