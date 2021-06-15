using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System;


namespace HealthyWealthyApp.Controllers
{
    public class ValuesController : ApiController
    {

        //Creates an instance of the object context
        HappyWealthyLifeDbEntities entities = new HappyWealthyLifeDbEntities();

        [ActionName("wealthyIsHappy")]
        public IHttpActionResult GetWealthyIsHappy()
        {
            List<Results> counts = new List<Results>();
            counts.Add(new Results() { CountryName = "Bellevue", CountryId = 3 });
            counts.Add(new Results() { CountryName = "Redmond", CountryId = 10 });

            return Json(counts);
        }

        // http://localhost:1289/api/values/happyLongLife
        [ActionName("happyLongLife")]
        public IHttpActionResult GetHappyLongerLife()
        {
            //List<Results> record = new List<Results>();


            var HappyCollection = (from country in entities.Countries
                                   from happyScore in country.Happinesses
/*                                   from lifeSpan in country.LifeYears
                                   where(lifeSpan.countryId == happyScore.countryId)*/
                                   let avgHappyScore = (new[]
                                  {  happyScore.yr2005,
                                     happyScore.yr2006,
                                     happyScore.yr2007,
                                     happyScore.yr2008,
                                     happyScore.yr2009,
                                     happyScore.yr2010,
                                     happyScore.yr2011,
                                     happyScore.yr2012,
                                     happyScore.yr2013,
                                     happyScore.yr2014,
                                     happyScore.yr2015,
                                     happyScore.yr2016,
                                     happyScore.yr2017,
                                     happyScore.yr2018,
                                     happyScore.yr2019
                                  }).Average()
                                   orderby avgHappyScore descending
                                   select new
                                   {
                                       CountryId = country.countryId,
                                       CountryName = country.countryName,
                                       AvgHappyScore = avgHappyScore, 
                                       //AvgLifeSpan = GetAvgLifeSpanByCountryId(happyScore.countryId)

                                   }).Take(10);

            GetAvgLifeSpanByCountryId(41);


            /*IEnumerable<Results> enumerable()
            {
                foreach (var item in LifeCollection)
                {
                    if (HappyCollection.)
                    {

                    }
                }

                return null
            }

*/
            return Json(HappyCollection);
        }


        public int GetAvgLifeSpanByCountryId(int countryId)
        {
            var LifeCollection = from lifeSpan in entities.LifeYears
                                 where (lifeSpan.countryId == countryId)
                                 let avgLifeSpan = (new[]
                                   {
                                      lifeSpan.yr2005,
                                      lifeSpan.yr2006,
                                      lifeSpan.yr2007,
                                      lifeSpan.yr2008,
                                      lifeSpan.yr2009,
                                      lifeSpan.yr2010,
                                      lifeSpan.yr2011,
                                      lifeSpan.yr2012,
                                      lifeSpan.yr2013,
                                      lifeSpan.yr2014,
                                      lifeSpan.yr2015,
                                      lifeSpan.yr2016,
                                      lifeSpan.yr2017,
                                      lifeSpan.yr2018,
                                      lifeSpan.yr2019,
                                   }).Average()
                                 select new
                                 {
                                     avgLifeSpan
                                };

            Console.WriteLine("Items in LifeCollection: ");
            foreach(var item in LifeCollection)
            {
                Console.WriteLine(item);
            }
            //int[] array =  LifeCollection.ToArray<int>();

            return 0;
        }


        //Helper to get avg life span 
        [ActionName("avgLifeSpan")]
        public IHttpActionResult GetAvgLifeSpan()
        {
            var LifeCollection = from country in entities.Countries
                                 from lifeSpan in country.LifeYears
                                 let avgLifeSpan = (new[]
                                   {
                                      lifeSpan.yr2005,
                                      lifeSpan.yr2006,
                                      lifeSpan.yr2007,
                                      lifeSpan.yr2008,
                                      lifeSpan.yr2009,
                                      lifeSpan.yr2010,
                                      lifeSpan.yr2011,
                                      lifeSpan.yr2012,
                                      lifeSpan.yr2013,
                                      lifeSpan.yr2014,
                                      lifeSpan.yr2015,
                                      lifeSpan.yr2016,
                                      lifeSpan.yr2017,
                                      lifeSpan.yr2018,
                                      lifeSpan.yr2019,
                                   }).Average()
                                 select new
                                 {
                                     AvgLifeSpan = avgLifeSpan
                                 };
            return Json(LifeCollection);
        }

        // Query 3 - Show estimated income per person and life expectancy of up to next 10 years. 
        [ActionName("estdIncomeLife")]
        public IHttpActionResult GetEstdIncomeLife()
        {
            List<Results> counts = new List<Results>();
            counts.Add(new Results() { CountryName = "Seattle", CountryId = 69 });
            counts.Add(new Results() { CountryName = "Houston", CountryId = 78 });
            counts.Add(new Results() { CountryName = "Orlando", CountryId = 85 });
            counts.Add(new Results() { CountryName = "New Jersey", CountryId = 59 });

            return Json(counts);
        }
    }


    public class Results
    {
        public string CountryName { get; set; }

        public int CountryId { get; set; }

        public double AvgHappyScore { get; set; }

        public int AvgLifeSpan { get; set; }
    }

}
