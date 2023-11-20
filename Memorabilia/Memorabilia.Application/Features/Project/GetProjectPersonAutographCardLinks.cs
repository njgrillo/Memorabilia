namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographCardLinks(int ItemTypeId,
                                                 int PersonId,
                                                 int BrandId,
                                                 int? TeamId,
                                                 int? Year)
     : IQuery<Entity.Autograph[]>
{
    public class Handler(IAutographRepository autographRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetProjectPersonAutographCardLinks, Entity.Autograph[]>
    {
        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographCardLinks query)
            => await autographRepository.GetAllCards(query.ItemTypeId,
                                                     query.PersonId,
                                                     query.BrandId,
                                                     query.TeamId,
                                                     query.Year,
                                                     applicationStateService.CurrentUser.Id);
    }
}
