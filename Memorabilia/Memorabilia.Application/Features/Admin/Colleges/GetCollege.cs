namespace Memorabilia.Application.Features.Admin.Colleges;

public record GetCollege(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.College> collegeRepository) 
        : QueryHandler<GetCollege, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetCollege query)
            => await collegeRepository.Get(query.Id);
    }
}
