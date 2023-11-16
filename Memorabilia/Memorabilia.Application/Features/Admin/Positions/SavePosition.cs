namespace Memorabilia.Application.Features.Admin.Positions;

[AuthorizeByRole(Enum.Role.Admin)]
public record SavePosition(PositionEditModel Position) : ICommand
{
    public class Handler(IDomainRepository<Entity.Position> positionRepository) 
        : CommandHandler<SavePosition>
    {
        protected override async Task Handle(SavePosition request)
        {
            Entity.Position position;

            if (request.Position.IsNew)
            {
                position = new Entity.Position(request.Position.SportId,
                                               request.Position.Name,
                                               request.Position.Abbreviation);

                await positionRepository.Add(position);

                return;
            }

            position = await positionRepository.Get(request.Position.Id);

            if (request.Position.IsDeleted)
            {
                await positionRepository.Delete(position);

                return;
            }

            position.Set(request.Position.SportId,
                         request.Position.Name,
                         request.Position.Abbreviation);

            await positionRepository.Update(position);
        }
    }
}
