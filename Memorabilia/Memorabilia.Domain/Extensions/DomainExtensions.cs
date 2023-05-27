using Memorabilia.Domain.Constants;

namespace Memorabilia.Domain.Extensions;

public static class DomainExtensions
{
    public static bool CanHaveAnniversary(this BaseballType baseballType)
        => baseballType == BaseballType.TeamAnniversary;

    public static bool CanHaveCost(this AcquisitionType acquisitionType)
        => AcquisitionType.CostAcquisitionTypes.Contains(acquisitionType);

    public static bool CanHavePurchaseType(this AcquisitionType acquisitionType)
        => acquisitionType == AcquisitionType.Purchase;

    public static bool CanHaveSize(this ItemType itemType)
        => ItemType.SizeTypes.Contains(itemType);

    public static bool CanHaveSpot(this ItemType itemType)
       => ItemType.SpotTypes.Contains(itemType);

    public static bool CanHaveTeam(this ItemType itemType)
        => ItemType.TeamTypes.Contains(itemType);

    public static bool CanHaveYear(this BaseballType baseballType)
        => BaseballType.Yearly.Contains(baseballType);

    public static bool CanHaveSendAndReceiveDates(this AcquisitionType acquisitionType)
        => acquisitionType == AcquisitionType.ThroughTheMail;

    public static bool CanImportByYear(this BaseballType baseballType)
        => BaseballType.ImportByYear.Contains(baseballType);

    public static bool CanImportByYearRange(this BaseballType baseballType)
        => BaseballType.ImportByYearRange.Contains(baseballType);

    public static bool IsCommissionerType(this BaseballType baseballType)
        => BaseballType.Commissioner.Contains(baseballType);

    public static bool IsCyYoungAward(this AwardType awardType)
        => AwardType.CyYoungAwards.Contains(awardType);

    public static bool IsDateAccomplishment(this AccomplishmentType accomplishmentType)
         => AccomplishmentType.DateAccomplishment.Any(x => x.Id == accomplishmentType.Id);

    public static bool IsGameWorthly(this BaseballType baseballType)
        => BaseballType.GameWorthly.Contains(baseballType);

    public static bool IsGameWorthly(this GameStyleType gameStyleType)
        => GameStyleType.GameWorthly.Contains(gameStyleType);

    public static bool IsGameWorthlyBaseballBrand(this Brand brand)
        => Brand.GameWorthlyBaseballBrand.Contains(brand);

    public static bool IsLeaguePresidentType(this BaseballType baseballType)
        => BaseballType.LeaguePresident.Contains(baseballType);

    public static bool IsMostValuablePlayerAward(this AwardType awardType)
        => AwardType.MostValuablePlayerAwards.Contains(awardType);

    public static bool IsNavigatable(this AuthenticationCompany authenticationCompany)
        => AuthenticationCompany.Navigatable.Contains(authenticationCompany);

    public static bool IsPersonProject(this ProjectType projectType)
        => ProjectType.PersonProject.Contains(projectType);

    public static bool IsTeamProject(this ProjectType projectType)
        => ProjectType.TeamProject.Contains(projectType);

    public static bool IsWearable(this ItemType itemType)
        => ItemType.WearableTypes.Contains(itemType);

    public static bool IsYearAccomplishment(this AccomplishmentType accomplishmentType)
         => AccomplishmentType.YearAccomplishment.Any(x => x.Id == accomplishmentType.Id);

    public static bool IsYearly(this BaseballType baseballType) 
        => BaseballType.Yearly.Contains(baseballType);
}
