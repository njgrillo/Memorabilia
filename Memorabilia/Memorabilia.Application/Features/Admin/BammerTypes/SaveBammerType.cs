namespace Memorabilia.Application.Features.Admin.BammerTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveBammerType(DomainEditModel BammerType) : ICommand
{
    public class Handler : CommandHandler<SaveBammerType>
    {
        private readonly IDomainRepository<Entity.BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<Entity.BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task Handle(SaveBammerType request)
        {
            Entity.BammerType bammerType;

            if (request.BammerType.IsNew)
            {
                bammerType = new Entity.BammerType(request.BammerType.Name, 
                                                   request.BammerType.Abbreviation);

                await _bammerTypeRepository.Add(bammerType);

                return;
            }

            bammerType = await _bammerTypeRepository.Get(request.BammerType.Id);

            if (request.BammerType.IsDeleted)
            {
                await _bammerTypeRepository.Delete(bammerType);

                return;
            }

            bammerType.Set(request.BammerType.Name, 
                           request.BammerType.Abbreviation);

            await _bammerTypeRepository.Update(bammerType);
        }
    }
}
