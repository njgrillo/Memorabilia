namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record SaveAccomplishmentType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveAccomplishmentType>
    {
        private readonly IDomainRepository<Entity.AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task Handle(SaveAccomplishmentType request)
        {
            Entity.AccomplishmentType accomplishmentType;

            if (request.ViewModel.IsNew)
            {
                accomplishmentType = new Entity.AccomplishmentType(request.ViewModel.Name, request.ViewModel.Abbreviation);

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