using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class InvoiceDetail
    {
        [Key]
        public int DetalleFacturaId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal Precio { get; set; }
        //foraneas
        [Required]
        public int PacienteId { get; set; }
        public virtual Patient Patients { get; set; }
        [Required]
        public int ExamenId { get; set; }
        public virtual Exam Exams { get; set; }

        [Required]
        public int PromocionId { get; set; }
        public virtual Promotion Promotions { get; set; }

        //*****************************************************
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
