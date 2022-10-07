﻿namespace Memorabilia.Application.Features.Autograph;

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
            Domain.Entities.Autograph autograph;

            if (command.IsNew)
            {
                autograph = new Domain.Entities.Autograph(command.AcquiredDate,
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
        private readonly SaveAutographViewModel _viewModel;

        public Command(SaveAutographViewModel viewModel)
        {
            _viewModel = viewModel;
            Id = _viewModel.Id;
        }

        public DateTime? AcquiredDate => _viewModel.AcquiredDate;

        public int? AcquisitionTypeId => _viewModel.AcquisitionTypeId > 0 ? _viewModel.AcquisitionTypeId : null;

        public int ColorId => _viewModel.ColorId;

        public int ConditionId => _viewModel.ConditionId;

        public decimal? Cost => _viewModel.Cost;

        public DateTime CreateDate => _viewModel.CreateDate;

        public int? Denominator => _viewModel.Denominator;

        public decimal? EstimatedValue => _viewModel.EstimatedValue;

        public bool FullName => _viewModel.FullName;

        public int? Grade => _viewModel.Grade;

        public int Id { get; set; }

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public DateTime? LastModifiedDate => _viewModel.LastModifiedDate;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public string Note => _viewModel.Note;

        public int? Numerator => _viewModel.Numerator;

        public string PersonalizationText => _viewModel.PersonalizationText;

        public int PersonId => _viewModel.Person.Id;

        public int? PurchaseTypeId => _viewModel.PurchaseTypeId > 0 ? _viewModel.PurchaseTypeId : null;

        public DateTime? ReceivedDate => _viewModel.ReceivedDate;

        public DateTime? SentDate => _viewModel.SentDate;

        public int WritingInstrumentId => _viewModel.WritingInstrumentId;
    }
}
