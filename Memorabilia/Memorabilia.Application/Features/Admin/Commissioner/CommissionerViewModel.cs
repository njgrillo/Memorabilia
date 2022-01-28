namespace Memorabilia.Application.Features.Admin.Commissioner
{
    public class CommissionerViewModel
    {
        private readonly Domain.Entities.Commissioner _commissioner;

        public CommissionerViewModel() { }

        public CommissionerViewModel(Domain.Entities.Commissioner commissioner)
        {
            _commissioner = commissioner;
        }

        public int? BeginYear => _commissioner.BeginYear;

        public int? EndYear => _commissioner.EndYear;

        public int Id => _commissioner.Id;

        public int PersonId => _commissioner.PersonId;

        public string PersonName => _commissioner.Person.FullName;

        public int SportId => _commissioner.SportId;

        public string SportName => Domain.Constants.Sport.Find(SportId)?.Name;
    }
}
