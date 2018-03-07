using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteCadastrosDAL.Dados;
using TesteCadastrosDAL.Configuracoes;

namespace Teste_Cadastros.Helper
{
    public class ConfiguracoesHelper
    {
        
        public static IEnumerable<SelectListItem> EstadosList(object selecionado)
        {
            var list = new List<SelectListItem>();

            foreach (Estados e in Configuracoes.Estados())
            {
                list.Add(new SelectListItem { Text = e.Uf, Value = e.Uf, Selected = (e.Uf == selecionado.ToString()) });
            }

            return list;

        }


        public static Config ConfiguracoesObj()
        {
            CadastrosContext db = new CadastrosContext();
            Config obj = db.Config.FirstOrDefault();
            if (obj != null)
            {
                return obj;
            }
            return null;
        }

    }
}