using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class FranchiseHallOfFameType
    {
        public static readonly FranchiseHallOfFameType AngelsHallOfFame = new(4, "Angels Hall of Fame", Franchise.LosAngelesAngels);
        public static readonly FranchiseHallOfFameType AthleticsHallOfFame = new(6, "Athletics Hall of Fame", Franchise.OaklandAthletics);
        public static readonly FranchiseHallOfFameType BravesHallOfFame = new(1, "Braves Hall of Fame", Franchise.AtlantaBraves);
        public static readonly FranchiseHallOfFameType CardinalsHallOfFame = new(7, "Cardinals Hall of Fame", Franchise.SaintLouisCardinals);
        public static readonly FranchiseHallOfFameType CubsHallOfFame = new(8, "Cubs Hall of Fame", Franchise.ChicagoCubs);
        public static readonly FranchiseHallOfFameType GuardiansHallOfFame = new(10, "Guardians Hall of Fame", Franchise.ClevelandGuardians);
        public static readonly FranchiseHallOfFameType HoustonAstrosHallOfFame = new(5, "Houston Astros Hall of Fame", Franchise.HoustonAstros);
        public static readonly FranchiseHallOfFameType MetsHallOfFame = new(11, "Mets Hall of Fame", Franchise.NewYorkMets);
        public static readonly FranchiseHallOfFameType MilwaukeeBrewersWallOfHonor = new(2, "Milwaukee Brewers Wall of Honor", Franchise.MilwaukeeBrewers);
        public static readonly FranchiseHallOfFameType NationalsHallOfFame = new(12, "Nationals Hall of Fame", Franchise.WashingtonNationals);
        public static readonly FranchiseHallOfFameType OriolesHallOfFame = new(13, "Orioles Hall of Fame", Franchise.BaltimoreOrioles);
        public static readonly FranchiseHallOfFameType PadresHallOfFame = new(14, "Padres Hall of Fame", Franchise.SanDiegoPadres);
        public static readonly FranchiseHallOfFameType PhilliesHallOfFame = new(15, "Phillies Hall of Fame", Franchise.PhiladelphiaPhillies);
        public static readonly FranchiseHallOfFameType RedSoxHallOfFame = new(16, "Red Sox Hall of Fame", Franchise.BostonRedSox);
        public static readonly FranchiseHallOfFameType RedsHallOfFame = new(17, "Reds Hall of Fame", Franchise.CincinnatiReds);
        public static readonly FranchiseHallOfFameType SanFranciscoGiantsWallOfFame = new(9, "San Francisco Giants Wall of Fame", Franchise.SanFranciscoGiants);
        public static readonly FranchiseHallOfFameType TexasRangersHallOfFame = new(3, "Texas Rangers Hall of Fame", Franchise.TexasRangers);
        public static readonly FranchiseHallOfFameType TorontoBlueJaysLevelOfExcellence = new(18, "Toronto Blue Jays Level Of Excellence", Franchise.TorontoBlueJays);

        public static readonly FranchiseHallOfFameType[] All =
        {
            AngelsHallOfFame,
            AthleticsHallOfFame,
            BravesHallOfFame,
            CardinalsHallOfFame,
            CubsHallOfFame,
            GuardiansHallOfFame,
            HoustonAstrosHallOfFame,
            MetsHallOfFame,
            MilwaukeeBrewersWallOfHonor,
            NationalsHallOfFame,
            OriolesHallOfFame,
            PadresHallOfFame,
            PhilliesHallOfFame,
            RedsHallOfFame,
            RedSoxHallOfFame,
            SanFranciscoGiantsWallOfFame,
            TexasRangersHallOfFame,
            TorontoBlueJaysLevelOfExcellence
        };

        private FranchiseHallOfFameType(int id, string name, Franchise franchise)
        {
            Id = id;
            Name = name;
            Franchise = franchise;
        }

        public Franchise Franchise { get; }

        public int Id { get; }

        public string Name { get; }

        public static FranchiseHallOfFameType Find(int franchiseId)
        {
            return All.SingleOrDefault(franchiseHallOfFameType => franchiseHallOfFameType.Franchise == Franchise.Find(franchiseId));
        }

        public static FranchiseHallOfFameType Find(Franchise franchise)
        {
            return All.SingleOrDefault(franchiseHallOfFameType => franchiseHallOfFameType.Franchise == franchise);
        }
    }
}
