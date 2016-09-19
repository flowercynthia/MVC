namespace TestEmpty.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleModel_Id = c.String(maxLength: 128),
                        UserModel_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.RoleModel", t => t.RoleModel_Id)
                .ForeignKey("dbo.Usuario", t => t.UserModel_Id)
                .Index(t => t.RoleModel_Id)
                .Index(t => t.UserModel_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PreferenceLevel = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        UserModel_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UserModel_Id)
                .Index(t => t.UserModel_Id);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserModel_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Usuario", t => t.UserModel_Id)
                .Index(t => t.UserModel_Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        CodCliente = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Arreglo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClienteModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteModel_Id)
                .Index(t => t.ClienteModel_Id);
            
            CreateTable(
                "dbo.Encargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaEntrega = c.DateTime(nullable: false),
                        DireccionEntrega = c.String(),
                        ArregloId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Arreglo", t => t.ArregloId, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ArregloId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaVenta = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        VendedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Vendedor", t => t.VendedorId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.VendedorId);
            
            CreateTable(
                "dbo.DetalleVentaFlor",
                c => new
                    {
                        VentaId = c.Int(nullable: false),
                        FlorId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VentaId, t.FlorId })
                .ForeignKey("dbo.Flor", t => t.FlorId, cascadeDelete: true)
                .ForeignKey("dbo.Venta", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.VentaId)
                .Index(t => t.FlorId);
            
            CreateTable(
                "dbo.Flor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Color = c.String(),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Entrega",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comentario = c.String(),
                        FotoUrl = c.String(),
                        EncargoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Encargo", t => t.EncargoId, cascadeDelete: true)
                .Index(t => t.EncargoId);
            
            CreateTable(
                "dbo.ItemArreglo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Color = c.String(),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleVentaArreglo",
                c => new
                    {
                        VentaId = c.Int(nullable: false),
                        ArregloId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VentaId, t.ArregloId })
                .ForeignKey("dbo.Arreglo", t => t.ArregloId, cascadeDelete: true)
                .ForeignKey("dbo.Venta", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.VentaId)
                .Index(t => t.ArregloId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleVentaArreglo", "VentaId", "dbo.Venta");
            DropForeignKey("dbo.DetalleVentaArreglo", "ArregloId", "dbo.Arreglo");
            DropForeignKey("dbo.Entrega", "EncargoId", "dbo.Encargo");
            DropForeignKey("dbo.Venta", "VendedorId", "dbo.Vendedor");
            DropForeignKey("dbo.Vendedor", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.DetalleVentaFlor", "VentaId", "dbo.Venta");
            DropForeignKey("dbo.DetalleVentaFlor", "FlorId", "dbo.Flor");
            DropForeignKey("dbo.Venta", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Arreglo", "ClienteModel_Id", "dbo.Cliente");
            DropForeignKey("dbo.Encargo", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Encargo", "ArregloId", "dbo.Arreglo");
            DropForeignKey("dbo.UserRole", "UserModel_Id", "dbo.Usuario");
            DropForeignKey("dbo.UserLogin", "UserModel_Id", "dbo.Usuario");
            DropForeignKey("dbo.UserClaim", "UserModel_Id", "dbo.Usuario");
            DropForeignKey("dbo.UserRole", "RoleModel_Id", "dbo.RoleModel");
            DropIndex("dbo.DetalleVentaArreglo", new[] { "ArregloId" });
            DropIndex("dbo.DetalleVentaArreglo", new[] { "VentaId" });
            DropIndex("dbo.Entrega", new[] { "EncargoId" });
            DropIndex("dbo.Vendedor", new[] { "UsuarioId" });
            DropIndex("dbo.DetalleVentaFlor", new[] { "FlorId" });
            DropIndex("dbo.DetalleVentaFlor", new[] { "VentaId" });
            DropIndex("dbo.Venta", new[] { "VendedorId" });
            DropIndex("dbo.Venta", new[] { "ClienteId" });
            DropIndex("dbo.Encargo", new[] { "ClienteId" });
            DropIndex("dbo.Encargo", new[] { "ArregloId" });
            DropIndex("dbo.Arreglo", new[] { "ClienteModel_Id" });
            DropIndex("dbo.UserLogin", new[] { "UserModel_Id" });
            DropIndex("dbo.UserClaim", new[] { "UserModel_Id" });
            DropIndex("dbo.UserRole", new[] { "UserModel_Id" });
            DropIndex("dbo.UserRole", new[] { "RoleModel_Id" });
            DropTable("dbo.DetalleVentaArreglo");
            DropTable("dbo.ItemArreglo");
            DropTable("dbo.Entrega");
            DropTable("dbo.Vendedor");
            DropTable("dbo.Flor");
            DropTable("dbo.DetalleVentaFlor");
            DropTable("dbo.Venta");
            DropTable("dbo.Encargo");
            DropTable("dbo.Arreglo");
            DropTable("dbo.Cliente");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.Usuario");
            DropTable("dbo.UserRole");
            DropTable("dbo.RoleModel");
        }
    }
}
