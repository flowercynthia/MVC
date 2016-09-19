namespace TestEmpty.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModelsIntegerKey51 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
        }
    }
}
