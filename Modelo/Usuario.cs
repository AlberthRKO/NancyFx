using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalUsuario.Modelo
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Correo { get; set; }
        [StringLength(100)]
        public string Contra { get; set; }
        
    }
}