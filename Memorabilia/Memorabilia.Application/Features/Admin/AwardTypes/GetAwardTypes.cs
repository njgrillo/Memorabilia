namespace Memorabilia.Application.Features.Admin.AwardTypes;

public record GetAwardTypes() : IQuery<Entity.AwardType[]>
{
    public class Handler(IDomainRepository<Entity.AwardType> awardTypeRepository) 
        : QueryHandler<GetAwardTypes, Entity.AwardType[]>
    {
        protected override async Task<Entity.AwardType[]> Handle(GetAwardTypes query)
            => await awardTypeRepository.GetAll();
    }
}
