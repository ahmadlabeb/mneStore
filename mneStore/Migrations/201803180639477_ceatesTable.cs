namespace mneStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ceatesTable : DbMigration
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
                        serialNamber = c.String(),
                        barcode = c.String(),
                        quantity = c.Double(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        billsId = c.Int(nullable: false),
                        KindsId = c.Int(nullable: false),
                        UnitItemsId = c.Int(nullable: false),
                        brandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bills", t => t.billsId, cascadeDelete: true)
                .ForeignKey("dbo.brands", t => t.brandId, cascadeDelete: true)
                .ForeignKey("dbo.Kinds", t => t.KindsId, cascadeDelete: true)
                .ForeignKey("dbo.UnitItems", t => t.UnitItemsId, cascadeDelete: true)
                .Index(t => t.billsId)
                .Index(t => t.KindsId)
                .Index(t => t.UnitItemsId)
                .Index(t => t.brandId);
            
            CreateTable(
                "dbo.brands",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nameBrand = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Kinds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nameKind = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UnitItems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NameUnit = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.String(),
                        EmployeeNumber = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.items", "UnitItemsId", "dbo.UnitItems");
            DropForeignKey("dbo.items", "KindsId", "dbo.Kinds");
            DropForeignKey("dbo.items", "brandId", "dbo.brands");
            DropForeignKey("dbo.items", "billsId", "dbo.bills");
            DropForeignKey("dbo.bills", "currunciesId", "dbo.Curruncies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.items", new[] { "brandId" });
            DropIndex("dbo.items", new[] { "UnitItemsId" });
            DropIndex("dbo.items", new[] { "KindsId" });
            DropIndex("dbo.items", new[] { "billsId" });
            DropIndex("dbo.bills", new[] { "currunciesId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UnitItems");
            DropTable("dbo.Kinds");
            DropTable("dbo.brands");
            DropTable("dbo.items");
            DropTable("dbo.Curruncies");
            DropTable("dbo.bills");
        }
    }
}
