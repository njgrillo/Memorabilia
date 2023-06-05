namespace Memorabilia.Application.Features.Project;

public record GetProjectMemorabiliaTeamLinks(Dictionary<string, object> Parameters)
     : IQuery<MemorabiliaItemModel[]>
{
    public class Handler : QueryHandler<GetProjectMemorabiliaTeamLinks, MemorabiliaItemModel[]>
{
    private readonly IMemorabiliaItemRepository _memorabiliaRepository;

    public Handler(IMemorabiliaItemRepository memorabiliaRepository)
    {
            _memorabiliaRepository = memorabiliaRepository;
    }

    protected override async Task<MemorabiliaItemModel[]> Handle(GetProjectMemorabiliaTeamLinks query)
    {
        Domain.Entities.Memorabilia[] memorabilia = await _memorabiliaRepository.GetAll(query.Parameters);

        return memorabilia.Any()
            ? memorabilia.Select(item => new MemorabiliaItemModel(item))
                         .ToArray()
            : Array.Empty<MemorabiliaItemModel>();
    }
}
}
