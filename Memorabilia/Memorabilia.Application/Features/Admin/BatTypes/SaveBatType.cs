namespace Memorabilia.Application.Features.Admin.BatTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveBatType(DomainEditModel BatType) : ICommand
{
    public class Handler : CommandHandler<SaveBatType>
    {
        private readonly IDomainRepository<Entity.BatType> _batTypeRepository;

        public Handler(IDomainRepository<Entity.BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task Handle(SaveBatType request)
        {
            Entity.BatType batType;

            if (request.BatType.IsNew)
            {
                batType = new Entity.BatType(request.BatType.Name, 
                                             request.BatType.Abbreviation);

                await _batTypeRepository.Add(batType);

                return;
            }

            batType = await _batTypeRepository.Get(request.BatType.Id);

            if (request.BatType.IsDeleted)
            {
                await _batTypeRepository.Delete(batType);

                return;
            }

            batType.Set(request.BatType.Name, 
                        request.BatType.Abbreviation);

            await _batTypeRepository.Update(batType);
        }
    }
}
