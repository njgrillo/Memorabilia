using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Positions;

public record GetPositions() : IQuery<PositionsViewModel>
{
    public class Handler : QueryHandler<GetPositions, PositionsViewModel>
    {
        private readonly IDomainRepository<Position> _positionRepository;

        public Handler(IDomainRepository<Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        protected override async Task<PositionsViewModel> Handle(GetPositions query)
        {
            return new PositionsViewModel(await _positionRepository.GetAll());
        }
    }
}
