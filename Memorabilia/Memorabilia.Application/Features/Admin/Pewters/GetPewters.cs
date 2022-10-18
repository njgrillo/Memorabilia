using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Pewters;

public record GetPewters() : IQuery<PewtersViewModel>
{
    public class Handler : QueryHandler<GetPewters, PewtersViewModel>
    {
        private readonly IDomainRepository<Pewter> _pewterRepository;

        public Handler(IDomainRepository<Pewter> pewterRepository)
        {
            _pewterRepository = pewterRepository;
        }

        protected override async Task<PewtersViewModel> Handle(GetPewters query)
        {
            var pewters = (await _pewterRepository.GetAll())
                                .OrderBy(pewter => pewter.FranchiseName)
                                .ThenBy(pewter => pewter.Team.Name)
                                .ThenBy(pewter => pewter.SizeName)
                                .ThenBy(pewter => pewter.ImageTypeName);

            return new PewtersViewModel(pewters);
        }
    }
}
