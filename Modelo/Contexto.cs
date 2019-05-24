using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalUsuario.Modelo
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name=Locadora")
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}