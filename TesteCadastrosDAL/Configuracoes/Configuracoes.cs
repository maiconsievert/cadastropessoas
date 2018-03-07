using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TesteCadastrosDAL.Configuracoes
{
    public class Configuracoes
    {
        public static IEnumerable<Estados> Estados()
        {
            return new List<Estados>
            {
                new Estados { Uf = "PR" },
                new Estados { Uf = "SC" }
            };
        }
    }
}
