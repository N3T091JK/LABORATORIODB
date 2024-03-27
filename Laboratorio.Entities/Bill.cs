using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Bill
    {
        [Key]
        public int FacturaId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal Total { get; set; }
        public int Cantidad { get; set;}
        //Foraneas
        [Required]
        public int EmpleadoId { get; set; }
        public virtual Employee Employees { get; set; }
        [Required]
        public int DetalleFacturaId { get; set; }
        public virtual InvoiceDetail InvoiceDetails { get; set; }
    }


}
