using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conferences;

public class ConferenceViewModel
{
    private readonly Conference _conference;

    public ConferenceViewModel() { }

    public ConferenceViewModel(Conference conference)
    {
        _conference = conference;
    }

    public string Abbreviation => _conference.Abbreviation;

    public int Id => _conference.Id;

    public string Name => _conference.Name;

    public int SportLeagueLevelId => _conference.SportLeagueLevelId;

    public string SportLeagueLevelName => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;
}
