using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnsinoSuperior.Models
{
    public class Departamento
    {
        public long? DepartamentoID { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Instituição")]
        public long? InstituicaoID { get; set; }        
        public Instituicao Instituicao { get; set; }
    }
}
