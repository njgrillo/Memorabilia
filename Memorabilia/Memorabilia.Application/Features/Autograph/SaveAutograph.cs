using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph
{
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
                    autograph = new Domain.Entities.Autograph(command.MemorabiliaId, 
                                                              command.PersonId,
                                                              command.ConditionId,
                                                              command.SpotId,
                                                              command.WritingInstrumentId,
                                                              command.ColorId,
                                                              command.UserId);

                    await _autographRepository.Add(autograph).ConfigureAwait(false);

                    return;
                }

                autograph = await _autographRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _autographRepository.Delete(autograph).ConfigureAwait(false);

                    return;
                }

                autograph.Set(command.PersonId,
                              command.ConditionId,
                              command.SpotId,
                              command.WritingInstrumentId,
                              command.ColorId);

                await _autographRepository.Update(autograph).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveAutographViewModel _viewModel;

            public Command(SaveAutographViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int? ColorId => _viewModel.ColorId;

            public int? ConditionId => _viewModel.ConditionId;

            public DateTime CreateDate => _viewModel.CreateDate;

            public int Id => _viewModel.Id;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public DateTime? LastModifiedDate => _viewModel.LastModifiedDate;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int PersonId => _viewModel.PersonId;

            public int? SpotId => _viewModel.SpotId;

            public int UserId => _viewModel.UserId;

            public int? WritingInstrumentId => _viewModel.WritingInstrumentId;
        }
    }
}
