using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCadastrosDAL.Validacoes
{
    public class Validacoes
    {

        public static bool IdadeMinima(DateTime datanascimento)
        {

            int idade = DateTime.Now.Year - datanascimento.Year;
            if (DateTime.Now < datanascimento.AddYears(idade)) idade--;

            if (idade < 18)
                return false;
            else
                return true;

        }

    }
}
