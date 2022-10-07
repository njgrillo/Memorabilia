﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colors;

public class SaveColor
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Color> _colorRepository;

        public Handler(IDomainRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task Handle(Command command)
        {
            Color color;

            if (command.IsNew)
            {
                color = new Color(command.Name, command.Abbreviation);

                await _colorRepository.Add(color);

                return;
            }

            color = await _colorRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _colorRepository.Delete(color);

                return;
            }

            color.Set(command.Name, command.Abbreviation);

            await _colorRepository.Update(color);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
