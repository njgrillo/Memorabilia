using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges;

public record GetCollege(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetCollege, DomainModel>
    {
        private readonly IDomainRepository<College> _collegeRepository;

        public Handler(IDomainRepository<College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<DomainModel> Handle(GetCollege query)
        {
            return new DomainModel(await _collegeRepository.Get(query.Id));
        }
    }
}
