using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Enums;
using EstateWebManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class UpdateAreaHandler : IRequestHandler<UpdateArea, Area>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAreaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Area> Handle(UpdateArea request, CancellationToken cancellationToken)
        {
            var toUpdate = new Area
            {
                Id = request.Id,
                Neighborhood = request.Neighborhood,
                City = request.City,
                ShortName = request.ShortName,
                County = request.County,
                Country = request.Country,
                PhonePrefix = request.PhonePrefix,
                Continent = request.Continent,
                Pollution = request.Pollution,
                Traffic = request.Traffic,
                LivingCost = request.LivingCost,
                Criminality = request.Criminality,
                AverageTemperature = request.AverageTemperature
            };

            _unitOfWork.AreaRepository.Update(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
