using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sizes;

public record SaveSize(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveSize>
    {
        private readonly IDomainRepository<Size> _sizeRepository;

        public Handler(IDomainRepository<Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task Handle(SaveSize request)
        {
            Size size;

            if (request.ViewModel.IsNew)
            {
                size = new Size(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _sizeRepository.Add(size);

                return;
            }

            size = await _sizeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _sizeRepository.Delete(size);

                return;
            }

            size.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _sizeRepository.Update(size);
        }
    }
}
