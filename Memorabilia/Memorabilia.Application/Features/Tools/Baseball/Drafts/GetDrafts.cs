namespace Memorabilia.Application.Features.Tools.Baseball.Drafts;

public record GetDrafts(int FranchiseId) : IQuery<DraftsViewModel>
{
    public class Handler : QueryHandler<GetDrafts, DraftsViewModel>
    {
        private readonly IDraftRepository _draftRepository;

        public Handler(IDraftRepository draftRepository)
        {
            _draftRepository = draftRepository;
        }

        protected override async Task<DraftsViewModel> Handle(GetDrafts query)
        {
            return new DraftsViewModel(await _draftRepository.GetAll(query.FranchiseId))
            {
                FranchiseId = query.FranchiseId
            };
        }
    }
}
