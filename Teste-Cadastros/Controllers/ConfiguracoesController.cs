using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteCadastrosDAL.Dados;
using TesteCadastrosDAL.Configuracoes;

namespace Teste_Cadastros.Controllers
{
    public class ConfiguracoesController : Controller
    {

        private CadastrosContext db = new CadastrosContext();

        // GET: Configuracoes
        public ActionResult Index()
        {

            Config obj = db.Config.FirstOrDefault();

            if (obj != null)
            {
                ViewBag.EstadosList = Helper.ConfiguracoesHelper.EstadosList(obj.Uf);

                return View(obj);
            }

            ViewBag.EstadosList = Helper.ConfiguracoesHelper.EstadosList("");
                                 

            return View();
        }
        

        // POST: Configuracoes/Edit/5
        [HttpPost]
        public ActionResult Index(Config obj)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                // Cria nova configuração

                if (obj.Id == 0)
                {
                    db.Config.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                // Atualiza configuração
                else
                {
                    db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }

            try
            { }
            catch
            {
                
            }

            ViewBag.EstadosList = Helper.ConfiguracoesHelper.EstadosList("");

            return View(obj);
        }
        
    }
}
