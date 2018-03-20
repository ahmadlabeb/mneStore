namespace mneStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsfsdf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.brands", "nameBrand", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.brands", "nameBrand", c => c.String());
        }
    }
}
