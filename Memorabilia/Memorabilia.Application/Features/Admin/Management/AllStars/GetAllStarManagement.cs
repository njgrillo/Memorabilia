namespace Memorabilia.Application.Features.Admin.Management.AllStars;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAllStarManagement(int Id) : IQuery<Entity.AllStarDetail>
{
    public class Handler(IAllStarDetailRepository allStarDetailRepository) 
        : QueryHandler<GetAllStarManagement, Entity.AllStarDetail>
    {
        protected override async Task<Entity.AllStarDetail> Handle(GetAllStarManagement query)
            => await allStarDetailRepository.Get(query.Id);
    }
}
