using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HealthyWealthyApp.Controllers
{
    public class ValuesController : ApiController
    {
        [ActionName("topCDCounts")]
        public IHttpActionResult GetTopCDCounts()
        {
            List<CityCDCount> counts = new List<CityCDCount>();
            counts.Add(new CityCDCount() { CityName = "Bellevue", RowsCount = 3 });
            counts.Add(new CityCDCount() { CityName = "Redmond", RowsCount = 10 });
            
            return Json(counts);
        }
    }

    public class CityCDCount
    {
        public string CityName { get; set; }
        public int RowsCount { get; set; }
    }
}
