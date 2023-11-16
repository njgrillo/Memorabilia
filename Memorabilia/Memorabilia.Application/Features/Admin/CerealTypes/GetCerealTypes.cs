namespace Memorabilia.Application.Features.Admin.CerealTypes;

public record GetCerealTypes() : IQuery<Entity.CerealType[]>
{
    public class Handler(IDomainRepository<Entity.CerealType> CerealTypeRepository) 
        : QueryHandler<GetCerealTypes, Entity.CerealType[]>
    {
        protected override async Task<Entity.CerealType[]> Handle(GetCerealTypes query)
            => await CerealTypeRepository.GetAll();
    }
}
