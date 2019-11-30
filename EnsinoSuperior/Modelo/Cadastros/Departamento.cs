using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
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
