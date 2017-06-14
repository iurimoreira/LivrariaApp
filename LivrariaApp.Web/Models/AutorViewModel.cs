using System;
using System.ComponentModel.DataAnnotations;

namespace LivrariaApp.Web.Models
{
    public class AutorViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int AutorId { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime AnoNascimento { get; set; }
    }
}