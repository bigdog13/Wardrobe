using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Top
    {
        [Key]
        public string topID { get; set; }

        public string topName { get; set; }
        public string topPhoto { get; set; }
        public string topColor { get; set; }
        public string topSeason { get; set; }
        public string topOccasion { get; set; }

        //navigation//
        public virtual ICollection<Outfit> Outfits { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }
 }
}