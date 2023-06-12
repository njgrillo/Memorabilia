namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public record SaveInternationalHallOfFameType(DomainEditModel InternationalHallOfFameType) : ICommand
{
    public class Handler : CommandHandler<SaveInternationalHallOfFameType>
    {
        private readonly IDomainRepository<Entity.InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<Entity.InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task Handle(SaveInternationalHallOfFameType request)
        {
            Entity.InternationalHallOfFameType internationalHallOfFameType;

            if (request.InternationalHallOfFameType.IsNew)
            {
                internationalHallOfFameType = new Entity.InternationalHallOfFameType(request.InternationalHallOfFameType.Name, 
                                                                                     request.InternationalHallOfFameType.Abbreviation);

                await _internationalHallOfFameTypeRepository.Add(internationalHallOfFameType);

                return;
            }

            internationalHallOfFameType = await _internationalHallOfFameTypeRepository.Get(request.InternationalHallOfFameType.Id);

            if (request.InternationalHallOfFameType.IsDeleted)
            {
                await _internationalHallOfFameTypeRepository.Delete(internationalHallOfFameType);

                return;
            }

            internationalHallOfFameType.Set(request.InternationalHallOfFameType.Name, 
                                            request.InternationalHallOfFameType.Abbreviation);

            await _internationalHallOfFameTypeRepository.Update(internationalHallOfFameType);
        }
    }
}
