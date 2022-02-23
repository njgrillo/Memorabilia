using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Helmet
{
    public class SaveHelmet
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

                memorabilia.SetHelmet(command.BrandId,
                                      command.GameDate,
                                      command.GameStyleTypeId,
                                      command.HelmetQualityTypeId,
                                      command.HelmetTypeId,
                                      command.LevelTypeId,
                                      command.PersonId,
                                      command.SizeId,
                                      command.SportIds,
                                      command.TeamIds);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveHelmetViewModel _viewModel;

            public Command(SaveHelmetViewModel viewModel)
            {
                _viewModel = viewModel;
            }            

            public int BrandId => _viewModel.BrandId;

            public DateTime? GameDate => _viewModel.GameDate;

            public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

            public int? HelmetQualityTypeId => _viewModel.HelmetQualityTypeId > 0 ? _viewModel.HelmetQualityTypeId : null;

            public int? HelmetTypeId => _viewModel.HelmetTypeId > 0 ? _viewModel.HelmetTypeId : null;

            public int LevelTypeId => _viewModel.LevelTypeId;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person?.Id : null;

            public int SizeId => _viewModel.SizeId;

            public int[] SportIds => _viewModel.SportIds.ToArray();

            public int[] TeamIds => _viewModel.TeamIds.ToArray();
        }
    }
}
