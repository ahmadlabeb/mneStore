namespace mneStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableUnits : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnitItems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NameUnit = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.items", "UnitItemsId", c => c.Int(nullable: false));
            CreateIndex("dbo.items", "UnitItemsId");
            AddForeignKey("dbo.items", "UnitItemsId", "dbo.UnitItems", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.items", "UnitItemsId", "dbo.UnitItems");
            DropIndex("dbo.items", new[] { "UnitItemsId" });
            DropColumn("dbo.items", "UnitItemsId");
            DropTable("dbo.UnitItems");
        }
    }
}
