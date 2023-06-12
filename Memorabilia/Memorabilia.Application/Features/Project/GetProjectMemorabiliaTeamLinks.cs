namespace Memorabilia.Application.Features.Project;

public record GetProjectMemorabiliaTeamLinks(Dictionary<string, object> Parameters)
     : IQuery<Entity.Memorabilia[]>
{
    public class Handler : QueryHandler<GetProjectMemorabiliaTeamLinks, Entity.Memorabilia[]>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
                _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<Entity.Memorabilia[]> Handle(GetProjectMemorabiliaTeamLinks query)
            => await _memorabiliaRepository.GetAll(query.Parameters);
    }
}
