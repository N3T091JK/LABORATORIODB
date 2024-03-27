using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class User
    {
        [Key]
        public int UsuarioId { get; set; }
        [MaxLength(30)]
        [Required]
        public string NomUsuario { get; set; }
        [MaxLength(15)]
        [Required]
        public string Password { get; set; }
        //Foranea
        [Required]
        public int EmpleadoId { get; set; }
        public virtual Employee Employees { get; set; }
        [Required]
        public int EstadoId { get; set; }
        public virtual State States { get; set; }
        [Required]
        public int TipoUsuarioId { get; set; }
        public virtual UserType UserTypes { get; set; }
        //**********************************************************************************
        public virtual ICollection<Log> Logs { get; set; }
       
    }
}
