using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UIAutomationChallenge.ObjectModels;
using FileHelpers;
using RandomNameGeneratorLibrary;

namespace UIAutomationChallenge.Utils
{
    public class DataGenerator
    {
        private User _user = new User();
        private static readonly Random _random = new Random();

        public static string GenerateRandomEmail()
        {
            var emailRandom = "mclovin-user" + _random.Next(1, 10000) + "@gmail.com";
            return emailRandom;
        }

        public static string GenerateRandomTitle()
        {
            return _random.Next(1, 2) == 1 ? "Mr." : "Mrs.";
        }

        public static int GenerateRamdomMobilePhone()
        {
            return _random.Next(100000000, 999999999);
        }

        public static string GenerateRandomState()
        {
            var number = _random.Next(1, 10);
           
            switch (number)
            {
                case 1: return "Alabama";
                case 2: return "Alaska";
                case 3: return "Arizona";
                case 4: return "Arkansas";
                case 5: return "California";
                case 6: return "Colorado";
                case 7: return "Connecticut";
                case 8: return "Delaware";
                case 9: return "Florida";
                case 10: return "Georgia";
                default: return "Alabama";
            }
        }

        public static string[] GenerateRandomName()
        {
            var personGenerator = new PersonNameGenerator();
            var name = personGenerator.GenerateRandomMaleFirstAndLastName();
            string[] data = name.Split(' ');

            return data;
        }

        public static User GenerateRandomUser()
        {
            return new User
            {
                Email = GenerateRandomEmail(),
                Title = GenerateRandomTitle(),
                FirstName = GenerateRandomName()[0],
                LastName = GenerateRandomName()[1],
                Password = "mclovin123",
                DateBirth = DateTime.Today,
                Address = "Avenida Brasil 15",
                City = "Lima",
                State = GenerateRandomState(),
                ZipCode = 15403,
                Country = "United States",
                MobilePhone = GenerateRamdomMobilePhone(),
                AddressAlias = "Random Adress"
            };
        }

        public static void AddMoreUsersToCsvFile(User user)
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0,
                               AppDomain.CurrentDomain.BaseDirectory.Length - 9) + "/Resources/userData.csv";
            var engine = new FileHelperEngine<User>();
            engine.AppendToFile(filePath, user);
        }

        public static List<User> GetTestDataFromCsvFile()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0,
                            AppDomain.CurrentDomain.BaseDirectory.Length - 9) + "/Resources/userData.csv";
            var engine = new FileHelperEngine<User>();
            var users = engine.ReadFile(filePath);
            var listUsers = users.Select(item => new User
                {
                    Email = item.Email,
                    Title = item.Title,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Password = item.Password,
                    DateBirth = item.DateBirth,
                    Address = item.Address,
                    City = item.City,
                    State = item.State,
                    ZipCode = item.ZipCode,
                    Country = item.Country,
                    MobilePhone = item.MobilePhone,
                    AddressAlias = item.AddressAlias
                })
                .ToList();
            return listUsers;
        }

        public static void ClearCsvFile()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0,
                               AppDomain.CurrentDomain.BaseDirectory.Length - 9) + "/Resources/userData.csv";

             if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}