namespace Memorabilia.Application.Features.Admin.Conference
{
    public class ConferenceViewModel
    {
        private readonly Domain.Entities.Conference _conference;

        public ConferenceViewModel() { }

        public ConferenceViewModel(Domain.Entities.Conference conference)
        {
            _conference = conference;
        }

        public string Abbreviation => _conference.Abbreviation;

        public int Id => _conference.Id;

        public string Name => _conference.Name;

        public int SportId => _conference.SportId;

        public string SportName => Domain.Constants.Sport.Find(SportId)?.Name;
    }
}
