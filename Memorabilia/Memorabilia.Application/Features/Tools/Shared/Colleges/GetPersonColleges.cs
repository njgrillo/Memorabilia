namespace Memorabilia.Application.Features.Tools.Shared.Colleges;

public record GetPersonColleges(Constant.College College, Constant.Sport Sport) 
    : IQuery<Entity.PersonCollege[]>
{
    public class Handler(IPersonCollegeRepository collegeRepository) 
        : QueryHandler<GetPersonColleges, Entity.PersonCollege[]>
    {
        protected override async Task<Entity.PersonCollege[]> Handle(GetPersonColleges query)
            => (await collegeRepository.GetAll(query.College.Id, query.Sport.Id))
                    .ToArray();
    }
}
