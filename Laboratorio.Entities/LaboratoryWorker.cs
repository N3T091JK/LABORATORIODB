using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class LaboratoryWorker
    {
        [Key]
        public int LaboratoristaId { get; set; }
        [MaxLength(25)]
        [Required]
        public string PVPM { get; set; }
        //foranea
        [Required]
        public int EmpleadoId { get; set; }
        public virtual Employee Employees { get; set; }
    }
}
