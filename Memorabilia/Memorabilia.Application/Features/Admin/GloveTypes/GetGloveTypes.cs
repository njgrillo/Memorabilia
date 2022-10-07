using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GloveTypes;

public class GetGloveTypes
{
    public class Handler : QueryHandler<Query, GloveTypesViewModel>
    {
        private readonly IDomainRepository<GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task<GloveTypesViewModel> Handle(Query query)
        {
            return new GloveTypesViewModel(await _gloveTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<GloveTypesViewModel> { }
}
