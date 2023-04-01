using AutoMapper;
using EstateWebManager.API.Dto;
using EstateWebManager.API.Services;
using EstateWebManager.Application;
using EstateWebManager.Application.Commands;
using EstateWebManager.Application.Queries;
using EstateWebManager.Domain.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EstateWebManager.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/areas")]
    public class AreasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;
        private readonly ILogger<AreasController> _logger;

        private readonly MyLocationSettings _settings;

        public AreasController(IMediator mediator,
                               IMapper mapper,
                               IOptions<MyLocationSettings> options,
                               ISingletonService singletonService,
                               IScopedService scopedService,
                               ITransientService transientService,
                               ILogger<AreasController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _settings = options.Value;
            _logger = logger;
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;

            _logger.LogInformation("[{traceId}][{timeStamp}][Location Service]\n\tServer location is in {City}, {Country}", Guid.NewGuid(), DateTime.Now, _settings.HomeCity, _settings.HomeCountry);
        }

        [HttpPost]
        public async Task<IActionResult> InsertArea([FromBody] AreaPutPostDto area)
        {
            var command = _mapper.Map<InsertArea>(area);

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<AreaGetDto>(created);

            return CreatedAtAction(nameof(GetAreaById), new { areaId = created.Id }, dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAreas()
        {
            var query = new GetAllAreas();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<AreaGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{areaId}")]
        public async Task<IActionResult> GetAreaById(int areaId)
        {
            var query = new GetAreaById { Id = areaId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<AreaGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("neighborhood")]
        public async Task<IActionResult> GetAreaByNeighborhood([FromQuery] string city,
                                                               [FromQuery] string neighborhood)
        {
            var query = new GetAreaByNeighborhood { City = city, Neighborhood = neighborhood };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<AreaGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("city/{city}")]
        public async Task<IActionResult> GetAreasByCity(string city)
        {
            var query = new GetAreasByCity { City = city };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<AreaGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("country/{country}")]
        public async Task<IActionResult> GetAreasByCountry(string country)
        {
            var query = new GetAreasByCountry { Country = country };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<AreaGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{areaId}")]
        public async Task<IActionResult> UpdateArea(int areaId, [FromBody] AreaPutPostDto updated)
        {
            var command = new UpdateArea
            {
                Id = areaId,
                Neighborhood = updated.Neighborhood,
                ShortName = updated.ShortName,
                City = updated.City,
                County = updated.County,
                Country = updated.Country,
                PhonePrefix = updated.PhonePrefix,
                Continent = updated.Continent,
                Pollution = updated.Pollution,
                Traffic = updated.Traffic,
                LivingCost = updated.LivingCost,
                Criminality = updated.Criminality,
                AverageTemperature = updated.AverageTemperature,
            };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("{areaId}")]
        public async Task<IActionResult> DeleteArea(int areaId)
        {
            var command = new DeleteArea { Id = areaId };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
