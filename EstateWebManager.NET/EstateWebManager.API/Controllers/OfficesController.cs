using AutoMapper;
using EstateWebManager.API.Dto;
using EstateWebManager.API.Services;
using EstateWebManager.API.Wrappers;
using EstateWebManager.Application;
using EstateWebManager.Application.Commands;
using EstateWebManager.Application.Queries;
using EstateWebManager.Domain.Models.RealEstateClasses;
using Faker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.IO;

namespace EstateWebManager.API.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;
        public readonly IUriService _uriService;

        private readonly MyLocationSettings _settings;

        public OfficesController(IMapper mapper, IMediator mediator,
            IOptions<MyLocationSettings> options, IUriService uriService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertOffice([FromBody] OfficePutPostDto office)
        {
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest();
            }
            
            Debug.WriteLine(office.ToString());
            
            var command = new InsertOffice
            {
                UserId = office.UserId,
                Type = office.Type,
                Title = office.Title,
                Description = office.Description,
                ContactName = office.ContactName,
                ContactPhone = office.ContactPhone,
                ContactMail = office.ContactMail,
                Latitude = office.Latitude,
                Longitude = office.Longitude,
                Street = office.Street,
                Number = office.Number,
                ZipCode = office.ZipCode,
                Building = office.Building,
                FloorNumber = office.FloorNumber,
                DoorNumber = office.DoorNumber,
                AreaId = office.AreaId,
                LastUpdate = office.LastUpdate,
                TransactionType = office.TransactionType,
                Price = office.Price,
                Currency = office.Currency,
                PeriodOfTime = office.PeriodOfTime,
                Rating = office.Rating,
                BuiltUpArea = office.BuiltUpArea,
                AC = office.AC,
                Internet = office.Internet,
                ParkingPlace = office.ParkingPlace,
                AvailableStarting = office.AvailableStarting,
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<OfficeGetDto>(result);

            return CreatedAtAction(nameof(GetOfficeById), new { id = mappedResult.Id }, mappedResult);
        }

        [HttpGet]
        [Route("city/{city}")]
        public async Task<IActionResult> GetAllOffices(string city)
        {
            var query = new GetAllOffices { City = city };
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<List<OfficeGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOfficeById(int id)
        {
            var query = new GetOfficeById { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<OfficeGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetOfficesByUserId(string userId, [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var queryString = Request.QueryString.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var query = new GetOfficesByUserId { UserId = userId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var totalRecords = result.Count;

            var pagedResult = result.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                    .Take(validFilter.PageSize).ToList();
            var mappedResult = _mapper.Map<List<OfficeGetDto>>(pagedResult);
            var pagedResponse = PaginationHelper.CreatePagedResponse(mappedResult, validFilter, totalRecords, _uriService, route, queryString);
            pagedResponse.StatusCode = 200;

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> GetOfficesByAddress([FromQuery] string? street,
                                                             [FromQuery] string? city,
                                                             [FromQuery] string country,
                                                             [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var queryString = Request.QueryString.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);


            var query = new GetOfficesByAddress { Street = street, City = city, Country = country };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var totalRecords = result.Count;

            var pagedResult = result.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                    .Take(validFilter.PageSize).ToList();
            var mappedResult = _mapper.Map<List<OfficeGetDto>>(pagedResult);
            var pagedResponse = PaginationHelper.CreatePagedResponse(mappedResult, validFilter, totalRecords, _uriService, route, queryString);
            pagedResponse.StatusCode = 200;

            return Ok(pagedResponse);
        }
        
        [HttpGet]
        [Route("built-up-area")]
        public async Task<IActionResult> GetOfficesByMinBuiltUpArea([FromQuery] string city,
                                                                    [FromQuery] int minBuiltUpArea)
        {
            var query = new GetOfficesByMinBuiltUpArea { City = city, MinBuiltUpArea = minBuiltUpArea };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<OfficeGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("price-range")]
        public async Task<IActionResult> GetOfficesByPriceRange([FromQuery] string city,
                                                                [FromQuery] int min,
                                                                [FromQuery] int max,
                                                                [FromQuery] string currency,
                                                                [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var queryString = Request.QueryString.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            
            var query = new GetOfficesByPriceRange { City = city, Min = min, Max = max, Currency = currency };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var totalRecords = result.Count;

            var pagedResult = result.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                    .Take(validFilter.PageSize).ToList();
            var mappedResult = _mapper.Map<List<OfficeGetDto>>(pagedResult);
            var pagedResponse = PaginationHelper.CreatePagedResponse(mappedResult, validFilter, totalRecords, _uriService, route, queryString);
            pagedResponse.StatusCode = 200;

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("rating")]
        public async Task<IActionResult> GetOfficesByRating([FromQuery] string city, [FromQuery] string rating)
        {
            var query = new GetOfficesByRating { City = city, Rating = rating };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<OfficeGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("options")]
        public async Task<IActionResult> GetOfficesWithOptions([FromQuery] string city,
                                                               [FromQuery] string rating,
                                                               [FromQuery] int minBuiltUpArea,
                                                               [FromQuery] bool ac,
                                                               [FromQuery] bool internet,
                                                               [FromQuery] bool parkingPlace,
                                                               [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var queryString = Request.QueryString.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            
            var query = new GetOfficesWithOptions
                            {
                                City = city,
                                Rating = rating,
                                MinBuiltUpArea= minBuiltUpArea,
                                AC = ac,
                                Internet = internet,
                                ParkingPlace = parkingPlace
                            };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var totalRecords = result.Count;

            var pagedResult = result.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                    .Take(validFilter.PageSize).ToList();
            var mappedResult = _mapper.Map<List<OfficeGetDto>>(pagedResult);
            var pagedResponse = PaginationHelper.CreatePagedResponse(mappedResult, validFilter, totalRecords, _uriService, route, queryString);
            pagedResponse.StatusCode = 200;

            return Ok(pagedResponse);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOffice(int id, [FromBody] OfficePutPostDto updated)
        {
            var command = new UpdateOffice
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
                Rating = updated.Rating,
                BuiltUpArea = updated.BuiltUpArea,
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
        public async Task<IActionResult> DeleteOffice(int id)
        {
            var command = new DeleteOffice { Id = id };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
