namespace Memorabilia.Application.Features.Admin.Division
{
    public class DivisionViewModel
    {
        private readonly Domain.Entities.Division _division;

        public DivisionViewModel() { }

        public DivisionViewModel(Domain.Entities.Division division)
        {
            _division = division;
        }

        public string Abbreviation => _division.Abbreviation;

        public int? ConferenceId => _division.ConferenceId;

        public string ConferenceName => Domain.Constants.Conference.Find(ConferenceId ?? 0)?.Name;

        public int Id => _division.Id;

        public string Name => _division.Name;       
    }
}
