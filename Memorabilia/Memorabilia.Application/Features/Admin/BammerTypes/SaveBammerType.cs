namespace Memorabilia.Application.Features.Admin.BammerTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveBammerType(DomainEditModel BammerType) 
    : ICommand
{
    public class Handler(IDomainRepository<Entity.BammerType> bammerTypeRepository) 
        : CommandHandler<SaveBammerType>
    {
        protected override async Task Handle(SaveBammerType request)
        {
            Entity.BammerType bammerType;

            if (request.BammerType.IsNew)
            {
                bammerType = new Entity.BammerType(request.BammerType.Name, 
                                                   request.BammerType.Abbreviation);

                await bammerTypeRepository.Add(bammerType);

                return;
            }

            bammerType = await bammerTypeRepository.Get(request.BammerType.Id);

            if (request.BammerType.IsDeleted)
            {
                await bammerTypeRepository.Delete(bammerType);

                return;
            }

            bammerType.Set(request.BammerType.Name, 
                           request.BammerType.Abbreviation);

            await bammerTypeRepository.Update(bammerType);
        }
    }
}
