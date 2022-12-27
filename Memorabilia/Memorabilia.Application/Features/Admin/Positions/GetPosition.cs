using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Positions;

public record GetPosition(int Id) : IQuery<PositionViewModel>
{
    public class Handler : QueryHandler<GetPosition, PositionViewModel>
    {
        private readonly IDomainRepository<Position> _positionRepository;

        public Handler(IDomainRepository<Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        protected override async Task<PositionViewModel> Handle(GetPosition query)
        {
            return new PositionViewModel(await _positionRepository.Get(query.Id));
        }
    }
}
