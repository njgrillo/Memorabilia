using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Basketball
{
    public class SaveBasketball
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

                memorabilia.SetBasketball(command.BasketballTypeId,
                                          command.BrandId,
                                          command.CommissionerId,
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
            private readonly SaveBasketballViewModel _viewModel;

            public Command(SaveBasketballViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int? BasketballTypeId => _viewModel.BasketballTypeId > 0 ? _viewModel.BasketballTypeId : null;

            public int BrandId => _viewModel.BrandId;

            public int CommissionerId => _viewModel.CommissionerId;

            public DateTime? GameDate => _viewModel.GameDate;

            public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

            public int LevelTypeId => _viewModel.LevelTypeId;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person?.Id : null;

            public int SizeId => _viewModel.SizeId;

            public int SportId => Domain.Constants.Sport.Basketball.Id;

            public int? TeamId => _viewModel.Team?.Id > 0 ? _viewModel.Team?.Id : null;
        }
    }
}
