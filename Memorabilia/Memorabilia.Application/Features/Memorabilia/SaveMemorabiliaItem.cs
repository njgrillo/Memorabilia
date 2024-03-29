﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia
{
    public class SaveMemorabiliaItem
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Memorabilia memorabilia;

                if (command.IsNew)
                {
                    memorabilia = new Domain.Entities.Memorabilia(command.AcquiredDate,
                                                                  command.AcquiredWithAutograph,
                                                                  command.AcquisitionTypeId,
                                                                  command.ConditionId,                                                                  
                                                                  command.Cost,
                                                                  command.EstimatedValue,
                                                                  command.ItemTypeId,
                                                                  command.PrivacyTypeId,                                                                  
                                                                  command.PurchaseTypeId,
                                                                  command.UserId);

                    await _memorabiliaRepository.Add(memorabilia).ConfigureAwait(false);

                    command.Id = memorabilia.Id;

                    return;
                }

                memorabilia = await _memorabiliaRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _memorabiliaRepository.Delete(memorabilia).ConfigureAwait(false);

                    return;
                }

                memorabilia.Set(command.AcquiredDate,    
                                command.AcquiredWithAutograph,
                                command.AcquisitionTypeId,
                                command.ConditionId,
                                command.Cost,
                                command.EstimatedValue,
                                command.PrivacyTypeId,
                                command.PurchaseTypeId);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveMemorabiliaItemViewModel _viewModel;

            public Command(SaveMemorabiliaItemViewModel viewModel)
            {
                _viewModel = viewModel;
                Id = _viewModel.Id;
            }

            public int AcquisitionTypeId => _viewModel.AcquisitionTypeId;

            public DateTime? AcquiredDate => _viewModel.AcquiredDate;

            public bool AcquiredWithAutograph => _viewModel.AcquiredWithAutograph;

            public int? ConditionId => _viewModel.ConditionId > 0 ? _viewModel.ConditionId : null;

            public decimal? Cost => _viewModel.Cost;

            public DateTime CreateDate => _viewModel.CreateDate;

            public decimal? EstimatedValue => _viewModel.EstimatedValue;

            public int Id { get; set; }

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public int ItemTypeId => _viewModel.ItemTypeId;

            public DateTime? LastModifiedDate => _viewModel.LastModifiedDate;

            public int PrivacyTypeId => _viewModel.PrivacyTypeId;

            public int? PurchaseTypeId => _viewModel.PurchaseTypeId > 0 ? _viewModel.PurchaseTypeId : null;

            public int UserId => _viewModel.UserId;
        }
    }
}
