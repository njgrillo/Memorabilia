namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamChampionshipEditModel : EditModel
{
    public TeamChampionshipEditModel() { }

    public TeamChampionshipEditModel(TeamChampionshipModel teamChampionship)
    {
        Id = teamChampionship.Id;
        ChampionshipTypeId = teamChampionship.ChampionTypeId;
        SportLeagueLevelId = teamChampionship.SportLeagueLevelId;
        TeamId = teamChampionship.TeamId;
        Year = teamChampionship.Year;
    }        

    public int ChampionshipTypeId { get; set; }

    public string ChampionshipTypeName 
        => Constant.ChampionType.Find(ChampionshipTypeId)?.Name;

    public int SportLeagueLevelId { get; }

    public int TeamId { get; set; }

    public int Year { get; set; }
}
