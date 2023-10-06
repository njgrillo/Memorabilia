namespace Memorabilia.Application.Features.Admin.Franchises;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveFranchise(FranchiseEditModel Franchise) : ICommand
{
    public class Handler : CommandHandler<SaveFranchise>
    {
        private readonly IDomainRepository<Entity.Franchise> _franchiseRepository;

        public Handler(IDomainRepository<Entity.Franchise> franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        protected override async Task Handle(SaveFranchise request)
        {
            Entity.Franchise franchise;

            if (request.Franchise.IsNew)
            {
                franchise = new Entity.Franchise(request.Franchise.SportLeagueLevelId,
                                                 request.Franchise.Name,
                                                 request.Franchise.Location,
                                                 request.Franchise.FoundYear);

                await _franchiseRepository.Add(franchise);

                return;
            }

            franchise = await _franchiseRepository.Get(request.Franchise.Id);

            if (request.Franchise.IsDeleted)
            {
                await _franchiseRepository.Delete(franchise);

                return;
            }

            franchise.Set(request.Franchise.Name, 
                          request.Franchise.Location, 
                          request.Franchise.FoundYear);

            await _franchiseRepository.Update(franchise);
        }
    }
}
