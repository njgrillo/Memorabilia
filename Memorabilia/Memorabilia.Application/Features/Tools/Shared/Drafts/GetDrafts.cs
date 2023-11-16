namespace Memorabilia.Application.Features.Tools.Shared.Drafts;

public record GetDrafts(Constant.Franchise Franchise, 
                        Constant.Sport Sport) 
    : IQuery<Entity.Draft[]>
{
    public class Handler(IDraftRepository draftRepository) 
        : QueryHandler<GetDrafts, Entity.Draft[]>
    {
        protected override async Task<Entity.Draft[]> Handle(GetDrafts query)
            => (await draftRepository.GetAll(query.Franchise.Id))
                    .ToArray();
    }
}
