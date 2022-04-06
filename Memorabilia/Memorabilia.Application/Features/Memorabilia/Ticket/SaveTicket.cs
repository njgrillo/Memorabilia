﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Ticket
{
    public class SaveTicket
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task Handle(Command command)
            {
                var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId).ConfigureAwait(false);

                memorabilia.SetTicket(command.GameDate,
                                      command.GamePersonId,
                                      command.GameStyleTypeId,
                                      command.LevelTypeId,
                                      command.PersonId,
                                      command.SizeId,
                                      command.SportId,
                                      command.TeamIds);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveTicketViewModel _viewModel;

            public Command(SaveTicketViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public DateTime? GameDate => _viewModel.GameDate;

            public int? GamePersonId => _viewModel.GamePersonId > 0 ? _viewModel.GamePersonId : null;

            public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

            public int LevelTypeId => _viewModel.LevelTypeId;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person.Id : null;

            public int SizeId => _viewModel.SizeId;

            public int? SportId => _viewModel.Sport?.Id > 0 ? _viewModel.Sport.Id : null;

            public int[] TeamIds => _viewModel.Teams.Select(team => team.Id).ToArray();
        }
    }
}
