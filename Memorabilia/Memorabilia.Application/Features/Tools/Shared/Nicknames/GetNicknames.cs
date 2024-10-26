namespace Memorabilia.Application.Features.Tools.Shared.Nicknames;

public record GetNicknames(
    PageInfo PageInfo, 
    int? SportId = null, 
    string Filter = null    
    )
    : IQuery<PersonNicknamesViewModel>
{
    public class Handler(IPersonRepository personRepository)
        : QueryHandler<GetNicknames, PersonNicknamesViewModel>
    {
        protected override async Task<PersonNicknamesViewModel> Handle(GetNicknames query)
        {
            PagedResult<Entity.Person> result
                = await personRepository.GetAllNicknames(query.PageInfo, query.SportId, query.Filter);

            return new PersonNicknamesViewModel(result.Data, Constant.Sport.Find(query.SportId ?? 0), result.PageInfo);
        }
    }
}
