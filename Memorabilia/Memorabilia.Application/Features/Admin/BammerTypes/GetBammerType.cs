namespace Memorabilia.Application.Features.Admin.BammerTypes;

public record GetBammerType(int Id) : IQuery<Entity.BammerType>
{
    public class Handler : QueryHandler<GetBammerType, Entity.BammerType>
    {
        private readonly IDomainRepository<Entity.BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<Entity.BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task<Entity.BammerType> Handle(GetBammerType query)
            => await _bammerTypeRepository.Get(query.Id);
    }
}
