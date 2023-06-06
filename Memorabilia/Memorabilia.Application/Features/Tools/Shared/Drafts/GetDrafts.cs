using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Drafts;

public record GetDrafts(Franchise Franchise, Sport Sport) : IQuery<DraftsModel>
{
    public class Handler : QueryHandler<GetDrafts, DraftsModel>
    {
        private readonly IDraftRepository _draftRepository;

        public Handler(IDraftRepository draftRepository)
        {
            _draftRepository = draftRepository;
        }

        protected override async Task<DraftsModel> Handle(GetDrafts query)
        {
            return new DraftsModel(await _draftRepository.GetAll(query.Franchise.Id), query.Sport)
            {
                Franchise = query.Franchise
            };
        }
    }
}
