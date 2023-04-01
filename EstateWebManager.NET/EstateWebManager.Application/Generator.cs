using EstateWebManager.Domain.Enums;
using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.AppointmentClasses;
using EstateWebManager.Domain.Models.RealEstateClasses;
using EstateWebManager.Domain.Validation;
using EstateWebManager.Domain.Validation.RealEstateValidation;
using Faker;
using FluentValidation;
using System;
using System.Drawing;
using System.Text;

namespace EstateWebManager.Application
{
    public class Generator
    {
        private static readonly string[] Currency = { "£", "$", "\u20AC" };

        private struct CountryData
        {
            public string CountryName;
            public string Continent;
            public string PhonePrefix;
            public CountryData(string countryName, string continent, string phonePrefix)
            {
                CountryName = countryName;
                Continent = continent;
                PhonePrefix = phonePrefix;
            }
        }

        private static readonly CountryData[] CountryInfo =
        {
            new CountryData("Argentina", "South America", "+54"),
            new CountryData("Australia", "Australia and Oceania", "+61"),
            new CountryData("Austria", "Europe", "+43"),
            new CountryData("Cameron", "Africa", "+237"),
            new CountryData("Canada", "North America", "+1"),
            new CountryData("France", "Europe", "+33"),
            new CountryData("India", "Asia", "+91"),
            new CountryData("Scotland", "Europe", "+44"),
            new CountryData("United States of America", "North America", "+1"),
            new CountryData("People's Republic of China", "Asia", "+86"),
            new CountryData("Brazil", "South America", "+55"),
            new CountryData("Egypt", "Africa", "+20"),
            new CountryData("New Zealand", "Australia and Oceania", "+64")
        };

        private static readonly string[] RomanianCities =
        {
            "Bucharest",
            "Timisoara",
            "Cluj-Napoca",
            "Brasov",
            "Iasi",
            "Constanta"
        };

        private static readonly string[] RomanianNeighborhoods = { "Copou", "Agronomie", "Bucsinescu", "Dancu", "Tudor Vladimirescu", "Dimitrie Cantemir", "Alexandru cel Bun", "Moara de Foc", "Aviatiei", "Antene", "Baba Dochia", "Blascovici", "Calea Sagului", "Cetate", "Dorobantilor", "Freidorf", "Gara Nord", "Lipovei", "Odobescu", "Soarelui", "Torontalului", "Tipografilor", "Kogalniceanu" };

        private static readonly string[] RomanianStreets = { "Abatorului", "Academiei", "Aerogarii", "Aeroportului", "Agigea", "Piata Unirii", "Vasile Alecsandri", "Almas", "Alunului", "Baba Novac", "Baltagului", "Barajului", "Barsanei", "Jean Louis Calderon", "Caminului", "Candesti", "Miron Cristea", "Crisul Alb", "Crizantemelor", "Cronicarilor", "Decebal", "Delfinului", "Dobreni", "Dorului", "Eforie", "Elena Doamna", "Eroilor", "Eternitatii", "Expozitiei", "Fabricii", "Ferentari", "Frumoasa", "Garoafei", "Giulesti", "Hanului", "Calistrat Hogas", "Iancului", "Inovatiei", "Nicolae Iorga", "Izvorul Crisului", "Jaristea", "Mihail Kogalniceanu ", "Leon Voda", "Lespezi", "Macului", "Mamaia", "Natiunile Unite", "Negru Voda", "Oastei", "Oltului", "Oteleni", "Padurii", "Privighetorii", "Emil Racovita", "Salciei", "Teius", "Titan", "Universitatii", "Vacaresti", "Vicina", "Zidarului" };

        private static readonly string[] Levels = { "low", "average", "high" };
        /*private static readonly string[] BuildingStates =
        {
            "needs repairing",
            "acceptable",
            "good",
            "premium",
            "luxurious",
            "brand new"
        };*/

        private static readonly string[] HeatingTypes =
        {
            "individual gas heating system",
            "centralised heating system",
            "electric",
            "electric and fireplace",
            "gas heating system and fireplace",
            "not specified"
        };

        private static readonly string[] Titles =
        {
            "Great offer!",
            "New opportunity",
            "Exclusive",
            "Best investment",
            "Your next home",
            "Your dream home",
            "Best buy",
            "Urgent offer",
            "Opportunity",
            "Nice and affordable"
        };

        private static readonly string[] FenceTypes =
        {
            "none",
            "wired",
            "wood",
            "concrete",
            "brick",
            "iron"
        };

        private static readonly string[] LandStatusTypes =
        {
            "pasture",
            "forest",
            "fallow land",
            "meadow",
            "ruins",
            "garden"
        };

        private static readonly string[] LandTopographyTypes =
        {
            "valley",
            "spur",
            "mesa",
            "cliff",
            "plateau",
            "concave",
            "convex",
            "ridge"
        };

        private static readonly Random Random = new Random();

        public static List<Area> GenerateAreas(int numberOfAreas)
        {
            var result = new List<Area>(numberOfAreas);
            var areaValidator = new AreaValidator();
            string neighborhood;
            string city;
            string county;
            CountryData country;

            while (numberOfAreas > 0)
            {
                numberOfAreas--;

                if (Random.Next(2) == 0)
                {
                    neighborhood = RomanianNeighborhoods[Random.Next(RomanianNeighborhoods.Length)];
                    city = RomanianCities[Random.Next(RomanianCities.Length)];
                    county = city;
                    country = new CountryData("Romania", "Europe", "+40");
                }
                else
                {
                    neighborhood = Address.StreetName();
                    city = Address.City();
                    county = Address.UkCounty();
                    country = CountryInfo[Random.Next(CountryInfo.Length)];
                }

                try
                {
                    var area = new Area(neighborhood,
                                        city,
                                        city[..2].ToUpper(),
                                        county,
                                        country.CountryName,
                                        country.PhonePrefix,
                                        country.Continent,
                                        Levels[Random.Next(3)],
                                        Levels[Random.Next(3)],
                                        Levels[Random.Next(3)],
                                        Levels[Random.Next(3)],
                                        Math.Round(Random.NextDouble() * 10 + 10, 2));
                    areaValidator.ValidateAndThrow(area);
                    result.Add(area);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }

        public static List<Flat> GenerateFlats(int numberOfEstates, Area area)
        {
            if (numberOfEstates is <= 0 or > 100)
            {
                throw new Exception("Number of estates to be generated must be greater than 0 and lesser than 101");
            }

            var result = new List<Flat>(numberOfEstates);
            var flatValidator = new FlatValidator();

            while (numberOfEstates > 0)
            {
                numberOfEstates--;

                string street;
                if (area.Country == "Romania")
                {
                    street = RomanianStreets[Random.Next(RomanianStreets.Length)];
                }
                else
                {
                    street = Faker.Address.StreetName();
                }

                int numberOfBedrooms = Random.Next(5) + 1;
                int numberOfBathrooms = Random.Next(2) + 1;
                string transaction = new string[] { "Sale", "Rent" }[Random.Next(2)];
                int price = (transaction == "Sale" ? numberOfBedrooms * 27_000 + Random.Next(11) * 1000
                    : numberOfBedrooms * 200 + Random.Next(11) * 30);
                string? periodOfTime = (transaction == "Rent") ? "month" : null;
                int floor = Random.Next(0, 13);
                int door = floor * 5 + Random.Next(5);

                try
                {
                    var flat = new Flat
                    {
                        Type = EstateTypes.Flat,
                        Title = Titles[Random.Next(Titles.Length)],
                        Description = GenerateDescription(),
                        ContactName = GenerateName(),
                        ContactPhone = Phone.Number(),
                        ContactMail = Internet.Email(),
                        Latitude = GenerateLatitude(),
                        Longitude = GenerateLongitude(),
                        Street = street,
                        Number = Random.Next(1, 150).ToString(),
                        ZipCode = Faker.Address.ZipCode(),
                        Building = GenerateBuildingNumber(),
                        FloorNumber = floor,
                        DoorNumber = door,
                        Area = area,
                        LastUpdate = DateTime.Now,
                        TransactionType = transaction,
                        Price = price,
                        Currency = Currency[Random.Next(3)],
                        PeriodOfTime = periodOfTime,
                        BuiltUpArea = 20 * numberOfBedrooms + 10,
                        Bedrooms = numberOfBedrooms,
                        Bathrooms = numberOfBathrooms,
                        Heating = HeatingTypes[Random.Next(HeatingTypes.Length)],
                        AC = GenerateYesOrNo(),
                        Internet = GenerateYesOrNo(),
                        ParkingPlace = GenerateYesOrNo(),
                        AvailableStarting = DateTime.Now
                    };
                    flatValidator.ValidateAndThrow(flat);
                    result.Add(flat);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }

        public static List<Office> GenerateOffices(int numberOfEstates, Area area)
        {
            if (numberOfEstates is <= 0 or > 100)
            {
                throw new Exception("Number of estates to be generated must be greater than 0 and lesser than 101");
            }

            var result = new List<Office>(numberOfEstates);
            var officeValidator = new OfficeValidator();

            while (numberOfEstates > 0)
            {
                numberOfEstates--;

                string street;
                if (area.Country == "Romania")
                {
                    street = RomanianStreets[Random.Next(RomanianStreets.Length)];
                }
                else
                {
                    street = Faker.Address.StreetName();
                }

                string transaction = "Rent";
                int builtUpArea = 15 + Random.Next(11) * 15;
                int price = builtUpArea * 20;
                string periodOfTime = "month";
                int floor = Random.Next(0, 13);
                int door = floor * 5 + Random.Next(5);

                try
                {
                    var office = new Office
                    {
                        Type = EstateTypes.Office,
                        Title = Titles[Random.Next(Titles.Length)],
                        Description = GenerateDescription(),
                        ContactName = GenerateName(),
                        ContactPhone = Phone.Number(),
                        ContactMail = Internet.Email(),
                        Latitude = GenerateLatitude(),
                        Longitude = GenerateLongitude(),
                        Street = street,
                        Number = Random.Next(1, 150).ToString(),
                        ZipCode = Faker.Address.ZipCode(),
                        Building = GenerateBuildingNumber(),
                        FloorNumber = floor,
                        DoorNumber = door,
                        Area = area,
                        LastUpdate = DateTime.Now,
                        TransactionType = transaction,
                        Price = price,
                        Currency = Currency[Random.Next(3)],
                        PeriodOfTime = periodOfTime,
                        Rating = new[] { "A", "B", "C", "Green" }[Random.Next(4)],
                        BuiltUpArea = builtUpArea,
                        AC = GenerateYesOrNo(),
                        Internet = GenerateYesOrNo(),
                        ParkingPlace = GenerateYesOrNo(),
                        AvailableStarting = DateTime.Now
                    };
                    officeValidator.ValidateAndThrow(office);
                    result.Add(office);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }

        public static List<House> GenerateHouses(int numberOfEstates, Area area)
        {
            if (numberOfEstates is <= 0 or > 100)
            {
                throw new Exception("Number of estates to be generated must be greater than 0 and lesser than 101");
            }

            var result = new List<House>(numberOfEstates);
            var houseValidator = new HouseValidator();

            while (numberOfEstates > 0)
            {
                numberOfEstates--;

                string street;
                if (area.Country == "Romania")
                {
                    street = RomanianStreets[Random.Next(RomanianStreets.Length)];
                }
                else
                {
                    street = Faker.Address.StreetName();
                }

                int numberOfBedrooms = Random.Next(5) + 2;
                int numberOfBathrooms = Random.Next(2) + 1;
                int landArea = new[] { 300, 500, 1000, 1500, 2000, 5000 }[Random.Next(6)];
                string transaction = new string[] { "Sale", "Rent" }[Random.Next(2)];

                int price;
                if (transaction == "Sale")
                {
                    price = (numberOfBedrooms * 27_000 + numberOfBathrooms * 8_000 + landArea * 25);
                }
                else
                {
                    price = (numberOfBedrooms * 200 + numberOfBathrooms * 100 + landArea);
                }

                string? periodOfTime = (transaction == "Rent") ? "month" : null;

                try
                {
                    var house = new House
                    {
                        Type = EstateTypes.House,
                        Title = Titles[Random.Next(Titles.Length)],
                        Description = GenerateDescription(),
                        ContactName = GenerateName(),
                        ContactPhone = Phone.Number(),
                        ContactMail = Internet.Email(),
                        Latitude = GenerateLatitude(),
                        Longitude = GenerateLongitude(),
                        Street = street,
                        Number = Random.Next(1, 150).ToString(),
                        ZipCode = Faker.Address.ZipCode(),
                        Building = GenerateBuildingNumber(),
                        FloorNumber = null,
                        DoorNumber = null,
                        Area = area,
                        LastUpdate = DateTime.Now,
                        TransactionType = transaction,
                        Price = price,
                        Currency = Currency[Random.Next(3)],
                        PeriodOfTime = periodOfTime,
                        YearBuilt = Random.Next(52) + 1970,
                        BuiltUpArea = 20 * numberOfBedrooms + 10,
                        LandArea = landArea,
                        Floors = numberOfBedrooms / 2,
                        Bedrooms = numberOfBedrooms,
                        Bathrooms = numberOfBathrooms,
                        Heating = HeatingTypes[Random.Next(HeatingTypes.Length)],
                        AC = GenerateYesOrNo(),
                        Internet = GenerateYesOrNo(),
                        Garage = GenerateYesOrNo(),
                        SwimmingPool = GenerateYesOrNo(),
                        AvailableStarting = DateTime.Now
                    };
                    houseValidator.ValidateAndThrow(house);
                    result.Add(house);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }

        public static List<Land> GenerateLands(int numberOfEstates, Area area)
        {
            if (numberOfEstates is <= 0 or > 100)
            {
                throw new Exception("Number of estates to be generated must be greater than 0 and lesser than 101");
            }

            var result = new List<Land>(numberOfEstates);
            var landValidator = new LandValidator();

            while (numberOfEstates > 0)
            {
                numberOfEstates--;

                string street;
                if (area.Country == "Romania")
                {
                    street = RomanianStreets[Random.Next(RomanianStreets.Length)];
                }
                else
                {
                    street = Faker.Address.StreetName();
                }

                int landArea = new[] { 300, 500, 1000, 1500, 2000, 5000 }[Random.Next(6)];
                string transaction = "Sale";
                int pricePerSqMeter = 10 + Random.Next(140);
                int price = landArea * pricePerSqMeter;
                string water = GenerateWater();

                try
                {
                    var land = new Land
                    {
                        Type = EstateTypes.Land,
                        Title = Titles[Random.Next(Titles.Length)],
                        Description = GenerateDescription(),
                        ContactName = GenerateName(),
                        ContactPhone = Phone.Number(),
                        ContactMail = Internet.Email(),
                        Latitude = GenerateLatitude(),
                        Longitude = GenerateLongitude(),
                        Street = street,
                        Number = Random.Next(1, 150).ToString(),
                        ZipCode = Faker.Address.ZipCode(),
                        Building = GenerateBuildingNumber(),
                        FloorNumber = null,
                        DoorNumber = null,
                        Area = area,
                        LastUpdate = DateTime.Now,
                        TransactionType = transaction,
                        Price = price,
                        Currency = Currency[Random.Next(3)],
                        PeriodOfTime = null,
                        LandArea = landArea,
                        Topography = LandTopographyTypes[Random.Next(LandTopographyTypes.Length)],
                        Fence = FenceTypes[Random.Next(FenceTypes.Length)],
                        CurrentStatus = LandStatusTypes[Random.Next(LandStatusTypes.Length)],
                        Electricity = GenerateYesOrNo(),
                        Water = water,
                        Sewerage = (water == "none") ? "none" : GenerateSewerage(),
                        Heating = GenerateHeating(),
                        AvailableStarting = DateTime.Now
                    };
                    landValidator.ValidateAndThrow(land);
                    result.Add(land);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }

        public static List<EstateAgent> GenerateAgents(int numberOfAgents)
        {
            var result = new List<EstateAgent>(numberOfAgents);
            while (numberOfAgents > 0)
            {
                numberOfAgents--;
                result.Add(new EstateAgent
                {
                    Name = Name.FullName(),
                    PhoneNumber = Phone.Number(),
                    Email = Internet.Email()
                });
            }
            return result;
        }

        public static List<Client> GenerateClients(int numberOfClients)
        {
            var result = new List<Client>(numberOfClients);
            while (numberOfClients > 0)
            {
                numberOfClients--;
                result.Add(new Client
                {
                    Name = Name.FullName(),
                    PhoneNumber = Phone.Number(),
                    Email = Internet.Email()
                });
            }
            return result;
        }

        public static List<Appointment> GenerateAppointments(List<EstateAgent> agents,
                                                             List<Client> clients,
                                                             List<Flat> flats,
                                                             List<Office> offices,
                                                             List<House> houses,
                                                             List<Land> lands)
        {
            var appointments = new List<Appointment>(150);

            int count = 0;
            while (count < 150)
            {
                int type = Random.Next(4);
                RealEstate estate = type switch
                {
                    0 => flats[Random.Next(flats.Count)],
                    1 => offices[Random.Next(offices.Count)],
                    2 => houses[Random.Next(houses.Count)],
                    _ => lands[Random.Next(lands.Count)],
                };

                Client client = clients[Random.Next(clients.Count)];
                EstateAgent agent = agents[Random.Next(agents.Count)];


                DateTime date = GenerateAppointmentDate();

                while (appointments
                    .Any(appointment => (appointment.Agent == agent
                                        && appointment.Date == date) 
                                    || (appointment.Client == client
                                        && appointment.Date == date)))
                {
                    date = GenerateAppointmentDate();
                }
                appointments.Add(new Appointment(agent,
                                                 client,
                                                 estate,
                                                 date));
                count++;
            }
            return appointments;
        }

        public static List<Image> GenerateImages(List<RealEstate> estates)
        {
            var result = new List<Image>(estates.Count);
            
            foreach (var estate in estates)
            {
                var image = new Image
                {
                    RealEstateId = estate.Id,
                    ImageUri = GetUri(estate.Type)
                };
                result.Add(image);
            }
            return result;
        }

        private static Uri GetUri(EstateTypes type)
        {
            var estateTypes = new string[] { "flat", "office", "house", "land" };
            return type switch
            {
                EstateTypes.Office => new Uri("https://estatewebmanager.blob.core.windows.net/estates/" + estateTypes[Random.Next(4)] + (Random.Next(3) + 1).ToString() + ".jpg"),
                EstateTypes.Flat => new Uri("https://estatewebmanager.blob.core.windows.net/estates/flat" + (Random.Next(3) + 1).ToString() +".jpg"),
                EstateTypes.House => new Uri("https://estatewebmanager.blob.core.windows.net/estates/house" + (Random.Next(3) + 1).ToString() + ".jpg"),
                EstateTypes.Land => new Uri("https://estatewebmanager.blob.core.windows.net/estates/land" + (Random.Next(3) + 1).ToString() + ".jpg"),
                _ => throw new Exception("Invalid estate type")
            };
        }

        private static string GenerateDescription()
        {
            return Lorem.Sentence();
        }

        private static string GenerateName()
        {
            return Faker.Name.FullName(NameFormats.Standard);
        }
        private static double GenerateLatitude()
        {
            return Random.NextDouble() * 40 + 20;
        }

        private static double GenerateLongitude()
        {
            return Random.NextDouble() * 120;
        }
        private static string GenerateBuildingNumber()
        {
            var stringBuilder = new StringBuilder(Random.Next(1, 1000).ToString());
            var letter = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' }[Random.Next(13)];
            stringBuilder.Append(letter);
            return stringBuilder.ToString();
        }
        private static string GenerateWater()
        {
            return new string[] { "well", "centralised system", "none" }[Random.Next(3)];
        }
        private static string GenerateSewerage()
        {
            return new string[] { "septic tank", "connected to public sewerage system", "none" }[Random.Next(3)];
        }
        private static string GenerateHeating()
        {
            return new string[] { "connected to public gas pipe", "none" }[Random.Next(2)];
        }
        private static string GenerateYesOrNo()
        {
            return Random.Next(2) == 0 ? "yes" : "no";
        }

        private static DateTime GenerateAppointmentDate()
        {
            DateTime date = DateTime.Today;
            date = date.AddHours(Random.Next(8, 20));
            date = date.AddDays(Random.Next(2, 100));
            return date;
        }
    }
}
