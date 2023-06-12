namespace Memorabilia.Application.Features.Admin.BammerTypes;

public record GetBammerTypes() : IQuery<Entity.BammerType[]>
{
    public class Handler : QueryHandler<GetBammerTypes, Entity.BammerType[]>
    {
        private readonly IDomainRepository<Entity.BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<Entity.BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task<Entity.BammerType[]> Handle(GetBammerTypes query)
            => (await _bammerTypeRepository.GetAll()).ToArray();
    }
}
