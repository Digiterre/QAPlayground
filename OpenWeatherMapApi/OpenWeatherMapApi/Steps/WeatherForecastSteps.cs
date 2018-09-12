using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenWeatherMapApi.Helpers;
using RestSharp;
using TechTalk.SpecFlow;

namespace OpenWeatherMapApi.Steps
{
    [Binding]
    public class WeatherForecastSteps
    {
        private UriBuilder WeatherMapUri { get; } = new UriBuilder("http://api.openweathermap.org/data/2.5/forecast");
        private DayOfWeek DayOfHoliday { get; set; }
        private IRestResponse Response { get; set; }
        private IList<double> Temp { get; } = new List<double>();
        private string City { get; set; }
        private JObject ResponseBody { get; set; }



        [Given(@"I am in the city of (.*)")]
        public void GivenIAmInTheCityOf(string city)
        {
            City = city;
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            WeatherMapUri.Query = "q=" + City + "&units=metric&appid=" + apiKey;
        }

        [Given(@"I only like to holiday on (.*)")]
        public void GivenIOnlyLikeToHolidayOn(string day)
        {
            DayOfWeek holidaydayOfWeek;
            if (Enum.TryParse(day, true, out holidaydayOfWeek))
                DayOfHoliday = holidaydayOfWeek;
        }

        [When(@"I look up the weather forecast")]
        public void WhenILookUpTheWeatherForecast()
        {
            var client = new RestHelper();
            client.SetEndPoint(WeatherMapUri.Uri.ToString());
            Response = client.GetQuery(WeatherMapUri.Query);
        }
        
        [Then(@"I should get the weather forecast")]
        public void ThenIShouldGetTheWeatherForecast()
        {
            IsValidJson(Response.Content).Should().BeTrue();
            Response.StatusCode.Should().Be(HttpStatusCode.OK, "The forecast in not valid.");
            ResponseBody = JObject.Parse(Response.Content);
            string[] cityAndCountry = City.Split(',');
            ResponseBody["city"]["name"].Value<string>()
                .Should()
                .Be(cityAndCountry[0], "returned forecast match city");
            if (cityAndCountry.Length > 1)
                ResponseBody["city"]["country"].Value<string>()
                    .Should()
                    .Be(cityAndCountry[1], "returned forecast should match country");
        }

        [Then(@"I should get the weather forecast with (.*)")]
        public void ThenIShouldGetTheWeatherForecastWith(HttpStatusCode status)
        {
            IsValidJson(Response.Content).Should().BeTrue();
            Response.StatusCode.Should().Be(status, "Incorrect Status");
        }


        [Then(@"the temperature should be warmer than (.*)")]
        public void ThenTheTemperatureShouldBeWarmerThan(string temperature)
        {
            double expectedTemp = Convert.ToDouble(temperature);
            var responseBody = JObject.Parse(Response.Content);
            var listOfForecasts = JArray.Parse(responseBody["list"].ToString());
            foreach (var forecast in listOfForecasts)
            {
                if (IsForecastFortheDayOfTheHoliday(forecast))
                {
                    GetMinimumTemperature(forecast);
                }
            }
            Temp.Count.Should().BeGreaterThan(0, "The forecast shoulod match the day");
            Temp.Min().Should().BeGreaterThan(expectedTemp, "The temperature should be warmer");
        }

        [Given(@"I look up the weather forecast for (.*) with bad apiKey")]
        public void GivenILookUpTheWeatherForecastForLagosWithIncorrect(string city)
        {
            City = city;
            string apiKey = ConfigurationManager.AppSettings["badApiKey"];
            WeatherMapUri.Query = "q=" + City + "&units=metric&appid=" + apiKey;
            var client = new RestHelper();
            client.SetEndPoint(WeatherMapUri.Uri.ToString());
            Response = client.GetQuery(WeatherMapUri.Query);
        }

        [Then(@"I should get an invalid response from (.*) the api")]
        public void ThenIShouldGetAnInvalidResponseFromTheApi(HttpStatusCode status)
        {
            IsValidJson(Response.Content).Should().BeTrue();
            Response.StatusCode.Should().Be(status, "Incorrect Status");
        }



        private bool IsForecastFortheDayOfTheHoliday(JToken forecast)
        {
            var dateOfForcast = forecast["dt_txt"].Value<DateTime>();
            return dateOfForcast.DayOfWeek.Equals(DayOfHoliday);
        }

        private void GetMinimumTemperature(JToken forecast)
        {
            var minimumTempForQuarter = forecast["main"]["temp_min"].Value<double>();
            Temp.Add(minimumTempForQuarter);
        }

        private static bool IsValidJson(string jsonString)
        {
            jsonString = jsonString.Trim();
            if ((jsonString.StartsWith("{") && jsonString.EndsWith("}")) || //For object
                (jsonString.StartsWith("[") && jsonString.EndsWith("]"))) //For array
            {
                try
                {
                    JToken.Parse(jsonString);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }
    }
}
