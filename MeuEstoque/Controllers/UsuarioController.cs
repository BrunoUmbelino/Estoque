using MeuEstoque.Models.Classes;
using MeuEstoque.Models.Contexto;
using System;
using System.Data.Entity;
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
            Usuario testeLogin = db.Usuarios.Where(m => m.Email == usuario.Email).FirstOrDefault();
            if (testeLogin != null && testeLogin.Senha == usuario.Senha)
            {
                FormsAuthentication.SetAuthCookie(testeLogin.Email, false);
                Session["UsuarioLogado"] = testeLogin.NomeCompleto;
                Session["UsuarioId"] = testeLogin.Id;
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
        [ValidateAntiForgeryToken]
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

        [Authorize]
        public ActionResult MinhaConta()
        {
            int id = Convert.ToInt32(Session["UsuarioId"]);
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [Authorize]
        public ActionResult Editar()
        {
            int id = Convert.ToInt32(Session["UsuarioId"]);
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Editar([Bind(Include ="Id, NomeCompleto, Email, Senha, SenhaConfirmada")]Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MinhaConta");
            }
            return View(usuario);
        }
    }
}