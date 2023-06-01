using System.ComponentModel.DataAnnotations;

namespace MvcTheater.Models{
    public class Actor{
        [Key]
        public int Id{get; set;}
        [Display(Name="FirstName")]
        public string FirstName{get; set;}
        [Display(Name="LastName")]
        public string LastName{get; set;}
        [Display(Name="Age")]
        public int Age{get; set;}
        [Display(Name="Country")]
        public string Country{get; set;}
        [Display(Name="FavoriteMovie")]
        [DisplayFormat(NullDisplayText="No Favorite Movie")]
        public string? FavouriteMovie{get; set;}
        public Team Team{get; set;}

    }
}