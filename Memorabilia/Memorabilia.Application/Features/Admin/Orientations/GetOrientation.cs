using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Orientations;

public record GetOrientation(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetOrientation, DomainViewModel>
    {
        private readonly IDomainRepository<Orientation> _orientationRepository;

        public Handler(IDomainRepository<Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetOrientation query)
        {
            return new DomainViewModel(await _orientationRepository.Get(query.Id));
        }
    }
}
