using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class Patient
    {
        [Key]
        public int PacienteId { get; set; }
        [MaxLength(20)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(20)]
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public int Edad { get; set; }
        [MaxLength(10)]
        [Required]
        public string DUI { get; set; }
        [MaxLength(15)]
        [Required]
        public string NumCelular { get; set; }
        [MaxLength(100)]
        [Required]
        public string Direccion { get; set; }
        //Foranea
        [Required]
        public int EstadoId { get; set; }
        public virtual State States { get; set; }
        [Required]
        public int GeneroId { get; set; }
        public virtual Gender Genders { get; set; }
        //********************************************************************************************      
        public virtual ICollection<ExamRegistration> ExamRegistrations { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
