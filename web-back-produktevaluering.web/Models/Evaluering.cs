using System.ComponentModel.DataAnnotations;

namespace web_back_produktevaluering.web.Models
{
    public class Evaluering
    {
        public int EvalueringId { get; set; }

        [Required]
        public string Navn { get; set; }

        [Required]
        public string Produkt { get; set; }

        [Required]
        [Range(1, 10)]
        public int Karakter { get; set; }
    }
}