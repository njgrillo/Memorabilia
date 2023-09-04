namespace Memorabilia.Application.Features.Admin.Management.Awards;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetAwardManagement(int AwardTypeId) : IQuery<Entity.AwardDetail>
{
    public class Handler : QueryHandler<GetAwardManagement, Entity.AwardDetail>
    {
        private readonly IAwardDetailRepository _awardDetailRepository;

        public Handler(IAwardDetailRepository awardDetailRepository)
        {
            _awardDetailRepository = awardDetailRepository;
        }

        protected override async Task<Entity.AwardDetail> Handle(GetAwardManagement query)
            => await _awardDetailRepository.Get(query.AwardTypeId);
    }
}
