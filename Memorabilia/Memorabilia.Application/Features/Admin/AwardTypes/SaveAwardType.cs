using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AwardTypes;

public record SaveAwardType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveAwardType>
    {
        private readonly IDomainRepository<AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task Handle(SaveAwardType request)
        {
            AwardType awardType;

            if (request.ViewModel.IsNew)
            {
                awardType = new AwardType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _awardTypeRepository.Add(awardType);

                return;
            }

            awardType = await _awardTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _awardTypeRepository.Delete(awardType);

                return;
            }

            awardType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _awardTypeRepository.Update(awardType);
        }
    }
}
