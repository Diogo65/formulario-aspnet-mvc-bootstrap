using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormularioAspNetMvc.Models
{
    public class CadastroContext : DbContext
    {
        public CadastroContext() : base("DbCadastroPessoas")
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}