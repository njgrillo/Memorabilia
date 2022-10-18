using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colors;

public record SaveColor(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveColor>
    {
        private readonly IDomainRepository<Color> _colorRepository;

        public Handler(IDomainRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task Handle(SaveColor request)
        {
            Color color;

            if (request.ViewModel.IsNew)
            {
                color = new Color(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _colorRepository.Add(color);

                return;
            }

            color = await _colorRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _colorRepository.Delete(color);

                return;
            }

            color.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _colorRepository.Update(color);
        }
    }
}
