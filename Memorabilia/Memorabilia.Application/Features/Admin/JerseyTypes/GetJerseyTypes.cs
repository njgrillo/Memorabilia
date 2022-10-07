using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public class GetJerseyTypes
{
    public class Handler : QueryHandler<Query, JerseyTypesViewModel>
    {
        private readonly IDomainRepository<JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task<JerseyTypesViewModel> Handle(Query query)
        {
            return new JerseyTypesViewModel(await _jerseyTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<JerseyTypesViewModel> { }
}
