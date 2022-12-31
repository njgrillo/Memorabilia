using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Drafts;

public record GetDrafts(Franchise Franchise, Sport Sport) : IQuery<DraftsViewModel>
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
            return new DraftsViewModel(await _draftRepository.GetAll(query.Franchise.Id), query.Sport)
            {
                Franchise = query.Franchise
            };
        }
    }
}
