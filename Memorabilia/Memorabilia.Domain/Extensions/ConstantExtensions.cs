namespace Memorabilia.Domain.Extensions;

public static class ConstantExtensions
{
    public static bool CanHaveAnniversary(this Constant.BaseballType baseballType)
        => baseballType == Constant.BaseballType.TeamAnniversary;

    public static bool CanHaveCost(this Constant.AcquisitionType acquisitionType)
        => Constant.AcquisitionType.CostAcquisitionTypes.Contains(acquisitionType);

    public static bool CanHavePurchaseType(this Constant.AcquisitionType acquisitionType)
        => acquisitionType == Constant.AcquisitionType.Purchase;

    public static bool CanHaveSize(this Constant.ItemType itemType)
        => Constant.ItemType.SizeTypes.Contains(itemType);

    public static bool CanHaveSpot(this Constant.ItemType itemType)
       => Constant.ItemType.SpotTypes.Contains(itemType);

    public static bool CanHaveTeam(this Constant.ItemType itemType)
        => Constant.ItemType.TeamTypes.Contains(itemType);

    public static bool CanHaveYear(this Constant.BaseballType baseballType)
        => Constant.BaseballType.Yearly.Contains(baseballType);

    public static bool CanHaveSendAndReceiveDates(this Constant.AcquisitionType acquisitionType)
        => acquisitionType == Constant.AcquisitionType.ThroughTheMail;

    public static bool CanImportByYear(this Constant.BaseballType baseballType)
        => Constant.BaseballType.ImportByYear.Contains(baseballType);

    public static bool CanImportByYearRange(this Constant.BaseballType baseballType)
        => Constant.BaseballType.ImportByYearRange.Contains(baseballType);    

    public static bool IsCommissionerType(this Constant.BaseballType baseballType)
        => Constant.BaseballType.Commissioner.Contains(baseballType);

    public static bool IsCyYoungAward(this Constant.AwardType awardType)
        => Constant.AwardType.CyYoungAwards.Contains(awardType);

    public static bool IsDateAccomplishment(this Constant.AccomplishmentType accomplishmentType)
         => Constant.AccomplishmentType.DateAccomplishment.Any(x => x.Id == accomplishmentType.Id);

    public static bool IsGameWorthly(this Constant.BaseballType baseballType)
        => Constant.BaseballType.GameWorthly.Contains(baseballType);

    public static bool IsGameWorthly(this Constant.GameStyleType gameStyleType)
        => Constant.GameStyleType.GameWorthly.Contains(gameStyleType);

    public static bool IsGameWorthlyBaseballBrand(this Constant.Brand brand)
        => Constant.Brand.GameWorthlyBaseballBrand.Contains(brand);

    public static bool IsLeaguePresidentType(this Constant.BaseballType baseballType)
        => Constant.BaseballType.LeaguePresident.Contains(baseballType);

    public static bool IsMostValuablePlayerAward(this Constant.AwardType awardType)
        => Constant.AwardType.MostValuablePlayerAwards.Contains(awardType);

    public static bool IsNavigatable(this Constant.AuthenticationCompany authenticationCompany)
        => Constant.AuthenticationCompany.Navigatable.Contains(authenticationCompany);

    public static bool IsPersonProject(this Constant.ProjectType projectType)
        => Constant.ProjectType.PersonProject.Contains(projectType);

    public static bool IsProjectHelmet(this Constant.HelmetFinish helmetFinish)
        => Constant.HelmetFinish.Project.Contains(helmetFinish);

    public static bool IsTeamProject(this Constant.ProjectType projectType)
        => Constant.ProjectType.TeamProject.Contains(projectType);

    public static bool IsWearable(this Constant.ItemType itemType)
        => Constant.ItemType.WearableTypes.Contains(itemType);

    public static bool IsYearAccomplishment(this Constant.AccomplishmentType accomplishmentType)
         => Constant.AccomplishmentType.YearAccomplishment.Any(x => x.Id == accomplishmentType.Id);

    public static bool IsYearly(this Constant.BaseballType baseballType) 
        => Constant.BaseballType.Yearly.Contains(baseballType);
}
