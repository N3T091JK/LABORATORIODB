using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class PurchaseDetail
    {

        [Key]
        public int CompraDetalleId { get; set; }
        [Required]
        public DateTime FechaCompra { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public string CodProducto { get; set; }
        //Foranea
        [Required]
        public int CategoriaId { get; set; }
        public virtual Category Categories { get; set; }
        [Required]
        public int ProductoId { get; set; }
        public virtual Product Products { get; set; }
        [Required]
        
        //*************************************************************
        public virtual ICollection<Buy> Buys { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }

    }
}
