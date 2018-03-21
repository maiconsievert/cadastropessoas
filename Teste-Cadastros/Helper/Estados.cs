using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroPessoasDAL.Models;

namespace CadastroPessoas.Helper
{
    public class Estados
    {

        public static IEnumerable<SelectListItem> EstadosList(object selecionado)
        {
            var estados = new List<Estado>
            {
                new Estado { Uf = "AC" },
                new Estado { Uf = "AL" },
                new Estado { Uf = "AP" },
                new Estado { Uf = "AM" },
                new Estado { Uf = "BA" },
                new Estado { Uf = "CE" },
                new Estado { Uf = "DF" },
                new Estado { Uf = "ES" },
                new Estado { Uf = "GO" },
                new Estado { Uf = "MA" },
                new Estado { Uf = "MT" },
                new Estado { Uf = "MS" },
                new Estado { Uf = "MG" },
                new Estado { Uf = "PA" },
                new Estado { Uf = "PB" },
                new Estado { Uf = "PR" },
                new Estado { Uf = "PE" },
                new Estado { Uf = "PI" },
                new Estado { Uf = "RJ" },
                new Estado { Uf = "RN" },
                new Estado { Uf = "RS" },
                new Estado { Uf = "RO" },
                new Estado { Uf = "RR" },
                new Estado { Uf = "SC" },
                new Estado { Uf = "SP" },
                new Estado { Uf = "SE" },
                new Estado { Uf = "TO" }

            };

            var list = new List<SelectListItem>();

            foreach (Estado e in estados)
            {
                list.Add(new SelectListItem { Text = e.Uf, Value = e.Uf, Selected = (e.Uf == selecionado.ToString()) });
            }

            return list;

        }
    }

}