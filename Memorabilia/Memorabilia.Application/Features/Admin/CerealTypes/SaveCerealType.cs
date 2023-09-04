namespace Memorabilia.Application.Features.Admin.CerealTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveCerealType(DomainEditModel CerealType) : ICommand
{
    public class Handler : CommandHandler<SaveCerealType>
    {
        private readonly IDomainRepository<Entity.CerealType> _cerealTypeRepository;

        public Handler(IDomainRepository<Entity.CerealType> cerealTypeRepository)
        {
            _cerealTypeRepository = cerealTypeRepository;
        }

        protected override async Task Handle(SaveCerealType request)
        {
            Entity.CerealType cerealType;

            if (request.CerealType.IsNew)
            {
                cerealType = new Entity.CerealType(request.CerealType.Name, 
                                                   request.CerealType.Abbreviation);

                await _cerealTypeRepository.Add(cerealType);

                return;
            }

            cerealType = await _cerealTypeRepository.Get(request.CerealType.Id);

            if (request.CerealType.IsDeleted)
            {
                await _cerealTypeRepository.Delete(cerealType);

                return;
            }

            cerealType.Set(request.CerealType.Name, 
                           request.CerealType.Abbreviation);

            await _cerealTypeRepository.Update(cerealType);
        }
    }
}
