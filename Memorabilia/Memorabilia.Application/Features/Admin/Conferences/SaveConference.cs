using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conferences;

public record SaveConference(SaveConferenceViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveConference>
    {
        private readonly IDomainRepository<Conference> _conferenceRepository;

        public Handler(IDomainRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        protected override async Task Handle(SaveConference request)
        {
            Conference conference;

            if (request.ViewModel.IsNew)
            {
                conference = new Conference(request.ViewModel.SportLeagueLevelId,
                                            request.ViewModel.Name,
                                            request.ViewModel.Abbreviation);

                await _conferenceRepository.Add(conference);

                return;
            }

            conference = await _conferenceRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _conferenceRepository.Delete(conference);

                return;
            }

            conference.Set(request.ViewModel.SportLeagueLevelId,
                           request.ViewModel.Name,
                           request.ViewModel.Abbreviation);

            await _conferenceRepository.Update(conference);
        }
    }
}
