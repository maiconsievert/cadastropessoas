using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teste_Cadastros.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() {
        
        }

        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {

            var Configuracao = Teste_Cadastros.Helper.ConfiguracoesHelper.ConfiguracoesObj();

            if (Configuracao == null && filterContext.RouteData.Values["controller"].ToString() != "Configuracoes")
            {
                filterContext.Result = RedirectToAction("Index", "Configuracoes");
            }
            
            base.OnActionExecuting(filterContext);
        }


    }
}