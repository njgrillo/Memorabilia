using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.CerealTypes;

public record GetCerealType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetCerealType, DomainModel>
    {
        private readonly IDomainRepository<CerealType> _CerealTypeRepository;

        public Handler(IDomainRepository<CerealType> CerealTypeRepository)
        {
            _CerealTypeRepository = CerealTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetCerealType query)
        {
            return new DomainModel(await _CerealTypeRepository.Get(query.Id));
        }
    }
}
