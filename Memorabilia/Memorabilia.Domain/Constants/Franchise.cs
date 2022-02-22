using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Franchise
    {
        public static readonly Franchise ArizonaCardinals = new(33, "Arizona Cardinals");
        public static readonly Franchise ArizonaDiamondbacks = new(28, "Arizona Diamondbacks");
        public static readonly Franchise AtlantaBraves = new(16, "Atlanta Braves");
        public static readonly Franchise AtlantaFalcons = new(31, "Atlanta Falcons");
        public static readonly Franchise BaltimoreOrioles = new(1, "Baltimore Orioles");
        public static readonly Franchise BaltimoreRavens = new(34, "Baltimore Ravens");
        public static readonly Franchise BostonRedSox = new(2, "Boston Red Sox");
        public static readonly Franchise BuffaloBills = new(35, "Buffalo Bills");
        public static readonly Franchise CarolinaPanthers = new(32, "Carolina Panthers");
        public static readonly Franchise ChicagoBears = new(36, "Chicago Bears");
        public static readonly Franchise ChicagoCubs = new(24, "Chicago Cubs");
        public static readonly Franchise ChicagoWhiteSox = new(6, "Chicago White Sox");
        public static readonly Franchise CincinnatiBengals = new(37, "Cincinnati Bengals");
        public static readonly Franchise CincinnatiReds = new(22, "Cincinnati Reds");
        public static readonly Franchise ClevelandBrowns = new(38, "Cleveland Browns");
        public static readonly Franchise ClevelandGuardians = new(7, "Cleveland Guardians");
        public static readonly Franchise ColoradoRockies = new(29, "Colorado Rockies");
        public static readonly Franchise DallasCowboys = new(39, "Dallas Cowboys");
        public static readonly Franchise DenverBroncos = new(40, "Denver Broncos");
        public static readonly Franchise DetroitLions = new(41, "Detroit Lions");
        public static readonly Franchise DetroitTigers = new(8, "Detroit Tigers");
        public static readonly Franchise GreenBayPackers = new(42, "Green Bay Packers");
        public static readonly Franchise HoustonAstros = new(11, "Houston Astros");
        public static readonly Franchise HoustonTexans = new(43, "Houston Texans");
        public static readonly Franchise IndianapolisColts = new(45, "Indianapolis Colts");
        public static readonly Franchise JacksonvilleJaguars = new(44, "Jacksonville Jaguars");
        public static readonly Franchise KansasCityChiefs = new(46, "Kansas City Chiefs");
        public static readonly Franchise KansasCityRoyals = new(10, "Kansas City Royals");
        public static readonly Franchise LasVegasRaiders = new(47, "Las Vegas Raiders");
        public static readonly Franchise LosAngelesAngels = new(12, "Los Angeles Angels");
        public static readonly Franchise LosAngelesChargers = new(48, "Los Angeles Chargers");
        public static readonly Franchise LosAngelesDodgers = new(26, "Los Angeles Dodgers");
        public static readonly Franchise LosAngelesRams = new(49, "Los Angeles Rams");
        public static readonly Franchise MiamiDolphins = new(50, "Miami Dolphins");
        public static readonly Franchise MiamiMarlins = new(17, "Miami Marlins");
        public static readonly Franchise MilwaukeeBrewers = new(21, "Milwaukee Brewers");
        public static readonly Franchise MinnesotaTwins = new(9, "Minnesota Twins");
        public static readonly Franchise MinnesotaVikings = new(51, "Minnesota Vikings");
        public static readonly Franchise NewEnglandPatriots = new(52, "New England Patriots");
        public static readonly Franchise NewOrleansSaints = new(55, "New Orleans Saints");
        public static readonly Franchise NewYorkGiants = new(53, "New York Giants");
        public static readonly Franchise NewYorkJets = new(54, "New York Jets");
        public static readonly Franchise NewYorkMets = new(18, "New York Mets");
        public static readonly Franchise NewYorkYankees = new(3, "New York Yankees");
        public static readonly Franchise OaklandAthletics = new(13, "Oakland Athletics");
        public static readonly Franchise PhiladelphiaEagles = new(57, "Philadelphia Eagles");
        public static readonly Franchise PhiladelphiaPhillies = new(19, "Philadelphia Phillies");
        public static readonly Franchise PittsburghPirates = new(23, "Pittsburgh Pirates");
        public static readonly Franchise PittsburghSteelers = new(56, "Pittsburgh Steelers");
        public static readonly Franchise SaintLouisCardinals = new(25, "St. Louis Cardinals");
        public static readonly Franchise SanDiegoPadres = new(30, "San Diego Padres");
        public static readonly Franchise SanFranciscoFortyNiners = new(58, "San Francisco 49ers");
        public static readonly Franchise SanFranciscoGiants = new(27, "San Francisco Giants");
        public static readonly Franchise SeattleMariners = new(14, "Seattle Mariners");
        public static readonly Franchise SeattleSeahawks = new(60, "Seattle Seahawks");
        public static readonly Franchise TampaBayBuccaneers = new(59, "Tampa Bay Buccaneers");
        public static readonly Franchise TampaBayRays = new(4, "Tampa Bay Rays");
        public static readonly Franchise TennesseeTitans = new(61, "Tennessee Titans");
        public static readonly Franchise TexasRangers = new(15, "Texas Rangers");
        public static readonly Franchise TorontoBlueJays = new(5, "Toronto Blue Jays");
        public static readonly Franchise WashingtonCommanders = new(62, "Washington Commanders");
        public static readonly Franchise WashingtonNationals = new(20, "Washington Nationals");

        public static readonly Franchise[] All =
        {
            ArizonaCardinals,
            ArizonaDiamondbacks,
            AtlantaBraves,
            AtlantaFalcons,
            BaltimoreOrioles,
            BaltimoreRavens,
            BostonRedSox,
            BuffaloBills,
            CarolinaPanthers,
            ChicagoBears,
            ChicagoCubs,
            ChicagoWhiteSox,
            CincinnatiBengals,
            CincinnatiReds,
            ClevelandBrowns,
            ClevelandGuardians,
            ColoradoRockies,
            DallasCowboys,
            DenverBroncos,
            DetroitLions,
            DetroitTigers,
            GreenBayPackers,
            HoustonAstros,
            HoustonTexans,
            IndianapolisColts,
            JacksonvilleJaguars,
            KansasCityChiefs,
            KansasCityRoyals,
            LasVegasRaiders,
            LosAngelesAngels,
            LosAngelesChargers,
            LosAngelesDodgers,
            LosAngelesRams,
            MiamiDolphins,
            MiamiMarlins,
            MilwaukeeBrewers,
            MinnesotaTwins,
            MinnesotaVikings,
            NewEnglandPatriots,
            NewOrleansSaints,
            NewYorkGiants,
            NewYorkJets,
            NewYorkMets,
            NewYorkYankees,
            OaklandAthletics,
            PhiladelphiaEagles,
            PhiladelphiaPhillies,
            PittsburghPirates,
            PittsburghSteelers,
            SaintLouisCardinals,
            SanDiegoPadres,
            SanFranciscoFortyNiners,
            SanFranciscoGiants,
            SeattleMariners,
            SeattleSeahawks,
            TampaBayBuccaneers,
            TampaBayRays,
            TennesseeTitans,
            TexasRangers,
            TorontoBlueJays,
            WashingtonCommanders,
            WashingtonNationals
        };

        public static readonly Franchise[] Baseball =
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

        public static readonly Franchise[] Football =
        {
            ArizonaCardinals,
            AtlantaFalcons,
            BaltimoreRavens,
            BuffaloBills,
            CarolinaPanthers,
            ChicagoBears,
            CincinnatiBengals,
            ClevelandBrowns,
            DallasCowboys,
            DenverBroncos,
            DetroitLions,
            GreenBayPackers,
            HoustonTexans,
            IndianapolisColts,
            JacksonvilleJaguars,
            KansasCityChiefs,
            LasVegasRaiders,
            LosAngelesChargers,
            LosAngelesRams,
            MiamiDolphins,
            MinnesotaVikings,
            NewEnglandPatriots,
            NewOrleansSaints,
            NewYorkGiants,
            NewYorkJets,
            PhiladelphiaEagles,
            PittsburghSteelers,
            SanFranciscoFortyNiners,
            SeattleSeahawks,
            TampaBayBuccaneers,
            TennesseeTitans,
            WashingtonCommanders
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
            return All.SingleOrDefault(franchise => franchise.Id == id);
        }

        public static Franchise[] GetFranchises(SportLeagueLevel sport)
        {
            if (sport == SportLeagueLevel.MajorLeagueBaseball)
                return Baseball;

            if (sport == SportLeagueLevel.NationalFootballLeague)
                return Football;

            return All;
        }
    }
}
