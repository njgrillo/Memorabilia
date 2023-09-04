namespace Memorabilia.Application.Features.Admin.Conferences;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveConference(ConferenceEditModel Conference) : ICommand
{
    public class Handler : CommandHandler<SaveConference>
    {
        private readonly IDomainRepository<Entity.Conference> _conferenceRepository;

        public Handler(IDomainRepository<Entity.Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        protected override async Task Handle(SaveConference request)
        {
            Entity.Conference conference;

            if (request.Conference.IsNew)
            {
                conference = new Entity.Conference(request.Conference.SportLeagueLevelId,
                                                   request.Conference.Name,
                                                   request.Conference.Abbreviation);

                await _conferenceRepository.Add(conference);

                return;
            }

            conference = await _conferenceRepository.Get(request.Conference.Id);

            if (request.Conference.IsDeleted)
            {
                await _conferenceRepository.Delete(conference);

                return;
            }

            conference.Set(request.Conference.SportLeagueLevelId,
                           request.Conference.Name,
                           request.Conference.Abbreviation);

            await _conferenceRepository.Update(conference);
        }
    }
}
