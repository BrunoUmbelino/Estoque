using MeuEstoque.Models.Classes;
using MeuEstoque.Models.Contexto;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MeuEstoque.Controllers
{
    public class UsuarioController : Controller
    {
        private MeuEstoqueContext db = new MeuEstoqueContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        { 
            var testeLogin = db.Usuarios.Where(m => m.Email == usuario.Email).FirstOrDefault();
            if (testeLogin != null && testeLogin.Senha == usuario.Senha)
            {
                FormsAuthentication.SetAuthCookie(testeLogin.Email, false);
                return RedirectToAction("Index", "Home");
            }
            else ModelState.AddModelError("", "Login ou senha inválidos");
            return View();
        }

        public ActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarUsuario([Bind(Include = "Id,NomeCompleto,Email,Senha,SenhaConfirmada")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}