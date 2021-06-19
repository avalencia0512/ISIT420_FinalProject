using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System;
using Newtonsoft.Json;

namespace HealthyWealthyApp.Controllers
{
    public class ValuesController : ApiController
    {

        //Creates an instance of the object context
        HappyWealthyLifeDbEntities entities = new HappyWealthyLifeDbEntities();

        //Query #1: Does wealth equal happiness?  - Analyze happiness and income to show happiness of top 5 countries with highest and lowest incomes. 
        //http://localhost:1289/api/values/wealthyIsHappy
        [ActionName("wealthyIsHappy")]
        public IHttpActionResult GetWealthyIsHappy()
        {
            //Top5IncomePP returns the top 5 wealthiest countries (PP) and their happiness score 
            var Top5IncomePP = (from incomePP in entities.IncomePPs
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
                                    CountryId = incomePP.countryId,
                                    CountryName = incomePP.Country.countryName,
                                    AvgWealthPP = avgIncomePP,
                                    AvgHappyScore = avgHappyScore

                                }).Take(5);
            List<HappyIncome> top5IncomeList = Top5IncomePP.ToList<HappyIncome>();


            var Low5IncomePP = (from incomePP in entities.IncomePPs
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
                                    CountryId = incomePP.countryId,
                                    CountryName = incomePP.Country.countryName,
                                    AvgWealthPP = avgIncomePP,
                                    AvgHappyScore = avgHappyScore

                                }).Take(5);
            List<HappyIncome> low5IncomeList = Low5IncomePP.ToList<HappyIncome>();

            HappyIncomeObjectResults res = new HappyIncomeObjectResults(top5IncomeList, low5IncomeList);

            return Ok(res);
        }

        //Query #2 - Do happy people live longer? - Relate happiness with life expectancy. Analyze if more happy people live longer. 
        // http://localhost:1289/api/values/happyLongLife
        [ActionName("happyLongLife")]
        public IHttpActionResult GetHappyLongerLife()
        {
            //Happy collection returns the top 10 happiest countries and displays the avg life span per country.
            var HappyCollection = (    from happyScore in entities.Happinesses
                                       from lifeSpan in entities.LifeYears
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
                                       select new HappyLife
                                       {
                                           CountryId = happyScore.countryId,
                                           CountryName = happyScore.Country.countryName,
                                           /*CountryId = country.countryId,
                                           CountryName = country.countryName,*/
                                           AvgHappyScore = avgHappyScore,
                                           AvgLifeSpan = avgLifeSpan
                                       }).Take(10);
            List<HappyLife> happyList = HappyCollection.ToList<HappyLife>();


            //Life collection takes the top 10 countries with the highest avg life spans and shows their happiness score
            var LifeCollection = (/*from country in entities.Countries*/
                                   from happyScore in entities.Happinesses
                                   from lifeSpan in entities.LifeYears
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
                                   select new HappyLife
                                   {
                                       CountryId = happyScore.countryId,
                                       CountryName = happyScore.Country.countryName,
                                       AvgHappyScore = avgHappyScore,
                                       AvgLifeSpan = avgLifeSpan
                                   }).Take(10);
            List<HappyLife> lifeList = LifeCollection.ToList<HappyLife>();

            HappyLifeObjectResults res = new HappyLifeObjectResults(happyList, lifeList);

            return Ok(res);

        }


        // Query 3 - Show estimated income per person and life expectancy of up to next 10 years. 
        //http://localhost:1289/api/values/estdIncomeLife
        [ActionName("estdIncomeLife")]
        public IHttpActionResult GetEstdIncomeLife()
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
                                    select new LifeIncome
                                    {
                                        CountryId = country.countryId,
                                        CountryName = country.countryName,
                                        AvgWealthPP = avgWealth,
                                        AvgLifeSpan = avgLifeSpan
                                    }).Take(10);
            List<LifeIncome> wealthList = WealthCollection.ToList<LifeIncome>();

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
                                   select new LifeIncome
                                   {
                                       CountryId = country.countryId,
                                       CountryName = country.countryName,
                                       AvgWealthPP = avgWealth,
                                       AvgLifeSpan = avgLifeSpan
                                   }).Take(10);
            List<LifeIncome> lifeList = WLifeCollection.ToList<LifeIncome>();

            LifeIncomeObjectResults res = new LifeIncomeObjectResults(wealthList, lifeList);

            return Ok(res);
        }
    }


    public class HappyIncomeObjectResults
    {
        public HappyIncomeObjectResults(List<HappyIncome> incomeCollectionResults, List<HappyIncome> happyCollectionResults)
        {
            this.top5IncomeCollectionResults = happyCollectionResults;
            this.low5IncomeCollectionResults = incomeCollectionResults;
        }

        public List<HappyIncome> top5IncomeCollectionResults;
        public List<HappyIncome> low5IncomeCollectionResults;
    }

    public class HappyLifeObjectResults
    {
        public HappyLifeObjectResults(List<HappyLife> happyCollectionResults, List<HappyLife> lifeCollectinResults)
        {
            this.happyCollectionResults = happyCollectionResults;
            this.lifeCollectinResults = lifeCollectinResults;
        }

        public List<HappyLife> happyCollectionResults;
        public List<HappyLife> lifeCollectinResults;
    }

    public class LifeIncomeObjectResults
    {
        public LifeIncomeObjectResults(List<LifeIncome> incomeCollectionResults, List<LifeIncome> lifeCollectinResults)
        {
            this.incomeCollectionResults = incomeCollectionResults;
            this.lifeCollectinResults = lifeCollectinResults;
        }

        public List<LifeIncome> incomeCollectionResults;
        public List<LifeIncome> lifeCollectinResults;
    }

    public class HappyIncome
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public double AvgHappyScore { get; set; }

        public double AvgWealthPP { get; set; }

    }


    public class HappyLife
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public double AvgHappyScore { get; set; }

        public double AvgLifeSpan { get; set; }

    }


    public class LifeIncome
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public double AvgLifeSpan { get; set; }

        public double AvgWealthPP { get; set; }
    }

}
