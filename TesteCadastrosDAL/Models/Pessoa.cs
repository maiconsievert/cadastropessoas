using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoasDAL.Models
{

    public partial class Pessoas
    {
        public int Id { get; set; }

        public string Tipo { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        public string Cpf { get; set; }
        public string Cnpj { get; set; }

        [Required]
        public virtual Pessoas_Enderecos PessoasEndereco { get; set; }
    }
    
    public partial class Pessoas_Enderecos
    {
        public int Id { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        public virtual Pessoas Pessoa { get; set; }
    }

}
