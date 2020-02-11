using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET_WebApi_Reagentes.Models
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext() : base("EstoqueDB")
        {                
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reagentes> Reagentes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}