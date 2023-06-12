namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamDivisionModel
{
    private readonly Entity.TeamDivision _teamDivision;

    public TeamDivisionModel() { }

    public TeamDivisionModel(Entity.TeamDivision teamDivision)
    {
        _teamDivision = teamDivision;
    }

    public int? BeginYear 
        => _teamDivision.BeginYear;

    public int DivisionId
        => _teamDivision.DivisionId;

    public int? EndYear 
        => _teamDivision.EndYear;

    public int Id 
        => _teamDivision.Id;

    public int TeamId 
        => _teamDivision.TeamId;
}
