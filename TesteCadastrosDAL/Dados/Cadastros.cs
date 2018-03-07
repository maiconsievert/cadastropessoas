using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCadastrosDAL.Dados
{
    public class Cadastros
    {
        public int Id { get; set; }

        [DisplayName("Data de cadastro")]
        public DateTime? DataCadastro { get; set; }

        [DisplayName("Data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataNascimento { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        public string Uf { get; set; }
        public string Rg { get; set; }

        public virtual ICollection<CadastrosTelefones> Telefones { get; set; }

    }

    public class CadastrosTelefones
    {
        public int Id { get; set; }

        [Required]
        public string Telefone { get; set; }

        public virtual Cadastros Cadastro { get; set; }
    }
}
