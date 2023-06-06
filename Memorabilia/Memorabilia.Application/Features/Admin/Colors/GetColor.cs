using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colors;

public record GetColor(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetColor, DomainModel>
    {
        private readonly IDomainRepository<Color> _colorRepository;

        public Handler(IDomainRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task<DomainModel> Handle(GetColor query)
        {
            return new DomainModel(await _colorRepository.Get(query.Id));
        }
    }
}
