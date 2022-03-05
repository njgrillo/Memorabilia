﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Shirt
{
    public class SaveShirt
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

                memorabilia.SetShirt(command.BrandId,
                                     command.GameDate,
                                     command.GamePersonId,
                                     command.GameStyleTypeId,
                                     command.LevelTypeId,
                                     command.PersonIds,
                                     command.SizeId,
                                     command.SportIds,
                                     command.TeamIds);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveShirtViewModel _viewModel;

            public Command(SaveShirtViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int BrandId => _viewModel.BrandId;

            public DateTime? GameDate => _viewModel.GameDate;

            public int? GamePersonId => _viewModel.GamePersonId > 0 ? _viewModel.GamePersonId : null;

            public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

            public int LevelTypeId => _viewModel.LevelTypeId;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int[] PersonIds => _viewModel.People.Select(person => person.Id).ToArray();

            public int SizeId => _viewModel.SizeId;

            public int[] SportIds => _viewModel.SportIds.ToArray();

            public int[] TeamIds => _viewModel.Teams.Select(team => team.Id).ToArray();
        }
    }
}
