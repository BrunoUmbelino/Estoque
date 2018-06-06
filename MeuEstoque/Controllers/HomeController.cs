using MeuEstoque.Models.Classes;
using System.Web.Mvc;

namespace MeuEstoque.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Usuario Usuario)
        {
            Usuario usuarioLogado = Usuario; 
            return View(Usuario);
        }
    }
}