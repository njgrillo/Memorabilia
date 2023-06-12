namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamDivisionEditModel : EditModel
{
    public TeamDivisionEditModel() { }

    public TeamDivisionEditModel(TeamDivisionModel teamDivision)
    {
        Id = teamDivision.Id;
        Division = Constant.Division.Find(teamDivision.DivisionId);
        TeamId = teamDivision.TeamId;
        BeginYear = teamDivision.BeginYear;
        EndYear = teamDivision.EndYear;
    }

    public int? BeginYear { get; set; }

    public Constant.Division Division { get; set; }

    public string DivisionName 
        => Division?.Name;

    public int? EndYear { get; set; }

    public int TeamId { get; set; }
}
