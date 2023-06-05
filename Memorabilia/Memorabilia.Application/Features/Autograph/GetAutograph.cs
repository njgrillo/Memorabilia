namespace Memorabilia.Application.Features.Autograph;

public record GetAutograph(int Id)
    : IQuery<Entity.Autograph>
{
    public class Handler : QueryHandler<GetAutograph, Entity.Autograph>
    {
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository)
        {
            _autographRepository = autographRepository;
        }

        protected override async Task<Entity.Autograph> Handle(GetAutograph query)
        {
            return await _autographRepository.Get(query.Id);
        }
    }
}
