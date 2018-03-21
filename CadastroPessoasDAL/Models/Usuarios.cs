using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoasDAL.Models
{

    public partial class Usuarios
    {
        
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public Usuarios(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        protected Usuarios() { }

    }
    

}
