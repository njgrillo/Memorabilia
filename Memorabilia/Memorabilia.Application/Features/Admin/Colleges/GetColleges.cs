using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges;

public record GetColleges() : IQuery<CollegesViewModel>
{
    public class Handler : QueryHandler<GetColleges, CollegesViewModel>
    {
        private readonly IDomainRepository<College> _collegeRepository;

        public Handler(IDomainRepository<College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<CollegesViewModel> Handle(GetColleges query)
        {
            return new CollegesViewModel(await _collegeRepository.GetAll());
        }
    }
}
