using LivrariaApp.Domain;
using LivrariaApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LivrariaApp.Web
{
    public class DbContext
    {
       
        private static HttpClient clientConfiguration()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64317/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public IEnumerable<AutorViewModel> pegarTodosAutores()
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.GetAsync("api/Autores").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<AutorViewModel>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public AutorViewModel encontrarAutor(int id)
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.GetAsync("api/Autores/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<AutorViewModel>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool CriarAutor(AutorViewModel autor)
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.PostAsJsonAsync("api/Autores", autor).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool EditarAutor(AutorViewModel autor)
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.PutAsJsonAsync("api/Autores/" + autor.AutorId, autor).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteAutor(int id)
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.DeleteAsync("api/Autores/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Livro> pegarTodosLivros()
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.GetAsync("api/Livros").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Livro>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public LivroViewModel encontrarLivro(int id)
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.GetAsync("api/livros/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<LivroViewModel>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool CriarLivro(LivroViewModel livro)
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.PostAsJsonAsync("api/Livros", livro).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool EditarLivro(Livro livro)
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.PutAsJsonAsync("api/livros/" + livro.LivroId, livro).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteLivro(int id)
        {
            try
            {
                var client = clientConfiguration();
                HttpResponseMessage response = client.DeleteAsync("api/livros/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}