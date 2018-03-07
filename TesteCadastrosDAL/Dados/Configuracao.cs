using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCadastrosDAL.Dados
{
    public class Config
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Uf { get; set; }

    }
    
}
