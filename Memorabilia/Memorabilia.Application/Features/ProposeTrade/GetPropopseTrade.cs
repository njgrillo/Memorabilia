namespace Memorabilia.Application.Features.ProposeTrade;

public record GetPropopseTrade(int Id) : IQuery<Entity.ProposeTrade>
{
    public class Handler : QueryHandler<GetPropopseTrade, Entity.ProposeTrade>
    {
        private readonly IProposeTradeRepository _proposeTradeRepository;

        public Handler(IProposeTradeRepository proposeTradeRepository)
        {
            _proposeTradeRepository = proposeTradeRepository;
        }

        protected override async Task<Entity.ProposeTrade> Handle(GetPropopseTrade query)
            => await _proposeTradeRepository.Get(query.Id);
    }
}
