using Microsoft.AspNetCore.Mvc.Testing;
using EstateWebManager.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json;
using EstateWebManager.API.Dto;
using EstateWebManager.Application.Commands;
using System.Text;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.IntegrationTests
{
    [TestClass]
    public class OfficeControllerTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<EstateWebManagerPresentation> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<EstateWebManagerPresentation>();
        }

        [TestMethod]
        public async Task GetAllOfficesInAreaShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/offices/address?country=Romania");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task InsertOfficeShouldReturnCreatedResponse()
        {
            var officeInsertCommand = new InsertOffice
            {
                Type = Domain.Enums.EstateTypes.Office,
                Title = "Offer",
                Description = "Lorem ipsum",
                ContactName = "Bogdan F.",
                ContactPhone = "+4 0770 455 676",
                ContactMail = "selling@gmail.com",
                Latitude = 45.43254325,
                Longitude = 28.54325432,
                Street = "Sperantei",
                Number = "103C",
                ZipCode = "5504780",
                Building = "Prime Office",
                FloorNumber = 3,
                DoorNumber = 14,
                AreaId = 5,
                LastUpdate = DateTime.Now,
                TransactionType = "Rent",
                Price = 400,
                Currency = "$",
                PeriodOfTime = "month",
                Rating = "A",
                BuiltUpArea = 50,
                AC = "yes",
                Internet = "yes",
                ParkingPlace = "yes",
                AvailableStarting = DateTime.Now
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/offices", new StringContent(JsonConvert.SerializeObject(officeInsertCommand), Encoding.UTF8, "application/json"));
            
            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task GetOfficeByIdShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/offices/733");

            var result = await response.Content.ReadAsStringAsync();
            var office = JsonConvert.DeserializeObject<OfficeGetDto>(result);

            OfficeAsserts(office);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task UpdateOfficeShouldReturnUpdatedOffice()
        {
            var officeCommand = new UpdateOffice
            {
                Id = 1001,
                Type = Domain.Enums.EstateTypes.Office,
                Title = "For rent!",
                Description = "Lorem ipsum",
                ContactName = "Camelia F.",
                ContactPhone = "+4 0770 455 676",
                ContactMail = "selling@gmail.com",
                Latitude = 45.43254325,
                Longitude = 28.54325432,
                Street = "Sperantei",
                Number = "103C",
                ZipCode = "5504780",
                Building = "Prime Office",
                FloorNumber = 3,
                DoorNumber = 14,
                AreaId = 5,
                LastUpdate = DateTime.Now,
                TransactionType = "Rent",
                Price = 400,
                Currency = "$",
                PeriodOfTime = "month",
                Rating = "A",
                BuiltUpArea = 50,
                AC = "yes",
                Internet = "yes",
                ParkingPlace = "yes",
                AvailableStarting = DateTime.Now
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/offices/1001", new StringContent(JsonConvert.SerializeObject(officeCommand), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var office = JsonConvert.DeserializeObject<OfficeGetDto>(result);
            
            Assert.AreEqual(office.Id, officeCommand.Id);
            Assert.AreEqual(office.Title, officeCommand.Title);
            Assert.AreEqual(office.Description, officeCommand.Description);
            Assert.AreEqual(office.ContactName, officeCommand.ContactName);
            Assert.AreEqual(office.Price, officeCommand.Price);
        }

        private static void OfficeAsserts(OfficeGetDto office)
        {
            Assert.IsNotNull(office);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}