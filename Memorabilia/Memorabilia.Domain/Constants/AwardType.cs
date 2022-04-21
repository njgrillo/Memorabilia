﻿using Framework.Extension;
using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class AwardType
    {
        public static readonly AwardType AllStarGameMostValuablePlayer = new(1, "All Star Most Valuable Player", "All Star MVP");
        public static readonly AwardType AmericanLeagueCyYoung = new(3, "American League Cy Young", "AL CY");
        public static readonly AwardType AmericanLeagueMostValuablePlayer = new(2, "American League Most Valuable Player", "AL MVP");        
        public static readonly AwardType AmericanLeagueRookieOfTheYear = new(13, "American League Rookie of the Year", "AL ROY");        
        public static readonly AwardType FinalsMostValuablePlayer = new(4, "Finals Most Valuable Player", "Finals MVP");
        public static readonly AwardType GoldenSpikes = new(5, "Golden Spikes", string.Empty);
        public static readonly AwardType GoldGlove = new(6, "Gold Glove", string.Empty);
        public static readonly AwardType ManagerOfTheYear = new(7, "Manager of the Year", string.Empty);
        public static readonly AwardType MostValuablePlayer = new(16, "Most Valuable Player", "MVP");
        public static readonly AwardType NationalLeagueCyYoung = new(8, "National League Cy Young", "NL CY");
        public static readonly AwardType NationalLeagueMostValuablePlayer = new(9, "National League Most Valuable Player", "NL MVP");
        public static readonly AwardType NationalLeagueRookieOfTheYear = new(14, "National League Rookie of the Year", "NL ROY");
        public static readonly AwardType PlatinumGlove = new(15, "Platinum Glove", string.Empty);
        public static readonly AwardType ProBowlMostValuablePlayer = new(10, "Pro Bowl Most Valuable Player", "Pro Bowl MVP");
        public static readonly AwardType SilverSlugguer = new(11, "Silver Slugger", string.Empty);
        public static readonly AwardType WorldSeriesMostValuablePlayer = new(12, "World Series Most Valuable Player", "WS MVP");

        public static readonly AwardType[] All =
        {
            AllStarGameMostValuablePlayer,
            AmericanLeagueCyYoung,
            AmericanLeagueMostValuablePlayer,
            AmericanLeagueRookieOfTheYear,
            FinalsMostValuablePlayer,
            GoldenSpikes,
            GoldGlove,
            ManagerOfTheYear,
            MostValuablePlayer,
            NationalLeagueCyYoung,
            NationalLeagueMostValuablePlayer,
            NationalLeagueRookieOfTheYear,
            PlatinumGlove,
            ProBowlMostValuablePlayer,
            SilverSlugguer,
            WorldSeriesMostValuablePlayer
        };

        private AwardType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static AwardType Find(int id)
        {
            return All.SingleOrDefault(awardType => awardType.Id == id);
        }

        public override string ToString()
        {
            return !Abbreviation.IsNullOrEmpty() ? Abbreviation : Name;
        }
    }
}
