using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace CadastroPessoasWeb.Controllers
{
    public class IntegracoesController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticacao()
        {
            return View();
        }

        public ActionResult ListarPessoas()
        {
            return View();
        }
    }
}
