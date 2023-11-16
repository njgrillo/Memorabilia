namespace Memorabilia.Application.Features.Admin.Colleges;

public record GetColleges() : IQuery<Entity.College[]>
{
    public class Handler(IDomainRepository<Entity.College> collegeRepository) 
        : QueryHandler<GetColleges, Entity.College[]>
    {
        protected override async Task<Entity.College[]> Handle(GetColleges query)
            => await collegeRepository.GetAll();
    }
}
