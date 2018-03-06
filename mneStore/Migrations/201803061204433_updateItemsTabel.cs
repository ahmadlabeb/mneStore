namespace mneStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateItemsTabel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.items", "quantity", c => c.Double(nullable: false));
            AddColumn("dbo.items", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.items", "price");
            DropColumn("dbo.items", "quantity");
        }
    }
}
