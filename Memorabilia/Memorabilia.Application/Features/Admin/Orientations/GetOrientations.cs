using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Orientations;

public record GetOrientations() : IQuery<OrientationsViewModel>
{
    public class Handler : QueryHandler<GetOrientations, OrientationsViewModel>
    {
        private readonly IDomainRepository<Orientation> _orientationRepository;

        public Handler(IDomainRepository<Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task<OrientationsViewModel> Handle(GetOrientations query)
        {
            return new OrientationsViewModel(await _orientationRepository.GetAll());
        }
    }
}
