using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LivrariaApp.Web.Models.Clientes
{
    public class AutorCliente
    {
        private string Base_URL = "http://localhost:64317/api";

        private static HttpClient clientConfiguration()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64317/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public IEnumerable<AutorViewModel> pegarTodos()
        {
            try
            {
                //HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri(Base_URL);
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
        public AutorViewModel encontrar(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
        public bool Criar(AutorViewModel autor)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/Autores", autor).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Editar(AutorViewModel autor)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("api/Autores/" + autor.AutorId, autor).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("api/Autores/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}