using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GloveTypes;

public record GetGloveType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetGloveType, DomainModel>
    {
        private readonly IDomainRepository<GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetGloveType query)
        {
            return new DomainModel(await _gloveTypeRepository.Get(query.Id));
        }
    }
}
