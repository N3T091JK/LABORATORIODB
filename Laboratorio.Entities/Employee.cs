using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Employee
    {
        [Key]
        public int EmpleadoId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(50)]
        [Required]
        public string Apellidos { get; set; }
        [MaxLength(10)]
        [Required]
        public string DUI { get; set; }
        [MaxLength(100)]
        [Required]
        public string Correo { get; set; }
        [Required]
        public int Edad { get; set; }
        [MaxLength(15)]
        [Required]
        public string NumCelular { get; set; }
        [MaxLength(100)]
        [Required]
        public string Direccion { get; set; }
        [Required]
        public int EstadoId { get; set; }
        public virtual State States { get; set; }
        [Required]
        public int GeneroId { get; set; }
        public virtual Gender Genders { get; set; }
        //****************************************************************************
        //Llamados           
        public virtual ICollection<User> Users { get; set; }       
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<LaboratoryWorker> LaboratoryWorkers { get; set; }
    }
}
