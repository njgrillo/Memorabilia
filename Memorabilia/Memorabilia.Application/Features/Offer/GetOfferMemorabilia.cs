namespace Memorabilia.Application.Features.Offer;

public record GetOfferMemorabilia(int MemorabiliaId)
    : IQuery<Entity.Memorabilia>
{
    public class Handler : QueryHandler<GetOfferMemorabilia, Entity.Memorabilia>
{
    private readonly ISiteMemorabiliaRepository _memorabiliaRepository;

    public Handler(ISiteMemorabiliaRepository memorabiliaRepository)
    {
        _memorabiliaRepository = memorabiliaRepository;
    }

    protected override async Task<Entity.Memorabilia> Handle(GetOfferMemorabilia query)
        => await _memorabiliaRepository.Get(query.MemorabiliaId);
}
}
