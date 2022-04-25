using Framework.Extension;
using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class AwardType
    {
        public static readonly AwardType AllStarGameMostValuablePlayer = new(1, "All Star Most Valuable Player", "All Star MVP");
        public static readonly AwardType AmericanLeagueChampionshipSeriesMostValuablePlayer = new(17, "American League Championship Series Most Valuable Player", "ALCS MVP");
        public static readonly AwardType AmericanLeagueComebackPlayerOfTheYear = new(24, "American League Comeback Player of the Year", "AL Comeback Player of the Year");
        public static readonly AwardType AmericanLeagueCyYoung = new(3, "American League Cy Young", "AL CY");
        public static readonly AwardType AmericanLeagueHankAaronAward = new(18, "American League Hank Aaron Award", "AL Hank Aaron Award");
        public static readonly AwardType AmericanLeagueManagerOfTheYear = new(26, "American League Manager of the Year", "AL Manager of the Year");        
        public static readonly AwardType AmericanLeagueMostValuablePlayer = new(2, "American League Most Valuable Player", "AL MVP");        
        public static readonly AwardType AmericanLeagueRelieverOfTheYear = new(32, "American League Reliever of the Year", "AL Reliever of the Year");        
        public static readonly AwardType AmericanLeagueRookieOfTheYear = new(13, "American League Rookie of the Year", "AL ROY");        
        public static readonly AwardType AssociatedPressAthleteOfTheYear = new(19, "Associated Press Athlete of the Year", "AP Athlete of the Year");        
        public static readonly AwardType DickHowserTrophy = new(29, "Dick Howser Trophy", string.Empty);
        public static readonly AwardType FieldingBibleAward = new(21, "Fielding Bible Award", string.Empty);
        public static readonly AwardType FinalsMostValuablePlayer = new(4, "Finals Most Valuable Player", "Finals MVP");
        public static readonly AwardType GoldenSpikes = new(5, "Golden Spikes", string.Empty);
        public static readonly AwardType GoldGlove = new(6, "Gold Glove", string.Empty);
        public static readonly AwardType ManagerOfTheYear = new(7, "Manager of the Year", string.Empty);
        public static readonly AwardType MostValuablePlayer = new(16, "Most Valuable Player", "MVP");
        public static readonly AwardType NationalLeagueChampionshipSeriesMostValuablePlayer = new(22, "National League Championship Series Most Valuable Player", "NLCS MVP");
        public static readonly AwardType NationalLeagueComebackPlayerOfTheYear = new(25, "National League Comeback Player of the Year", "NL Comeback Player of the Year");
        public static readonly AwardType NationalLeagueCyYoung = new(8, "National League Cy Young", "NL CY");
        public static readonly AwardType NationalLeagueHankAaronAward = new(28, "National League Hank Aaron Award", "NL Hank Aaron Award");
        public static readonly AwardType NationalLeagueManagerOfTheYear = new(27, "National League Manager of the Year", "NL Manager of the Year");
        public static readonly AwardType NationalLeagueMostValuablePlayer = new(9, "National League Most Valuable Player", "NL MVP");
        public static readonly AwardType NationalLeagueRelieverOfTheYear = new(33, "National League Reliever of the Year", "NL Reliever of the Year");
        public static readonly AwardType NationalLeagueRookieOfTheYear = new(14, "National League Rookie of the Year", "NL ROY");
        public static readonly AwardType PlatinumGlove = new(15, "Platinum Glove", string.Empty);
        public static readonly AwardType ProBowlMostValuablePlayer = new(10, "Pro Bowl Most Valuable Player", "Pro Bowl MVP");
        public static readonly AwardType RobertoClementeAward = new(23, "Roberto Clemente Award", string.Empty);
        public static readonly AwardType SilverSlugguer = new(11, "Silver Slugger", string.Empty);
        public static readonly AwardType SportsIllustratedSportspersonOfTheYear = new(30, "Sports Illustrated Sportsperson Of The Year", "SI Sportsperson Of The Year");
        public static readonly AwardType WilsonDefensivePlayerOfTheYearAward = new(20, "Wilson Defensive Player of the Year Award", string.Empty);
        public static readonly AwardType WorldBaseballClassicMostValuablePlayer = new (31, "World Baseball Classic Most Valuable Player", "WBC MVP");
        public static readonly AwardType WorldSeriesMostValuablePlayer = new(12, "World Series Most Valuable Player", "WS MVP");

        public static readonly AwardType[] All =
        {
            AllStarGameMostValuablePlayer,
            AmericanLeagueChampionshipSeriesMostValuablePlayer,
            AmericanLeagueComebackPlayerOfTheYear,
            AmericanLeagueCyYoung,
            AmericanLeagueHankAaronAward,
            AmericanLeagueManagerOfTheYear,
            AmericanLeagueMostValuablePlayer,
            AmericanLeagueRelieverOfTheYear,
            AmericanLeagueRookieOfTheYear,
            AssociatedPressAthleteOfTheYear,
            DickHowserTrophy,
            FieldingBibleAward,
            FinalsMostValuablePlayer,
            GoldenSpikes,
            GoldGlove,
            ManagerOfTheYear,
            MostValuablePlayer,
            NationalLeagueChampionshipSeriesMostValuablePlayer,
            NationalLeagueComebackPlayerOfTheYear,
            NationalLeagueCyYoung,
            NationalLeagueHankAaronAward,
            NationalLeagueManagerOfTheYear,
            NationalLeagueMostValuablePlayer,
            NationalLeagueRelieverOfTheYear,
            NationalLeagueRookieOfTheYear,
            PlatinumGlove,
            ProBowlMostValuablePlayer,
            RobertoClementeAward,
            SilverSlugguer,
            SportsIllustratedSportspersonOfTheYear,
            WilsonDefensivePlayerOfTheYearAward,
            WorldBaseballClassicMostValuablePlayer,
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
