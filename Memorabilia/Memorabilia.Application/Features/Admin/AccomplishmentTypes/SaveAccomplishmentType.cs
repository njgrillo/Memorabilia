using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record SaveAccomplishmentType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveAccomplishmentType>
    {
        private readonly IDomainRepository<AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task Handle(SaveAccomplishmentType request)
        {
            AccomplishmentType accomplishmentType;

            if (request.ViewModel.IsNew)
            {
                accomplishmentType = new AccomplishmentType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _accomplishmentTypeRepository.Add(accomplishmentType);

                return;
            }

            accomplishmentType = await _accomplishmentTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _accomplishmentTypeRepository.Delete(accomplishmentType);

                return;
            }

            accomplishmentType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _accomplishmentTypeRepository.Update(accomplishmentType);
        }
    }
}