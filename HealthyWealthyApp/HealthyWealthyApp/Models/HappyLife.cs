using System;

namespace HealthyWealthyApp.Models
{
    public class HappyLife
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public double AvgHappyScore { get; set; }

        public double AvgLifeSpan { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is HappyLife))
                return false;
            HappyLife p = (HappyLife)obj;
            return (p.CountryId ==CountryId && p.CountryName == CountryName && p.AvgHappyScore == AvgHappyScore && p.AvgLifeSpan == AvgLifeSpan);
        }
        public override int GetHashCode()
        {
            return String.Format("{0}|{1}|{2}|{3}", CountryId, CountryName, AvgHappyScore, AvgLifeSpan).GetHashCode();
        }

    }
}