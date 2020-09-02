using Microsoft.EntityFrameworkCore;
using BeltExam.Models;

namespace BeltExam.Contexts
{
    public class MyContext : DbContext{
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users{get;set;}

        public DbSet<Hobby> Hobbies{get;set;}

        public DbSet<Guest> Guests{get;set;}
    }
}