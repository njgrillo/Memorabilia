using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Jersey
{
    public class SaveJersey
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

                memorabilia.SetJersey(command.BrandId,
                                      command.GameDate,
                                      command.GamePersonId,
                                      command.GameStyleTypeId,
                                      command.LevelTypeId,
                                      command.PersonIds,
                                      command.QualityTypeId,
                                      command.SizeId,
                                      command.SportIds,
                                      command.StyleTypeId,
                                      command.TeamIds,
                                      command.TypeId);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveJerseyViewModel _viewModel;

            public Command(SaveJerseyViewModel viewModel)
            {
                _viewModel = viewModel;
            }            

            public int BrandId => _viewModel.BrandId;

            public DateTime? GameDate => _viewModel.GameDate;

            public int? GamePersonId => _viewModel.GamePersonId > 0 ? _viewModel.GamePersonId : null;

            public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

            public int LevelTypeId => _viewModel.LevelTypeId;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int[] PersonIds => _viewModel.PersonIds.ToArray();

            public int QualityTypeId => _viewModel.JerseyQualityTypeId;

            public int SizeId => _viewModel.SizeId;

            public int[] SportIds => _viewModel.SportIds.ToArray();

            public int StyleTypeId => _viewModel.JerseyStyleTypeId;

            public int[] TeamIds => _viewModel.TeamIds.ToArray();

            public int TypeId => _viewModel.JerseyTypeId;
        }
    }
}
