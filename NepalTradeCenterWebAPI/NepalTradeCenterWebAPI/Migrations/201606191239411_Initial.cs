namespace NepalTradeCenterWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        productCode = c.String(),
                        productName = c.String(),
                        quantity = c.Int(nullable: false),
                        initialCost = c.Double(nullable: false),
                        sellingPrice = c.Double(nullable: false),
                        profitPercentage = c.Double(nullable: false),
                        color = c.String(),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                        modifier = c.String(),
                        staus = c.Boolean(nullable: false),
                        isAvailabe = c.Boolean(nullable: false),
                        sizeID = c.Int(nullable: false),
                        categoryID = c.Int(nullable: false),
                        testfield = c.String(),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.Size", t => t.sizeID, cascadeDelete: true)
                .Index(t => t.sizeID);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        sizeID = c.Int(nullable: false, identity: true),
                        sizeName = c.String(),
                    })
                .PrimaryKey(t => t.sizeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "sizeID", "dbo.Size");
            DropIndex("dbo.Product", new[] { "sizeID" });
            DropTable("dbo.Size");
            DropTable("dbo.Product");
        }
    }
}
