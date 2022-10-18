using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colors;

public record GetColor(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetColor, DomainViewModel>
    {
        private readonly IDomainRepository<Color> _colorRepository;

        public Handler(IDomainRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetColor query)
        {
            return new DomainViewModel(await _colorRepository.Get(query.Id));
        }
    }
}
