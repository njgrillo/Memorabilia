﻿using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.GloveTypes
{
    public class SaveGloveType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IGloveTypeRepository _gloveTypeRepository;

            public Handler(IGloveTypeRepository gloveTypeRepository)
            {
                _gloveTypeRepository = gloveTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                GloveType gloveType;

                if (command.IsNew)
                {
                    gloveType = new GloveType(command.Name, command.Abbreviation);
                    await _gloveTypeRepository.Add(gloveType).ConfigureAwait(false);

                    return;
                }

                gloveType = await _gloveTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _gloveTypeRepository.Delete(gloveType).ConfigureAwait(false);

                    return;
                }

                gloveType.Set(command.Name, command.Abbreviation);

                await _gloveTypeRepository.Update(gloveType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
