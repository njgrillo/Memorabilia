namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class ChampionshipProfileModel(Entity.Champion champion)
{
    public int ChampionshipTypeId 
        => champion.ChampionTypeId;

    public string ChampionshipTypeName 
        => Constant.ChampionType.Find(ChampionshipTypeId)?.Name;

    public int TeamId 
        => champion.TeamId;

    public string TeamName 
        => $"{champion.Team?.Location} {champion.Team?.Name}";        

    public int Year 
        => champion.Year;

    public bool Filter(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
               (isNumeric && Year == year) ||
               ChampionshipTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               TeamName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
