using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conferences;

public class SaveConference
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Conference> _conferenceRepository;

        public Handler(IDomainRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        protected override async Task Handle(Command command)
        {
            Conference conference;

            if (command.IsNew)
            {
                conference = new Conference(command.SportLeagueLevelId,
                                            command.Name,
                                            command.Abbreviation);

                await _conferenceRepository.Add(conference);

                return;
            }

            conference = await _conferenceRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _conferenceRepository.Delete(conference);

                return;
            }

            conference.Set(command.SportLeagueLevelId,
                           command.Name,
                           command.Abbreviation);

            await _conferenceRepository.Update(conference);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveConferenceViewModel _viewModel;

        public Command(SaveConferenceViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public string Abbreviation => _viewModel.Abbreviation;

        public int Id => _viewModel.Id;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;


        public string Name => _viewModel.Name;

        public int SportLeagueLevelId => _viewModel.SportLeagueLevelId;
    }
}
