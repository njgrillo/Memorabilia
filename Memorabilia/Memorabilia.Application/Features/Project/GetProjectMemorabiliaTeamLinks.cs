namespace Memorabilia.Application.Features.Project;

public record GetProjectMemorabiliaTeamLinks(Dictionary<string, object> Parameters)
     : IQuery<MemorabiliaItemViewModel[]>
{
    public class Handler : QueryHandler<GetProjectMemorabiliaTeamLinks, MemorabiliaItemViewModel[]>
{
    private readonly IMemorabiliaItemRepository _memorabiliaRepository;

    public Handler(IMemorabiliaItemRepository memorabiliaRepository)
    {
            _memorabiliaRepository = memorabiliaRepository;
    }

    protected override async Task<MemorabiliaItemViewModel[]> Handle(GetProjectMemorabiliaTeamLinks query)
    {
        Domain.Entities.Memorabilia[] memorabilia = await _memorabiliaRepository.GetAll(query.Parameters);

        return memorabilia.Any()
            ? memorabilia.Select(item => new MemorabiliaItemViewModel(item))
                         .ToArray()
            : Array.Empty<MemorabiliaItemViewModel>();
    }
}
}
