using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TesteCadastrosDAL.Validacoes;

namespace TesteCadastrosTests
{
    [TestFixture]
    public class CadastroTests
    {

        [Test]
        public void Idade_Maior_Dezoito()
        {

            DateTime entrada = new DateTime(2000, 3, 1);

            bool retorno = Validacoes.IdadeMinima(entrada);

            Assert.AreEqual(true, retorno);

        }

    }
}
