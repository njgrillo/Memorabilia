namespace Memorabilia.Application.Features.Admin.Franchises;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveFranchise(FranchiseEditModel Franchise) : ICommand
{
    public class Handler(IDomainRepository<Entity.Franchise> franchiseRepository) 
        : CommandHandler<SaveFranchise>
    {
        protected override async Task Handle(SaveFranchise request)
        {
            Entity.Franchise franchise;

            if (request.Franchise.IsNew)
            {
                franchise = new Entity.Franchise(request.Franchise.SportLeagueLevelId,
                                                 request.Franchise.Name,
                                                 request.Franchise.Location,
                                                 request.Franchise.FoundYear);

                await franchiseRepository.Add(franchise);

                return;
            }

            franchise = await franchiseRepository.Get(request.Franchise.Id);

            if (request.Franchise.IsDeleted)
            {
                await franchiseRepository.Delete(franchise);

                return;
            }

            franchise.Set(request.Franchise.Name, 
                          request.Franchise.Location, 
                          request.Franchise.FoundYear);

            await franchiseRepository.Update(franchise);
        }
    }
}
