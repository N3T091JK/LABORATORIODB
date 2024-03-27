using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class UserRole
    {
        [Key]
        public int RolUsuarioId { get; set; }
        [MaxLength(50)]
        [Required]
        public string NombreRol { get; set;}
        //Foranea
        [Required]
        public int TipoUsuarioId { get; set; }
        public virtual UserType UserTypes { get; set; }
        public int EstadoId { get; set; }
        public virtual State States { get; set; }

    }
}
