using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public class GetFigureSpecialtyType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _figureSpecialtyTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
