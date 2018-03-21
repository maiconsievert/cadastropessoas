using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CadastroPessoasDAL.Models;
using CadastroPessoasDAL.Contexto;

namespace CadastroPessoas.Controllers
{
    public class ListarPessoasController : ApiController
    {

        private CadastrosContext db = new CadastrosContext();

        // GET: api/ListarPessoas
        public IEnumerable<Pessoas> Get()
        {
            return db.Pessoas.ToList();
        }
        
    }
}
