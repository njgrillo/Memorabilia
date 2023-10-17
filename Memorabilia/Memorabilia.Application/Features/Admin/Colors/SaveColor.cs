namespace Memorabilia.Application.Features.Admin.Colors;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveColor(DomainEditModel Color) : ICommand
{
    public class Handler : CommandHandler<SaveColor>
    {
        private readonly IDomainRepository<Entity.Color> _colorRepository;

        public Handler(IDomainRepository<Entity.Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task Handle(SaveColor request)
        {
            Entity.Color color;

            if (request.Color.IsNew)
            {
                color = new Entity.Color(request.Color.Name, 
                                         request.Color.Abbreviation);

                await _colorRepository.Add(color);

                return;
            }

            color = await _colorRepository.Get(request.Color.Id);

            if (request.Color.IsDeleted)
            {
                await _colorRepository.Delete(color);

                return;
            }

            color.Set(request.Color.Name, 
                      request.Color.Abbreviation);

            await _colorRepository.Update(color);
        }
    }
}
