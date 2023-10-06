namespace Memorabilia.Application.Features.Admin.Positions;

[AuthorizeByRole(Enum.Role.Admin)]
public record SavePosition(PositionEditModel Position) : ICommand
{
    public class Handler : CommandHandler<SavePosition>
    {
        private readonly IDomainRepository<Entity.Position> _positionRepository;

        public Handler(IDomainRepository<Entity.Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        protected override async Task Handle(SavePosition request)
        {
            Entity.Position position;

            if (request.Position.IsNew)
            {
                position = new Entity.Position(request.Position.SportId,
                                               request.Position.Name,
                                               request.Position.Abbreviation);

                await _positionRepository.Add(position);

                return;
            }

            position = await _positionRepository.Get(request.Position.Id);

            if (request.Position.IsDeleted)
            {
                await _positionRepository.Delete(position);

                return;
            }

            position.Set(request.Position.SportId,
                         request.Position.Name,
                         request.Position.Abbreviation);

            await _positionRepository.Update(position);
        }
    }
}
