﻿namespace Memorabilia.Application.Features.Memorabilia.Lithograph;

public class SaveLithograph
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

            memorabilia.SetLithograph(command.BrandId,
                                      command.Matted,
                                      command.OrientationId,
                                      command.PersonIds,
                                      command.SizeId,
                                      command.SportIds,
                                      command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveLithographViewModel _viewModel;

        public Command(SaveLithographViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public bool Matted => _viewModel.Matted;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int OrientationId => _viewModel.OrientationId;

        public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

        public int SizeId => _viewModel.SizeId;

        public int[] SportIds => _viewModel.SportIds.ToArray();

        public int[] TeamIds => _viewModel.Teams.Where(team => !team.IsDeleted).Select(team => team.Id).ToArray();
    }
}
