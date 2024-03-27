using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Exam
    {
        [Key]
        public int ExamenId { get; set; }
        [MaxLength(50)]
        [Required]
        public string NombreExamen { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int TipoDeExamenId { get; set; }
        public virtual TypeOfExam TypeOfExams { get; set; }
        [Required]
        public int EstadoId { get; set; }
        public virtual State States { get; set; }

        //**************************************************************************************
        //LLamado
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
