using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LivrariaApp.Web.Models
{
    public class LivroViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int LivroId { get; set; }

        [Required]
        [Display(Name = "Isbn")]
        public string Isbn { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Ano")]
        public int Ano { get; set; }

        public virtual List<AutorViewModel> Autores { get; set; }
    }
}