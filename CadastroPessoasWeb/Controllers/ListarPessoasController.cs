using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CadastroPessoasDAL.Models;
using CadastroPessoasDAL.Contexto;
using System.Web.Http.Cors;

namespace CadastroPessoasWeb.Controllers
{
    public class ListarPessoasController : ApiController
    {

        private CadastrosContext db = new CadastrosContext();

        // GET: api/ListarPessoas
        [Authorize]
        public IHttpActionResult Get()
        {
            return Ok(db.Pessoas.ToList());
        }
        
    }
}
