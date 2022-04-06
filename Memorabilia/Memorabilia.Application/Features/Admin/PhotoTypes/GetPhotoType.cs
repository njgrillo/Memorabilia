using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PhotoTypes
{
    public class GetPhotoType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IPhotoTypeRepository _photoTypeRepository;

            public Handler(IPhotoTypeRepository photoTypeRepository)
            {
                _photoTypeRepository = photoTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _photoTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
