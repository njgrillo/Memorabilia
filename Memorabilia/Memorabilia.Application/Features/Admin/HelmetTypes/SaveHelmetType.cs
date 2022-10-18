using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public record SaveHelmetType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveHelmetType>
    {
        private readonly IDomainRepository<HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task Handle(SaveHelmetType request)
        {
            HelmetType helmetType;

            if (request.ViewModel.IsNew)
            {
                helmetType = new HelmetType(request.ViewModel.Name, request.ViewModel.Abbreviation);
                await _helmetTypeRepository.Add(helmetType);

                return;
            }

            helmetType = await _helmetTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _helmetTypeRepository.Delete(helmetType);

                return;
            }

            helmetType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _helmetTypeRepository.Update(helmetType);
        }
    }
}
