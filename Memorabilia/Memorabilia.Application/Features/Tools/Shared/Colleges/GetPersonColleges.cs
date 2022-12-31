using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Colleges;

public record GetPersonColleges(College College, Sport Sport) : IQuery<PersonCollegesViewModel>
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
            return new PersonCollegesViewModel(await _collegeRepository.GetAll(query.College.Id, query.Sport.Id), query.Sport)
            {
                College = query.College
            };
        }
    }
}
