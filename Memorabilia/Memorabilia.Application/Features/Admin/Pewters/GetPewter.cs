namespace Memorabilia.Application.Features.Admin.Pewters;

public record GetPewter(int Id) : IQuery<Entity.Pewter>
{
    public class Handler : QueryHandler<GetPewter, Entity.Pewter>
    {
        private readonly IDomainRepository<Entity.Pewter> _pewterRepository;

        public Handler(IDomainRepository<Entity.Pewter> pewterRepository)
        {
            _pewterRepository = pewterRepository;
        }

        protected override async Task<Entity.Pewter> Handle(GetPewter query)
            => await _pewterRepository.Get(query.Id);
    }
}
