using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges;

public record GetCollege(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetCollege, DomainViewModel>
    {
        private readonly IDomainRepository<College> _collegeRepository;

        public Handler(IDomainRepository<College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetCollege query)
        {
            return new DomainViewModel(await _collegeRepository.Get(query.Id));
        }
    }
}
