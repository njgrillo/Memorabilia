using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GloveTypes;

public record GetGloveTypes() : IQuery<GloveTypesViewModel>
{
    public class Handler : QueryHandler<GetGloveTypes, GloveTypesViewModel>
    {
        private readonly IDomainRepository<GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task<GloveTypesViewModel> Handle(GetGloveTypes query)
        {
            return new GloveTypesViewModel(await _gloveTypeRepository.GetAll());
        }
    }
}
