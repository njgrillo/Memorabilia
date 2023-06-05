namespace Memorabilia.Application.Features.Memorabilia;

public class SaveMemorabiliaItem
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

                await _memorabiliaRepository.Add(memorabilia);

                command.Id = memorabilia.Id;

                return;
            }

            memorabilia = await _memorabiliaRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _memorabiliaRepository.Delete(memorabilia);

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

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly MemorabiliaItemEditModel _viewModel;

        public Command(MemorabiliaItemEditModel viewModel)
        {
            _viewModel = viewModel;
            Id = _viewModel.Id;
        }

        public int AcquisitionTypeId => _viewModel.AcquisitionTypeId;

        public DateTime? AcquiredDate => _viewModel.AcquiredDate;

        public bool AcquiredWithAutograph => _viewModel.AcquiredWithAutograph;

        public Entity.Collection[] Collections => _viewModel.Collections.ToArray();

        public int? ConditionId 
            => _viewModel.ConditionId > 0 ? _viewModel.ConditionId : null;

        public decimal? Cost => _viewModel.Cost;

        public DateTime CreateDate => _viewModel.CreateDate;

        public int? Denominator => _viewModel.Denominator;

        public decimal? EstimatedValue => _viewModel.EstimatedValue;

        public bool ForTrade => _viewModel.ForTrade;

        public bool Framed => _viewModel.Framed;

        public int Id { get; set; }

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public int ItemTypeId => _viewModel.ItemType?.Id ?? 0;

        public DateTime? LastModifiedDate => _viewModel.LastModifiedDate;

        public string Note => _viewModel.Note;  

        public int? Numerator => _viewModel.Numerator;

        public int PrivacyTypeId => _viewModel.PrivacyTypeId;

        public int? PurchaseTypeId 
            => _viewModel.PurchaseTypeId > 0 ? _viewModel.PurchaseTypeId : null;

        public int UserId => _viewModel.UserId;
    }
}
