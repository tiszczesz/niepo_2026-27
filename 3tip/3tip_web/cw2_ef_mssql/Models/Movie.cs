using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cw2_ef_mssql.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [DisplayName("Tytuł")]
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        public string Title { get; set; }
        
        [DisplayName("Reżyser")]
        [Required(ErrorMessage = "Pole reżyser jest wymagane")]
        public string Director { get; set; }
       
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        [DisplayName("Rok")]
        public int Year { get; set; }
        
        [DisplayName("Cena")]
        [Range(0, 100, ErrorMessage = "Cena musi być w przedziale od 0 do 100")]
        public decimal? Price { get; set; }
    }
}
