namespace Memorabilia.Application.Features.Admin.BaseballTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveBaseballType(DomainEditModel BaseballType) : ICommand
{
    public class Handler : CommandHandler<SaveBaseballType>
    {
        private readonly IDomainRepository<Entity.BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<Entity.BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task Handle(SaveBaseballType request)
        {
            Entity.BaseballType baseballType;

            if (request.BaseballType.IsNew)
            {
                baseballType = new Entity.BaseballType(request.BaseballType.Name, 
                                                       request.BaseballType.Abbreviation);

                await _baseballTypeRepository.Add(baseballType);

                return;
            }

            baseballType = await _baseballTypeRepository.Get(request.BaseballType.Id);

            if (request.BaseballType.IsDeleted)
            {
                await _baseballTypeRepository.Delete(baseballType);

                return;
            }

            baseballType.Set(request.BaseballType.Name, 
                             request.BaseballType.Abbreviation);

            await _baseballTypeRepository.Update(baseballType);
        }
    }
}
