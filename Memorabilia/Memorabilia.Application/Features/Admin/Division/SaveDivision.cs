﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Division
{
    public class SaveDivision
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IDivisionRepository _divisionRepository;

            public Handler(IDivisionRepository divisionRepository)
            {
                _divisionRepository = divisionRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Division division;

                if (command.IsNew)
                {
                    division = new Domain.Entities.Division(command.ConferenceId,
                                                            command.Name,
                                                            command.Abbreviation);

                    await _divisionRepository.Add(division).ConfigureAwait(false);

                    return;
                }

                division = await _divisionRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _divisionRepository.Delete(division).ConfigureAwait(false);

                    return;
                }

                division.Set(command.ConferenceId,
                             command.Name,
                             command.Abbreviation);

                await _divisionRepository.Update(division).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveDivisionViewModel _viewModel;

            public Command(SaveDivisionViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public string Abbreviation => _viewModel.Abbreviation;

            public int? ConferenceId => _viewModel.ConferenceId > 0 ? _viewModel.ConferenceId : null;

            public int Id => _viewModel.Id;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public string Name => _viewModel.Name;            
        }
    }
}
