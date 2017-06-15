using System.Collections.Generic;

namespace LivrariaApp.Domain
{
    public class Livro
    {
        public Livro()
        {
            this.Autores = new HashSet<Autor>();
        }

        public Livro(string isbn,string titulo, int ano)
        {
            this.Isbn = isbn;
            this.Titulo = titulo;
            this.Ano = ano;
            this.LivroId = 0;
        }

        public int LivroId { get; set; }

        public string Isbn { get; set; }

        public string Titulo { get; set; }

        public int Ano { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }
    }
}
