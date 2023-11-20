namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographWorldSeriesLinks(int ItemTypeId,
                                                        int PersonId,
                                                        int TeamId,
                                                        int? Year)
     : IQuery<Entity.Autograph[]>
{
    public class Handler(IAutographRepository autographRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetProjectPersonAutographWorldSeriesLinks, Entity.Autograph[]>
    {
        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographWorldSeriesLinks query)
            => await autographRepository.GetAllWorldSeries(query.ItemTypeId,
                                                           query.PersonId,
                                                           query.TeamId,
                                                           query.Year,
                                                           applicationStateService.CurrentUser.Id);
    }
}
