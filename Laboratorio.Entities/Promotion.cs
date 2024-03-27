using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Promotion
    {
        [Key]
        public int PromocionId { get; set; }
        [MaxLength(500)]
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Precio { get; set; }
        //Foranea
        [Required]
        public int TipoDeExamenId { get; set; }
        public virtual TypeOfExam TypeOfExams { get; set; }
        public int EstadoId { get; set; }
        public virtual State States { get; set; }
        //********************************************************************
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
