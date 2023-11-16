namespace Memorabilia.Application.Features.Autograph;

public record GetAutograph(int Id)
    : IQuery<Entity.Autograph>
{
    public class Handler(IAutographRepository autographRepository) 
        : QueryHandler<GetAutograph, Entity.Autograph>
    {
        private readonly IAutographRepository _autographRepository 
            = autographRepository;

        protected override async Task<Entity.Autograph> Handle(GetAutograph query)
            => await _autographRepository.Get(query.Id);
    }
}
