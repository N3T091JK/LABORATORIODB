using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Entities.AppContext
{
    class JTDataContext : DbContext
    {
        public JTDataContext() : base("conn")
        {

        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Buy> Buys { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamRegistration> ExamRegistrations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Laboratory> laboratories { get; set; }
        public DbSet<LaboratoryWorker> LaboratoryWorkers { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseDetail> purchaseDetails { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TypeOfExam> typeOfExams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

    }
}
