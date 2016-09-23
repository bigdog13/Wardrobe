using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Accessory
    {
        [Key]
        public int accessoryID { get; set; }

        public string accessoryName { get; set; }
        public string accessoryPhoto { get; set; }
        public string accessoryColor { get; set; }
        public string accessorySeason { get; set; }
        public string accessoryOccasion { get; set; }

        //Nav properties

        public virtual ICollection<Outfit> Outfits { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }

    }
}