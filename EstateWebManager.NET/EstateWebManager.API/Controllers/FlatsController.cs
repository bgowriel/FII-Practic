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
    [Route("api/flats")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        private readonly MyLocationSettings _settings;

        public FlatsController(IMapper mapper, IMediator mediator,
            IOptions<MyLocationSettings> options)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> InsertFlat([FromBody] FlatPutPostDto flat)
        {
            var command = new InsertFlat
            {
                Type = flat.Type,
                Title = flat.Title,
                Description = flat.Description,
                ContactName = flat.ContactName,
                ContactPhone = flat.ContactPhone,
                ContactMail = flat.ContactMail,
                Latitude = flat.Latitude,
                Longitude = flat.Longitude,
                Street = flat.Street,
                Number = flat.Number,
                ZipCode = flat.ZipCode,
                Building = flat.Building,
                FloorNumber = flat.FloorNumber,
                DoorNumber = flat.DoorNumber,
                AreaId = flat.AreaId,
                LastUpdate = flat.LastUpdate,
                TransactionType = flat.TransactionType,
                Price = flat.Price,
                Currency = flat.Currency,
                PeriodOfTime = flat.PeriodOfTime,
                BuiltUpArea = flat.BuiltUpArea,
                Bedrooms = flat.Bedrooms,
                Bathrooms = flat.Bathrooms,
                Heating = flat.Heating,
                AC = flat.AC,
                Internet = flat.Internet,
                ParkingPlace = flat.ParkingPlace,
                AvailableStarting = flat.AvailableStarting
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<FlatGetDto>(result);

            return CreatedAtAction(nameof(GetFlatById), new { id = mappedResult.Id }, mappedResult);
        }

        [HttpGet]
        [Route("city/{city}")]
        public async Task<IActionResult> GetAllFlats(string city)
        {
            var query = new GetAllFlats { City = city };
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<List<FlatGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFlatById(int id)
        {
            var query = new GetFlatById { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<FlatGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> GetFlatsByAddress([FromQuery] string? street,
                                                           [FromQuery] string? city,
                                                           [FromQuery] string country)
        {
            var query = new GetFlatsByAddress { Street = street, City = city, Country = country };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<FlatGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("built-up-area")]
        public async Task<IActionResult> GetFlatsByMinBuiltUpArea([FromQuery] string city,
                                                                  [FromQuery] int minBuiltUpArea)
        {
            var query = new GetFlatsByMinBuiltUpArea { City = city, MinBuiltUpArea = minBuiltUpArea };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<FlatGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("price-range")]
        public async Task<IActionResult> GetFlatsByPriceRange([FromQuery] string city,
                                                              [FromQuery] int min,
                                                              [FromQuery] int max,
                                                              [FromQuery] string currency)
        {
            var query = new GetFlatsByPriceRange { City = city, Min = min, Max = max, Currency = currency };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<FlatGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("transaction")]
        public async Task<IActionResult> GetFlatsByTransactionType([FromQuery] string city, [FromQuery] string type)
        {
            var query = new GetFlatsByTransactionType { City = city, TransactionType = type };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<FlatGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("options")]
        public async Task<IActionResult> GetFlatsWithOptions([FromQuery] string city,
                                                             [FromQuery] string transactionType,
                                                             [FromQuery] int bedrooms,
                                                             [FromQuery] int bathrooms,
                                                             [FromQuery] bool ac,
                                                             [FromQuery] bool internet,
                                                             [FromQuery] bool parkingPlace)
        {
            var query = new GetFlatsWithOptions
                            {
                                City = city,
                                TransactionType = transactionType,
                                Bedrooms = bedrooms,
                                Bathrooms = bathrooms,
                                AC = ac,
                                Internet = internet,
                                ParkingPlace = parkingPlace
                            };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<FlatGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFlat(int id, [FromBody] FlatPutPostDto updated)
        {
            var command = new UpdateFlat
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
                BuiltUpArea = updated.BuiltUpArea,
                Bedrooms = updated.Bedrooms,
                Bathrooms = updated.Bathrooms,
                Heating = updated.Heating,
                AC = updated.AC,
                Internet = updated.Internet,
                ParkingPlace = updated.ParkingPlace,
                AvailableStarting = updated.AvailableStarting
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFlat(int id)
        {
            var command = new DeleteFlat { Id = id };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
