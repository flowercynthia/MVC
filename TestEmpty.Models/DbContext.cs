namespace TestEmpty.Models
{
    using Administracion;
    using Arreglos;
    using Inventario;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using Venta;
    public interface IApplicationDbContext
    {
        //Identity Models
        /*DbSet<UserModel> AppUsers { get;}
        DbSet<RoleModel> AppRoles { get; }*/
        DbSet<UserRoleModel> UserRoles { get; set; }
        DbSet<UserLoginModel> UserLogins { get; set; }
        DbSet<UserClaimModel> UserClaims { get; set; }

        //Administracion Models
        DbSet<ClienteModel> Clientes { get; set; }

        //Arreglos Models
        DbSet<ArregloModel> Arreglos { get; set; }
        DbSet<EncargoModel> Encargos { get; set; }
        DbSet<EntregaModel> Entregas { get; set; }

        //Inventario Models
        DbSet<FlorModel> Flores { get; set; }
        DbSet<ItemArregloModel> ItemArreglos { get; set; }

        //Venta Models
        DbSet<DetalleVentaFlorModel> DetalleVentaFlores { get; set; }
        DbSet<DetalleVentaArregloModel> DetalleVentaArreglos { get; set; }
        DbSet<VendedorModel> Vendedores { get; set; }
        DbSet<VentaModel> Ventas { get; set; }
    }
    public class EmptyDbContext : IdentityDbContext<UserModel, RoleModel, int, UserLoginModel, UserRoleModel, UserClaimModel>, IApplicationDbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'EmptyModel' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'TestEmpty.Models.EmptyModel' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'EmptyModel'  en el archivo de configuración de la aplicación.
        public EmptyDbContext()
            : base("DefaultConnection")
        {
        }
        public static EmptyDbContext Create()
        {
            return new EmptyDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Identity Models
            modelBuilder.Entity<UserModel>().ToTable("Usuario").Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<RoleModel>().ToTable("RoleModel");
            modelBuilder.Entity<UserRoleModel>().ToTable("UserRole").HasKey(x => new { RoleId = x.RoleId, UserId = x.UserId });
            modelBuilder.Entity<UserLoginModel>().ToTable("UserLogin").HasKey(x => x.UserId);
            modelBuilder.Entity<UserClaimModel>().ToTable("UserClaim");

            //Administracion Models
            modelBuilder.Entity<ClienteModel>().ToTable("Cliente");

            //Arreglos Models
            modelBuilder.Entity<ArregloModel>().ToTable("Arreglo");
            modelBuilder.Entity<EncargoModel>().ToTable("Encargo");
            modelBuilder.Entity<EntregaModel>().ToTable("Entrega");

            //Inventario Models
            modelBuilder.Entity<FlorModel>().ToTable("Flor");
            modelBuilder.Entity<ItemArregloModel>().ToTable("ItemArreglo");

            //Venta Models
            modelBuilder.Entity<DetalleVentaFlorModel>().ToTable("DetalleVentaFlor").HasKey(x=>new { VentaId = x.VentaId, FlorId = x.FlorId});
            modelBuilder.Entity<DetalleVentaArregloModel>().ToTable("DetalleVentaArreglo").HasKey(x => new { VentaId = x.VentaId, ArregloId = x.ArregloId });
            modelBuilder.Entity<VendedorModel>().ToTable("Vendedor");
            modelBuilder.Entity<VentaModel>().ToTable("Venta");
        }
        #region Identity Models
        /*public DbSet<UserModel> AppUsers
        {
            get
            {
                return this.Users as DbSet<UserModel>;
            }
        }

        public DbSet<RoleModel> AppRoles
        {
            get
            {
                return this.Roles as DbSet<RoleModel>;
            }
        }*/
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<UserLoginModel> UserLogins { get; set; }
        public DbSet<UserClaimModel> UserClaims { get; set; }
        #endregion

        #region Administracion Models
        public DbSet<ClienteModel> Clientes { get; set; }
        #endregion

        #region Arreglos Models
        public DbSet<ArregloModel> Arreglos { get; set; }
        public DbSet<EncargoModel> Encargos { get; set; }
        public DbSet<EntregaModel> Entregas { get; set; }
        #endregion

        #region Inventario Models
        public DbSet<FlorModel> Flores { get; set; }
        public DbSet<ItemArregloModel> ItemArreglos { get; set; }
        #endregion

        #region Venta Models
        public DbSet<DetalleVentaFlorModel> DetalleVentaFlores { get; set; }
        public DbSet<DetalleVentaArregloModel> DetalleVentaArreglos { get; set; }
        public DbSet<VendedorModel> Vendedores { get; set; }
        public DbSet<VentaModel> Ventas { get; set; }
        
        #endregion
    }
}