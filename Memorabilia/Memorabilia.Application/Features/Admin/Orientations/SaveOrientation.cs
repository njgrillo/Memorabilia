namespace Memorabilia.Application.Features.Admin.Orientations;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveOrientation(DomainEditModel Orientation) : ICommand
{
    public class Handler(IDomainRepository<Entity.Orientation> orientationRepository) 
        : CommandHandler<SaveOrientation>
    {
        protected override async Task Handle(SaveOrientation request)
        {
            Entity.Orientation orientation;

            if (request.Orientation.IsNew)
            {
                orientation = new Entity.Orientation(request.Orientation.Name, 
                                                     request.Orientation.Abbreviation);

                await orientationRepository.Add(orientation);

                return;
            }

            orientation = await orientationRepository.Get(request.Orientation.Id);

            if (request.Orientation.IsDeleted)
            {
                await orientationRepository.Delete(orientation);

                return;
            }

            orientation.Set(request.Orientation.Name, 
                            request.Orientation.Abbreviation);

            await orientationRepository.Update(orientation);
        }
    }
}
