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

                memorabilia.SetBaseball(command.Anniversary,                                        
                                        command.BaseballTypeId,
                                        command.BrandId, 
                                        command.CommissionerId, 
                                        command.GameDate,
                                        command.GameStyleTypeId,
                                        command.LevelTypeId,
                                        command.PersonId,
                                        command.SizeId, 
                                        command.SportId,
                                        command.TeamIds,
                                        command.Year);                                    

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

            public string Anniversary => _viewModel.BaseballTypeAnniversary;                     

            public int? BaseballTypeId => _viewModel.BaseballTypeId > 0 ? _viewModel.BaseballTypeId : null;            

            public int BrandId => _viewModel.BrandId;

            public int CommissionerId => _viewModel.CommissionerId;

            public DateTime? GameDate => _viewModel.GameDate;

            public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

            public int LevelTypeId => _viewModel.LevelTypeId;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person.Id : null;

            public int SizeId => _viewModel.SizeId;

            public int SportId => Domain.Constants.Sport.Baseball.Id;

            public int[] TeamIds => _viewModel.Teams.Where(team => !team.IsDeleted).Select(team => team.Id).ToArray();

            public int? Year => _viewModel.BaseballTypeYear;            
        }
    }
}
