using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoasDAL
{
    public class RelatorioWrapper
    {
        public IList<Models.Pessoas> Cadastros { get; set; }
        public string Filtro_Nome { get; set; }
        public DateTime? Filtro_DataNascimento { get; set; }
        public DateTime? Filtro_DataCadastro { get; set; }

        public RelatorioWrapper()
        {

        }
    }
}
