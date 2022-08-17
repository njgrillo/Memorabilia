using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Franchise
    {
        public static readonly Franchise ArizonaCardinals = new(33, "Arizona Cardinals");
        public static readonly Franchise ArizonaDiamondbacks = new(28, "Arizona Diamondbacks");
        public static readonly Franchise AtlantaBraves = new(16, "Atlanta Braves");
        public static readonly Franchise AtlantaFalcons = new(31, "Atlanta Falcons");
        public static readonly Franchise AtlantaHawks = new(63, "Atlanta Hawks");
        public static readonly Franchise BaltimoreOrioles = new(1, "Baltimore Orioles");
        public static readonly Franchise BaltimoreRavens = new(34, "Baltimore Ravens");
        public static readonly Franchise BostonCeltics = new(64, "Boston Celtics");
        public static readonly Franchise BostonRedSox = new(2, "Boston Red Sox");
        public static readonly Franchise BrooklynNets = new(65, "Brooklyn Nets");
        public static readonly Franchise BuffaloBills = new(35, "Buffalo Bills");
        public static readonly Franchise CarolinaPanthers = new(32, "Carolina Panthers");
        public static readonly Franchise CharlotteHornets = new(66, "Charlotte Hornets");
        public static readonly Franchise ChicagoBears = new(36, "Chicago Bears");
        public static readonly Franchise ChicagoBulls = new(67, "Chicago Bulls");
        public static readonly Franchise ChicagoCubs = new(24, "Chicago Cubs");
        public static readonly Franchise ChicagoWhiteSox = new(6, "Chicago White Sox");
        public static readonly Franchise CincinnatiBengals = new(37, "Cincinnati Bengals");
        public static readonly Franchise CincinnatiReds = new(22, "Cincinnati Reds");
        public static readonly Franchise ClevelandBrowns = new(38, "Cleveland Browns");
        public static readonly Franchise ClevelandCavaliers = new(68, "Cleveland Cavaliers");
        public static readonly Franchise ClevelandGuardians = new(7, "Cleveland Guardians");
        public static readonly Franchise ColoradoRockies = new(29, "Colorado Rockies");
        public static readonly Franchise DallasCowboys = new(39, "Dallas Cowboys");
        public static readonly Franchise DallasMavericks = new(69, "Dallas Mavericks");
        public static readonly Franchise DenverBroncos = new(40, "Denver Broncos");
        public static readonly Franchise DenverNuggets = new(70, "Denver Nuggets");
        public static readonly Franchise DetroitLions = new(41, "Detroit Lions");
        public static readonly Franchise DetroitPistons = new(92, "Detroit Pistons");
        public static readonly Franchise DetroitTigers = new(8, "Detroit Tigers");
        public static readonly Franchise GoldenStateWarriors = new(71, "Golden State Warriors");
        public static readonly Franchise GreenBayPackers = new(42, "Green Bay Packers");
        public static readonly Franchise HoustonAstros = new(11, "Houston Astros");
        public static readonly Franchise HoustonRockets = new(72, "Houston Rockets");
        public static readonly Franchise HoustonTexans = new(43, "Houston Texans");
        public static readonly Franchise IndianaPacers = new(73, "Indiana Pacers");
        public static readonly Franchise IndianapolisColts = new(45, "Indianapolis Colts");
        public static readonly Franchise JacksonvilleJaguars = new(44, "Jacksonville Jaguars");
        public static readonly Franchise KansasCityChiefs = new(46, "Kansas City Chiefs");
        public static readonly Franchise KansasCityRoyals = new(10, "Kansas City Royals");
        public static readonly Franchise LasVegasRaiders = new(47, "Las Vegas Raiders");
        public static readonly Franchise LosAngelesAngels = new(12, "Los Angeles Angels");
        public static readonly Franchise LosAngelesChargers = new(48, "Los Angeles Chargers");
        public static readonly Franchise LosAngelesClippers = new(74, "Los Angeles Clippers");
        public static readonly Franchise LosAngelesDodgers = new(26, "Los Angeles Dodgers");
        public static readonly Franchise LosAngelesLakers = new(75, "Los Angeles Lakers");
        public static readonly Franchise LosAngelesRams = new(49, "Los Angeles Rams");
        public static readonly Franchise MemphisGrizzlies = new(76, "Memphis Grizzlies");
        public static readonly Franchise MiamiDolphins = new(50, "Miami Dolphins");
        public static readonly Franchise MiamiHeat = new(77, "Miami Heat");
        public static readonly Franchise MiamiMarlins = new(17, "Miami Marlins");
        public static readonly Franchise MilwaukeeBrewers = new(21, "Milwaukee Brewers");
        public static readonly Franchise MilwaukeeBucks = new(78, "Milwaukee Bucks");
        public static readonly Franchise MinnesotaTimberwolves = new(79, "Minnesota Timberwolves");
        public static readonly Franchise MinnesotaTwins = new(9, "Minnesota Twins");
        public static readonly Franchise MinnesotaVikings = new(51, "Minnesota Vikings");
        public static readonly Franchise NewEnglandPatriots = new(52, "New England Patriots");
        public static readonly Franchise NewOrleansPelicans = new(80, "New Orleans Pelicans");
        public static readonly Franchise NewOrleansSaints = new(55, "New Orleans Saints");
        public static readonly Franchise NewYorkGiants = new(53, "New York Giants");        
        public static readonly Franchise NewYorkJets = new(54, "New York Jets");
        public static readonly Franchise NewYorkKnicks = new(81, "New York Knicks");
        public static readonly Franchise NewYorkMets = new(18, "New York Mets");
        public static readonly Franchise NewYorkYankees = new(3, "New York Yankees");
        public static readonly Franchise OaklandAthletics = new(13, "Oakland Athletics");
        public static readonly Franchise OklahomaCityThunder = new(82, "Oklahoma City Thunder");
        public static readonly Franchise OrlandoMagic = new(83, "Orlando Magic");
        public static readonly Franchise Philadelphia76ers = new(84, "Philadelphia 76ers");
        public static readonly Franchise PhiladelphiaEagles = new(57, "Philadelphia Eagles");
        public static readonly Franchise PhiladelphiaPhillies = new(19, "Philadelphia Phillies");
        public static readonly Franchise PhoenixSuns = new(85, "Phoenix Suns");
        public static readonly Franchise PittsburghPirates = new(23, "Pittsburgh Pirates");
        public static readonly Franchise PittsburghSteelers = new(56, "Pittsburgh Steelers");
        public static readonly Franchise PortlandTrailBlazers = new(86, "Portland Trail Blazers");
        public static readonly Franchise SacrementoKings = new(87, "Sacremento Kings");
        public static readonly Franchise SaintLouisCardinals = new(25, "St. Louis Cardinals");
        public static readonly Franchise SanAntonioSpurs = new(88, "San Antonio Spurs");
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
        public static readonly Franchise TorontoRaptors = new(89, "Toronto Raptors");
        public static readonly Franchise UtahJazz = new(90, "Utah Jazz");
        public static readonly Franchise WashingtonCommanders = new(62, "Washington Commanders");
        public static readonly Franchise WashingtonNationals = new(20, "Washington Nationals");
        public static readonly Franchise WashingtonWizards = new(91, "Washington Wizards");

        public static readonly Franchise[] All =
        {
            ArizonaCardinals,
            ArizonaDiamondbacks,
            AtlantaBraves,
            AtlantaFalcons,
            AtlantaHawks,
            BaltimoreOrioles,
            BaltimoreRavens,
            BostonCeltics,
            BostonRedSox,
            BrooklynNets,
            BuffaloBills,
            CarolinaPanthers,
            CharlotteHornets,
            ChicagoBears,
            ChicagoBulls,
            ChicagoCubs,
            ChicagoWhiteSox,
            CincinnatiBengals,
            CincinnatiReds,
            ClevelandBrowns,
            ClevelandCavaliers,
            ClevelandGuardians,
            ColoradoRockies,
            DallasCowboys,
            DallasMavericks,
            DenverBroncos,
            DenverNuggets,
            DetroitLions,
            DetroitPistons,
            DetroitTigers,
            GoldenStateWarriors,
            GreenBayPackers,
            HoustonAstros,
            HoustonRockets,
            HoustonTexans,
            IndianaPacers,
            IndianapolisColts,
            JacksonvilleJaguars,
            KansasCityChiefs,
            KansasCityRoyals,
            LasVegasRaiders,
            LosAngelesAngels,
            LosAngelesChargers,
            LosAngelesClippers,
            LosAngelesDodgers,
            LosAngelesLakers,
            LosAngelesRams,
            MemphisGrizzlies,
            MiamiDolphins,
            MiamiHeat,
            MiamiMarlins,
            MilwaukeeBrewers,
            MilwaukeeBucks,
            MinnesotaTimberwolves,
            MinnesotaTwins,
            MinnesotaVikings,
            NewEnglandPatriots,
            NewOrleansPelicans,
            NewOrleansSaints,
            NewYorkGiants,
            NewYorkJets,
            NewYorkKnicks,
            NewYorkMets,
            NewYorkYankees,
            OaklandAthletics,
            OklahomaCityThunder,
            OrlandoMagic,
            Philadelphia76ers,
            PhiladelphiaEagles,
            PhiladelphiaPhillies,
            PhoenixSuns,
            PittsburghPirates,
            PittsburghSteelers,
            PortlandTrailBlazers,
            SacrementoKings,
            SaintLouisCardinals,
            SanAntonioSpurs,
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
            TorontoRaptors,
            UtahJazz,
            WashingtonCommanders,
            WashingtonNationals,
            WashingtonWizards
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

        public static readonly Franchise[] Basketball =
        {
            AtlantaHawks,
            BostonCeltics,
            BrooklynNets,
            CharlotteHornets,
            ChicagoBulls,
            ClevelandCavaliers,
            DallasMavericks,
            DenverNuggets,
            DetroitPistons,
            GoldenStateWarriors,
            HoustonRockets,
            IndianaPacers,
            LosAngelesClippers,
            LosAngelesLakers,
            MemphisGrizzlies,
            MiamiHeat,
            MilwaukeeBucks,
            MinnesotaTimberwolves,
            NewOrleansPelicans,
            NewYorkKnicks,
            OklahomaCityThunder,
            OrlandoMagic,
            Philadelphia76ers,
            PhoenixSuns,
            PortlandTrailBlazers,
            SacrementoKings,
            SanAntonioSpurs,
            TorontoRaptors,
            UtahJazz,
            WashingtonWizards
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

        public static Franchise[] GetAll(SportLeagueLevel sport)
        {
            if (sport == SportLeagueLevel.MajorLeagueBaseball)
                return Baseball;

            if (sport == SportLeagueLevel.NationalBasketballAssociation)
                return Basketball;

            if (sport == SportLeagueLevel.NationalFootballLeague)
                return Football;

            return All;
        }

        public static Franchise[] GetAll(int[] sportIds)
        {
            if (!sportIds.Any())
                return All;

            var sports = sportIds.Select(id => Sport.Find(id));
            var franchises = new List<Franchise>();

            if (sports.Any(sport => sport == Sport.Baseball))
                franchises.AddRange(Baseball);

            if (sports.Any(sport => sport == Sport.Basketball))
                franchises.AddRange(Basketball);

            if (sports.Any(sport => sport == Sport.Football))
                franchises.AddRange(Football);

            return franchises.OrderBy(franchise => franchise.Name).ToArray();
        }
    }
}
