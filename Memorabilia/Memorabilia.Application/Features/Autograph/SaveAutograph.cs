namespace Memorabilia.Application.Features.Autograph;

public class SaveAutograph
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository)
        {
            _autographRepository = autographRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.Autograph autograph;

            if (command.IsNew)
            {
                autograph = new Entity.Autograph(command.AcquiredDate,
                                                 command.AcquisitionTypeId,
                                                 command.ColorId,
                                                 command.ConditionId,
                                                 command.Cost,
                                                 command.Denominator,
                                                 command.EstimatedValue,
                                                 command.FullName,
                                                 command.Grade,
                                                 command.MemorabiliaId,
                                                 command.Note,
                                                 command.Numerator,
                                                 command.PersonalizationText,
                                                 command.PersonId,
                                                 command.PurchaseTypeId,
                                                 command.ReceivedDate,
                                                 command.SentDate,
                                                 command.WritingInstrumentId);

                await _autographRepository.Add(autograph);

                command.Id = autograph.Id;

                return;
            }

            autograph = await _autographRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _autographRepository.Delete(autograph);

                return;
            }

            autograph.Set(command.AcquiredDate,
                          command.AcquisitionTypeId,
                          command.ColorId,
                          command.ConditionId,
                          command.Cost,
                          command.Denominator,
                          command.EstimatedValue,
                          command.FullName,
                          command.Grade,
                          command.Note,
                          command.Numerator,
                          command.PersonalizationText,
                          command.PersonId,
                          command.PurchaseTypeId,
                          command.ReceivedDate,
                          command.SentDate,
                          command.WritingInstrumentId);

            await _autographRepository.Update(autograph);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly AutographEditModel _editModel;

        public Command(AutographEditModel editModel)
        {
            _editModel = editModel;
            Id = _editModel.Id;
        }

        public DateTime? AcquiredDate 
            => _editModel.AcquiredDate;

        public int? AcquisitionTypeId 
            => _editModel.AcquisitionTypeId.ToNullableInt();

        public int ColorId 
            => _editModel.ColorId;

        public int ConditionId 
            => _editModel.ConditionId;

        public decimal? Cost 
            => _editModel.Cost;

        public DateTime CreateDate 
            => _editModel.CreateDate;

        public int? Denominator 
            => _editModel.Denominator;

        public decimal? EstimatedValue 
            => _editModel.EstimatedValue;

        public bool FullName 
            => _editModel.FullName;

        public int? Grade 
            => _editModel.Grade;

        public int Id { get; set; }

        public bool IsDeleted 
            => _editModel.IsDeleted;

        public bool IsModified 
            => _editModel.IsModified;

        public bool IsNew 
            => _editModel.IsNew;

        public DateTime? LastModifiedDate 
            => _editModel.LastModifiedDate;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public string Note 
            => _editModel.Note;

        public int? Numerator 
            => _editModel.Numerator;

        public string PersonalizationText 
            => _editModel.PersonalizationText;

        public int PersonId 
            => _editModel.Person.Id;

        public int? PurchaseTypeId 
            => _editModel.PurchaseTypeId.ToNullableInt();

        public DateTime? ReceivedDate 
            => _editModel.ReceivedDate;

        public DateTime? SentDate 
            => _editModel.SentDate;

        public int WritingInstrumentId 
            => _editModel.WritingInstrumentId;
    }
}
