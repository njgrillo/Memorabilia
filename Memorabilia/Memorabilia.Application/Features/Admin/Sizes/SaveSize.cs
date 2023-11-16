namespace Memorabilia.Application.Features.Admin.Sizes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveSize(DomainEditModel Size) : ICommand
{
    public class Handler(IDomainRepository<Entity.Size> sizeRepository) 
        : CommandHandler<SaveSize>
    {
        protected override async Task Handle(SaveSize request)
        {
            Entity.Size size;

            if (request.Size.IsNew)
            {
                size = new Entity.Size(request.Size.Name, 
                                       request.Size.Abbreviation);

                await sizeRepository.Add(size);

                return;
            }

            size = await sizeRepository.Get(request.Size.Id);

            if (request.Size.IsDeleted)
            {
                await sizeRepository.Delete(size);

                return;
            }

            size.Set(request.Size.Name, 
                     request.Size.Abbreviation);

            await sizeRepository.Update(size);
        }
    }
}
