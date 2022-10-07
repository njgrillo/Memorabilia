using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colors;

public class GetColors
{
    public class Handler : QueryHandler<Query, ColorsViewModel>
    {
        private readonly IDomainRepository<Color> _colorRepository;

        public Handler(IDomainRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task<ColorsViewModel> Handle(Query query)
        {
            return new ColorsViewModel(await _colorRepository.GetAll());
        }
    }

    public class Query : IQuery<ColorsViewModel> { }
}
