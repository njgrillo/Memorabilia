using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.CerealTypes;

public record GetCerealType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetCerealType, DomainViewModel>
    {
        private readonly IDomainRepository<CerealType> _CerealTypeRepository;

        public Handler(IDomainRepository<CerealType> CerealTypeRepository)
        {
            _CerealTypeRepository = CerealTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetCerealType query)
        {
            return new DomainViewModel(await _CerealTypeRepository.Get(query.Id));
        }
    }
}
