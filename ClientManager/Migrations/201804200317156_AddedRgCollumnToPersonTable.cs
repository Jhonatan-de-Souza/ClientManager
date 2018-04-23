namespace ClientManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRgCollumnToPersonTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Rg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Rg");
        }
    }
}
