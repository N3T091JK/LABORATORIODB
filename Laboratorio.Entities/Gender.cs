using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Gender
    {

        [Key]
        public int GeneroId { get; set; }
        [MaxLength(50)]
        [Required]
        public string NomGenero { get; set; }
        //*********************************************************************************
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
