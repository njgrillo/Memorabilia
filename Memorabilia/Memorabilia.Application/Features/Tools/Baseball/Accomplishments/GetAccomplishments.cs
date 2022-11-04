namespace Memorabilia.Application.Features.Tools.Baseball.Accomplishments;

public record GetAccomplishments(int AccomplishmentTypeId) : IQuery<AccomplishmentsViewModel>
{
    public class Handler : QueryHandler<GetAccomplishments, AccomplishmentsViewModel>
    {
        private readonly IPersonAccomplishmentRepository _personAccomplishmentRepository;

        public Handler(IPersonAccomplishmentRepository personAccomplishmentRepository)
        {
            _personAccomplishmentRepository = personAccomplishmentRepository;
        }

        protected override async Task<AccomplishmentsViewModel> Handle(GetAccomplishments query)
        {
            return new AccomplishmentsViewModel(await _personAccomplishmentRepository.GetAll(query.AccomplishmentTypeId))
            {
                AccomplishmentTypeId = query.AccomplishmentTypeId
            };
        }
    }
}
