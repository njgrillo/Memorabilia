namespace Memorabilia.Application.Features.Tools.Shared.Drafts;

public record GetDrafts(Constant.Franchise Franchise, 
                        Constant.Sport Sport) 
    : IQuery<Entity.Draft[]>
{
    public class Handler : QueryHandler<GetDrafts, Entity.Draft[]>
    {
        private readonly IDraftRepository _draftRepository;

        public Handler(IDraftRepository draftRepository)
        {
            _draftRepository = draftRepository;
        }

        protected override async Task<Entity.Draft[]> Handle(GetDrafts query)
            => (await _draftRepository.GetAll(query.Franchise.Id))
                    .ToArray();
    }
}
