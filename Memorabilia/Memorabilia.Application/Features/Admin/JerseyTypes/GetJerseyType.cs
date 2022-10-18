using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public record GetJerseyType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetJerseyType, DomainViewModel>
    {
        private readonly IDomainRepository<JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetJerseyType query)
        {
            return new DomainViewModel(await _jerseyTypeRepository.Get(query.Id));
        }
    }
}
