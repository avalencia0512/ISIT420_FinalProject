using System;

namespace HealthyWealthyApp.Models
{
    public class HappyIncome
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public double AvgHappyScore { get; set; }

        public double AvgWealthPP { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is HappyIncome))
                return false;
            HappyIncome p = (HappyIncome)obj;
            return (p.CountryId == CountryId && p.CountryName == CountryName && p.AvgHappyScore == AvgHappyScore && 
                p.AvgWealthPP == AvgWealthPP);
        }

        public override int GetHashCode()
        {
            return String.Format("{0}|{1}|{2}|{3}", CountryId, CountryName, AvgHappyScore, AvgWealthPP).GetHashCode();
        }
    }
}