﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover
{
    public class SaveFirstDayCover
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

                memorabilia.SetFirstDayCover(command.PersonIds,
                                             command.SizeId,
                                             command.SportIds,
                                             command.TeamIds);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveFirstDayCoverViewModel _viewModel;

            public Command(SaveFirstDayCoverViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int[] PersonIds => _viewModel.People.Select(person => person.Id).ToArray();

            public int SizeId => _viewModel.SizeId;

            public int[] SportIds => _viewModel.SportIds.ToArray();

            public int[] TeamIds => _viewModel.Teams.Select(team => team.Id).ToArray();
        }
    }
}
