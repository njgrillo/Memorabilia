namespace Memorabilia.Application.Features.Admin.Management.Accomplishments;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetAccomplishmentManagement(int AccomplishmentTypeId)
    : IQuery<Entity.AccomplishmentDetail>
{
    public class Handler : QueryHandler<GetAccomplishmentManagement, Entity.AccomplishmentDetail>
    {
        private readonly IAccomplishmentDetailRepository _accomplishmentDetailRepository;

        public Handler(IAccomplishmentDetailRepository accomplishmentDetailRepository)
        {
            _accomplishmentDetailRepository = accomplishmentDetailRepository;
        }

        protected override async Task<Entity.AccomplishmentDetail> Handle(GetAccomplishmentManagement query)
            => await _accomplishmentDetailRepository.Get(query.AccomplishmentTypeId);
    }
}
