namespace ClientManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustesClassPerson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Person", "Cpf", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Person", "Rg", c => c.String(maxLength: 255));
            AlterColumn("dbo.Person", "Birthdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "Birthdate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Person", "Rg", c => c.String());
            AlterColumn("dbo.Person", "Cpf", c => c.String(nullable: false));
            AlterColumn("dbo.Person", "Name", c => c.String(nullable: false));
        }
    }
}
