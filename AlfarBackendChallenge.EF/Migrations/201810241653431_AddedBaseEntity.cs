namespace AlfarBackendChallenge.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBaseEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Address_AddressId", "dbo.Addresses");
            RenameColumn(table: "dbo.Customers", name: "Address_AddressId", newName: "Address_Id");
            RenameIndex(table: "dbo.Customers", name: "IX_Address_AddressId", newName: "IX_Address_Id");
            DropPrimaryKey("dbo.Addresses");
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Addresses", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Addresses", "CreationTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Addresses", "LastModificationTimeStamp", c => c.DateTime());
            AddColumn("dbo.Customers", "Id", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Customers", "CreationTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "LastModificationTimeStamp", c => c.DateTime());
            AddPrimaryKey("dbo.Addresses", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
            AddForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses", "Id");
            DropColumn("dbo.Addresses", "AddressId");
            DropColumn("dbo.Customers", "CustomerId");
            DropColumn("dbo.Customers", "LastModificationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "LastModificationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "CustomerId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.Addresses", "AddressId", c => c.Guid(nullable: false, identity: true));
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Addresses");
            DropColumn("dbo.Customers", "LastModificationTimeStamp");
            DropColumn("dbo.Customers", "CreationTimeStamp");
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.Addresses", "LastModificationTimeStamp");
            DropColumn("dbo.Addresses", "CreationTimeStamp");
            DropColumn("dbo.Addresses", "Id");
            AddPrimaryKey("dbo.Customers", "CustomerId");
            AddPrimaryKey("dbo.Addresses", "AddressId");
            RenameIndex(table: "dbo.Customers", name: "IX_Address_Id", newName: "IX_Address_AddressId");
            RenameColumn(table: "dbo.Customers", name: "Address_Id", newName: "Address_AddressId");
            AddForeignKey("dbo.Customers", "Address_AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
