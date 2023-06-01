using System.ComponentModel.DataAnnotations;

namespace MvcTheater.Models{
    public class Team{
        [Key]
        public int Id{get; set;}
        [Display(Name="Team name")]
        public string TeamName{get; set;}
        [Display(Name="Team size")]
        public int TeamSize{get; set;}
        ICollection<Actor> Actors{get; set;}
        ICollection<Show> Shows{get; set;}
        

    }
}