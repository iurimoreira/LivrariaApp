using LivrariaApp.Domain;
using LivrariaApp.Web.Models;
using LivrariaApp.Web.Models.Clientes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LivrariaApp.Web.Controllers
{
    public class LivrosController : Controller
    {
        private LivroCliente LC = new LivroCliente();
        private AutorCliente AC = new AutorCliente();

        public ActionResult Index()
        {
            ViewBag.listBooks = LC.pegarTodos();

            return View();
        }
        [HttpGet]
        public ActionResult Criar()
        {

            ViewBag.listAutores = new SelectList(AC.pegarTodos(), "AutorId", "Nome");
            return View("Criar");
        }
        [HttpPost]
        public ActionResult Criar(LivroViewModel livro, List<int> Autores)
        {
            foreach (var item in Autores)
            {
                livro.Autores.Add(AC.encontrar(item));
            }

            LC.Criar(livro);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            LC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewBag.listAutores = new SelectList(AC.pegarTodos(), "AutorId", "Nome");

            LivroViewModel livro = new LivroViewModel();
            livro = LC.encontrar(id);
            return View("Editar", livro);
        }
        [HttpPost]
        public ActionResult Editar(Livro livro)
        {
            LC.Editar(livro);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            LivroViewModel livro = new LivroViewModel();
            livro = LC.encontrar(id);
            return View("Detalhes", livro);
        }
    }
}