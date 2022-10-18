using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GloveTypes;

public record GetGloveType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetGloveType, DomainViewModel>
    {
        private readonly IDomainRepository<GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetGloveType query)
        {
            return new DomainViewModel(await _gloveTypeRepository.Get(query.Id));
        }
    }
}
