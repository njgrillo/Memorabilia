using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colors;

public record GetColors() : IQuery<ColorsViewModel>
{
    public class Handler : QueryHandler<GetColors, ColorsViewModel>
    {
        private readonly IDomainRepository<Color> _colorRepository;

        public Handler(IDomainRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task<ColorsViewModel> Handle(GetColors query)
        {
            return new ColorsViewModel(await _colorRepository.GetAll());
        }
    }
}
