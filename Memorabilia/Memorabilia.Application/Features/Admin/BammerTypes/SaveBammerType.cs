using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BammerTypes;

public record SaveBammerType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveBammerType>
    {
        private readonly IDomainRepository<BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task Handle(SaveBammerType request)
        {
            BammerType bammerType;

            if (request.ViewModel.IsNew)
            {
                bammerType = new BammerType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _bammerTypeRepository.Add(bammerType);

                return;
            }

            bammerType = await _bammerTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _bammerTypeRepository.Delete(bammerType);

                return;
            }

            bammerType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _bammerTypeRepository.Update(bammerType);
        }
    }
}
