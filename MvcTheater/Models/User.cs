using System.ComponentModel.DataAnnotations;

namespace MvcTheater.Models{
    public class User{
        [Key]
        public int Id{get; set;}

        public string? Login{get;set;}
        public string? Password{get;set;}
        
        public string? APIKey{get;set;}

    }
}