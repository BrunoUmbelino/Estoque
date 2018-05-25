using MeuEstoque.Models.Classes;
using MeuEstoque.Models.Contexto;
using System.Linq;
using System.Net;
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
                Session["UsuarioLogado"] = testeLogin.NomeCompleto;
                return RedirectToAction("Index", "Home");
            }
            else ModelState.AddModelError("", "Login ou senha inválidos");
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
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

        public ActionResult MinhaConta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.FirstOrDefault();
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
    }
}