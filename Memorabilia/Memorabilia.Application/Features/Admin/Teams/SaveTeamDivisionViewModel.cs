using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamDivisionViewModel : SaveViewModel
{
    public SaveTeamDivisionViewModel() { }

    public SaveTeamDivisionViewModel(TeamDivisionViewModel teamDivision)
    {
        Id = teamDivision.Id;
        Division = Division.Find(teamDivision.DivisionId);
        TeamId = teamDivision.TeamId;
        BeginYear = teamDivision.BeginYear;
        EndYear = teamDivision.EndYear;
    }

    public int? BeginYear { get; set; }

    public Division Division { get; set; }

    public string DivisionName => Division?.Name;

    public int? EndYear { get; set; }

    public int TeamId { get; set; }
}
