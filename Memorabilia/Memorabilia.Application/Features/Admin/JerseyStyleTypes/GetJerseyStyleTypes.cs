using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public record GetJerseyStyleTypes() : IQuery<JerseyStyleTypesViewModel>
{
    public class Handler : QueryHandler<GetJerseyStyleTypes, JerseyStyleTypesViewModel>
    {
        private readonly IDomainRepository<JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task<JerseyStyleTypesViewModel> Handle(GetJerseyStyleTypes query)
        {
            return new JerseyStyleTypesViewModel(await _jerseyStyleTypeRepository.GetAll());
        }
    }
}
