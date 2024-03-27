using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Laboratory
    {
        [Key]
        public int NumRegistro { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(70)]
        [Required]
        public string Direccion { get; set; }
        [Required]
        public String Telefono { get; set; }
        [MaxLength(50)]
        [Required]
        public string correo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Administrador { get; set; }
    }
}
