namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public record GetHelmetFinish(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.HelmetFinish> helmetFinishRepository) 
        : QueryHandler<GetHelmetFinish, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetHelmetFinish query)
            => await helmetFinishRepository.Get(query.Id);
    }
}
