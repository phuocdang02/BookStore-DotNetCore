
using System.ComponentModel.DataAnnotations;


namespace ClassLibrary_RepositoryDLL.Models
{
    public class RegisterModel
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Username { get; set; }

        //PASSWORD
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your confirm password was not match")]
        public string ConfirmPassword { get; set; }
        //END PASSWORD

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
