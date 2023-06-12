namespace Memorabilia.Application.Features.Tools.Shared.Colleges;

public record GetPersonColleges(Constant.College College, Constant.Sport Sport) 
    : IQuery<Entity.PersonCollege[]>
{
    public class Handler : QueryHandler<GetPersonColleges, Entity.PersonCollege[]>
    {
        private readonly IPersonCollegeRepository _collegeRepository;

        public Handler(IPersonCollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<Entity.PersonCollege[]> Handle(GetPersonColleges query)
            => (await _collegeRepository.GetAll(query.College.Id, query.Sport.Id))
                    .ToArray();
    }
}
