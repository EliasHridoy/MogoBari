using System;
using System.Collections.Generic;

namespace MogobariWebAPI.Models
{
    public partial class Picture
    {
        public Picture()
        {
            ProductPictureMapping = new HashSet<ProductPictureMapping>();
        }

        public int Id { get; set; }
        public string Filename { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public string VirtualPath { get; set; }

        public virtual ICollection<ProductPictureMapping> ProductPictureMapping { get; set; }
    }
}
