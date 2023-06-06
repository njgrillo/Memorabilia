using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Colleges;

public record GetPersonColleges(College College, Sport Sport) : IQuery<PersonCollegesModel>
{
    public class Handler : QueryHandler<GetPersonColleges, PersonCollegesModel>
    {
        private readonly IPersonCollegeRepository _collegeRepository;

        public Handler(IPersonCollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<PersonCollegesModel> Handle(GetPersonColleges query)
        {
            return new PersonCollegesModel(await _collegeRepository.GetAll(query.College.Id, query.Sport.Id), query.Sport)
            {
                College = query.College
            };
        }
    }
}
