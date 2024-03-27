using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Inventory
    {

        [Key]
        public int InventoryId { get; set; }
        [ForeignKey("Products")]
        public int ProductoId { get; set; }
        public virtual Product Products { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int CompraDetalleId { get; set; }
        public virtual PurchaseDetail PurchaseDetails { get; set; }
    }
}
