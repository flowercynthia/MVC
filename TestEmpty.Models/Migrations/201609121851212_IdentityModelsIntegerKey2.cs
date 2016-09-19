namespace TestEmpty.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModelsIntegerKey2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendedor", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UserClaim", "UserModel_Id", "dbo.Usuario");
            DropForeignKey("dbo.UserLogin", "UserModel_Id", "dbo.Usuario");
            DropForeignKey("dbo.UserRole", "UserModel_Id", "dbo.Usuario");
            DropForeignKey("dbo.UserRole", "RoleModel_Id", "dbo.RoleModel");
            DropIndex("dbo.Vendedor", new[] { "UsuarioId" });
            DropIndex("dbo.UserClaim", new[] { "UserModel_Id" });
            DropIndex("dbo.UserLogin", new[] { "UserModel_Id" });
            DropIndex("dbo.UserRole", new[] { "UserModel_Id" });
            DropIndex("dbo.UserRole", new[] { "RoleModel_Id" });
            DropPrimaryKey("dbo.Usuario");
            DropPrimaryKey("dbo.UserLogin");
            DropPrimaryKey("dbo.UserRole");
            DropPrimaryKey("dbo.RoleModel");
            AlterColumn("dbo.Vendedor", "UsuarioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserClaim", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserClaim", "UserModel_Id", c => c.Int());
            AlterColumn("dbo.UserLogin", "UserId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserLogin", "UserModel_Id", c => c.Int());
            AlterColumn("dbo.UserRole", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRole", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRole", "UserModel_Id", c => c.Int());
            AlterColumn("dbo.UserRole", "RoleModel_Id", c => c.Int());
            AlterColumn("dbo.RoleModel", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Usuario", "Id");
            AddPrimaryKey("dbo.UserLogin", "UserId");
            AddPrimaryKey("dbo.UserRole", new[] { "RoleId", "UserId" });
            AddPrimaryKey("dbo.RoleModel", "Id");
            CreateIndex("dbo.Vendedor", "UsuarioId");
            CreateIndex("dbo.UserClaim", "UserModel_Id");
            CreateIndex("dbo.UserLogin", "UserModel_Id");
            CreateIndex("dbo.UserRole", "UserModel_Id");
            CreateIndex("dbo.UserRole", "RoleModel_Id");
            AddForeignKey("dbo.Vendedor", "UsuarioId", "dbo.Usuario", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserClaim", "UserModel_Id", "dbo.Usuario", "Id");
            AddForeignKey("dbo.UserLogin", "UserModel_Id", "dbo.Usuario", "Id");
            AddForeignKey("dbo.UserRole", "UserModel_Id", "dbo.Usuario", "Id");
            AddForeignKey("dbo.UserRole", "RoleModel_Id", "dbo.RoleModel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleModel_Id", "dbo.RoleModel");
            DropForeignKey("dbo.UserRole", "UserModel_Id", "dbo.Usuario");
            DropForeignKey("dbo.UserLogin", "UserModel_Id", "dbo.Usuario");
            DropForeignKey("dbo.UserClaim", "UserModel_Id", "dbo.Usuario");
            DropForeignKey("dbo.Vendedor", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.UserRole", new[] { "RoleModel_Id" });
            DropIndex("dbo.UserRole", new[] { "UserModel_Id" });
            DropIndex("dbo.UserLogin", new[] { "UserModel_Id" });
            DropIndex("dbo.UserClaim", new[] { "UserModel_Id" });
            DropIndex("dbo.Vendedor", new[] { "UsuarioId" });
            DropPrimaryKey("dbo.RoleModel");
            DropPrimaryKey("dbo.UserRole");
            DropPrimaryKey("dbo.UserLogin");
            DropPrimaryKey("dbo.Usuario");
            AlterColumn("dbo.RoleModel", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserRole", "RoleModel_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserRole", "UserModel_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserRole", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserRole", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserLogin", "UserModel_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserLogin", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserClaim", "UserModel_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserClaim", "UserId", c => c.String());
            AlterColumn("dbo.Usuario", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Vendedor", "UsuarioId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.RoleModel", "Id");
            AddPrimaryKey("dbo.UserRole", new[] { "RoleId", "UserId" });
            AddPrimaryKey("dbo.UserLogin", "UserId");
            AddPrimaryKey("dbo.Usuario", "Id");
            CreateIndex("dbo.UserRole", "RoleModel_Id");
            CreateIndex("dbo.UserRole", "UserModel_Id");
            CreateIndex("dbo.UserLogin", "UserModel_Id");
            CreateIndex("dbo.UserClaim", "UserModel_Id");
            CreateIndex("dbo.Vendedor", "UsuarioId");
            AddForeignKey("dbo.UserRole", "RoleModel_Id", "dbo.RoleModel", "Id");
            AddForeignKey("dbo.UserRole", "UserModel_Id", "dbo.Usuario", "Id");
            AddForeignKey("dbo.UserLogin", "UserModel_Id", "dbo.Usuario", "Id");
            AddForeignKey("dbo.UserClaim", "UserModel_Id", "dbo.Usuario", "Id");
            AddForeignKey("dbo.Vendedor", "UsuarioId", "dbo.Usuario", "Id");
        }
    }
}
