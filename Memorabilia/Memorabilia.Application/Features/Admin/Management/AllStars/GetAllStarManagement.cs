namespace Memorabilia.Application.Features.Admin.Management.AllStars;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAllStarManagement(int Id) : IQuery<Entity.AllStarDetail>
{
    public class Handler : QueryHandler<GetAllStarManagement, Entity.AllStarDetail>
    {
        private readonly IAllStarDetailRepository _allStarDetailRepository;

        public Handler(IAllStarDetailRepository allStarDetailRepository)
        {
            _allStarDetailRepository = allStarDetailRepository;
        }

        protected override async Task<Entity.AllStarDetail> Handle(GetAllStarManagement query)
            => await _allStarDetailRepository.Get(query.Id);
    }
}
