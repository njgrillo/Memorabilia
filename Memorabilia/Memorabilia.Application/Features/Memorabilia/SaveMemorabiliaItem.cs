namespace Memorabilia.Application.Features.Memorabilia;

[AuthorizeByPermission(Enum.Permission.Memorabilia)]
public class SaveMemorabiliaItem
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia;

            if (command.IsNew)
            {
                memorabilia = new Entity.Memorabilia(command.AcquiredDate,
                                                     command.AcquiredWithAutograph,
                                                     command.AcquisitionTypeId,
                                                     command.Collections,
                                                     command.ConditionId,                                                                  
                                                     command.Cost,
                                                     command.Denominator,
                                                     command.EstimatedValue,
                                                     command.ForTrade,
                                                     command.Framed,
                                                     command.ItemTypeId,
                                                     command.Note,
                                                     command.Numerator,
                                                     command.PrivacyTypeId,                                                                  
                                                     command.PurchaseTypeId,
                                                     command.UserId);

                await memorabiliaRepository.Add(memorabilia);

                command.Id = memorabilia.Id;

                return;
            }

            memorabilia = await memorabiliaRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await memorabiliaRepository.Delete(memorabilia);

                return;
            }

            memorabilia.Set(command.AcquiredDate,    
                            command.AcquiredWithAutograph,
                            command.AcquisitionTypeId,
                            command.Collections,
                            command.ConditionId,
                            command.Cost,
                            command.Denominator,
                            command.EstimatedValue,
                            command.ForTrade,
                            command.Framed,
                            command.Note,
                            command.Numerator,
                            command.PrivacyTypeId,
                            command.PurchaseTypeId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly MemorabiliaEditModel _editModel;

        public Command(MemorabiliaEditModel editModel)
        {
            _editModel = editModel;
            Id = _editModel.Id;
        }

        public int AcquisitionTypeId 
            => _editModel.AcquisitionTypeId;

        public DateTime? AcquiredDate 
            => _editModel.AcquiredDate;

        public bool AcquiredWithAutograph 
            => _editModel.AcquiredWithAutograph;

        public Entity.Collection[] Collections
            => _editModel.Collections.ToArray();

        public int? ConditionId 
            => _editModel.ConditionId.ToNullableInt();

        public decimal? Cost 
            => _editModel.Cost;

        public DateTime CreateDate 
            => _editModel.CreateDate;

        public int? Denominator 
            => _editModel.Denominator;

        public decimal? EstimatedValue 
            => _editModel.EstimatedValue;

        public bool ForTrade 
            => _editModel.ForTrade;

        public bool Framed 
            => _editModel.Framed;

        public int Id { get; set; }

        public bool IsDeleted 
            => _editModel.IsDeleted;

        public bool IsNew 
            => _editModel.IsNew;

        public int ItemTypeId 
            => _editModel.ItemType?.Id ?? 0;

        public DateTime? LastModifiedDate 
            => _editModel.LastModifiedDate;

        public string Note 
            => _editModel.Note;  

        public int? Numerator 
            => _editModel.Numerator;

        public int PrivacyTypeId 
            => _editModel.PrivacyTypeId;

        public int? PurchaseTypeId
            => _editModel.PurchaseTypeId
                         .ToNullableInt();

        public int UserId 
            => _editModel.UserId;
    }
}
