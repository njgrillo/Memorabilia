﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph.Spot
{
    public class SaveSpot
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task Handle(Command command)
            {
                var autograph = await _autographRepository.Get(command.AutographId).ConfigureAwait(false);

                autograph.SetSpot(command.SpotId);

                await _autographRepository.Update(autograph).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveSpotViewModel _viewModel;

            public Command(SaveSpotViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int AutographId => _viewModel.AutographId;

            public int SpotId => _viewModel.SpotId;
        }
    }
}
