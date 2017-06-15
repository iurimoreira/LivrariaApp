using System.Web.Mvc;
using LivrariaApp.Web.Models;
using LivrariaApp.Web.Models.Clientes;

namespace LivrariaApp.Web.Controllers
{
    public class AutoresController : Controller
    {
        //private LivroCliente LC = new LivroCliente();
        //private AutorCliente AC = new AutorCliente();
        private DbContext db = new DbContext();

        public ActionResult Index()
        {
            ViewBag.listAutores = db.pegarTodosAutores();
            return View();
        }
        [HttpGet]
        public ActionResult Criar()
        {
            return View("Criar");
        }
        [HttpPost]
        public ActionResult Criar(AutorViewModel autor)
        {
            db.CriarAutor(autor);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            db.DeleteAutor(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            AutorViewModel autor = new AutorViewModel();
            autor = db.encontrarAutor(id);
            return View("Editar", autor);
        }
        [HttpPost]
        public ActionResult Editar(AutorViewModel autor)
        {
            db.EditarAutor(autor);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            AutorViewModel autor = new AutorViewModel();
            autor = db.encontrarAutor(id);
            return View("Detalhes", autor);
        }
    }
}
