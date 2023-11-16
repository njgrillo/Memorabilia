namespace Memorabilia.Application.Features.Admin.Conferences;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveConference(ConferenceEditModel Conference) : ICommand
{
    public class Handler(IDomainRepository<Entity.Conference> conferenceRepository) 
        : CommandHandler<SaveConference>
    {
        protected override async Task Handle(SaveConference request)
        {
            Entity.Conference conference;

            if (request.Conference.IsNew)
            {
                conference = new Entity.Conference(request.Conference.SportLeagueLevelId,
                                                   request.Conference.Name,
                                                   request.Conference.Abbreviation);

                await conferenceRepository.Add(conference);

                return;
            }

            conference = await conferenceRepository.Get(request.Conference.Id);

            if (request.Conference.IsDeleted)
            {
                await conferenceRepository.Delete(conference);

                return;
            }

            conference.Set(request.Conference.SportLeagueLevelId,
                           request.Conference.Name,
                           request.Conference.Abbreviation);

            await conferenceRepository.Update(conference);
        }
    }
}
