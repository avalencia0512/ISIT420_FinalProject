using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Newtonsoft.Json;

namespace HealthyWealthyApp.Controllers
{
    public class ValuesController : ApiController
    {

        //Creates an instance of the object context
        HappyWealthyLifeDbEntities entities = new HappyWealthyLifeDbEntities();

        [ActionName("wealthyIsHappy")]
        public IHttpActionResult GetWealthyIsHappy(int id)  // topCountryCount
        {
            List<Results> counts = new List<Results>();
            counts.Add(new Results() { CountryName = "Bellevue", CountryId = 3 });
            counts.Add(new Results() { CountryName = "Redmond", CountryId = 10 });

            List<Results> wealthList = new List<Results>()
            {
                new Results()  {  CountryId = 1,   CountryName = "Japan",
                                       AvgWealthPP = 37020, AvgHappyScore = 0.541    },
                new Results()  {  CountryId = 2,   CountryName = "Singapore",
                                       AvgWealthPP = 2920, AvgHappyScore = 0.493    }
            };
            List<Results> happyList = new List<Results>()
            {
                new Results()  {  CountryId = 1,   CountryName = "Costa Rica",
                                       AvgWealthPP = 520, AvgHappyScore = 0.718    },
                new Results()  {  CountryId = 2,   CountryName = "Bulgaria",
                                       AvgWealthPP = 2011, AvgHappyScore = 0.692    }
            };

            WealthyHappyObjectResults res = new WealthyHappyObjectResults(happyList, wealthList);

            return Ok(res);
        }

        //Query #2 - Do happy people live longer? - Relate happiness with life expectancy. Analyze if more happy people live longer. 
        // http://localhost:1289/api/values/happyLongLife
        [ActionName("happyLongLife")]
        public IHttpActionResult GetHappyLongerLife(string happinessScore, string countryId)
        {
            System.Data.Entity.DbSet<Country> countries = entities.Countries;
            List<Country> countryList = countries.ToList();

            var HappyCollection =  (from country in entities.Countries
                                       from happyScore in country.Happinesses
                                       from lifeSpan in country.LifeYears
                                       where (lifeSpan.countryId == happyScore.countryId)
                                       let avgHappyScore = (new[]
                                       {
                                             happyScore.yr2005,
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
                                       select new Results
                                       {
                                           CountryId = country.countryId,
                                           CountryName = country.countryName,
                                           AvgHappyScore = avgHappyScore,
                                           AvgLifeSpan = avgLifeSpan
                                       }).Take(10);
           List<Results> happyList =  HappyCollection.ToList<Results>();

            var LifeCollection = (from country in entities.Countries
                                   from happyScore in country.Happinesses
                                   from lifeSpan in country.LifeYears
                                   where (lifeSpan.countryId == happyScore.countryId)
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
                                  orderby avgLifeSpan descending
                                  let avgHappyScore = (new[]
                                   {
                                             happyScore.yr2005,
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
                                   select new Results
                                   {
                                       CountryId = country.countryId,
                                       CountryName = country.countryName,
                                       AvgHappyScore = avgHappyScore,
                                       AvgLifeSpan = avgLifeSpan
                                   }).Take(10);
            List<Results> lifeList = LifeCollection.ToList<Results>();
            HappyLifeObjectResults res = new HappyLifeObjectResults(happyList, lifeList);

            string sJSONResponse = JsonConvert.SerializeObject(res);
            return Ok(res);
            
        }


        // Query 3 - Show estimated income per person and life expectancy of up to next 10 years. 
        //http://localhost:1289/api/values/estdIncomeLife
        [ActionName("estdIncomeLife")]
        public IHttpActionResult GetEstdIncomeLife(string nextYears, string estdIncome)
        {
            var WealthCollection = (from country in entities.Countries
                                   from wealth in country.IncomePPs
                                   from lifeSpan in country.LifeYears
                                   where (lifeSpan.countryId == wealth.countryId)
                                   let avgWealth = (new[]
                                   {
                                             wealth.yr2005,
                                             wealth.yr2006,
                                             wealth.yr2007,
                                             wealth.yr2008,
                                             wealth.yr2009,
                                             wealth.yr2010,
                                             wealth.yr2011,
                                             wealth.yr2012,
                                             wealth.yr2013,
                                             wealth.yr2014,
                                             wealth.yr2015,
                                             wealth.yr2016,
                                             wealth.yr2017,
                                             wealth.yr2018,
                                             wealth.yr2019
                                       }).Average()
                                   orderby avgWealth descending
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
                                   select new Results
                                   {
                                       CountryId = country.countryId,
                                       CountryName = country.countryName,
                                       AvgWealthPP = avgWealth,
                                       AvgLifeSpan = avgLifeSpan
                                   }).Take(10);
            List<Results> wealthList = WealthCollection.ToList<Results>();

            var WLifeCollection = (from country in entities.Countries
                                  from wealth in country.IncomePPs
                                  from lifeSpan in country.LifeYears
                                  where (lifeSpan.countryId == wealth.countryId)
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
                                  orderby avgLifeSpan descending
                                  let avgWealth = (new[]
                                   {
                                             wealth.yr2005,
                                             wealth.yr2006,
                                             wealth.yr2007,
                                             wealth.yr2008,
                                             wealth.yr2009,
                                             wealth.yr2010,
                                             wealth.yr2011,
                                             wealth.yr2012,
                                             wealth.yr2013,
                                             wealth.yr2014,
                                             wealth.yr2015,
                                             wealth.yr2016,
                                             wealth.yr2017,
                                             wealth.yr2018,
                                             wealth.yr2019
                                       }).Average()
                                  select new Results
                                  {
                                      CountryId = country.countryId,
                                      CountryName = country.countryName,
                                      AvgWealthPP = avgWealth,
                                      AvgLifeSpan = avgLifeSpan
                                  }).Take(10);
            List<Results> lifeList = WLifeCollection.ToList<Results>();
            WealthyLifeObjectResults res = new WealthyLifeObjectResults(wealthList, lifeList);

            //string sJSONResponse = JsonConvert.SerializeObject(res);
            return Ok(res);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (entities != null)
                {
                    entities.Database.Connection.Close();
                    entities.Dispose();
                }
            }
        }
    }

    

    public class WealthyHappyObjectResults
    {
        public WealthyHappyObjectResults(List<Results> happyCollectionResults, List<Results> wealthyCollectionResults)
        {
            this.happyCollectionResults = happyCollectionResults;
            this.wealthyCollectionResults = wealthyCollectionResults;
        }

        public List<Results> happyCollectionResults;
        public List<Results> wealthyCollectionResults;
    }

    public class HappyLifeObjectResults
    {
        public HappyLifeObjectResults(List<Results> happyCollectionResults, List<Results> lifeCollectinResults)
        {
            this.happyCollectionResults = happyCollectionResults;
            this.lifeCollectinResults = lifeCollectinResults;
        }

        public List<Results> happyCollectionResults;
        public List<Results> lifeCollectinResults;
    }

    public class WealthyLifeObjectResults
    {
        public WealthyLifeObjectResults(List<Results> wealthyCollectionResults, List<Results> lifeCollectinResults)
        {
            this.wealthyCollectionResults = wealthyCollectionResults;
            this.lifeCollectinResults = lifeCollectinResults;
        }

        public List<Results> wealthyCollectionResults;
        public List<Results> lifeCollectinResults;
    }
    public class Results
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public double AvgHappyScore { get; set; }

        public double AvgLifeSpan { get; set; }

        public double AvgWealthPP { get; set; }
    }

}
