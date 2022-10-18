using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public record GetJerseyQualityType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetJerseyQualityType, DomainViewModel>
    {
        private readonly IDomainRepository<JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetJerseyQualityType query)
        {
            return new DomainViewModel(await _jerseyQualityTypeRepository.Get(query.Id));
        }
    }
}
