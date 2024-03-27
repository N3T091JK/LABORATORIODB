using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Buy
    {
        [Key]
        public int CompraId { get; set; }
        [Required]
        //Foraneas
        public int CompraDetalleId { get; set; }
        public virtual PurchaseDetail PurchaseDetails { get; set; }

    }
}
