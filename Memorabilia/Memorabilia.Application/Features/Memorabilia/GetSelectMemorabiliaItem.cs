namespace Memorabilia.Application.Features.Memorabilia;

public record GetSelectMemorabiliaItem(int Id) : IQuery<SelectMemorabiliaItemViewModel>
{
    public class Handler : QueryHandler<GetSelectMemorabiliaItem, SelectMemorabiliaItemViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<SelectMemorabiliaItemViewModel> Handle(GetSelectMemorabiliaItem query)
        {
            return new SelectMemorabiliaItemViewModel(await _memorabiliaRepository.Get(query.Id));
        }
    }
}
