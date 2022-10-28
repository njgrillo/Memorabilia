using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Divisions;

public class DivisionViewModel
{
    private readonly Division _division;

    public DivisionViewModel() { }

    public DivisionViewModel(Division division)
    {
        _division = division;
    }

    public string Abbreviation => _division.Abbreviation;

    public Domain.Constants.Conference Conference => Domain.Constants.Conference.Find(ConferenceId ?? 0);

    public int? ConferenceId => _division.ConferenceId;

    public string ConferenceName => Conference != null && !Conference.Name.IsNullOrEmpty() ? Conference.Name : "N/A";

    public int Id => _division.Id;

    public int? LeagueId => _division.LeagueId;

    public string LeagueName => Domain.Constants.League.Find(LeagueId ?? 0)?.Name;  

    public string Name => _division.Name;       
}
