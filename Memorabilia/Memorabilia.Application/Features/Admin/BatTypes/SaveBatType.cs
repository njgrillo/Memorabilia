using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BatTypes;

public record SaveBatType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveBatType>
    {
        private readonly IDomainRepository<BatType> _batTypeRepository;

        public Handler(IDomainRepository<BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task Handle(SaveBatType request)
        {
            BatType batType;

            if (request.ViewModel.IsNew)
            {
                batType = new BatType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _batTypeRepository.Add(batType);

                return;
            }

            batType = await _batTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _batTypeRepository.Delete(batType);

                return;
            }

            batType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _batTypeRepository.Update(batType);
        }
    }
}
