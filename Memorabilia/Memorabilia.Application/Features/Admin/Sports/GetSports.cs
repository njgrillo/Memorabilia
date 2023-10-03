namespace Memorabilia.Application.Features.Admin.Sports;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetSports() : IQuery<Entity.Sport[]>
{
    public class Handler : QueryHandler<GetSports, Entity.Sport[]>
    {
        private readonly IDomainRepository<Entity.Sport> _sportRepository;

        public Handler(IDomainRepository<Entity.Sport> sportRepository)
        {
            _sportRepository = sportRepository;
        }

        protected override async Task<Entity.Sport[]> Handle(GetSports query)
            => (await _sportRepository.GetAll())
                    .OrderBy(sport => sport.Name)
                    .ToArray();
    }
}
