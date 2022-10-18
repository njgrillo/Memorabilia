using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BammerTypes;

public record GetBammerTypes() : IQuery<BammerTypesViewModel>
{
    public class Handler : QueryHandler<GetBammerTypes, BammerTypesViewModel>
    {
        private readonly IDomainRepository<BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task<BammerTypesViewModel> Handle(GetBammerTypes query)
        {
            return new BammerTypesViewModel(await _bammerTypeRepository.GetAll());
        }
    }
}
