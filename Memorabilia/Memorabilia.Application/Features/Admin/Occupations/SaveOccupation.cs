namespace Memorabilia.Application.Features.Admin.Occupations;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveOccupation(DomainEditModel Occupation) : ICommand
{
    public class Handler(IDomainRepository<Entity.Occupation> occupationRepository) 
        : CommandHandler<SaveOccupation>
    {
        protected override async Task Handle(SaveOccupation request)
        {
            Entity.Occupation occupation;

            if (request.Occupation.IsNew)
            {
                occupation = new Entity.Occupation(request.Occupation.Name, 
                                                   request.Occupation.Abbreviation);

                await occupationRepository.Add(occupation);

                return;
            }

            occupation = await occupationRepository.Get(request.Occupation.Id);

            if (request.Occupation.IsDeleted)
            {
                await occupationRepository.Delete(occupation);

                return;
            }

            occupation.Set(request.Occupation.Name, 
                           request.Occupation.Abbreviation);

            await occupationRepository.Update(occupation);
        }
    }
}
