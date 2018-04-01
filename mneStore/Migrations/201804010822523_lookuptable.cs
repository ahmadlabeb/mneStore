namespace mneStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lookuptable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NameItems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nameOfItems = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.items", "idNameItems", c => c.Int(nullable: false));
            CreateIndex("dbo.items", "idNameItems");
            AddForeignKey("dbo.items", "idNameItems", "dbo.NameItems", "id", cascadeDelete: true);
            DropColumn("dbo.items", "nameItem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.items", "nameItem", c => c.String(nullable: false));
            DropForeignKey("dbo.items", "idNameItems", "dbo.NameItems");
            DropIndex("dbo.items", new[] { "idNameItems" });
            DropColumn("dbo.items", "idNameItems");
            DropTable("dbo.NameItems");
        }
    }
}
