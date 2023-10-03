namespace Memorabilia.Application.Features.ProposeTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetProposeTradeMemorabiliaItem(int MemorabiliaId)
    : IQuery<Entity.Memorabilia>
{
    public class Handler : QueryHandler<GetProposeTradeMemorabiliaItem, Entity.Memorabilia>
    {
        private readonly ISiteMemorabiliaRepository _memorabiliaRepository;

        public Handler(ISiteMemorabiliaRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<Entity.Memorabilia> Handle(GetProposeTradeMemorabiliaItem query)
            => await _memorabiliaRepository.Get(query.MemorabiliaId);
    }
}
