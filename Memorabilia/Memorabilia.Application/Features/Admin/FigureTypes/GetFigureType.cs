using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureTypes;

public class GetFigureType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _figureTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
