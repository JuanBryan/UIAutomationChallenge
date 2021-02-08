using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;
using RestSharp;
using System;
using UIAutomationChallenge.Driver;
using UIAutomationChallenge.ObjectModels;
using UIAutomationChallenge.Utils;

namespace UIAutomationChallenge.Specifications
{
    class StepsCountryValidations : PageFactory
    {
        public RestClient client = new RestClient("http://localhost:3000/");
        public RestRequest request = new RestRequest();
        public IRestResponse<Country> response = new RestResponse<Country>();

        [Step("Given the user gets <GetAllCountriesURL> countries")]
        public void GivenTheUserGetsAllContries(string endPoint)
        {
            string endPointURL = Environment.GetEnvironmentVariable(endPoint);
            request = new RestRequest(endPointURL+ "alpha/{alpha2Code}", Method.GET);
        }

        [Step("Then the user validate if the code <idPoint> and the Country <string> exists and have the data content <dataValuesTable>")]
        public void ThenTheUserValidateTheCodeAndTheCountryExists(string idPoint, string country, Table dataValuesTable)
        {
            var rows = dataValuesTable.GetTableRows();
            request.AddUrlSegment(idPoint, country);
            var response = client.Execute<Country>(request);
            AreEqual(200, (int)response.StatusCode, "There is a problem with the response code for the alpha2Code: " + country + " Status code is not 200");
            WriteMessage("Validating that the alpha2Code value: " + response.GetResponseObject(idPoint) + " is present" );
            Assert.That(response.GetResponseObject(idPoint), Is.EqualTo(country), "alpha2Code is not correct");
            foreach (var row in rows)
            {
                WriteMessage("Validating that the name value: " + row.GetCell("name") + " is present in the response" );
                Assert.That(response.GetResponseObject("name"), Is.EqualTo(row.GetCell("name")), "alpha2Code is not correct");
                WriteMessage("Validating that the alpha3Code value: " + row.GetCell("name") + " is present in the response" );
                Assert.That(response.GetResponseObject("alpha3Code"), Is.EqualTo(row.GetCell("alpha3Code")), "alpha2Code is not correct");
            }
            request.Parameters.Clear();
        }

        [Step("Then the user validate if the code <idPoint> and the Country <string> not exists and returns error code <errorCode>")]
        public void ThenTheUserValidateTheCodeAndTheCountryNotExists(string idPoint, string country, int errorCode)
        {
            request.AddUrlSegment(idPoint, country);
            var response = client.Execute<Country>(request);
            AreEqual(errorCode, (int)response.StatusCode, "There is a problem with the response code for the alpha2Code: " + country + " Status code is not 404");
            request.Parameters.Clear();
        }

        [Step("Given the user wanna register a new countries <ApiBaseURL>")]
        public void GivenTheUserWannaRegisterNewCountries(string endPoint)
        {
            string endPointURL = Environment.GetEnvironmentVariable(endPoint);
            request = new RestRequest(endPointURL+ "newCountry/{alpha2Code}", Method.POST);
        }


        [Step("Then  the user validate a new country addition using POST <table>")]
        public void ThenUserValidateNewCountryAdditionUsingPOST(Table countryValues)
        {
            var rows = countryValues.GetTableRows();
            request.RequestFormat = DataFormat.Json;
            foreach (var row in rows)
            {
                request.AddJsonBody(new Country() { Name = row.GetCell("name"), Alpha2Code = row.GetCell("name"), Alpha3Code = row.GetCell("name") });
            }
            var response = client.Execute<Country>(request);
            AreEqual(200, (int)response.StatusCode, "This error is expected as this functionality is being developed");
            request.Parameters.Clear();
        }
    }
}
