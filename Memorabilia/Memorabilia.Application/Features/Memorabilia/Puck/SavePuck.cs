﻿namespace Memorabilia.Application.Features.Memorabilia.Puck;

public class SavePuck
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

            memorabilia.SetPuck(command.BrandId,
                                command.GameDate,
                                command.GameStyleTypeId,
                                command.LevelTypeId,
                                command.PersonId,
                                command.SizeId,
                                command.SportId,
                                command.TeamId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly PuckEditModel _editModel;

        public Command(PuckEditModel editModel)
        {
            _editModel = editModel;
        }

        public int BrandId 
            => _editModel.BrandId;

        public DateTime? GameDate 
            => _editModel.GameDate;

        public int? GameStyleTypeId 
            => _editModel.GameStyleTypeId.ToNullableInt();

        public int LevelTypeId 
            => _editModel.LevelTypeId;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int? PersonId 
            => _editModel.Person?.Id.ToNullableInt() ?? null;

        public int SizeId 
            => _editModel.SizeId;

        public int SportId 
            => Constant.Sport.Hockey.Id;

        public int? TeamId 
            => _editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
