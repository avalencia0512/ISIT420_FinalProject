using System.Collections.Generic;

namespace HealthyWealthyApp.Models
{
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
}