using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class MigrationHistory
    {
        [Key]
        public int HistorialMigracionId { get; set; }
        [MaxLength(500)]
        [Required]
        public string ConTextKey { get; set; }
        [MaxLength(50)]
        [Required]
        public string ProductoVersion { get; set; }
        [MaxLength(500)]
        [Required]
        public string Modelo { get; set; }
    }
}
