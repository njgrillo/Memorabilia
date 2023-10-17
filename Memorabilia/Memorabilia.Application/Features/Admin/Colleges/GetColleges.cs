namespace Memorabilia.Application.Features.Admin.Colleges;

public record GetColleges() : IQuery<Entity.College[]>
{
    public class Handler : QueryHandler<GetColleges, Entity.College[]>
    {
        private readonly IDomainRepository<Entity.College> _collegeRepository;

        public Handler(IDomainRepository<Entity.College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<Entity.College[]> Handle(GetColleges query)
            => await _collegeRepository.GetAll();
    }
}
