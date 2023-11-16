using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographHallOfFameLinks(int ItemTypeId,
                                                       int PersonId,
                                                       int SportLeagueLevelId,
                                                       int? Year)
     : IQuery<Entity.Autograph[]>
{
    public class Handler(IAutographRepository autographRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetProjectPersonAutographHallOfFameLinks, Entity.Autograph[]>
    {
        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographHallOfFameLinks query)
            => await autographRepository.GetAllHallOfFamers(query.ItemTypeId,
                                                            query.PersonId,
                                                            query.SportLeagueLevelId,
                                                            query.Year,
                                                            applicationStateService.CurrentUser.Id);
    }
}
