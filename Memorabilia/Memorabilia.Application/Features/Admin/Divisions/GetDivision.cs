using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Divisions;

public record GetDivision(int Id) : IQuery<DivisionViewModel>
{
    public class Handler : QueryHandler<GetDivision, DivisionViewModel>
    {
        private readonly IDomainRepository<Division> _divisionRepository;

        public Handler(IDomainRepository<Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        protected override async Task<DivisionViewModel> Handle(GetDivision query)
        {
            return new DivisionViewModel(await _divisionRepository.Get(query.Id));
        }
    }
}
