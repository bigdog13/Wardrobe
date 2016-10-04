using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe.Models
{
    public class Occasion
    {
        [Key]
        public int OccasionID { get; set; }

        public string OccasionName { get; set; }

        //navigation properties
        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<Shoe> Shoes { get; set; }
        public virtual ICollection<Top> Tops { get; set; }
        public virtual ICollection<Bottom> Bottoms { get; set; }


        public virtual ICollection<Outfit> Outfits { get; set; }
    }
}