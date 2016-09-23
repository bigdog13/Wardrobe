using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Shoe
    {
        [Key]
        public int shoeID { get; set; }

        public string shoeName { get; set; }
        public string shoePhoto { get; set; }
        public string shoeColor { get; set; }
        public string shoeSeason { get; set; }
        public string shoeOccasion { get; set; }

        //Nav property

        public virtual ICollection<Outfit> Outfits { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }
    }
}