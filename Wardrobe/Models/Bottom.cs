using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Bottom

    {
        [Key]
        public string bottomID { get; set; }

        public string bottomName { get; set; }
        public string bottomPhoto { get; set; }
        public string bottomColor { get; set; }
        public string bottomSeason { get; set; }
        public string bottomOccasion { get; set; }
        
        //navigation//
        public virtual ICollection<Outfit> Outfits { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }
    }
}