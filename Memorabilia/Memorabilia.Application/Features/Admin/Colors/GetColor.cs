using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colors;

public class GetColor
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<Color> _colorRepository;

        public Handler(IDomainRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _colorRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
