using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public record GetJerseyTypes() : IQuery<JerseyTypesViewModel>
{
    public class Handler : QueryHandler<GetJerseyTypes, JerseyTypesViewModel>
    {
        private readonly IDomainRepository<JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task<JerseyTypesViewModel> Handle(GetJerseyTypes query)
        {
            return new JerseyTypesViewModel(await _jerseyTypeRepository.GetAll());
        }
    }
}
