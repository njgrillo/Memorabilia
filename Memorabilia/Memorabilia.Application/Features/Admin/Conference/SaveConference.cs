using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Conference
{
    public class SaveConference
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IConferenceRepository _conferenceRepository;

            public Handler(IConferenceRepository conferenceRepository)
            {
                _conferenceRepository = conferenceRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Conference conference;

                if (command.IsNew)
                {
                    conference = new Domain.Entities.Conference(command.SportId,
                                                                command.Name,
                                                                command.Abbreviation);

                    await _conferenceRepository.Add(conference).ConfigureAwait(false);

                    return;
                }

                conference = await _conferenceRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _conferenceRepository.Delete(conference).ConfigureAwait(false);

                    return;
                }

                conference.Set(command.SportId,
                               command.Name,
                               command.Abbreviation);

                await _conferenceRepository.Update(conference).ConfigureAwait(false);
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

            public int SportId => _viewModel.SportId;
        }
    }
}
