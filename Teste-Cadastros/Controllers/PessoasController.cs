using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroPessoasDAL;
using CadastroPessoasDAL.Contexto;
using CadastroPessoasDAL.Models;
using System.Data.Entity;

namespace CadastroPessoas.Controllers
{
    public class PessoasController : BaseController
    {
        private CadastrosContext db = new CadastrosContext();
        

        public ActionResult Index(string pesquisa)
        {

            var list = from c in db.Pessoas.ToList()
                       select c;

            if (pesquisa != null)
            {
                list = list.Where(
                    f => f.Nome.ToLower().Contains(pesquisa.ToLower())
                    || f.Email.ToLower().Contains(pesquisa.ToLower())
                    || f.Cpf.ToLower().Contains(pesquisa.ToLower())
                    || f.Cnpj.ToLower().Contains(pesquisa.ToLower())
                    || f.PessoasEndereco.Rua.ToLower().Contains(pesquisa.ToLower())
                    || f.PessoasEndereco.Bairro.ToLower().Contains(pesquisa.ToLower())
                    || f.PessoasEndereco.Cidade.ToLower().Contains(pesquisa.ToLower())
                    || f.PessoasEndereco.Estado.ToLower().Contains(pesquisa.ToLower())                    
                );
                ViewBag.pesquisa = pesquisa;
            }
            
            return View(list);
        }

        public ActionResult Sucesso()
        {
            return View();
        }

        public ActionResult Create()
        {

            ViewBag.EstadosList = Helper.Estados.EstadosList("");
            Pessoas obj = new Pessoas();
            obj.PessoasEndereco = new Pessoas_Enderecos();
            return View(obj);
            
        }

        [HttpPost]
        public ActionResult Create(Pessoas cadastro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Pessoas.Add(cadastro);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.EstadosList = Helper.Estados.EstadosList("");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, String.Format("Ocorreu um erro: {0}", ex.Message));
            }
            return View(cadastro);
        }

        public ActionResult Edit(int id)
        {                        
            try
            {
                Pessoas obj = db.Pessoas.Where(x => x.Id == id).FirstOrDefault();
                if (obj != null)
                {
                    ViewBag.EstadosList = Helper.Estados.EstadosList(obj.PessoasEndereco.Estado);
                    return View(obj);
                }
                ModelState.AddModelError(String.Empty, "Cadastro não encontrado.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, String.Format("Ocorreu um erro: {0}", ex.Message));
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, Pessoas cadastro)
        {
            ViewBag.EstadosList = Helper.Estados.EstadosList("");
            try
            {
                if (ModelState.IsValid)
                {
                    if (cadastro.Tipo == "fisica")
                        cadastro.Cnpj = "";
                    else
                        cadastro.Cpf = "";
                    db.Entry(cadastro).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(cadastro.PessoasEndereco).State = EntityState.Modified;
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, String.Format("Ocorreu um erro: {0}", ex.Message));
            }
            return View(cadastro);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Pessoas obj = db.Pessoas.Where(x => x.Id == id).FirstOrDefault();
                if (obj != null)
                {
                    return View(obj);
                }
                ModelState.AddModelError(String.Empty, "Cadastro não encontrado.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, String.Format("Ocorreu um erro: {0}", ex.Message));
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, Pessoas obj)
        {
            try
            {
                obj = db.Pessoas.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(obj.PessoasEndereco).State = EntityState.Deleted;
                db.Entry(obj).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, String.Format("Ocorreu um erro: {0}", ex.Message));
            }
            return View(obj);
        }

       
    }
}
