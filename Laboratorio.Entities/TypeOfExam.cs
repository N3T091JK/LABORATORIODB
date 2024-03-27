using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class TypeOfExam
    {
        [Key]
        public int TipoDeExamenId { get; set; }
        [MaxLength(20)]
        [Required]
        public string NombreExamen { get; set; }
        //foranea
        public int EstadoId { get; set; }
        public virtual State States { get; set; }
        //*******************************************************************************************
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<ExamRegistration> ExamRegistrations { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
