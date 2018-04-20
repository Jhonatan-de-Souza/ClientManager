namespace ClientManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPersonTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Phonenumber = c.String(nullable: false),
                        Uf = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUpdateDate = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Person");
        }
    }
}
