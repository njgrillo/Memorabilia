namespace Memorabilia.Application.Features.Tools.Baseball.Accomplishments
{
    public class GetAccomplishments
    {
        public class Handler : QueryHandler<Query, AccomplishmentsViewModel>
        {
            private readonly IPersonAccomplishmentRepository _personAccomplishmentRepository;

            public Handler(IPersonAccomplishmentRepository personAccomplishmentRepository)
            {
                _personAccomplishmentRepository = personAccomplishmentRepository;
            }

            protected override async Task<AccomplishmentsViewModel> Handle(Query query)
            {
                return new AccomplishmentsViewModel(await _personAccomplishmentRepository.GetAll(query.AccomplishmentTypeId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<AccomplishmentsViewModel>
        {
            public Query(int accomplishmentTypeId)
            {
                AccomplishmentTypeId = accomplishmentTypeId;
            }

            public int AccomplishmentTypeId { get; }
        }
    }
}
