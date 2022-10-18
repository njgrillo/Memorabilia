using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public record GetHelmetFinish(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetHelmetFinish, DomainViewModel>
    {
        private readonly IDomainRepository<HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetHelmetFinish query)
        {
            return new DomainViewModel(await _helmetFinishRepository.Get(query.Id));
        }
    }
}
