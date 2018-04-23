namespace ClientManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeTodatetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "Birthdate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Person", "CreationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Person", "LastUpdateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }

        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.Person", "LastUpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Person", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Person", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
