namespace Memorabilia.Application.Features.Autograph;

public record GetAutographs(int? MemorabiliaId = null, 
                            int? UserId = null)
    : IQuery<Entity.Autograph[]>
{
    public class Handler : QueryHandler<GetAutographs, Entity.Autograph[]>
    {
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository)
        {
            _autographRepository = autographRepository;
        }

        protected override async Task<Entity.Autograph[]> Handle(GetAutographs query)
            => await _autographRepository.GetAll(query.MemorabiliaId);
    }
}
