using System.ComponentModel.DataAnnotations;

namespace MvcTheater.Models{
    public class Opinion{
        [Key]
        public int Id{get; set;}
        [Display(Name="Is positive?")]
        public bool IsPositive{get; set;}
        [Display(Name="Opinion text")]
        public string OpinionText{get; set;}
        public Show show{get; set;}

    }
}