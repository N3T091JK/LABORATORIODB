using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class UserType
    {
        [Key]
        public int TipoUsuarioId { get; set; }
        [MaxLength(50)]
        [Required]
        public string NomTipoUsuario { get; set; }
        //Foranea
        [Required]
        public int EstadoId { get; set; }
        public virtual State States { get; set; }
        //***************************************************************
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
