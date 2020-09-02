using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BeltExam.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId {get;set;}

        [Required(ErrorMessage="A hobby is required")]
        [Display(Name="Hobby: ")]

        public string Activity {get;set;}

        [Required(ErrorMessage="A description is required")]
        [Display(Name="Description: ")]

        public string Description {get;set;}

        public DateTime CreatedAt {get;set;}

        public DateTime UpdatedAt {get;set;}

        public int UserId{get;set;}
 
        public User Planner {get;set;}

        public List<Guest> Attendees {get;set;}

        
    }
}