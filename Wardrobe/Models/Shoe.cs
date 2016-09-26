using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Shoe
    {
        [Key]
        public int ShoeID { get; set; }

        public string ShoeName { get; set; }
        public string ShoePhoto { get; set; }
        public string ShoeColor { get; set; }
        [ForeignKey("Season")]
        public int SeasonID { get; set; }
        [ForeignKey("Occasion")]
        public int OccasionID { get; set; }

        //Nav property

        public virtual ICollection<Outfit> Outfits { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }
    }
}