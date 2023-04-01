using AutoMapper;
using EstateWebManager.API.Dto;
using EstateWebManager.Application;
using EstateWebManager.Application.Commands;
using EstateWebManager.Application.Queries;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EstateWebManager.API.Controllers
{
    [Route("api/lands")]
    [ApiController]
    public class LandsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        private readonly MyLocationSettings _settings;

        public LandsController(IMapper mapper, IMediator mediator,
            IOptions<MyLocationSettings> options)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> InsertLand([FromBody] LandPutPostDto land)
        {
            var command = new InsertLand
            {
                Type = land.Type,
                Title = land.Title,
                Description = land.Description,
                ContactName = land.ContactName,
                ContactPhone = land.ContactPhone,
                ContactMail = land.ContactMail,
                Latitude = land.Latitude,
                Longitude = land.Longitude,
                Street = land.Street,
                Number = land.Number,
                ZipCode = land.ZipCode,
                Building = land.Building,
                FloorNumber = land.FloorNumber,
                DoorNumber = land.DoorNumber,
                AreaId = land.AreaId,
                LastUpdate = land.LastUpdate,
                TransactionType = land.TransactionType,
                Price = land.Price,
                Currency = land.Currency,
                PeriodOfTime = land.PeriodOfTime,
                LandArea = land.LandArea,
                Topography = land.Topography,
                Fence = land.Fence,
                CurrentStatus = land.CurrentStatus,
                Electricity = land.Electricity,
                Water = land.Water,
                Sewerage = land.Sewerage,
                Heating = land.Heating,                
                AvailableStarting = land.AvailableStarting
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<LandGetDto>(result);

            return CreatedAtAction(nameof(GetLandById), new { id = mappedResult.Id }, mappedResult);
        }

        [HttpGet]
        [Route("city/{city}")]
        public async Task<IActionResult> GetAllLands(string city)
        {
            var query = new GetAllLands { City = city };
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<List<LandGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLandById(int id)
        {
            var query = new GetLandById { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<LandGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> GetLandsByAddress([FromQuery] string? street,
                                                           [FromQuery] string? city,
                                                           [FromQuery] string country)
        {
            var query = new GetLandsByAddress { Street = street, City = city, Country = country };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<LandGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("land-area")]
        public async Task<IActionResult> GetLandsByLandArea([FromQuery] string city,
                                                            [FromQuery] int minLandArea,
                                                            [FromQuery] int maxLandArea)
        {
            var query = new GetLandsByLandArea
                            {
                                City = city,
                                MinLandArea = minLandArea,
                                MaxLandArea = maxLandArea
                            };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<LandGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("price-range")]
        public async Task<IActionResult> GetLandsByPriceRange([FromQuery] string city,
                                                              [FromQuery] int min,
                                                              [FromQuery] int max,
                                                              [FromQuery] string currency)
        {
            var query = new GetLandsByPriceRange
                            {
                                City = city,
                                Min = min,
                                Max = max,
                                Currency = currency
                            };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<LandGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("options")]
        public async Task<IActionResult> GetLandsWithOptions([FromQuery] string city,
                                                             [FromQuery] int minLandArea,
                                                             [FromQuery] int maxLandArea,
                                                             [FromQuery] bool electricity,
                                                             [FromQuery] bool water,
                                                             [FromQuery] bool sewerage,
                                                             [FromQuery] bool heating)
        {
            var query = new GetLandsWithOptions
                            {
                                City = city,
                                MinLandArea = minLandArea,
                                MaxLandArea = maxLandArea,
                                Electricity = electricity,
                                Water = water,
                                Sewerage = sewerage,
                                Heating = heating
                            };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<LandGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLand(int id, [FromBody] LandPutPostDto updated)
        {
            var command = new UpdateLand
            {
                Id = id,
                Type = updated.Type,
                Title = updated.Title,
                Description = updated.Description,
                ContactName = updated.ContactName,
                ContactPhone = updated.ContactPhone,
                ContactMail = updated.ContactMail,
                Latitude = updated.Latitude,
                Longitude = updated.Longitude,
                Street = updated.Street,
                Number = updated.Number,
                ZipCode = updated.ZipCode,
                Building = updated.Building,
                FloorNumber = updated.FloorNumber,
                DoorNumber = updated.DoorNumber,
                AreaId = updated.AreaId,
                LastUpdate = updated.LastUpdate,
                TransactionType = updated.TransactionType,
                Price = updated.Price,
                Currency = updated.Currency,
                PeriodOfTime = updated.PeriodOfTime,
                LandArea = updated.LandArea,
                Topography = updated.Topography,
                Fence = updated.Fence,
                CurrentStatus = updated.CurrentStatus,
                Electricity = updated.Electricity,
                Water = updated.Water,
                Sewerage = updated.Sewerage,
                Heating = updated.Heating,
                AvailableStarting = updated.AvailableStarting
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLand(int id)
        {
            var command = new DeleteLand { Id = id };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
