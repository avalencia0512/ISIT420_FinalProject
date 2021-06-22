using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using HealthyWealthyApp.Models;

namespace HealthyWealthyApp.Controllers
{
    public class ValuesController : ApiController
    {

        //Creates an instance of the object context
        HappyWealthyLifeDbEntities entities = new HappyWealthyLifeDbEntities();

        //Query #1: Does wealth equal happiness?  - Analyze happiness and income to show happiness of top 5 countries with highest and lowest incomes. 
        //http://localhost:1289/api/values/wealthyIsHappy
        [ActionName("wealthyIsHappy")]
        public IHttpActionResult GetWealthyIsHappy(int id)  // topCountryCount
        {
            if (id == 0)
            {
                id = 5;
            }
            //Top5IncomePP returns the top 5 wealthiest countries (PP) and their happiness score 
            var Top5IncomePP = (from country in entities.Countries
                                from incomePP in entities.IncomePPs
                                from happyScore in entities.Happinesses
                                where (incomePP.countryId == happyScore.countryId)
                                let avgIncomePP = (new[]
                                {
                                              incomePP.yr2005,
                                              incomePP.yr2006,
                                              incomePP.yr2007,
                                              incomePP.yr2008,
                                              incomePP.yr2009,
                                              incomePP.yr2010,
                                              incomePP.yr2011,
                                              incomePP.yr2012,
                                              incomePP.yr2013,
                                              incomePP.yr2014,
                                              incomePP.yr2015,
                                              incomePP.yr2016,
                                              incomePP.yr2017,
                                              incomePP.yr2018,
                                              incomePP.yr2019,
                                }).Average()
                                orderby avgIncomePP descending
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
                                select new HappyIncome
                                {
                                    CountryId = country.countryId,
                                    CountryName = country.countryName,
                                    AvgWealthPP = avgIncomePP,
                                    AvgHappyScore = avgHappyScore

                                }).Take(id);
            List<HappyIncome> top5IncomeList = Top5IncomePP.ToList<HappyIncome>();

            var Low5IncomePP = (from country in entities.Countries
                                from incomePP in entities.IncomePPs
                                from happyScore in entities.Happinesses
                                where (incomePP.countryId == happyScore.countryId)
                                let avgIncomePP = (new[]
                                {
                                              incomePP.yr2005,
                                              incomePP.yr2006,
                                              incomePP.yr2007,
                                              incomePP.yr2008,
                                              incomePP.yr2009,
                                              incomePP.yr2010,
                                              incomePP.yr2011,
                                              incomePP.yr2012,
                                              incomePP.yr2013,
                                              incomePP.yr2014,
                                              incomePP.yr2015,
                                              incomePP.yr2016,
                                              incomePP.yr2017,
                                              incomePP.yr2018,
                                              incomePP.yr2019,
                                }).Average()
                                orderby avgIncomePP ascending
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
                                select new HappyIncome
                                {
                                    CountryId = country.countryId,
                                    CountryName = country.countryName,
                                    AvgWealthPP = avgIncomePP,
                                    AvgHappyScore = avgHappyScore

                                }).Take(id);
            List<HappyIncome> low5IncomeList = Low5IncomePP.ToList<HappyIncome>();

            HappyIncomeObjectResults res = new HappyIncomeObjectResults(top5IncomeList, low5IncomeList);

            return Ok(res);

        }

        //Query #2 - Do happy people live longer? - Relate happiness with life expectancy. Analyze if more happy people live longer. 
        // http://localhost:1289/api/values/happyLongLife
        [ActionName("happyLongLife")]
        public IHttpActionResult GetHappyLongerLife(double happinessScore, double lifeSpanParam)
        {

            //Happy collection returns the top 10 happiest countries and displays the avg life span per country.
            var HappyCollection = (from country in entities.Countries
                                   from happyScore in entities.Happinesses
                                   from lifeSpan in entities.LifeYears
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
                                   where (lifeSpan.countryId == happyScore.countryId && avgHappyScore >= happinessScore)
                                   orderby avgHappyScore ascending
                                   select new HappyLife
                                   {
                                       CountryId = country.countryId,
                                       CountryName = country.countryName,
                                       AvgHappyScore = avgHappyScore,
                                       AvgLifeSpan = avgLifeSpan
                                   });
            List<HappyLife> happyList = HappyCollection.ToList<HappyLife>();

            //Life collection takes the top 10 countries with the highest avg life spans and shows their happiness score
            var LifeCollection = (from country in entities.Countries
                                  from happyScore in entities.Happinesses
                                  from lifeSpan in entities.LifeYears
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
                                  where (lifeSpan.countryId == happyScore.countryId && avgLifeSpan >= lifeSpanParam)
                                  orderby avgLifeSpan ascending
                                  select new HappyLife
                                  {
                                      CountryId = country.countryId,
                                      CountryName = country.countryName,
                                      AvgHappyScore = avgHappyScore,
                                      AvgLifeSpan = avgLifeSpan
                                  });

            List<HappyLife> lifeList = LifeCollection.ToList<HappyLife>(); 
            HappyLifeObjectResults res = new HappyLifeObjectResults(happyList, lifeList);

            return Ok(res);
            
        }


        // Query 3 - Show estimated income per person and life expectancy of up to next 10 years. 
        //http://localhost:1289/api/values/estdIncomeLife
        [ActionName("estdIncomeLife")]
        public IHttpActionResult GetEstdIncomeLife(double estdIncome)
        {
            var WealthCollection = (from country in entities.Countries
                                   from wealth in country.IncomePPs
                                   from lifeSpan in country.LifeYears
                                   let avgWealth = (new[]
                                   {
                                             wealth.yr2021,
                                             wealth.yr2022,
                                             wealth.yr2023,
                                             wealth.yr2024,
                                             wealth.yr2025,
                                             wealth.yr2026,
                                             wealth.yr2027,
                                             wealth.yr2028,
                                             wealth.yr2029,
                                             wealth.yr2030,
                                             wealth.yr2031
                                       }).Average()
                                   where (lifeSpan.countryId == wealth.countryId && avgWealth >= estdIncome && lifeSpan.yr2021 > 0) 
                                   orderby wealth.Country.countryName ascending                                   
                                   select new LifeIncome
                                   {
                                       CountryId = country.countryId,
                                       CountryName = country.countryName,
                                       AvgWealthPP = avgWealth,
                                       EstdAge2021 = lifeSpan.yr2021,
                                       EstdAge2022 = lifeSpan.yr2022,
                                       EstdAge2023 = lifeSpan.yr2023,
                                       EstdAge2024 = lifeSpan.yr2024,
                                       EstdAge2025 = lifeSpan.yr2025,
                                       EstdAge2026 = lifeSpan.yr2026,
                                       EstdAge2027 = lifeSpan.yr2027,
                                       EstdAge2028 = lifeSpan.yr2028,
                                       EstdAge2029 = lifeSpan.yr2029,
                                       EstdAge2030 = lifeSpan.yr2030,
                                       EstdAge2031 = lifeSpan.yr2031
                                   });
            
            List<LifeIncome> wealthList = WealthCollection.ToList<LifeIncome>();

            return Ok(wealthList);
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
}
