using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BammerTypes;

public record GetBammerType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetBammerType, DomainViewModel>
    {
        private readonly IDomainRepository<BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetBammerType query)
        {
            return new DomainViewModel(await _bammerTypeRepository.Get(query.Id));
        }
    }
}
