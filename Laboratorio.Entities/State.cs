using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities
{
    public class State
    {
        [Key]
        public int EstadoId { get; set; }
        [MaxLength(30)]
        [Required]
        public string NomEstado { get; set; }
        //********************************************************************************************
        public virtual ICollection<ExamRegistration> ExamRegistrations { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<UserType> UserTypes { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<TypeOfExam> TypeOfExams { get; set; }
        public virtual ICollection<Category> Categorys { get; set; }
    }
}
