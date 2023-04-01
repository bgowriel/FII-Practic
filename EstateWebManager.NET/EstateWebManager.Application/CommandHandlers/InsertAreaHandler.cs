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
    public class InsertAreaHandler : IRequestHandler<InsertArea, Area>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertAreaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Area> Handle(InsertArea request, CancellationToken cancellationToken)
        {
            var area = new Area
            {
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

            await _unitOfWork.AreaRepository.Insert(area);
            await _unitOfWork.Save();

            return area;
        }
    }
}
