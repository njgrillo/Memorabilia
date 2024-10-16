namespace Memorabilia.Application.Features.Admin.Colleges;

public record GetCollege(int Id) : IQuery<Entity.College>
{
    public class Handler(IDomainRepository<Entity.College> collegeRepository) 
        : QueryHandler<GetCollege, Entity.College>
    {
        protected override async Task<Entity.College> Handle(GetCollege query)
            => await collegeRepository.Get(query.Id);
    }
}
