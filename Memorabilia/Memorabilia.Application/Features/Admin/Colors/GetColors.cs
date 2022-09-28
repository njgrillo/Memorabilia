namespace Memorabilia.Application.Features.Admin.Colors
{
    public class GetColors
    {
        public class Handler : QueryHandler<Query, ColorsViewModel>
        {
            private readonly IColorRepository _colorRepository;

            public Handler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            protected override async Task<ColorsViewModel> Handle(Query query)
            {
                return new ColorsViewModel(await _colorRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ColorsViewModel> { }
    }
}
