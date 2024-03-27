namespace Laboratorio.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBLaboratorio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        FacturaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PacienteId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        DetalleFacturaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacturaId)
                .ForeignKey("dbo.Employees", t => t.EmpleadoId)
                .ForeignKey("dbo.Patients", t => t.PacienteId)
                .ForeignKey("dbo.InvoiceDetails", t => t.DetalleFacturaId)
                .Index(t => t.PacienteId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.DetalleFacturaId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        DUI = c.Int(nullable: false),
                        Correo = c.String(nullable: false, maxLength: 100),
                        Edad = c.Int(nullable: false),
                        NumCelular = c.Int(nullable: false),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        EstadoId = c.Int(nullable: false),
                        GeneroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Genders", t => t.GeneroId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .Index(t => t.EstadoId)
                .Index(t => t.GeneroId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GeneroId = c.Int(nullable: false, identity: true),
                        NomGenero = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GeneroId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PacienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Apellidos = c.String(nullable: false, maxLength: 20),
                        Edad = c.Int(nullable: false),
                        DUI = c.String(nullable: false),
                        NumCelular = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        GeneroId = c.Int(nullable: false),
                        TypeOfExam_TipoDeExamenId = c.Int(),
                    })
                .PrimaryKey(t => t.PacienteId)
                .ForeignKey("dbo.TypeOfExams", t => t.TypeOfExam_TipoDeExamenId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .ForeignKey("dbo.Genders", t => t.GeneroId)
                .Index(t => t.EstadoId)
                .Index(t => t.GeneroId)
                .Index(t => t.TypeOfExam_TipoDeExamenId);
            
            CreateTable(
                "dbo.ExamRegistrations",
                c => new
                    {
                        RegistroExamenId = c.Int(nullable: false, identity: true),
                        FechaRealizado = c.DateTime(nullable: false),
                        FechaEntrega = c.DateTime(nullable: false),
                        PacienteId = c.Int(nullable: false),
                        TipoDeExamenId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistroExamenId)
                .ForeignKey("dbo.Patients", t => t.PacienteId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .ForeignKey("dbo.TypeOfExams", t => t.TipoDeExamenId)
                .Index(t => t.PacienteId)
                .Index(t => t.TipoDeExamenId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        NomEsado = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NombreCategoria = c.String(nullable: false, maxLength: 25),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        CompraDetalleId = c.Int(nullable: false, identity: true),
                        FechaCompra = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CodProducto = c.String(),
                        CategoriaId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompraDetalleId)
                .ForeignKey("dbo.Categories", t => t.CategoriaId)
                .ForeignKey("dbo.Products", t => t.ProductoId)
                .Index(t => t.CategoriaId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Buys",
                c => new
                    {
                        CompraId = c.Int(nullable: false, identity: true),
                        CompraDetalleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompraId)
                .ForeignKey("dbo.PurchaseDetails", t => t.CompraDetalleId)
                .Index(t => t.CompraDetalleId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        CompraDetalleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Products", t => t.ProductoId)
                .ForeignKey("dbo.PurchaseDetails", t => t.CompraDetalleId)
                .Index(t => t.ProductoId)
                .Index(t => t.CompraDetalleId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        NomProducto = c.String(nullable: false),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamenId = c.Int(nullable: false, identity: true),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoDeExamenId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamenId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .ForeignKey("dbo.TypeOfExams", t => t.TipoDeExamenId)
                .Index(t => t.TipoDeExamenId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        DetalleFacturaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PacienteId = c.Int(nullable: false),
                        ExamenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleFacturaId)
                .ForeignKey("dbo.Exams", t => t.ExamenId)
                .ForeignKey("dbo.Patients", t => t.PacienteId)
                .Index(t => t.PacienteId)
                .Index(t => t.ExamenId);
            
            CreateTable(
                "dbo.TypeOfExams",
                c => new
                    {
                        TipoDeExamenId = c.Int(nullable: false, identity: true),
                        NombreExamen = c.String(nullable: false, maxLength: 20),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoDeExamenId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromocionId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 500),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoDeExamenId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PromocionId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .ForeignKey("dbo.TypeOfExams", t => t.TipoDeExamenId)
                .Index(t => t.TipoDeExamenId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RolUsuarioId = c.Int(nullable: false, identity: true),
                        TipoUsuarioId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RolUsuarioId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .ForeignKey("dbo.UserTypes", t => t.TipoUsuarioId)
                .Index(t => t.TipoUsuarioId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        TipoUsuarioId = c.Int(nullable: false, identity: true),
                        NomTipoUsuario = c.String(nullable: false, maxLength: 50),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoUsuarioId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NomUsuario = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 15),
                        EmpleadoId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        TipoUsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Employees", t => t.EmpleadoId)
                .ForeignKey("dbo.States", t => t.EstadoId)
                .ForeignKey("dbo.UserTypes", t => t.TipoUsuarioId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.EstadoId)
                .Index(t => t.TipoUsuarioId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Tabla = c.String(nullable: false, maxLength: 30),
                        Accion = c.String(nullable: false, maxLength: 500),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("dbo.Users", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.LaboratoryWorkers",
                c => new
                    {
                        LaboratoristaId = c.Int(nullable: false, identity: true),
                        PVPM = c.String(nullable: false, maxLength: 25),
                        EmpleadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LaboratoristaId)
                .ForeignKey("dbo.Employees", t => t.EmpleadoId)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Laboratories",
                c => new
                    {
                        NumRegistro = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 70),
                        Telefono = c.String(nullable: false),
                        correo = c.String(nullable: false, maxLength: 50),
                        Administrador = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.NumRegistro);
            
            CreateTable(
                "dbo.MigrationHistories",
                c => new
                    {
                        HistorialMigracionId = c.Int(nullable: false, identity: true),
                        ConTextKey = c.String(nullable: false, maxLength: 500),
                        ProductoVersion = c.String(nullable: false, maxLength: 50),
                        Modelo = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.HistorialMigracionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LaboratoryWorkers", "EmpleadoId", "dbo.Employees");
            DropForeignKey("dbo.Patients", "GeneroId", "dbo.Genders");
            DropForeignKey("dbo.Users", "TipoUsuarioId", "dbo.UserTypes");
            DropForeignKey("dbo.Users", "EstadoId", "dbo.States");
            DropForeignKey("dbo.Logs", "UsuarioId", "dbo.Users");
            DropForeignKey("dbo.Users", "EmpleadoId", "dbo.Employees");
            DropForeignKey("dbo.UserRoles", "TipoUsuarioId", "dbo.UserTypes");
            DropForeignKey("dbo.UserTypes", "EstadoId", "dbo.States");
            DropForeignKey("dbo.UserRoles", "EstadoId", "dbo.States");
            DropForeignKey("dbo.Patients", "EstadoId", "dbo.States");
            DropForeignKey("dbo.TypeOfExams", "EstadoId", "dbo.States");
            DropForeignKey("dbo.Promotions", "TipoDeExamenId", "dbo.TypeOfExams");
            DropForeignKey("dbo.Promotions", "EstadoId", "dbo.States");
            DropForeignKey("dbo.Patients", "TypeOfExam_TipoDeExamenId", "dbo.TypeOfExams");
            DropForeignKey("dbo.Exams", "TipoDeExamenId", "dbo.TypeOfExams");
            DropForeignKey("dbo.ExamRegistrations", "TipoDeExamenId", "dbo.TypeOfExams");
            DropForeignKey("dbo.Exams", "EstadoId", "dbo.States");
            DropForeignKey("dbo.InvoiceDetails", "PacienteId", "dbo.Patients");
            DropForeignKey("dbo.InvoiceDetails", "ExamenId", "dbo.Exams");
            DropForeignKey("dbo.Bills", "DetalleFacturaId", "dbo.InvoiceDetails");
            DropForeignKey("dbo.ExamRegistrations", "EstadoId", "dbo.States");
            DropForeignKey("dbo.Employees", "EstadoId", "dbo.States");
            DropForeignKey("dbo.Categories", "EstadoId", "dbo.States");
            DropForeignKey("dbo.Inventories", "CompraDetalleId", "dbo.PurchaseDetails");
            DropForeignKey("dbo.Inventories", "ProductoId", "dbo.Products");
            DropForeignKey("dbo.Products", "EstadoId", "dbo.States");
            DropForeignKey("dbo.PurchaseDetails", "ProductoId", "dbo.Products");
            DropForeignKey("dbo.PurchaseDetails", "CategoriaId", "dbo.Categories");
            DropForeignKey("dbo.Buys", "CompraDetalleId", "dbo.PurchaseDetails");
            DropForeignKey("dbo.ExamRegistrations", "PacienteId", "dbo.Patients");
            DropForeignKey("dbo.Bills", "PacienteId", "dbo.Patients");
            DropForeignKey("dbo.Employees", "GeneroId", "dbo.Genders");
            DropForeignKey("dbo.Bills", "EmpleadoId", "dbo.Employees");
            DropIndex("dbo.LaboratoryWorkers", new[] { "EmpleadoId" });
            DropIndex("dbo.Logs", new[] { "UsuarioId" });
            DropIndex("dbo.Users", new[] { "TipoUsuarioId" });
            DropIndex("dbo.Users", new[] { "EstadoId" });
            DropIndex("dbo.Users", new[] { "EmpleadoId" });
            DropIndex("dbo.UserTypes", new[] { "EstadoId" });
            DropIndex("dbo.UserRoles", new[] { "EstadoId" });
            DropIndex("dbo.UserRoles", new[] { "TipoUsuarioId" });
            DropIndex("dbo.Promotions", new[] { "EstadoId" });
            DropIndex("dbo.Promotions", new[] { "TipoDeExamenId" });
            DropIndex("dbo.TypeOfExams", new[] { "EstadoId" });
            DropIndex("dbo.InvoiceDetails", new[] { "ExamenId" });
            DropIndex("dbo.InvoiceDetails", new[] { "PacienteId" });
            DropIndex("dbo.Exams", new[] { "EstadoId" });
            DropIndex("dbo.Exams", new[] { "TipoDeExamenId" });
            DropIndex("dbo.Products", new[] { "EstadoId" });
            DropIndex("dbo.Inventories", new[] { "CompraDetalleId" });
            DropIndex("dbo.Inventories", new[] { "ProductoId" });
            DropIndex("dbo.Buys", new[] { "CompraDetalleId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductoId" });
            DropIndex("dbo.PurchaseDetails", new[] { "CategoriaId" });
            DropIndex("dbo.Categories", new[] { "EstadoId" });
            DropIndex("dbo.ExamRegistrations", new[] { "EstadoId" });
            DropIndex("dbo.ExamRegistrations", new[] { "TipoDeExamenId" });
            DropIndex("dbo.ExamRegistrations", new[] { "PacienteId" });
            DropIndex("dbo.Patients", new[] { "TypeOfExam_TipoDeExamenId" });
            DropIndex("dbo.Patients", new[] { "GeneroId" });
            DropIndex("dbo.Patients", new[] { "EstadoId" });
            DropIndex("dbo.Employees", new[] { "GeneroId" });
            DropIndex("dbo.Employees", new[] { "EstadoId" });
            DropIndex("dbo.Bills", new[] { "DetalleFacturaId" });
            DropIndex("dbo.Bills", new[] { "EmpleadoId" });
            DropIndex("dbo.Bills", new[] { "PacienteId" });
            DropTable("dbo.MigrationHistories");
            DropTable("dbo.Laboratories");
            DropTable("dbo.LaboratoryWorkers");
            DropTable("dbo.Logs");
            DropTable("dbo.Users");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Promotions");
            DropTable("dbo.TypeOfExams");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Exams");
            DropTable("dbo.Products");
            DropTable("dbo.Inventories");
            DropTable("dbo.Buys");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.States");
            DropTable("dbo.ExamRegistrations");
            DropTable("dbo.Patients");
            DropTable("dbo.Genders");
            DropTable("dbo.Employees");
            DropTable("dbo.Bills");
        }
    }
}
