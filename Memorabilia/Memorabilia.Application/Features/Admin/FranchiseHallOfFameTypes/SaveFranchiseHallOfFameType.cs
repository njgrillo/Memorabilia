using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public record SaveFranchiseHallOfFameType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveFranchiseHallOfFameType>
    {
        private readonly IDomainRepository<FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task Handle(SaveFranchiseHallOfFameType request)
        {
            FranchiseHallOfFameType franchiseHallOfFameType;

            if (request.ViewModel.IsNew)
            {
                franchiseHallOfFameType = new FranchiseHallOfFameType(request.ViewModel.Name, request.ViewModel.Abbreviation);
                await _franchiseHallOfFameTypeRepository.Add(franchiseHallOfFameType);

                return;
            }

            franchiseHallOfFameType = await _franchiseHallOfFameTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _franchiseHallOfFameTypeRepository.Delete(franchiseHallOfFameType);

                return;
            }

            franchiseHallOfFameType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _franchiseHallOfFameTypeRepository.Update(franchiseHallOfFameType);
        }
    }
}
