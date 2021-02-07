using System;
using FileHelpers;

namespace UIAutomationChallenge.ObjectModels
{
    [DelimitedRecord(",")]
    public class User
    {
        public string Email { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime DateBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public int MobilePhone { get; set; }
        public string AddressAlias { get; set; }
    }
}
