using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Orientations;

public class GetOrientations
{
    public class Handler : QueryHandler<Query, OrientationsViewModel>
    {
        private readonly IDomainRepository<Orientation> _orientationRepository;

        public Handler(IDomainRepository<Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task<OrientationsViewModel> Handle(Query query)
        {
            return new OrientationsViewModel(await _orientationRepository.GetAll());
        }
    }

    public class Query : IQuery<OrientationsViewModel> { }
}
