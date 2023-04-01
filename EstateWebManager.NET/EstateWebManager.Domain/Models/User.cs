using EstateWebManager.Domain.Models.RealEstateClasses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Domain.Models
{
    public class User : IdentityUser
    {
        public List<RealEstate>? RealEstates { get; set; }
    }
}
