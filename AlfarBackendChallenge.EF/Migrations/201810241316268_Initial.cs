namespace AlfarBackendChallenge.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Guid(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Guid(nullable: false, identity: true),
                        LastModificationDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        PreferredName = c.String(),
                        EmailAddress = c.String(nullable: false, maxLength: 255),
                        Title = c.String(),
                        DateOfBirth = c.DateTime(),
                        Biography = c.String(),
                        JobTitle = c.String(),
                        Address_AddressId = c.Guid(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .Index(t => t.Address_AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "Address_AddressId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
