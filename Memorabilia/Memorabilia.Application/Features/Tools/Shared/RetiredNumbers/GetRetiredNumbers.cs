namespace Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;

public record GetRetiredNumbers(Constant.Franchise Franchise, 
                                Constant.Sport Sport) 
    : IQuery<Entity.RetiredNumber[]>
{
    public class Handler(IRetiredNumberRepository retiredNumberRepository) 
        : QueryHandler<GetRetiredNumbers, Entity.RetiredNumber[]>
    {
        protected override async Task<Entity.RetiredNumber[]> Handle(GetRetiredNumbers query)
            => (await retiredNumberRepository.GetAll(query.Franchise.Id))
                    .ToArray();
    }
}
