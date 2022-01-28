using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class SaveBaseball
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

                memorabilia.SetBaseballType(command.MemorabiliaBaseballTypeId, command.BaseballTypeId);
                memorabilia.SetBrand(command.MemorabiliaBrandId, command.BrandId);
                memorabilia.SetCommissioner(command.MemorabiliaCommissionerId, command.CommissionerId);
                memorabilia.SetPeople(command.PersonIds);
                memorabilia.SetSize(command.MemorabiliaSizeId, command.SizeId);
                memorabilia.SetSports(command.SportIds);
                memorabilia.SetTeams(command.TeamIds);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveBaseballViewModel _viewModel;

            public Command(SaveBaseballViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int BaseballTypeId => _viewModel.BaseballTypeId;

            public int BrandId => _viewModel.BrandId;

            public int CommissionerId => _viewModel.CommissionerId;

            public int MemorabiliaBaseballTypeId => _viewModel.MemorabiliaBaseballTypeId;

            public int MemorabiliaBrandId => _viewModel.MemorabiliaBrandId;

            public int MemorabiliaCommissionerId => _viewModel.MemorabiliaCommissionerId;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int MemorabiliaSizeId => _viewModel.MemorabiliaSizeId;

            public IEnumerable<int> PersonIds { get; set; }

            public int SizeId => _viewModel.SizeId;

            public IEnumerable<int> SportIds { get; set; }

            public IEnumerable<int> TeamIds { get; set; }
        }
    }
}
