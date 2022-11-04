namespace Memorabilia.Application.Features.Tools.Baseball.Colleges;

public record GetPersonColleges(int CollegeId, int SportLeagueLevelId) : IQuery<PersonCollegesViewModel>
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
            return new PersonCollegesViewModel(await _collegeRepository.GetAll(query.CollegeId, query.SportLeagueLevelId))
            {
                CollegeId = query.CollegeId
            };
        }
    }
}
