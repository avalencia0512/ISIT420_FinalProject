using System.Collections.Generic;

namespace HealthyWealthyApp.Models
{
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

}