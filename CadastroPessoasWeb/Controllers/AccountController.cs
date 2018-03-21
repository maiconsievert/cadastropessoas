using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CadastroPessoasDAL.Repository;
using CadastroPessoasDAL.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using CadastroPessoasDAL.Contexto;

namespace CadastroPessoasWeb.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IUserRepository _repo = null;
        private CadastrosContext db = new CadastrosContext();

        public AccountController()
        {
            _repo = new UserRepository(db);
        }

        
    }
}
