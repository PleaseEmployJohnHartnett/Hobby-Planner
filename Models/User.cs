using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace BeltExam.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name="First Name:")]
        [MinLength(3, ErrorMessage="First Name is too short.")]
        public string FirstName {get;set;}

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name="Last Name:")]
        [MinLength(3, ErrorMessage="Last Name is too short.")]
        public string LastName {get;set;}

        [Required(ErrorMessage = "Email is required")]
        [Display(Name="Email:")]
        [EmailAddress]
        public string Email {get;set;}

        [Required(ErrorMessage = "Password is required")]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage="Password must be at least 8 characters.")]
        public string Password {get;set;}

        [Required(ErrorMessage = "Confirm password is required")]
        [Display(Name="Confirm Password:")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string Confirm {get;set;}

        public DateTime CreateAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        //navigational prop one to many, a user can plan many weddings
        public List<Hobby> MyHobby {get;set;}

        //nav prop many to many a user can go to many weddings

        public List<Guest> GoingTo{get;set;}

        





    }
}