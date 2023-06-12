namespace Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;

public record GetRetiredNumbers(Constant.Franchise Franchise, 
                                Constant.Sport Sport) 
    : IQuery<Entity.RetiredNumber[]>
{
    public class Handler : QueryHandler<GetRetiredNumbers, Entity.RetiredNumber[]>
    {
        private readonly IRetiredNumberRepository _retiredNumberRepository;

        public Handler(IRetiredNumberRepository retiredNumberRepository)
        {
            _retiredNumberRepository = retiredNumberRepository;
        }

        protected override async Task<Entity.RetiredNumber[]> Handle(GetRetiredNumbers query)
            => (await _retiredNumberRepository.GetAll(query.Franchise.Id))
                    .ToArray();
    }
}
