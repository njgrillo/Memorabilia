﻿namespace Memorabilia.Application.Features.Memorabilia.Bookplate;

public class SaveBookplate
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

            memorabilia.SetBookplate(command.PersonId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveBookplateViewModel _viewModel;

        public Command(SaveBookplateViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person?.Id : null;
    }
}
