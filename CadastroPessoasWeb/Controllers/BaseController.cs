using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroPessoasWeb.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() {
        
        }

        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {

            // VERIFICAR LOGIN

            //#if DEBUG
            //    CadastroPessoasDAL.Contexto.CadastrosContext db = new CadastroPessoasDAL.Contexto.CadastrosContext();
            //    Session["UsuarioPainel"] = db.Usuarios.Where(x => x.Id == 1).FirstOrDefault();
            //#endif



            ViewBag.UsuarioAutenticado = false;

            if (Session["UsuarioPainel"] != null)
            {
                ViewBag.UsuarioAutenticado = true;
                ViewBag.Login = ((CadastroPessoasDAL.Models.Usuarios)Session["UsuarioPainel"]).Username;
            }
            else
            {
                if (filterContext.RouteData.Values["controller"].ToString() != "Login")
                {
                    filterContext.Result = RedirectToAction("Index", "Login");
                }
            }
            
            base.OnActionExecuting(filterContext);
        }


    }
}