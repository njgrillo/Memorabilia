namespace Memorabilia.Application.Features.Admin.Colors;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveColor(DomainEditModel Color) : ICommand
{
    public class Handler(IDomainRepository<Entity.Color> colorRepository) 
        : CommandHandler<SaveColor>
    {
        protected override async Task Handle(SaveColor request)
        {
            Entity.Color color;

            if (request.Color.IsNew)
            {
                color = new Entity.Color(request.Color.Name, 
                                         request.Color.Abbreviation);

                await colorRepository.Add(color);

                return;
            }

            color = await colorRepository.Get(request.Color.Id);

            if (request.Color.IsDeleted)
            {
                await colorRepository.Delete(color);

                return;
            }

            color.Set(request.Color.Name, 
                      request.Color.Abbreviation);

            await colorRepository.Update(color);
        }
    }
}
