using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographBaseballTypeLinks(int ItemTypeId,
                                                         int PersonId,
                                                         int BaseballTypeId,
                                                         int? TeamId,
                                                         int? Year)
     : IQuery<Entity.Autograph[]>
{
    public class Handler(IAutographRepository autographRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetProjectPersonAutographBaseballTypeLinks, Entity.Autograph[]>
    {
        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographBaseballTypeLinks query)
            => await autographRepository.GetAllBaseballTypes(query.ItemTypeId,
                                                             query.PersonId,
                                                             query.BaseballTypeId,
                                                             query.TeamId,
                                                             query.Year, 
                                                             applicationStateService.CurrentUser.Id);
    }
}
