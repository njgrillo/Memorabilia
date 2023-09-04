namespace Memorabilia.Application.Features.Admin.AwardTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveAwardType(DomainEditModel AwardType) : ICommand
{
    public class Handler : CommandHandler<SaveAwardType>
    {
        private readonly IDomainRepository<Entity.AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<Entity.AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task Handle(SaveAwardType request)
        {
            Entity.AwardType awardType;

            if (request.AwardType.IsNew)
            {
                awardType = new Entity.AwardType(request.AwardType.Name, 
                                                 request.AwardType.Abbreviation);

                await _awardTypeRepository.Add(awardType);

                return;
            }

            awardType = await _awardTypeRepository.Get(request.AwardType.Id);

            if (request.AwardType.IsDeleted)
            {
                await _awardTypeRepository.Delete(awardType);

                return;
            }

            awardType.Set(request.AwardType.Name, 
                          request.AwardType.Abbreviation);

            await _awardTypeRepository.Update(awardType);
        }
    }
}
