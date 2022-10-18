using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Pewters;

public record GetPewter(int Id) : IQuery<PewterViewModel>
{
    public class Handler : QueryHandler<GetPewter, PewterViewModel>
    {
        private readonly IDomainRepository<Pewter> _pewterRepository;

        public Handler(IDomainRepository<Pewter> pewterRepository)
        {
            _pewterRepository = pewterRepository;
        }

        protected override async Task<PewterViewModel> Handle(GetPewter query)
        {
            return new PewterViewModel(await _pewterRepository.Get(query.Id));
        }
    }
}
