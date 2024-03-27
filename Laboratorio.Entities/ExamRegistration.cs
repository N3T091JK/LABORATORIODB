using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class ExamRegistration
    {
        [Key]
        public int RegistroExamenId { get; set; }
        [Required]
        public DateTime FechaRealizado { get; set; }
        [Required]
        public DateTime FechaEntrega { get; set; }
        [Required]
        //Foraneas
        public int PacienteId { get; set; }
        public virtual Patient Patients { get; set; }
        [Required]
        public int TipoDeExamenId { get; set; }
        public virtual TypeOfExam TypeOfExams { get; set; }
        [Required]
        public int EstadoId { get; set; }
        public virtual State States { get; set; }
    }
}
