using AutoMapper;
using AutoMapper.Execution;
using EstateWebManager.API.Controllers;
using EstateWebManager.API.Dto;
using EstateWebManager.Application;
using EstateWebManager.Application.Commands;
using EstateWebManager.Application.Queries;
using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.RealEstateClasses;
using Faker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using Assert = NUnit.Framework.Assert;

namespace EstateWebManager.Tests.Unit
{
    [TestClass]
    public class FlatControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private Mock<IMapper> _mockMapper;
        private readonly Mock<IOptions<MyLocationSettings>> _mockOptions = new Mock<IOptions<MyLocationSettings>>();
        private FlatGetDto _flatExample;

        [SetUp]
        public void Setup()
        {
            _flatExample = new FlatGetDto()
            {
                Id = 234,
                Type = Domain.Enums.EstateTypes.Flat,
                Title = "Great offer!",
                Description = "Lorem ipsum.",
                ContactName = "Bogdan F.",
                ContactPhone = "+40 770 345 677",
                ContactMail = "selling@gmail.com",
                Latitude = 45.4431243,
                Longitude = 27.5425425,
                Street = "Aleea T. Neculai",
                Number = "12A",
                ZipCode = "700737",
                Building = "130B",
                FloorNumber = 1,
                DoorNumber = 8,
                AreaId = 2,
                LastUpdate = new DateTime(2022, 9, 8, 0, 5, 0),
                TransactionType = "Sale",
                Price = 65_000,
                Currency = "$",
                PeriodOfTime = null,
                BuiltUpArea = 55,
                Bedrooms = 2,
                Bathrooms = 1,
                Heating = "individual gas heating",
                AC = "yes",
                Internet = "yes",
                ParkingPlace = "yes",
                AvailableStarting = new DateTime(2022, 9, 8, 0, 5, 0)
            };
            _mockMapper = MappingData();
        }

        private Mock<IMapper> MappingData()
        {
            var mappingService = new Mock<IMapper>();

            mappingService.Setup(m => m.Map<FlatGetDto>(It.IsAny<Flat>())).Returns(_flatExample);

            return mappingService;
        }

        [TestCase("Iasi")]
        public async Task GetAllFlatsQuerryIsCalled(string city)
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllFlats>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new FlatsController(_mockMapper.Object, _mockMediator.Object, _mockOptions.Object);
            var result = await controller.GetAllFlats(city);

            //Assert
            _mockMediator.Verify(mediator => mediator.Send(It.IsAny<GetAllFlats>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestCase("Brasov", 50_000, 80_000, "€")]
        public async Task GetFlatsByPriceRangeQuerryIsCalled(string city,
                                                             int min,
                                                             int max,
                                                             string currency)
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetFlatsByPriceRange>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new FlatsController(_mockMapper.Object, _mockMediator.Object, _mockOptions.Object);
            var result = await controller.GetFlatsByPriceRange(city, min, max, currency);

            //Assert
            _mockMediator.Verify(mediator => mediator.Send(It.IsAny<GetFlatsByPriceRange>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Test]
        public async Task GetFlatByIdShouldReturnFlat()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetFlatById>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Flat
                        {
                            Id = 234,
                            Type = Domain.Enums.EstateTypes.Flat,
                            Title = "Great offer!",
                            Description = "Lorem ipsum.",
                            ContactName = "Bogdan F.",
                            ContactPhone = "+40 770 345 677",
                            ContactMail = "selling@gmail.com",
                            Latitude = 45.4431243,
                            Longitude = 27.5425425,
                            Street = "Aleea T. Neculai",
                            Number = "12A",
                            ZipCode = "700737",
                            Building = "130B",
                            FloorNumber = 1,
                            DoorNumber = 8,
                            AreaId = 2,
                            LastUpdate = new DateTime(2022, 9, 8, 0, 5, 0),
                            TransactionType = "Sale",
                            Price = 65_000,
                            Currency = "$",
                            PeriodOfTime = null,
                            BuiltUpArea = 55,
                            Bedrooms = 2,
                            Bathrooms = 1,
                            Heating = "individual gas heating",
                            AC = "yes",
                            Internet = "yes",
                            ParkingPlace = "yes",
                            AvailableStarting = new DateTime(2022, 9, 8, 0, 5, 0)
                });

            var controller = new FlatsController(_mockMapper.Object, _mockMediator.Object, _mockOptions.Object);

            var result = await controller.GetFlatById(234);

            var okResult = result as OkObjectResult;

            Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            Assert.That("Bogdan F.", Is.EqualTo(((FlatGetDto)okResult.Value).ContactName));
            Assert.That(65_000, Is.EqualTo(((FlatGetDto)okResult.Value).Price));
        }
    }
}