using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public record GetJerseyQualityTypes() : IQuery<JerseyQualityTypesViewModel>
{
    public class Handler : QueryHandler<GetJerseyQualityTypes, JerseyQualityTypesViewModel>
    {
        private readonly IDomainRepository<JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task<JerseyQualityTypesViewModel> Handle(GetJerseyQualityTypes query)
        {
            return new JerseyQualityTypesViewModel(await _jerseyQualityTypeRepository.GetAll());
        }
    }
}
