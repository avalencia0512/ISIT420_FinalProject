using System.Collections.Generic;
using System.Web.Http;

namespace HealthyWealthyApp.Controllers
{
    public class ValuesController : ApiController
    {
        [ActionName("wealthyIsHappy")]
        public IHttpActionResult GetWealthyIsHappy()
        {
            List<CityCDCount> counts = new List<CityCDCount>();
            counts.Add(new CityCDCount() { CityName = "Bellevue", RowsCount = 3 });
            counts.Add(new CityCDCount() { CityName = "Redmond", RowsCount = 10 });

            return Json(counts);
        }

        // http://localhost:1289/api/values/happyLongLife
        [ActionName("happyLongLife")]
        public IHttpActionResult GetHappyLongerLife()
        {
            List<CityCDCount> counts = new List<CityCDCount>();
            counts.Add(new CityCDCount() { CityName = "Mumbai", RowsCount = 84 });
            counts.Add(new CityCDCount() { CityName = "Bhavnagar", RowsCount = 65 });
            counts.Add(new CityCDCount() { CityName = "Surat", RowsCount = 42 });
            counts.Add(new CityCDCount() { CityName = "Ahmedabad", RowsCount = 41 });

            return Json(counts);
        }

        // Query 3 - Show estimated income per person and life expectancy of up to next 10 years. 
        [ActionName("estdIncomeLife")]
        public IHttpActionResult GetEstdIncomeLife()
        {
            List<CityCDCount> counts = new List<CityCDCount>();
            counts.Add(new CityCDCount() { CityName = "Seattle", RowsCount = 69 });
            counts.Add(new CityCDCount() { CityName = "Houston", RowsCount = 78 });
            counts.Add(new CityCDCount() { CityName = "Orlando", RowsCount = 85 });
            counts.Add(new CityCDCount() { CityName = "New Jersey", RowsCount = 59 });

            return Json(counts);
        }
    }


    public class CityCDCount
    {
        public string CityName { get; set; }
        public int RowsCount { get; set; }
    }

}
