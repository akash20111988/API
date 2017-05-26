using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult WeatherByCity(string id)
		{
			var url = "http://api.apixu.com/v1/current.json?key=f06e7c46c24144a5ae4104358170505&q=" + id;
			//http://api.openweathermap.org/data/2.5/forecast/city?id=524901&APPID=e67fab67a2bc61c221e8a6165965c107
			var client = new HttpClient();

			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			var response = client.GetAsync(url).Result;

			var weatherModel = response.Content.ReadAsAsync<WeatherModel>().Result;
			
			return View(weatherModel);
		}
    }
}