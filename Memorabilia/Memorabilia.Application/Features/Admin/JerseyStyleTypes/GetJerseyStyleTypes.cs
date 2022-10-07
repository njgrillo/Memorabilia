using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public class GetJerseyStyleTypes
{
    public class Handler : QueryHandler<Query, JerseyStyleTypesViewModel>
    {
        private readonly IDomainRepository<JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task<JerseyStyleTypesViewModel> Handle(Query query)
        {
            return new JerseyStyleTypesViewModel(await _jerseyStyleTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<JerseyStyleTypesViewModel> { }
}
