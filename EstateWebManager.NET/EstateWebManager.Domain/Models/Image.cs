using EstateWebManager.Domain.Models.RealEstateClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Domain.Models
{
    public class Image
    {
        public int Id { get; set; }

        public Uri ImageUri { get; set; }

        public int RealEstateId { get; set; }

        public RealEstate RealEstate { get; set; }
    }
}
