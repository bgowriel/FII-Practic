using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class InsertImage : IRequest<Image>
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public Uri ImageUri { get; set; }

        public int RealEstateId { get; set; }
    }
}
