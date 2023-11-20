namespace Memorabilia.Application.Features.Autograph;

public record GetAutographsByPerson(int PersonId)
    : IQuery<Entity.Autograph[]>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IAutographRepository autographRepository) 
        : QueryHandler<GetAutographsByPerson, Entity.Autograph[]>
    {
        protected override async Task<Entity.Autograph[]> Handle(GetAutographsByPerson query)
            => await autographRepository.GetAllByPerson(query.PersonId, applicationStateService.CurrentUser.Id);
    }
}
