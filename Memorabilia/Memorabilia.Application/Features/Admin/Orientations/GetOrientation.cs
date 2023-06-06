using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Orientations;

public record GetOrientation(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetOrientation, DomainModel>
    {
        private readonly IDomainRepository<Orientation> _orientationRepository;

        public Handler(IDomainRepository<Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task<DomainModel> Handle(GetOrientation query)
        {
            return new DomainModel(await _orientationRepository.Get(query.Id));
        }
    }
}
