using System.ComponentModel.DataAnnotations;

namespace Assignments.Models.Assign3
{
    public class EmployeeDetails
    {
        [Display(Name = "Id")]
        public int Empid { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression("^([a-zA-Z '-]+)(?<!\\s)$", ErrorMessage = "Please enter valid Name (Alphabets only)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your City name")]
        [RegularExpression("^([a-zA-Z '-]+)(?<!\\s)$", ErrorMessage = "Please enter valid City Name (Alphabets only)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your Job name")]
        [RegularExpression("^([a-zA-Z '-]+)(?<!\\s)$", ErrorMessage = "Please enter valid Job Name (Alphabets only)")]
        public string JobName { get; set; }
    }
}