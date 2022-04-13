﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Card
{
    public class SaveCard
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

                memorabilia.SetCard(command.BrandId,
                                    command.Custom,
                                    command.LevelTypeId,
                                    command.Licensed,
                                    command.OrientationId,
                                    command.PersonIds,
                                    command.SizeId,
                                    command.SportIds,
                                    command.TeamIds,
                                    command.Year);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveCardViewModel _viewModel;

            public Command(SaveCardViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int BrandId => _viewModel.BrandId;

            public bool Custom => _viewModel.Custom;

            public int LevelTypeId => _viewModel.LevelTypeId;

            public bool Licensed => _viewModel.Licensed;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int OrientationId => _viewModel.OrientationId;

            public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

            public int SizeId => _viewModel.SizeId;

            public int[] SportIds => _viewModel.SportIds.ToArray();

            public int[] TeamIds => _viewModel.Teams.Where(team => !team.IsDeleted).Select(team => team.Id).ToArray();

            public int? Year => _viewModel.Year > 0 ? _viewModel.Year : 0;
        }
    }
}
