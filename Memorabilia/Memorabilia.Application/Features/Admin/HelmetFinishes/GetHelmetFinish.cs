using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public record GetHelmetFinish(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetHelmetFinish, DomainModel>
    {
        private readonly IDomainRepository<HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task<DomainModel> Handle(GetHelmetFinish query)
        {
            return new DomainModel(await _helmetFinishRepository.Get(query.Id));
        }
    }
}
