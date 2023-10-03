namespace Memorabilia.Application.Features.Admin.Orientations;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetOrientations() : IQuery<Entity.Orientation[]>
{
    public class Handler : QueryHandler<GetOrientations, Entity.Orientation[]>
    {
        private readonly IDomainRepository<Entity.Orientation> _orientationRepository;

        public Handler(IDomainRepository<Entity.Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task<Entity.Orientation[]> Handle(GetOrientations query)
            => await _orientationRepository.GetAll();
    }
}
