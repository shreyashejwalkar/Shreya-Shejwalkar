using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Assignments.Models.Assign2
{
    [Table("tblEmployee")]
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression("^([a-zA-Z '-]+)(?<!\\s)$", ErrorMessage = "Please enter valid Name (Alphabets only)")]
        public String Name { get; set; }

        [Required(ErrorMessage = " Please Select Gender")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "Please enter your City name")]
        [RegularExpression("^([a-zA-Z '-]+)(?<!\\s)$", ErrorMessage = "Please enter valid City Name (Alphabets only)")]
        public String City { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public String EmailId { get; set; }
    }
}