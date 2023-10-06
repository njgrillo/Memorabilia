namespace Memorabilia.Application.Features.Admin.Orientations;

public record GetOrientation(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetOrientation, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.Orientation> _orientationRepository;

        public Handler(IDomainRepository<Entity.Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetOrientation query)
            => await _orientationRepository.Get(query.Id);
    }
}
