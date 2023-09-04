namespace Memorabilia.Application.Features.Admin.Pewters;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetPewters() : IQuery<Entity.Pewter[]>
{
    public class Handler : QueryHandler<GetPewters, Entity.Pewter[]>
    {
        private readonly IDomainRepository<Entity.Pewter> _pewterRepository;

        public Handler(IDomainRepository<Entity.Pewter> pewterRepository)
        {
            _pewterRepository = pewterRepository;
        }

        protected override async Task<Entity.Pewter[]> Handle(GetPewters query)
            => (await _pewterRepository.GetAll())
                    .OrderBy(pewter => pewter.FranchiseName)
                    .ThenBy(pewter => pewter.Team.Name)
                    .ThenBy(pewter => pewter.SizeName)
                    .ThenBy(pewter => pewter.ImageTypeName)
                    .ToArray();
    }
}
