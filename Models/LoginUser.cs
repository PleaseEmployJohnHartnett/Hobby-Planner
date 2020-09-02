using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class LoginUser
    
    {   [EmailAddress]
        [Required(ErrorMessage="Email is required.")]
        [Display(Name="Email:")]
        public string LoginEmail {get;set;}


        [Display(Name="Password:")]
        [Required(ErrorMessage="Password is required.")]
        [DataType(DataType.Password)]
        public string LoginPassword {get;set;}
    }
}