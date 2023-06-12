namespace Memorabilia.Application.Features.Admin.CerealTypes;

public record GetCerealType(int Id) : IQuery<Entity.CerealType>
{
    public class Handler : QueryHandler<GetCerealType, Entity.CerealType>
    {
        private readonly IDomainRepository<Entity.CerealType> _CerealTypeRepository;

        public Handler(IDomainRepository<Entity.CerealType> CerealTypeRepository)
        {
            _CerealTypeRepository = CerealTypeRepository;
        }

        protected override async Task<Entity.CerealType> Handle(GetCerealType query)
            => await _CerealTypeRepository.Get(query.Id);
    }
}
