using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Outfit
    {

        public Outfit()
        {
            Accessories = new HashSet<Accessory>();
        }
        [Key]
        public int OutfitID { get; set; }
        public string OutfitName { get; set; }

        [ForeignKey("Top")]
        public int TopOutfitID { get; set; }
        [ForeignKey("Bottom")]
        public int BottomOutfitID { get; set; }
        [ForeignKey("Shoe")]
        public int ShoeOutfitID { get; set; }
        [ForeignKey("Accessories")]
        public int AccessoryOutfitID { get; set; }

        [ForeignKey("Season")]
        public int SeasonOutfitID { get; set; }
        [ForeignKey("Occasion")]
        public int OccasionOutfitID { get; set; }

        //naviagation property Many//

        public virtual ICollection<Accessory> Accessories { get; set; }

        //Nav Property One//
        public virtual Bottom Bottom { get; set; }
        public virtual Top Top { get; set; }
        public virtual Shoe Shoe { get; set; }

        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }

    }
                   
    
}