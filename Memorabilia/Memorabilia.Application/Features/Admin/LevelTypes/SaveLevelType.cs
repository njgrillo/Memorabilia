using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LevelTypes;

public record SaveLevelType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveLevelType>
    {
        private readonly IDomainRepository<LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task Handle(SaveLevelType request)
        {
            LevelType levelType;

            if (request.ViewModel.IsNew)
            {
                levelType = new LevelType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _levelTypeRepository.Add(levelType);

                return;
            }

            levelType = await _levelTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _levelTypeRepository.Delete(levelType);

                return;
            }

            levelType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _levelTypeRepository.Update(levelType);
        }
    }
}
