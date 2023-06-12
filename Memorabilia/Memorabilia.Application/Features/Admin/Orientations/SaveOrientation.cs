namespace Memorabilia.Application.Features.Admin.Orientations;

public record SaveOrientation(DomainEditModel Orientation) : ICommand
{
    public class Handler : CommandHandler<SaveOrientation>
    {
        private readonly IDomainRepository<Entity.Orientation> _orientationRepository;

        public Handler(IDomainRepository<Entity.Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task Handle(SaveOrientation request)
        {
            Entity.Orientation orientation;

            if (request.Orientation.IsNew)
            {
                orientation = new Entity.Orientation(request.Orientation.Name, 
                                                     request.Orientation.Abbreviation);

                await _orientationRepository.Add(orientation);

                return;
            }

            orientation = await _orientationRepository.Get(request.Orientation.Id);

            if (request.Orientation.IsDeleted)
            {
                await _orientationRepository.Delete(orientation);

                return;
            }

            orientation.Set(request.Orientation.Name, 
                            request.Orientation.Abbreviation);

            await _orientationRepository.Update(orientation);
        }
    }
}
