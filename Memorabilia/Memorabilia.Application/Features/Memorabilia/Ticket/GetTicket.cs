namespace Memorabilia.Application.Features.Memorabilia.Ticket;

public class GetTicket
{
    public class Handler : QueryHandler<Query, TicketViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<TicketViewModel> Handle(Query query)
        {
            return new TicketViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<TicketViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
