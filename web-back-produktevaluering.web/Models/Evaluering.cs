using System;
using System.ComponentModel.DataAnnotations;

namespace web_back_produktevaluering.web.Models
{
    public class Evaluering
    {
        public int EvalueringId { get; set; }

        [Required(ErrorMessage = "Navn skal være udfyldt!")]
        public string Navn { get; set; }

        [Required(ErrorMessage = "Produkt skal være udfyldt!")]
        public string Produkt { get; set; }

        [Required(ErrorMessage = "Karakter skal være udfyldt!")]
        [Range(1, 10, ErrorMessage = "Karakteren skal være mellem 1 og 10!")]
        public int? Karakter { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Oprettet { get; set; }
    }
}