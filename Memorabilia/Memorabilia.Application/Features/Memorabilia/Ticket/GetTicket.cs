namespace Memorabilia.Application.Features.Memorabilia.Ticket;

public record GetTicket(int MemorabiliaId) : IQuery<TicketViewModel>
{
    public class Handler : QueryHandler<GetTicket, TicketViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<TicketViewModel> Handle(GetTicket query)
        {
            return new TicketViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
