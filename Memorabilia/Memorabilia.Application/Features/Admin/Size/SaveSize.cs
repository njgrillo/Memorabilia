﻿using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Size
{
    public class SaveSize
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ISizeRepository _sizeRepository;

            public Handler(ISizeRepository sizeRepository)
            {
                _sizeRepository = sizeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Size size;

                if (command.IsNew)
                {
                    size = new Domain.Entities.Size(command.Name, command.Abbreviation);
                    await _sizeRepository.Add(size).ConfigureAwait(false);

                    return;
                }

                size = await _sizeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _sizeRepository.Delete(size).ConfigureAwait(false);

                    return;
                }

                size.Set(command.Name, command.Abbreviation);

                await _sizeRepository.Update(size).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel)
            {
            }
        }
    }
}
