namespace Memorabilia.Application.Features.Admin.Commissioners;

public record GetCommissioner(int Id) : IQuery<Entity.Commissioner>
{
    public class Handler : QueryHandler<GetCommissioner, Entity.Commissioner>
    {
        private readonly ICommissionerRepository _commissionerRepository;

        public Handler(ICommissionerRepository commissionerRepository)
        {
            _commissionerRepository = commissionerRepository;
        }

        protected override async Task<Entity.Commissioner> Handle(GetCommissioner query)
            => await _commissionerRepository.Get(query.Id);
    }
}
