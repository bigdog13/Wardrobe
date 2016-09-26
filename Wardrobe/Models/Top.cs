using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Top
    {
        [Key]
        public int TopID { get; set; }

        public string TopName { get; set; }
        public string TopPhoto { get; set; }
        public string TopColor { get; set; }
        [ForeignKey("Season")]
        public int SeasonID { get; set; }
        [ForeignKey("Occasion")]
        public int OccasionID { get; set; }

        //navigation//
        public virtual ICollection<Outfit> Outfits { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }
 }
}