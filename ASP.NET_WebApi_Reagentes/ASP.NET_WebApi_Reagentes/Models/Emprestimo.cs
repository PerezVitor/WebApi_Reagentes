using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_WebApi_Reagentes.Models
{
    [Table("Emprestimo")]
    public class Emprestimo
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Id_Reagente { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double QntPesoEmprestado { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataEmprestimo { get; set; }
    }
}