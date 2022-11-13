namespace Memorabilia.Application.Features.Tools.Shared.Colleges;

public record GetPersonColleges(Domain.Constants.College College, Domain.Constants.SportLeagueLevel SportLeagueLevel) : IQuery<PersonCollegesViewModel>
{
    public class Handler : QueryHandler<GetPersonColleges, PersonCollegesViewModel>
    {
        private readonly IPersonCollegeRepository _collegeRepository;

        public Handler(IPersonCollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<PersonCollegesViewModel> Handle(GetPersonColleges query)
        {
            return new PersonCollegesViewModel(await _collegeRepository.GetAll(query.College.Id, query.SportLeagueLevel.Id), query.SportLeagueLevel)
            {
                College = query.College
            };
        }
    }
}
