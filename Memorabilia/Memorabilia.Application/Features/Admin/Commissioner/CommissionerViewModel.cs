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

        public Domain.Entities.Person Person => _commissioner.Person;

        public int SportLeagueLevelId => _commissioner.SportLeagueLevelId;

        public string SportLeagueLevelName => _commissioner.SportLeagueLevelName;
    }
}
