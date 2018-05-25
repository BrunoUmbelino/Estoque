﻿using MeuEstoque.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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