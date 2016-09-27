namespace Wardrobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryID = c.Int(nullable: false, identity: true),
                        AccessoryName = c.String(),
                        AccessoryPhoto = c.String(),
                        AccessoryColor = c.String(),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessoryID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID, cascadeDelete: true)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Occasions",
                c => new
                    {
                        OccasionID = c.Int(nullable: false, identity: true),
                        OccasionName = c.String(),
                    })
                .PrimaryKey(t => t.OccasionID);
            
            CreateTable(
                "dbo.Bottoms",
                c => new
                    {
                        BottomID = c.Int(nullable: false, identity: true),
                        BottomName = c.String(),
                        BottomPhoto = c.String(),
                        BottomColor = c.String(),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BottomID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID, cascadeDelete: true)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Outfits",
                c => new
                    {
                        OutfitID = c.Int(nullable: false, identity: true),
                        TopOutfit = c.Int(nullable: false),
                        BottomOutfit = c.Int(nullable: false),
                        ShoeOutfit = c.Int(nullable: false),
                        AccessoryOutfit = c.Int(nullable: false),
                        Bottom_BottomID = c.Int(),
                        Shoe_ShoeID = c.Int(),
                        Top_TopID = c.Int(),
                    })
                .PrimaryKey(t => t.OutfitID)
                .ForeignKey("dbo.Bottoms", t => t.Bottom_BottomID)
                .ForeignKey("dbo.Shoes", t => t.Shoe_ShoeID)
                .ForeignKey("dbo.Tops", t => t.Top_TopID)
                .Index(t => t.Bottom_BottomID)
                .Index(t => t.Shoe_ShoeID)
                .Index(t => t.Top_TopID);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        ShoeID = c.Int(nullable: false, identity: true),
                        ShoeName = c.String(),
                        ShoePhoto = c.String(),
                        ShoeColor = c.String(),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoeID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID, cascadeDelete: true)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        seasonID = c.Int(nullable: false, identity: true),
                        seasonName = c.String(),
                    })
                .PrimaryKey(t => t.seasonID);
            
            CreateTable(
                "dbo.Tops",
                c => new
                    {
                        TopID = c.Int(nullable: false, identity: true),
                        TopName = c.String(),
                        TopPhoto = c.String(),
                        TopColor = c.String(),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TopID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID, cascadeDelete: true)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.OutfitAccessories",
                c => new
                    {
                        Outfit_OutfitID = c.Int(nullable: false),
                        Accessory_AccessoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Outfit_OutfitID, t.Accessory_AccessoryID })
                .ForeignKey("dbo.Outfits", t => t.Outfit_OutfitID, cascadeDelete: true)
                .ForeignKey("dbo.Accessories", t => t.Accessory_AccessoryID, cascadeDelete: true)
                .Index(t => t.Outfit_OutfitID)
                .Index(t => t.Accessory_AccessoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Tops", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "Top_TopID", "dbo.Tops");
            DropForeignKey("dbo.Tops", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Outfits", "Shoe_ShoeID", "dbo.Shoes");
            DropForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Outfits", "Bottom_BottomID", "dbo.Bottoms");
            DropForeignKey("dbo.OutfitAccessories", "Accessory_AccessoryID", "dbo.Accessories");
            DropForeignKey("dbo.OutfitAccessories", "Outfit_OutfitID", "dbo.Outfits");
            DropForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions");
            DropIndex("dbo.OutfitAccessories", new[] { "Accessory_AccessoryID" });
            DropIndex("dbo.OutfitAccessories", new[] { "Outfit_OutfitID" });
            DropIndex("dbo.Tops", new[] { "OccasionID" });
            DropIndex("dbo.Tops", new[] { "SeasonID" });
            DropIndex("dbo.Shoes", new[] { "OccasionID" });
            DropIndex("dbo.Shoes", new[] { "SeasonID" });
            DropIndex("dbo.Outfits", new[] { "Top_TopID" });
            DropIndex("dbo.Outfits", new[] { "Shoe_ShoeID" });
            DropIndex("dbo.Outfits", new[] { "Bottom_BottomID" });
            DropIndex("dbo.Bottoms", new[] { "OccasionID" });
            DropIndex("dbo.Bottoms", new[] { "SeasonID" });
            DropIndex("dbo.Accessories", new[] { "OccasionID" });
            DropIndex("dbo.Accessories", new[] { "SeasonID" });
            DropTable("dbo.OutfitAccessories");
            DropTable("dbo.Tops");
            DropTable("dbo.Seasons");
            DropTable("dbo.Shoes");
            DropTable("dbo.Outfits");
            DropTable("dbo.Bottoms");
            DropTable("dbo.Occasions");
            DropTable("dbo.Accessories");
        }
    }
}
