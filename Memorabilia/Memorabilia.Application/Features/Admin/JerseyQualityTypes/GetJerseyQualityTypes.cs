using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public class GetJerseyQualityTypes
{
    public class Handler : QueryHandler<Query, JerseyQualityTypesViewModel>
    {
        private readonly IDomainRepository<JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task<JerseyQualityTypesViewModel> Handle(Query query)
        {
            return new JerseyQualityTypesViewModel(await _jerseyQualityTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<JerseyQualityTypesViewModel> { }
}
