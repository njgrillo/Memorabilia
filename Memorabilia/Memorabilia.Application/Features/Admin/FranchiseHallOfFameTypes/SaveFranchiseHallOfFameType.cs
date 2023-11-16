namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveFranchiseHallOfFameType(DomainEditModel FranchiseHallOfFameType) : ICommand
{
    public class Handler(IDomainRepository<Entity.FranchiseHallOfFameType> franchiseHallOfFameTypeRepository) 
        : CommandHandler<SaveFranchiseHallOfFameType>
    {
        protected override async Task Handle(SaveFranchiseHallOfFameType request)
        {
            Entity.FranchiseHallOfFameType franchiseHallOfFameType;

            if (request.FranchiseHallOfFameType.IsNew)
            {
                franchiseHallOfFameType = new Entity.FranchiseHallOfFameType(request.FranchiseHallOfFameType.Name, 
                                                                             request.FranchiseHallOfFameType.Abbreviation);
                
                await franchiseHallOfFameTypeRepository.Add(franchiseHallOfFameType);

                return;
            }

            franchiseHallOfFameType = await franchiseHallOfFameTypeRepository.Get(request.FranchiseHallOfFameType.Id);

            if (request.FranchiseHallOfFameType.IsDeleted)
            {
                await franchiseHallOfFameTypeRepository.Delete(franchiseHallOfFameType);

                return;
            }

            franchiseHallOfFameType.Set(request.FranchiseHallOfFameType.Name, 
                                        request.FranchiseHallOfFameType.Abbreviation);

            await franchiseHallOfFameTypeRepository.Update(franchiseHallOfFameType);
        }
    }
}
