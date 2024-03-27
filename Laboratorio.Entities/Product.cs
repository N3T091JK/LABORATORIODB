using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Product
    {
        [Key]
        public int ProductoId { get; set; }
        [MaxLength(50)]
        [Required]
        public string NomProducto { get; set; }
        //Foranea
        public int EstadoId { get; set; }
        public virtual State States { get; set; }
        //------------------------------------------
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
