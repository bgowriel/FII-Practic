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
    [Route("api/houses")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        private readonly MyLocationSettings _settings;

        public HousesController(IMapper mapper, IMediator mediator,
            IOptions<MyLocationSettings> options)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> InsertHouse([FromBody] HousePutPostDto house)
        {
            var command = new InsertHouse
            {
                Type = house.Type,
                Title = house.Title,
                Description = house.Description,
                ContactName = house.ContactName,
                ContactPhone = house.ContactPhone,
                ContactMail = house.ContactMail,
                Latitude = house.Latitude,
                Longitude = house.Longitude,
                Street = house.Street,
                Number = house.Number,
                ZipCode = house.ZipCode,
                Building = house.Building,
                FloorNumber = house.FloorNumber,
                DoorNumber = house.DoorNumber,
                AreaId = house.AreaId,
                LastUpdate = house.LastUpdate,
                TransactionType = house.TransactionType,
                Price = house.Price,
                Currency = house.Currency,
                PeriodOfTime = house.PeriodOfTime,
                YearBuilt = house.YearBuilt,
                BuiltUpArea = house.BuiltUpArea,
                LandArea = house.LandArea,
                Floors = house.Floors,
                Bedrooms = house.Bedrooms,
                Bathrooms = house.Bathrooms,
                Heating = house.Heating,
                AC = house.AC,
                Internet = house.Internet,
                Garage = house.Garage,
                SwimmingPool = house.SwimmingPool,
                AvailableStarting = house.AvailableStarting
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<HouseGetDto>(result);

            return CreatedAtAction(nameof(GetHouseById), new { id = mappedResult.Id }, mappedResult);
        }

        [HttpGet]
        [Route("city/{city}")]
        public async Task<IActionResult> GetAllHouses(string city)
        {
            var query = new GetAllHouses { City = city };
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<List<HouseGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHouseById(int id)
        {
            var query = new GetHouseById { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<HouseGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> GetHousesByAddress([FromQuery] string? street,
                                                            [FromQuery] string? city,
                                                            [FromQuery] string country)
        {
            var query = new GetHousesByAddress { Street = street, City = city, Country = country };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<HouseGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("built-up-area")]
        public async Task<IActionResult> GetHousesByMinAreas([FromQuery] string city,
                                                             [FromQuery] int minBuiltUpArea,
                                                             [FromQuery] int minLandArea)
        {
            var query = new GetHousesByMinAreas { City = city, MinBuiltUpArea = minBuiltUpArea, MinLandArea = minLandArea };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<HouseGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("year-built")]
        public async Task<IActionResult> GetHousesByMinYearBuilt([FromQuery] string city,
                                                                 [FromQuery] int minYearBuilt)
        {
            var query = new GetHousesByMinYearBuilt { City = city, MinYearBuilt = minYearBuilt };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<HouseGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("price-range")]
        public async Task<IActionResult> GetHousesByPriceRange([FromQuery] string city,
                                                               [FromQuery] int min,
                                                               [FromQuery] int max,
                                                               [FromQuery] string currency)
        {
            var query = new GetHousesByPriceRange
                            {
                                City = city,
                                Min = min,
                                Max = max,
                                Currency = currency
                            };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<HouseGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("transaction")]
        public async Task<IActionResult> GetHousesByTransactionType([FromQuery] string city,
                                                                    [FromQuery] string type)
        {
            var query = new GetHousesByTransactionType { City = city, TransactionType = type };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<HouseGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("options")]
        public async Task<IActionResult> GetHousesWithOptions([FromQuery] string city,
                                                              [FromQuery] string transactionType,
                                                              [FromQuery] int minYearBuilt,
                                                              [FromQuery] int minBuiltUpArea,
                                                              [FromQuery] int minLandArea,
                                                              [FromQuery] int bedrooms,
                                                              [FromQuery] int bathrooms,
                                                              [FromQuery] bool ac,
                                                              [FromQuery] bool internet,
                                                              [FromQuery] bool garage,
                                                              [FromQuery] bool swimmingPool)
        {
            var query = new GetHousesWithOptions
                            {
                                City = city,
                                TransactionType = transactionType,
                                MinYearBuilt = minYearBuilt,
                                MinBuiltUpArea = minBuiltUpArea,
                                MinLandArea = minLandArea,
                                Bedrooms = bedrooms,
                                Bathrooms = bathrooms,
                                AC = ac,
                                Internet = internet,
                                Garage = garage,
                                SwimmingPool = swimmingPool
                            };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<HouseGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateHouse(int id, [FromBody] HousePutPostDto updated)
        {
            var command = new UpdateHouse
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
                YearBuilt = updated.YearBuilt,
                BuiltUpArea = updated.BuiltUpArea,
                LandArea = updated.LandArea,
                Floors = updated.Floors,
                Bedrooms = updated.Bedrooms,
                Bathrooms = updated.Bathrooms,
                Heating = updated.Heating,
                AC = updated.AC,
                Internet = updated.Internet,
                Garage = updated.Garage,
                SwimmingPool = updated.SwimmingPool,
                AvailableStarting = updated.AvailableStarting
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            var command = new DeleteHouse { Id = id };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
