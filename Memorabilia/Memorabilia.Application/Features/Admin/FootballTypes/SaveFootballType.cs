namespace Memorabilia.Application.Features.Admin.FootballTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveFootballType(DomainEditModel FootballType) : ICommand
{
    public class Handler : CommandHandler<SaveFootballType>
    {
        private readonly IDomainRepository<Entity.FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<Entity.FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task Handle(SaveFootballType request)
        {
            Entity.FootballType footballType;

            if (request.FootballType.IsNew)
            {
                footballType = new Entity.FootballType(request.FootballType.Name, 
                                                       request.FootballType.Abbreviation);

                await _footballTypeRepository.Add(footballType);

                return;
            }

            footballType = await _footballTypeRepository.Get(request.FootballType.Id);

            if (request.FootballType.IsDeleted)
            {
                await _footballTypeRepository.Delete(footballType);

                return;
            }

            footballType.Set(request.FootballType.Name, 
                             request.FootballType.Abbreviation);

            await _footballTypeRepository.Update(footballType);
        }
    }
}
