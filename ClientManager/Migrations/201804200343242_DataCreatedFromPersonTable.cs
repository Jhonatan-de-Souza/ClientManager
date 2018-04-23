namespace ClientManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataCreatedFromPersonTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Person", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
