namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveFranchiseHallOfFameType(DomainEditModel FranchiseHallOfFameType) : ICommand
{
    public class Handler : CommandHandler<SaveFranchiseHallOfFameType>
    {
        private readonly IDomainRepository<Entity.FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<Entity.FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task Handle(SaveFranchiseHallOfFameType request)
        {
            Entity.FranchiseHallOfFameType franchiseHallOfFameType;

            if (request.FranchiseHallOfFameType.IsNew)
            {
                franchiseHallOfFameType = new Entity.FranchiseHallOfFameType(request.FranchiseHallOfFameType.Name, 
                                                                             request.FranchiseHallOfFameType.Abbreviation);
                
                await _franchiseHallOfFameTypeRepository.Add(franchiseHallOfFameType);

                return;
            }

            franchiseHallOfFameType = await _franchiseHallOfFameTypeRepository.Get(request.FranchiseHallOfFameType.Id);

            if (request.FranchiseHallOfFameType.IsDeleted)
            {
                await _franchiseHallOfFameTypeRepository.Delete(franchiseHallOfFameType);

                return;
            }

            franchiseHallOfFameType.Set(request.FranchiseHallOfFameType.Name, 
                                        request.FranchiseHallOfFameType.Abbreviation);

            await _franchiseHallOfFameTypeRepository.Update(franchiseHallOfFameType);
        }
    }
}
