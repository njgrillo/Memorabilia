using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations;

public record SaveOccupation(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveOccupation>
    {
        private readonly IDomainRepository<Occupation> _occupationRepository;

        public Handler(IDomainRepository<Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task Handle(SaveOccupation request)
        {
            Occupation occupation;

            if (request.ViewModel.IsNew)
            {
                occupation = new Occupation(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _occupationRepository.Add(occupation);

                return;
            }

            occupation = await _occupationRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _occupationRepository.Delete(occupation);

                return;
            }

            occupation.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _occupationRepository.Update(occupation);
        }
    }
}
