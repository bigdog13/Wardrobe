using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Accessory
    {
        [Key]
        public int AccessoryID { get; set; }

        public string AccessoryName { get; set; }
        public string AccessoryPhoto { get; set; }
        public string AccessoryColor { get; set; }

        [ForeignKey("Season")]
        public int SeasonID { get; set; }
        [ForeignKey("Occasion")]
        public int OccasionID { get; set; }

        //Nav properties

        public virtual ICollection<Outfit> Outfits { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }

    }
}