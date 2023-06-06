using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FootballTypes;

public record SaveFootballType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveFootballType>
    {
        private readonly IDomainRepository<FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task Handle(SaveFootballType request)
        {
            FootballType footballType;

            if (request.ViewModel.IsNew)
            {
                footballType = new FootballType(request.ViewModel.Name, request.ViewModel.Abbreviation);
                await _footballTypeRepository.Add(footballType);

                return;
            }

            footballType = await _footballTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _footballTypeRepository.Delete(footballType);

                return;
            }

            footballType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _footballTypeRepository.Update(footballType);
        }
    }
}
