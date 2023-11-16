namespace Memorabilia.Application.Features.Admin.Management.Awards;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAwardManagement(int AwardTypeId) : IQuery<Entity.AwardDetail>
{
    public class Handler(IAwardDetailRepository awardDetailRepository) 
        : QueryHandler<GetAwardManagement, Entity.AwardDetail>
    {
        protected override async Task<Entity.AwardDetail> Handle(GetAwardManagement query)
            => await awardDetailRepository.Get(query.AwardTypeId);
    }
}
