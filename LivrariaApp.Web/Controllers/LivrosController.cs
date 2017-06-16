using LivrariaApp.Domain;
using LivrariaApp.Web.Models;
using LivrariaApp.Web.Models.Clientes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LivrariaApp.Web.Controllers
{
    [Authorize]
    public class LivrosController : Controller
    {
        //private LivroCliente LC = new LivroCliente();
        //private AutorCliente AC = new AutorCliente();
        private DbContext db = new DbContext();

        public ActionResult Index()
        {
            ViewBag.listBooks = db.pegarTodosLivros();
            ViewBag.listAutores = db.pegarTodosAutores();
            return View();
        }
        [HttpGet]
        public ActionResult Criar()
        {

            ViewBag.listAutores = new SelectList(db.pegarTodosAutores(), "AutorId", "Nome");
            return View("Criar");
        }
        [HttpPost]
        public ActionResult Criar(LivroViewModel livro, List<int> Autores)
        {
            foreach (var item in Autores)
            {
                livro.Autores.Add(db.encontrarAutor(item));
            }

            db.CriarLivro(livro);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            db.DeleteLivro(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewBag.listAutores = new SelectList(db.pegarTodosAutores(), "AutorId", "Nome");

            LivroViewModel livro = new LivroViewModel();
            livro = db.encontrarLivro(id);
            return View("Editar", livro);
        }
        [HttpPost]
        public ActionResult Editar(Livro livro)
        {
            db.EditarLivro(livro);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            LivroViewModel livro = new LivroViewModel();
            livro = db.encontrarLivro(id);
            return View("Detalhes", livro);
        }
    }
}