using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Category
    {
        [Key]
        public int CategoriaId { get; set; }
        [MaxLength(25)]
        [Required]
        public string NombreCategoria { get; set; }
        //Foraneas
        [Required]
        public int EstadoId { get; set; }
        public virtual State States { get; set; }
        //*******************************************************************
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }

    }
}
