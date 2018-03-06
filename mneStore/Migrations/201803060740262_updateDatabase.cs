namespace mneStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nameBuy = c.String(nullable: false),
                        billNumber = c.String(nullable: false),
                        dateBill = c.DateTime(nullable: false),
                        currunciesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Curruncies", t => t.currunciesId, cascadeDelete: true)
                .Index(t => t.currunciesId);
            
            CreateTable(
                "dbo.Curruncies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nameUnit = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.items",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nameItem = c.String(nullable: false),
                        description = c.String(nullable: false),
                        brand = c.String(nullable: false),
                        serialNamber = c.String(nullable: false),
                        barcode = c.String(nullable: false),
                        billsId = c.Int(nullable: false),
                        KindsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bills", t => t.billsId, cascadeDelete: true)
                .ForeignKey("dbo.Kinds", t => t.KindsId, cascadeDelete: true)
                .Index(t => t.billsId)
                .Index(t => t.KindsId);
            
            CreateTable(
                "dbo.Kinds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nameKind = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.items", "KindsId", "dbo.Kinds");
            DropForeignKey("dbo.items", "billsId", "dbo.bills");
            DropForeignKey("dbo.bills", "currunciesId", "dbo.Curruncies");
            DropIndex("dbo.items", new[] { "KindsId" });
            DropIndex("dbo.items", new[] { "billsId" });
            DropIndex("dbo.bills", new[] { "currunciesId" });
            DropTable("dbo.Kinds");
            DropTable("dbo.items");
            DropTable("dbo.Curruncies");
            DropTable("dbo.bills");
        }
    }
}
