using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
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
                    memorabilia = new Domain.Entities.Memorabilia(command.ItemTypeId,
                                                                  command.ConditionId,
                                                                  command.ImagePath,
                                                                  command.Cost,
                                                                  command.EstimatedValue,
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

                memorabilia.Set(command.ConditionId,
                                command.ImagePath,
                                command.Cost,
                                command.EstimatedValue);

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

            public int? ConditionId => _viewModel.ConditionId;

            public decimal? Cost => _viewModel.Cost;

            public DateTime CreateDate => _viewModel.CreateDate;

            public decimal? EstimatedValue => _viewModel.EstimatedValue;

            public int Id { get; set; }

            public string ImagePath => _viewModel.ImagePath;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public int ItemTypeId => _viewModel.ItemTypeId;

            public DateTime? LastModifiedDate => _viewModel.LastModifiedDate;

            public int UserId => _viewModel.UserId;
        }
    }
}
