using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public record GetAccomplishments(AccomplishmentType AccomplishmentType, Sport Sport) : IQuery<AccomplishmentsViewModel>
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
            return new AccomplishmentsViewModel(await _personAccomplishmentRepository.GetAll(query.AccomplishmentType.Id), query.Sport)
            {
                AccomplishmentType = query.AccomplishmentType
            };
        }
    }
}
