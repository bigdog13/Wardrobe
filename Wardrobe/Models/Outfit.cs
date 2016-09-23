using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Outfit
    {
        [Key]
        public int outfitID { get; set; }

        public string topOutfit { get; set; }
        public string bottomOutfit { get; set; }
        public string shoesOutfit { get; set; }
        public string accessoriesOutfit { get; set; }

        //naviagation property Many//

        public virtual ICollection<Accessory> Accessories { get; set; }

        //Nav Property One//
        public virtual Bottom Bottom { get; set; }
        public virtual Top Top { get; set; }
        public virtual Shoe Shoe { get; set; }
    }
                   
    
}