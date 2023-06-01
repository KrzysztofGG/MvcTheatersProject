using System.ComponentModel.DataAnnotations;

namespace MvcTheater.Models{
    public class Show{
        [Key]
        public int Id{get; set;}
        [Display(Name="Show Name")]
        public string ShowName{get; set;}
        [DataType(DataType.Date)]
        [Display(Name="Show Date")]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime ShowDate{get; set;}
        [Display(Name="Show Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString="{0:hh:mm tt}", ApplyFormatInEditMode=true)]
        public DateTime ShowTime{get; set;}
        [Display(Name="Show Price")]
        public decimal ShowPrice{get; set;}
        [Display(Name="Show type")]
        public string ShowType{get; set;}
        public Team Team{get; set;}
        ICollection<Opinion> Opinions{get; set;}

    }
}