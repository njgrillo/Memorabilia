namespace Memorabilia.MinimalAPI.Extensions;

public static class DomainModelExtensions
{
    public static CommissionerApiModel ToModel(this Entity.Commissioner commissioner)
        => new(commissioner);

    public static CommissionerApiModel[] ToModelArray(this Entity.Commissioner[] commissioners)
        => commissioners.Select(commissioner => commissioner.ToModel()).ToArray();

    public static LeaguePresidentApiModel ToModel(this Entity.LeaguePresident leaguePresident)
        => new(leaguePresident);

    public static LeaguePresidentApiModel[] ToModelArray(this Entity.LeaguePresident[] leaguePresidents)
        => leaguePresidents.Select(leaguePresident => leaguePresident.ToModel()).ToArray();

    public static PersonApiModel ToModel(this Entity.Person person)
       => new(person);
}
