namespace Wardrobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Tops", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Tops", "SeasonID", "dbo.Seasons");
            DropIndex("dbo.Outfits", new[] { "Bottom_BottomID" });
            DropIndex("dbo.Outfits", new[] { "Shoe_ShoeID" });
            DropIndex("dbo.Outfits", new[] { "Top_TopID" });
            RenameColumn(table: "dbo.Outfits", name: "Bottom_BottomID", newName: "BottomOutfitID");
            RenameColumn(table: "dbo.Outfits", name: "Shoe_ShoeID", newName: "ShoeOutfitID");
            RenameColumn(table: "dbo.Outfits", name: "Top_TopID", newName: "TopOutfitID");
            AddColumn("dbo.Outfits", "AccessoryOutfitID", c => c.Int(nullable: false));
            AlterColumn("dbo.Outfits", "BottomOutfitID", c => c.Int(nullable: false));
            AlterColumn("dbo.Outfits", "ShoeOutfitID", c => c.Int(nullable: false));
            AlterColumn("dbo.Outfits", "TopOutfitID", c => c.Int(nullable: false));
            CreateIndex("dbo.Outfits", "TopOutfitID");
            CreateIndex("dbo.Outfits", "BottomOutfitID");
            CreateIndex("dbo.Outfits", "ShoeOutfitID");
            AddForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions", "OccasionID");
            AddForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons", "seasonID");
            AddForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions", "OccasionID");
            AddForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions", "OccasionID");
            AddForeignKey("dbo.Tops", "OccasionID", "dbo.Occasions", "OccasionID");
            AddForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons", "seasonID");
            AddForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons", "seasonID");
            AddForeignKey("dbo.Tops", "SeasonID", "dbo.Seasons", "seasonID");
            DropColumn("dbo.Outfits", "TopOutfit");
            DropColumn("dbo.Outfits", "BottomOutfit");
            DropColumn("dbo.Outfits", "ShoeOutfit");
            DropColumn("dbo.Outfits", "AccessoryOutfit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Outfits", "AccessoryOutfit", c => c.Int(nullable: false));
            AddColumn("dbo.Outfits", "ShoeOutfit", c => c.Int(nullable: false));
            AddColumn("dbo.Outfits", "BottomOutfit", c => c.Int(nullable: false));
            AddColumn("dbo.Outfits", "TopOutfit", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tops", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Tops", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions");
            DropIndex("dbo.Outfits", new[] { "ShoeOutfitID" });
            DropIndex("dbo.Outfits", new[] { "BottomOutfitID" });
            DropIndex("dbo.Outfits", new[] { "TopOutfitID" });
            AlterColumn("dbo.Outfits", "TopOutfitID", c => c.Int());
            AlterColumn("dbo.Outfits", "ShoeOutfitID", c => c.Int());
            AlterColumn("dbo.Outfits", "BottomOutfitID", c => c.Int());
            DropColumn("dbo.Outfits", "AccessoryOutfitID");
            RenameColumn(table: "dbo.Outfits", name: "TopOutfitID", newName: "Top_TopID");
            RenameColumn(table: "dbo.Outfits", name: "ShoeOutfitID", newName: "Shoe_ShoeID");
            RenameColumn(table: "dbo.Outfits", name: "BottomOutfitID", newName: "Bottom_BottomID");
            CreateIndex("dbo.Outfits", "Top_TopID");
            CreateIndex("dbo.Outfits", "Shoe_ShoeID");
            CreateIndex("dbo.Outfits", "Bottom_BottomID");
            AddForeignKey("dbo.Tops", "SeasonID", "dbo.Seasons", "seasonID", cascadeDelete: true);
            AddForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons", "seasonID", cascadeDelete: true);
            AddForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons", "seasonID", cascadeDelete: true);
            AddForeignKey("dbo.Tops", "OccasionID", "dbo.Occasions", "OccasionID", cascadeDelete: true);
            AddForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions", "OccasionID", cascadeDelete: true);
            AddForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions", "OccasionID", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons", "seasonID", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions", "OccasionID", cascadeDelete: true);
        }
    }
}
