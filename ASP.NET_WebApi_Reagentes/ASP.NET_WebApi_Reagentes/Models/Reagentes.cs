using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_WebApi_Reagentes.Models
{
    [Table("Reagentes")]
    public class Reagentes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string CodigoInterno { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string NumeroCAS { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double QuantidadePeso { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public TipoUnidade UnidadeMedida { get; set; }
        public SiglaReagente Sigla { get; set; }
        public string Observacoes { get; set; }
    }

    public enum TipoUnidade
    {
        ml,
        g
    }

    public enum SiglaReagente
    { 
        G,
        A1,
        C1,
        C2,
        C
    }
}