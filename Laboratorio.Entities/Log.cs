using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [MaxLength(30)]
        [Required]
        public string Tabla { get; set; }
        [MaxLength(500)]
        [Required]
        public string Accion { get; set; }
        [MaxLength(500)]
        [Required]
        public string Descripcion { get; set; }
        //Foranea
        public int UsuarioId { get; set; }
        public virtual User Users { get; set; }
    }
}
