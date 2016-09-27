namespace Wardrobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOutfitName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Outfits", "OutfitName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Outfits", "OutfitName");
        }
    }
}
