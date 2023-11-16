namespace Memorabilia.Application.Features.Admin.Management.Accomplishments;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAccomplishmentManagement(int AccomplishmentTypeId)
    : IQuery<Entity.AccomplishmentDetail>
{
    public class Handler(IAccomplishmentDetailRepository accomplishmentDetailRepository) 
        : QueryHandler<GetAccomplishmentManagement, Entity.AccomplishmentDetail>
    {
        protected override async Task<Entity.AccomplishmentDetail> Handle(GetAccomplishmentManagement query)
            => await accomplishmentDetailRepository.Get(query.AccomplishmentTypeId);
    }
}
