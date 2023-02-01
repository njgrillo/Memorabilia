using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.CerealTypes;

public record GetCerealTypes() : IQuery<CerealTypesViewModel>
{
    public class Handler : QueryHandler<GetCerealTypes, CerealTypesViewModel>
    {
        private readonly IDomainRepository<CerealType> _CerealTypeRepository;

        public Handler(IDomainRepository<CerealType> CerealTypeRepository)
        {
            _CerealTypeRepository = CerealTypeRepository;
        }

        protected override async Task<CerealTypesViewModel> Handle(GetCerealTypes query)
        {
            return new CerealTypesViewModel(await _CerealTypeRepository.GetAll());
        }
    }
}
