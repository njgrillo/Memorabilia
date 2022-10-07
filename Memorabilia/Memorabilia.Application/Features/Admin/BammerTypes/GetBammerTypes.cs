using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BammerTypes;

public class GetBammerTypes
{
    public class Handler : QueryHandler<Query, BammerTypesViewModel>
    {
        private readonly IDomainRepository<BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task<BammerTypesViewModel> Handle(Query query)
        {
            return new BammerTypesViewModel(await _bammerTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<BammerTypesViewModel> { }
}
