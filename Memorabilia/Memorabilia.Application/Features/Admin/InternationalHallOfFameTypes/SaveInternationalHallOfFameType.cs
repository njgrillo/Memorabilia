namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveInternationalHallOfFameType(DomainEditModel InternationalHallOfFameType) : ICommand
{
    public class Handler(IDomainRepository<Entity.InternationalHallOfFameType> internationalHallOfFameTypeRepository) 
        : CommandHandler<SaveInternationalHallOfFameType>
    {
        protected override async Task Handle(SaveInternationalHallOfFameType request)
        {
            Entity.InternationalHallOfFameType internationalHallOfFameType;

            if (request.InternationalHallOfFameType.IsNew)
            {
                internationalHallOfFameType = new Entity.InternationalHallOfFameType(request.InternationalHallOfFameType.Name, 
                                                                                     request.InternationalHallOfFameType.Abbreviation);

                await internationalHallOfFameTypeRepository.Add(internationalHallOfFameType);

                return;
            }

            internationalHallOfFameType = await internationalHallOfFameTypeRepository.Get(request.InternationalHallOfFameType.Id);

            if (request.InternationalHallOfFameType.IsDeleted)
            {
                await internationalHallOfFameTypeRepository.Delete(internationalHallOfFameType);

                return;
            }

            internationalHallOfFameType.Set(request.InternationalHallOfFameType.Name, 
                                            request.InternationalHallOfFameType.Abbreviation);

            await internationalHallOfFameTypeRepository.Update(internationalHallOfFameType);
        }
    }
}
