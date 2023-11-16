using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographItemTypeLinks(int ItemTypeId,
                                                     int PersonId,
                                                     bool? MultiSigned)
     : IQuery<Entity.Autograph[]>
{
    public class Handler(IAutographRepository autographRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetProjectPersonAutographItemTypeLinks, Entity.Autograph[]>
    {
        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographItemTypeLinks query)
            => await autographRepository.GetAllItemTypes(query.ItemTypeId,
                                                         query.PersonId,
                                                         query.MultiSigned,
                                                         applicationStateService.CurrentUser.Id);
    }
}
