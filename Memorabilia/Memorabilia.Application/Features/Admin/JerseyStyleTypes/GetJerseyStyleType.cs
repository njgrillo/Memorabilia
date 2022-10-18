using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public record GetJerseyStyleType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetJerseyStyleType, DomainViewModel>
    {
        private readonly IDomainRepository<JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetJerseyStyleType query)
        {
            return new DomainViewModel(await _jerseyStyleTypeRepository.Get(query.Id));
        }
    }
}
