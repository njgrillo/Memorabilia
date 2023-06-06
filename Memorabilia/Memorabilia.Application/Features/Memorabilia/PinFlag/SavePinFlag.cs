﻿namespace Memorabilia.Application.Features.Memorabilia.PinFlag;

public class SavePinFlag
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task Handle(Command command)
        {
            var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetPinFlag(command.GameDate, 
                                   command.GameStyleTypeId, 
                                   command.PersonId, 
                                   command.SportId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SavePinFlagViewModel _viewModel;

        public Command(SavePinFlagViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public DateTime? GameDate => _viewModel.GameDate;

        public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person?.Id : null;

        public int SportId => Constant.Sport.Golf.Id;
    }
}
