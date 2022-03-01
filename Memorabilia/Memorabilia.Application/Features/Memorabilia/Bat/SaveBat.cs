using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Bat
{
    public class SaveBat
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

                memorabilia.SetBat(command.BatTypeId,
                                   command.BrandId,
                                   command.ColorId,
                                   command.GameDate,
                                   command.GameStyleTypeId,
                                   command.Length,
                                   command.PersonId,
                                   command.SizeId,
                                   command.SportId,
                                   command.TeamId);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveBatViewModel _viewModel;

            public Command(SaveBatViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int? BatTypeId => _viewModel.BatTypeId > 0 ? _viewModel.BatTypeId : null;

            public int BrandId => _viewModel.BrandId;

            public int? ColorId => _viewModel.ColorId > 0 ? _viewModel.ColorId : null;

            public DateTime? GameDate => _viewModel.GameDate;

            public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

            public int? Length => _viewModel.Length > 0 ? _viewModel.Length : null;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int? PersonId => _viewModel.People.Any() ? _viewModel.People.First().Id: null;

            public int SizeId => _viewModel.SizeId;

            public int SportId => Domain.Constants.Sport.Baseball.Id;

            public int? TeamId => _viewModel.Team?.Id > 0 ? _viewModel.Team?.Id : null;
        }
    }
}
