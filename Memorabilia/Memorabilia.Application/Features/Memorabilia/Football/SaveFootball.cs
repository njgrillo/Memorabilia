using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Football
{
    public class SaveFootball
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

                memorabilia.SetFootball(command.BrandId,
                                        command.CommissionerId,
                                        command.FootballTypeId,
                                        command.GameDate,
                                        command.GameStyleTypeId,
                                        command.LevelTypeId,
                                        command.PersonId,
                                        command.SizeId,
                                        command.SportId,
                                        command.TeamId);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveFootballViewModel _viewModel;

            public Command(SaveFootballViewModel viewModel)
            {
                _viewModel = viewModel;
            }            

            public int BrandId => _viewModel.BrandId;

            public int CommissionerId => _viewModel.CommissionerId;

            public int? FootballTypeId => _viewModel.FootballTypeId > 0 ? _viewModel.FootballTypeId : null;

            public DateTime? GameDate => _viewModel.GameDate;

            public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

            public int LevelTypeId => _viewModel.LevelTypeId;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int? PersonId => _viewModel.People.Any() ? _viewModel.People.First().Id : null;

            public int SizeId => _viewModel.SizeId;

            public int SportId => Domain.Constants.Sport.Football.Id;

            public int? TeamId => _viewModel.Teams.Any() ? _viewModel.Teams.First().Id : null;
        }
    }
}
