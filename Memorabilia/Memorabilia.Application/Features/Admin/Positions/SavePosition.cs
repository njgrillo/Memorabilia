using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Positions;

public record SavePosition(SavePositionViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SavePosition>
    {
        private readonly IDomainRepository<Position> _positionRepository;

        public Handler(IDomainRepository<Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        protected override async Task Handle(SavePosition request)
        {
            Position position;

            if (request.ViewModel.IsNew)
            {
                position = new Position(request.ViewModel.SportId,
                                        request.ViewModel.Name,
                                        request.ViewModel.Abbreviation);

                await _positionRepository.Add(position);

                return;
            }

            position = await _positionRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _positionRepository.Delete(position);

                return;
            }

            position.Set(request.ViewModel.SportId,
                         request.ViewModel.Name,
                         request.ViewModel.Abbreviation);

            await _positionRepository.Update(position);
        }
    }
}
