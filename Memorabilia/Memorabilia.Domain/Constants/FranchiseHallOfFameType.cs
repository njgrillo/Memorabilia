namespace Memorabilia.Domain.Constants;

public sealed class FranchiseHallOfFameType : DomainItemConstant
{
    public static readonly FranchiseHallOfFameType AngelsHallOfFame = new(4, "Angels Hall of Fame", Franchise.LosAngelesAngels);
    public static readonly FranchiseHallOfFameType ArizonaCardinalsRingOfHonor = new(38, "Arizona Cardinals Ring of Honor", Franchise.ArizonaCardinals);
    public static readonly FranchiseHallOfFameType AthleticsHallOfFame = new(6, "Athletics Hall of Fame", Franchise.OaklandAthletics);
    public static readonly FranchiseHallOfFameType BaltimoreRavensRingOfHonor = new(35, "Baltimore Ravens Ring of Honor", Franchise.BaltimoreRavens);
    public static readonly FranchiseHallOfFameType BravesHallOfFame = new(1, "Braves Hall of Fame", Franchise.AtlantaBraves);
    public static readonly FranchiseHallOfFameType CardinalsHallOfFame = new(7, "Cardinals Hall of Fame", Franchise.SaintLouisCardinals);
    public static readonly FranchiseHallOfFameType CubsHallOfFame = new(8, "Cubs Hall of Fame", Franchise.ChicagoCubs);
    public static readonly FranchiseHallOfFameType DallasCowboysRingOfHonor = new(27, "Dallas Cowboys Ring of Honor", Franchise.DallasCowboys);
    public static readonly FranchiseHallOfFameType DenverBroncosRingOfFame = new(32, "Denver Broncos Ring of Fame", Franchise.DenverBroncos);
    public static readonly FranchiseHallOfFameType GreenBayPackersHallOfFame = new(26, "Green Bay Packers Hall of Fame", Franchise.GreenBayPackers);
    public static readonly FranchiseHallOfFameType GuardiansHallOfFame = new(10, "Guardians Hall of Fame", Franchise.ClevelandGuardians);
    public static readonly FranchiseHallOfFameType HoustonAstrosHallOfFame = new(5, "Houston Astros Hall of Fame", Franchise.HoustonAstros);
    public static readonly FranchiseHallOfFameType KansasCityChiefsHallOfFame = new(34, "Kansas City Chiefs Hall of Fame", Franchise.KansasCityChiefs);
    public static readonly FranchiseHallOfFameType KansasCityRoyalsHallOfFame = new(22, "Kansas City Royals Hall of Fame", Franchise.KansasCityRoyals);
    public static readonly FranchiseHallOfFameType LosAngelesChargersHallOfFame = new (29, "Los Angeles Chargers Hall of Fame", Franchise.LosAngelesChargers);
    public static readonly FranchiseHallOfFameType MetsHallOfFame = new(11, "Mets Hall of Fame", Franchise.NewYorkMets);
    public static readonly FranchiseHallOfFameType MilwaukeeBrewersWallOfHonor = new(2, "Milwaukee Brewers Wall of Honor", Franchise.MilwaukeeBrewers);
    public static readonly FranchiseHallOfFameType MinnesotaTwinsHallOfFame = new(23, "Minnesota Twins Hall of Fame", Franchise.MinnesotaTwins);
    public static readonly FranchiseHallOfFameType MonumentPark = new(18, "Monument Park", Franchise.NewYorkYankees);
    public static readonly FranchiseHallOfFameType NationalsHallOfFame = new(12, "Nationals Hall of Fame", Franchise.WashingtonNationals);
    public static readonly FranchiseHallOfFameType NewOrleansSaintsHallOfFame = new (30, "New Orleans Saints Hall of Fame", Franchise.NewOrleansSaints);
    public static readonly FranchiseHallOfFameType NewOrleansSaintsRingOfHonor = new (31, "New Orleans Saints Ring of Honor", Franchise.NewOrleansSaints);
    public static readonly FranchiseHallOfFameType OriolesHallOfFame = new(13, "Orioles Hall of Fame", Franchise.BaltimoreOrioles);
    public static readonly FranchiseHallOfFameType PadresHallOfFame = new(14, "Padres Hall of Fame", Franchise.SanDiegoPadres);
    public static readonly FranchiseHallOfFameType PhiladelphiaEaglesHallOfFame = new(33, "Philadelphia Eagles Hall of Fame", Franchise.PhiladelphiaEagles);
    public static readonly FranchiseHallOfFameType PhilliesHallOfFame = new(15, "Phillies Hall of Fame", Franchise.PhiladelphiaPhillies);
    public static readonly FranchiseHallOfFameType PittsburghSteelersHallOfHonor = new(37, "Pittsburgh Steelers Hall of Honor", Franchise.PittsburghSteelers);
    public static readonly FranchiseHallOfFameType RedSoxHallOfFame = new(16, "Red Sox Hall of Fame", Franchise.BostonRedSox);
    public static readonly FranchiseHallOfFameType RedsHallOfFame = new(17, "Reds Hall of Fame", Franchise.CincinnatiReds);
    public static readonly FranchiseHallOfFameType SanDiegoPadresHallOfFame = new(21, "San Diego Padres Hall of Fame", Franchise.SanDiegoPadres);
    public static readonly FranchiseHallOfFameType SanFranciscoGiantsWallOfFame = new(9, "San Francisco Giants Wall of Fame", Franchise.SanFranciscoGiants);
    public static readonly FranchiseHallOfFameType SeattleMarinersHallOfFame = new(20, "Seattle Mariners Hall of Fame", Franchise.SeattleMariners);
    public static readonly FranchiseHallOfFameType TampaBayBuccaneersRingOfHonor = new (39, "Tampa Bay Buccaneers Ring of Honor", Franchise.TampaBayBuccaneers);
    public static readonly FranchiseHallOfFameType TexasRangersHallOfFame = new(3, "Texas Rangers Hall of Fame", Franchise.TexasRangers);
    public static readonly FranchiseHallOfFameType TitansOilersRingOfHonor = new(36, "Titans/Oilers Ring of Honor", Franchise.TennesseeTitans);
    public static readonly FranchiseHallOfFameType TorontoBlueJaysLevelOfExcellence = new(19, "Toronto Blue Jays Level Of Excellence", Franchise.TorontoBlueJays);
    public static readonly FranchiseHallOfFameType WashingtonCommandersRingOfFame = new(28, "Washington Commanders Ring of Fame", Franchise.WashingtonCommanders);

    public static readonly FranchiseHallOfFameType[] All =
    {
        AngelsHallOfFame,
        ArizonaCardinalsRingOfHonor,
        AthleticsHallOfFame,
        BaltimoreRavensRingOfHonor,
        BravesHallOfFame,
        CardinalsHallOfFame,
        CubsHallOfFame,
        DallasCowboysRingOfHonor,
        DenverBroncosRingOfFame,
        GreenBayPackersHallOfFame,
        GuardiansHallOfFame,
        HoustonAstrosHallOfFame,
        KansasCityChiefsHallOfFame,
        KansasCityRoyalsHallOfFame,
        LosAngelesChargersHallOfFame,
        MetsHallOfFame,
        MilwaukeeBrewersWallOfHonor,
        MinnesotaTwinsHallOfFame,
        MonumentPark,
        NationalsHallOfFame,
        NewOrleansSaintsHallOfFame,
        NewOrleansSaintsRingOfHonor,
        OriolesHallOfFame,
        PadresHallOfFame,
        PhiladelphiaEaglesHallOfFame,
        PhilliesHallOfFame,
        PittsburghSteelersHallOfHonor,
        RedsHallOfFame,
        RedSoxHallOfFame,
        SanDiegoPadresHallOfFame,
        SanFranciscoGiantsWallOfFame,
        SeattleMarinersHallOfFame,
        TampaBayBuccaneersRingOfHonor,
        TexasRangersHallOfFame,
        TitansOilersRingOfHonor,
        TorontoBlueJaysLevelOfExcellence,
        WashingtonCommandersRingOfFame
    };

    public static readonly FranchiseHallOfFameType[] Baseball =
    {
        AngelsHallOfFame,
        AthleticsHallOfFame,
        BravesHallOfFame,
        CardinalsHallOfFame,
        CubsHallOfFame,
        GuardiansHallOfFame,
        HoustonAstrosHallOfFame,
        KansasCityRoyalsHallOfFame,
        MetsHallOfFame,
        MilwaukeeBrewersWallOfHonor,
        MinnesotaTwinsHallOfFame,
        MonumentPark,
        NationalsHallOfFame,
        OriolesHallOfFame,
        PadresHallOfFame,
        PhilliesHallOfFame,
        RedsHallOfFame,
        RedSoxHallOfFame,
        SanDiegoPadresHallOfFame,
        SanFranciscoGiantsWallOfFame,
        SeattleMarinersHallOfFame,
        TexasRangersHallOfFame,
        TorontoBlueJaysLevelOfExcellence
    };

    public static readonly FranchiseHallOfFameType[] Football =
    {
        ArizonaCardinalsRingOfHonor,
        BaltimoreRavensRingOfHonor,
        DallasCowboysRingOfHonor,
        DenverBroncosRingOfFame,
        GreenBayPackersHallOfFame,
        KansasCityChiefsHallOfFame,
        LosAngelesChargersHallOfFame,
        NewOrleansSaintsHallOfFame,
        NewOrleansSaintsRingOfHonor,
        PhiladelphiaEaglesHallOfFame,
        PittsburghSteelersHallOfHonor,
        TampaBayBuccaneersRingOfHonor,
        TitansOilersRingOfHonor,
        WashingtonCommandersRingOfFame
    };

    private FranchiseHallOfFameType(int id, string name, Franchise franchise) : base(id, name)
    {
        Franchise = franchise;
    }

    public Franchise Franchise { get; }

    public static FranchiseHallOfFameType Find(int franchiseId)
    {
        return All.SingleOrDefault(franchiseHallOfFameType => franchiseHallOfFameType.Franchise == Franchise.Find(franchiseId));
    }

    public static FranchiseHallOfFameType Find(Franchise franchise)
    {
        return All.SingleOrDefault(franchiseHallOfFameType => franchiseHallOfFameType.Franchise == franchise);
    }

    public static FranchiseHallOfFameType[] GetAll(params Sport[] sports)
    {
        if (!sports.Any())
            return All;

        var franchiseHallOfFameTypes = new List<FranchiseHallOfFameType>();

        if (sports.Any(sport => sport == Sport.Baseball))
            franchiseHallOfFameTypes.AddRange(Baseball);

        if (sports.Any(sport => sport == Sport.Football))
            franchiseHallOfFameTypes.AddRange(Football);

        return franchiseHallOfFameTypes.OrderBy(franchiseHallOfFameType => franchiseHallOfFameType.Franchise.Name).ToArray();
    }

    public override string ToString()
    {
        return $"{Franchise.Name} ({Name})";
    }
}
