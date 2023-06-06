using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Orientations;

public record SaveOrientation(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveOrientation>
    {
        private readonly IDomainRepository<Orientation> _orientationRepository;

        public Handler(IDomainRepository<Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task Handle(SaveOrientation request)
        {
            Orientation orientation;

            if (request.ViewModel.IsNew)
            {
                orientation = new Orientation(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _orientationRepository.Add(orientation);

                return;
            }

            orientation = await _orientationRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _orientationRepository.Delete(orientation);

                return;
            }

            orientation.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _orientationRepository.Update(orientation);
        }
    }
}
