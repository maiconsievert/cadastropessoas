using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroPessoasDAL;
using CadastroPessoasDAL.Contexto;
using CadastroPessoasDAL.Models;
using CadastroPessoasDAL.Helper;
using System.Data.Entity;

namespace CadastroPessoasWeb.Controllers
{
    public class LoginController : BaseController
    {
        private CadastrosContext db = new CadastrosContext();

        

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Sair()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Index(string login, string senha)
        {            
            try
            {
                if (login == String.Empty || senha == String.Empty)
                {
                    ViewBag.MsgErro = "Usuário ou Senha incorretos";
                }
                else
                {
                    var senhaHashed = MD5Helper.GetMd5HashData(senha);
                    Usuarios obj = db.Usuarios.Where(x => x.Username == login && x.Password == senhaHashed).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UsuarioPainel"] = obj;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.MsgErro = "Usuário ou Senha incorretos";
                    }
                }   
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, String.Format("Ocorreu um erro: {0}", ex.Message));
            }
            return View();
        }
        
       
    }
}
