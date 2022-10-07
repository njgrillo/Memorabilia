using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sizes;

public class SaveSize
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Size> _sizeRepository;

        public Handler(IDomainRepository<Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task Handle(Command command)
        {
            Size size;

            if (command.IsNew)
            {
                size = new Size(command.Name, command.Abbreviation);

                await _sizeRepository.Add(size);

                return;
            }

            size = await _sizeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _sizeRepository.Delete(size);

                return;
            }

            size.Set(command.Name, command.Abbreviation);

            await _sizeRepository.Update(size);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
