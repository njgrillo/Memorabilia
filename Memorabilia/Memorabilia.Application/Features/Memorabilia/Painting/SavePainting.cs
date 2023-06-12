﻿namespace Memorabilia.Application.Features.Memorabilia.Painting;

public class SavePainting
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
            Entity.Memorabilia memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetPainting(command.BrandId,
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
        private readonly PaintingEditModel _editModel;

        public Command(PaintingEditModel editModel)
        {
            _editModel = editModel;
        }

        public int BrandId 
            => _editModel.BrandId;

        public bool Matted 
            => _editModel.Matted;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int OrientationId 
            => _editModel.OrientationId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();

        public int SizeId 
            => _editModel.SizeId;

        public int[] SportIds 
            => _editModel.SportIds.ToArray();

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();
    }
}
