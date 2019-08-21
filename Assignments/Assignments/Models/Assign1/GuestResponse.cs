using System.ComponentModel.DataAnnotations;
namespace Assignments.Models.Assign1
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression("^([a-zA-Z '-]+)(?<!\\s)$", ErrorMessage ="Please enter valid Name (Alphabets only)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression("\\+?\\d[\\d -]{8,12}\\d", ErrorMessage="Please enter valid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }
    }
}