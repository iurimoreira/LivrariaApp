using System;
using System.Collections.Generic;

namespace LivrariaApp.Domain
{
    public class Autor
    {
        public Autor()
        {
            this.Livros = new HashSet<Livro>();
        }

        public int AutorId { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime AnoNascimento { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
