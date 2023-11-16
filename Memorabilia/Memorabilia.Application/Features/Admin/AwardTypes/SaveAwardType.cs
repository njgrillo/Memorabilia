namespace Memorabilia.Application.Features.Admin.AwardTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveAwardType(DomainEditModel AwardType) 
    : ICommand
{
    public class Handler(IDomainRepository<Entity.AwardType> awardTypeRepository) 
        : CommandHandler<SaveAwardType>
    {
        protected override async Task Handle(SaveAwardType request)
        {
            Entity.AwardType awardType;

            if (request.AwardType.IsNew)
            {
                awardType = new Entity.AwardType(request.AwardType.Name, 
                                                 request.AwardType.Abbreviation);

                await awardTypeRepository.Add(awardType);

                return;
            }

            awardType = await awardTypeRepository.Get(request.AwardType.Id);

            if (request.AwardType.IsDeleted)
            {
                await awardTypeRepository.Delete(awardType);

                return;
            }

            awardType.Set(request.AwardType.Name, 
                          request.AwardType.Abbreviation);

            await awardTypeRepository.Update(awardType);
        }
    }
}
