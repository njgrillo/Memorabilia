namespace Memorabilia.Application.Features.Admin.Occupations;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveOccupation(DomainEditModel Occupation) : ICommand
{
    public class Handler : CommandHandler<SaveOccupation>
    {
        private readonly IDomainRepository<Entity.Occupation> _occupationRepository;

        public Handler(IDomainRepository<Entity.Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task Handle(SaveOccupation request)
        {
            Entity.Occupation occupation;

            if (request.Occupation.IsNew)
            {
                occupation = new Entity.Occupation(request.Occupation.Name, 
                                                   request.Occupation.Abbreviation);

                await _occupationRepository.Add(occupation);

                return;
            }

            occupation = await _occupationRepository.Get(request.Occupation.Id);

            if (request.Occupation.IsDeleted)
            {
                await _occupationRepository.Delete(occupation);

                return;
            }

            occupation.Set(request.Occupation.Name, 
                           request.Occupation.Abbreviation);

            await _occupationRepository.Update(occupation);
        }
    }
}
