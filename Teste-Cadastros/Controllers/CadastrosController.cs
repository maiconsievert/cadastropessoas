using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteCadastrosDAL;
using TesteCadastrosDAL.Dados;
using TesteCadastrosDAL.Validacoes;
using System.Data.Entity;

namespace Teste_Cadastros.Controllers
{
    public class CadastrosController : BaseController
    {
        private CadastrosContext db = new CadastrosContext();

        public ActionResult Relatorio(string filtro_nome, DateTime? filtro_datanascimento, DateTime? filtro_datacadastro)
        {
            var list = from c in db.Cadastros.ToList<Cadastros>()
                       select c;

            if (filtro_nome != null)
            {
                list = list.Where(f => f.Nome.ToLower().Contains(filtro_nome.ToLower()));
            }

            if (filtro_datanascimento != null)
            {
                DateTime dt = (DateTime)filtro_datanascimento;
                list = list.Where(
                    f => ((DateTime)f.DataNascimento).Day == dt.Day && ((DateTime)f.DataNascimento).Month == dt.Month && ((DateTime)f.DataNascimento).Year == dt.Year
                );
            }

            if (filtro_datacadastro != null)
            {
                DateTime dt = (DateTime)filtro_datacadastro;
                list = list.Where(
                    f => ((DateTime)f.DataCadastro).Day == dt.Day && ((DateTime)f.DataCadastro).Month == dt.Month && ((DateTime)f.DataCadastro).Year == dt.Year
                );
                ViewBag.FiltroDataCadastroAtual = filtro_datacadastro.ToString();
            }

            ViewBag.FiltroNomeAtual = filtro_nome;
            ViewBag.FiltroDataNascimentoAtual = filtro_datanascimento.ToString();
            

            return View(list);
        }


        // GET: Cadastros
        public ActionResult Index()
        {
            IList<Cadastros> itens = db.Cadastros.ToList<Cadastros>();

            return View(itens);
        }

        public ActionResult Sucesso()
        {
            return View();
        }

        // GET: Cadastros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cadastros/Create
        public ActionResult Create()
        {

            Cadastros obj = new Cadastros();
            obj.Telefones = new List<CadastrosTelefones>
            {
                new CadastrosTelefones()
            };
            
            return View(obj);
        }

        // POST: Cadastros/Create
        [HttpPost]
        public ActionResult Create(Cadastros cadastro)
        {
            try
            {

                var config = Helper.ConfiguracoesHelper.ConfiguracoesObj();

                if (config.Uf == "PR" && !Validacoes.IdadeMinima((DateTime)cadastro.DataNascimento))
                {
                    ModelState.AddModelError(String.Empty, "A pessoa precisa ser maior de 18 anos.");
                }

                if (ModelState.IsValid)
                {

                    cadastro.DataCadastro = DateTime.Now;
                    cadastro.Uf = config.Uf;

                    db.Cadastros.Add(cadastro);

                    if (cadastro.Telefones != null)
                    {
                        foreach (CadastrosTelefones t in cadastro.Telefones)
                        {
                            db.CadastrosTelefones.Add(t);
                        }
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                

            }
            catch
            {

            }

            return View(cadastro);

        }

        // GET: Cadastros/Edit/5
        public ActionResult Edit(int id)
        {

            Cadastros obj = db.Cadastros.Include(a => a.Telefones).Where(x => x.Id == id).FirstOrDefault<Cadastros>();

            if (obj != null)
            {
                //obj.Telefones = db.CadastrosTelefones.Where(x => x.Cadastro.Id == id).ToList<CadastrosTelefones>();
                
                return View(obj);
            }

            ModelState.AddModelError(String.Empty, "Cadastro não encontrado.");

            return View();
        }

        // POST: Cadastros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cadastros cadastro)
        {
            try
            {


                if (ModelState.IsValid)
                {

                    db.Cadastros.Attach(cadastro);
                    db.Entry(cadastro).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    var telefonesBd = db.CadastrosTelefones.AsNoTracking().Where(x => x.Cadastro.Id == id).ToList<CadastrosTelefones>();

                    foreach (var telefone in telefonesBd)
                    {
                        if (!cadastro.Telefones.Where(t => t.Id == telefone.Id).Any())
                        {
                            db.Entry(telefone).State = EntityState.Deleted;
                        }
                    }

                    if (cadastro.Telefones != null)
                    {
                        foreach (CadastrosTelefones t in cadastro.Telefones)
                        {
                            if (t.Id == 0)
                            {
                                t.Cadastro = cadastro;
                                db.CadastrosTelefones.Add(t);
                            }
                            else
                            {
                                db.Entry(t).State = EntityState.Modified;
                            }
                        }
                    }
                    
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }

            }
            catch
            {
                return View(cadastro);
            }

            return View(cadastro);

        }

        // GET: Cadastros/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Cadastros.FirstOrDefault());
        }

        // POST: Cadastros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cadastros obj)
        {
            try
            {
                var telefonesBd = db.CadastrosTelefones.AsNoTracking().Where(x => x.Cadastro.Id == id).ToList<CadastrosTelefones>();

                foreach (var telefone in telefonesBd)
                {
                    db.Entry(telefone).State = EntityState.Deleted;
                }
                db.SaveChanges();

                db.Entry(obj).State = EntityState.Deleted;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(obj);
            }

            return View(obj);

        }

        public ActionResult Telefone()
        {
            var telefone = new CadastrosTelefones();
            return PartialView("_Telefone", telefone);
        }
    }
}
