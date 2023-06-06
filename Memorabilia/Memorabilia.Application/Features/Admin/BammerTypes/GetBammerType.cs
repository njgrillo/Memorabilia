using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BammerTypes;

public record GetBammerType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetBammerType, DomainModel>
    {
        private readonly IDomainRepository<BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetBammerType query)
        {
            return new DomainModel(await _bammerTypeRepository.Get(query.Id));
        }
    }
}
