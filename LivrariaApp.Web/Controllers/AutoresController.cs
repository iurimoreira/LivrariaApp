using System.Web.Mvc;
using LivrariaApp.Web.Models;
using LivrariaApp.Web.Models.Clientes;

namespace LivrariaApp.Web.Controllers
{
    public class AutoresController : Controller
    {
        private AutorCliente AC = new AutorCliente();

        public ActionResult Index()
        {
            ViewBag.listAutores = AC.pegarTodos();
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
            AC.Criar(autor);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            AC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            AutorViewModel autor = new AutorViewModel();
            autor = AC.encontrar(id);
            return View("Editar", autor);
        }
        [HttpPost]
        public ActionResult Editar(AutorViewModel autor)
        {
            AC.Editar(autor);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            AutorViewModel autor = new AutorViewModel();
            autor = AC.encontrar(id);
            return View("Detalhes", autor);
        }
    }
}
