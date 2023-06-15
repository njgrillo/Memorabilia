namespace Memorabilia.MinimalAPI.Extensions;

public static class DomainModelExtensions
{
    public static CommissionerAPIModel ToModel(this Entity.Commissioner commissioner)
        => new(commissioner);

    public static CommissionerAPIModel[] ToModelArray(this Entity.Commissioner[] commissioners)
        => commissioners.Select(commissioner => commissioner.ToModel()).ToArray();

    public static LeaguePresidentAPIModel ToModel(this Entity.LeaguePresident leaguePresident)
        => new(leaguePresident);

    public static LeaguePresidentAPIModel[] ToModelArray(this Entity.LeaguePresident[] leaguePresidents)
        => leaguePresidents.Select(leaguePresident => leaguePresident.ToModel()).ToArray();
}
