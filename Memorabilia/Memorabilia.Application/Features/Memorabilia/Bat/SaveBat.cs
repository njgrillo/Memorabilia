namespace Memorabilia.Application.Features.Memorabilia.Bat;

public class SaveBat
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetBat(command.BatTypeId,
                               command.BrandId,
                               command.ColorId,
                               command.GameDate,
                               command.GameStyleTypeId,
                               command.Length,
                               command.PersonId,
                               command.SizeId,
                               command.SportId,
                               command.TeamId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(BatEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int? BatTypeId 
            => editModel.BatTypeId.ToNullableInt();

        public int BrandId 
            => editModel.BrandId;

        public int? ColorId 
            => editModel.ColorId.ToNullableInt();

        public DateTime? GameDate 
            => editModel.GameDate;

        public int? GameStyleTypeId 
            => editModel.GameStyleTypeId.ToNullableInt();

        public int? Length 
            => editModel.Length > 0 
            ? editModel.Length 
            : null;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int? PersonId 
            => editModel.Person?.Id.ToNullableInt() ?? null;

        public int SizeId 
            => editModel.SizeId;

        public int SportId 
            => Constant.Sport.Baseball.Id;

        public int? TeamId 
            => editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
