namespace Wardrobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeasonOccasion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Outfits", "SeasonOutfitID", c => c.Int(nullable: false));
            AddColumn("dbo.Outfits", "OccasionOutfitID", c => c.Int(nullable: false));
            CreateIndex("dbo.Outfits", "SeasonOutfitID");
            CreateIndex("dbo.Outfits", "OccasionOutfitID");
            AddForeignKey("dbo.Outfits", "OccasionOutfitID", "dbo.Occasions", "OccasionID");
            AddForeignKey("dbo.Outfits", "SeasonOutfitID", "dbo.Seasons", "seasonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outfits", "SeasonOutfitID", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "OccasionOutfitID", "dbo.Occasions");
            DropIndex("dbo.Outfits", new[] { "OccasionOutfitID" });
            DropIndex("dbo.Outfits", new[] { "SeasonOutfitID" });
            DropColumn("dbo.Outfits", "OccasionOutfitID");
            DropColumn("dbo.Outfits", "SeasonOutfitID");
        }
    }
}
