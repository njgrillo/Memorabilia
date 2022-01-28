using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Franchise
    {
        public static readonly Franchise ArizonaDiamondbacks = new(28, "Arizona Diamondbacks");
        public static readonly Franchise AtlantaBraves = new(16, "Atlanta Braves");
        public static readonly Franchise BaltimoreOrioles = new(1, "Baltimore Orioles");
        public static readonly Franchise BostonRedSox = new(2, "Boston Red Sox");
        public static readonly Franchise ChicagoCubs = new(24, "Chicago Cubs");
        public static readonly Franchise ChicagoWhiteSox = new(6, "Chicago White Sox");
        public static readonly Franchise CincinnatiReds = new(22, "Cincinnati Reds");
        public static readonly Franchise ClevelandGuardians = new(7, "Cleveland Guardians");
        public static readonly Franchise ColoradoRockies = new(29, "Colorado Rockies");
        public static readonly Franchise DetroitTigers = new(8, "Detroit Tigers");
        public static readonly Franchise HoustonAstros = new(11, "Houston Astros");
        public static readonly Franchise KansasCityRoyals = new(10, "Kansas City Royals");
        public static readonly Franchise LosAngelesAngels = new(12, "Los Angeles Angels");
        public static readonly Franchise LosAngelesDodgers = new(26, "Los Angeles Dodgers");
        public static readonly Franchise MiamiMarlins = new(17, "Miami Marlins");
        public static readonly Franchise MilwaukeeBrewers = new(21, "Milwaukee Brewers");
        public static readonly Franchise MinnesotaTwins = new(9, "MinnesotaTwins");
        public static readonly Franchise NewYorkMets = new(18, "New York Mets");
        public static readonly Franchise NewYorkYankees = new(3, "New York Yankees");
        public static readonly Franchise OaklandAthletics = new(13, "Oakland Athletics");
        public static readonly Franchise PhiladelphiaPhillies = new(19, "Philadelphia Phillies");
        public static readonly Franchise PittsburghPirates = new(23, "Pittsburgh Pirates");
        public static readonly Franchise SaintLouisCardinals = new(25, "St. Louis Cardinals");
        public static readonly Franchise SanDiegoPadres = new(30, "San Diego Padres");
        public static readonly Franchise SanFranciscoGiants = new(27, "San Francisco Giants");
        public static readonly Franchise SeattleMariners = new(14, "Seattle Mariners");
        public static readonly Franchise TampaBayRays = new(4, "Tampa Bay Rays");
        public static readonly Franchise TexasRangers = new(15, "Texas Rangers");
        public static readonly Franchise TorontoBlueJays = new(5, "Toronto Blue Jays");
        public static readonly Franchise WashingtonNationals = new(20, "Washington Nationals");

        public static readonly Franchise[] All =
        {
            ArizonaDiamondbacks,
            AtlantaBraves,
            BaltimoreOrioles,
            BostonRedSox,
            ChicagoCubs,
            ChicagoWhiteSox,
            CincinnatiReds,
            ClevelandGuardians,
            ColoradoRockies,
            DetroitTigers,
            HoustonAstros,
            KansasCityRoyals,
            LosAngelesAngels,
            LosAngelesDodgers,
            MiamiMarlins,
            MilwaukeeBrewers,
            MinnesotaTwins,
            NewYorkMets,
            NewYorkYankees,
            OaklandAthletics,
            PhiladelphiaPhillies,
            PittsburghPirates,
            SaintLouisCardinals,
            SanDiegoPadres,
            SanFranciscoGiants,
            SeattleMariners,
            TampaBayRays,
            TexasRangers,
            TorontoBlueJays,
            WashingtonNationals
        };

        private Franchise(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static Franchise Find(int id)
        {
            return All.SingleOrDefault(Franchise => Franchise.Id == id);
        }
    }
}
