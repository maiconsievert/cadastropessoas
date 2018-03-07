using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCadastrosDAL
{
    public class RelatorioWrapper
    {
        public IList<Dados.Cadastros> Cadastros { get; set; }
        public string Filtro_Nome { get; set; }
        public DateTime? Filtro_DataNascimento { get; set; }
        public DateTime? Filtro_DataCadastro { get; set; }

        public RelatorioWrapper()
        {

        }
    }
}
