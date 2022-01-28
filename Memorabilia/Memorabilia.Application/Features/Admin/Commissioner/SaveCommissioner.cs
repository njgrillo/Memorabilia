﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Commissioner
{
    public class SaveCommissioner
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ICommissionerRepository _commissionerRepository;

            public Handler(ICommissionerRepository commissionerRepository)
            {
                _commissionerRepository = commissionerRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Commissioner commissioner;

                if (command.IsNew)
                {
                    commissioner = new Domain.Entities.Commissioner(command.SportId, command.PersonId, command.BeginYear, command.EndYear);
                    await _commissionerRepository.Add(commissioner).ConfigureAwait(false);

                    return;
                }

                commissioner = await _commissionerRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _commissionerRepository.Delete(commissioner).ConfigureAwait(false);

                    return;
                }

                commissioner.Set(command.BeginYear, command.EndYear);

                await _commissionerRepository.Update(commissioner).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveCommissionerViewModel _viewModel;

            public Command(SaveCommissionerViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int? BeginYear => _viewModel.BeginYear;

            public int? EndYear => _viewModel.EndYear;

            public int Id => _viewModel.Id;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public int PersonId => _viewModel.PersonId;

            public int SportId => _viewModel.SportId;
        }
    }
}
