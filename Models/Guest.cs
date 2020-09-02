namespace BeltExam.Models
{
    public class Guest
    {
        public int GuestId {get;set;}
        public int UserId {get;set;}
        public int HobbyId {get;set;}

        public User HobbyMember{get;set;}

        public Hobby Event{get;set;}
    }
}