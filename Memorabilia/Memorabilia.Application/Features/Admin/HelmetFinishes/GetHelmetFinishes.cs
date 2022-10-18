using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public record GetHelmetFinishes() : IQuery<HelmetFinishesViewModel>
{
    public class Handler : QueryHandler<GetHelmetFinishes, HelmetFinishesViewModel>
    {
        private readonly IDomainRepository<HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task<HelmetFinishesViewModel> Handle(GetHelmetFinishes query)
        {
            return new HelmetFinishesViewModel(await _helmetFinishRepository.GetAll());
        }
    }
}
