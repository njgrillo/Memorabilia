using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.CerealTypes;

public record SaveCerealType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveCerealType>
    {
        private readonly IDomainRepository<CerealType> _cerealTypeRepository;

        public Handler(IDomainRepository<CerealType> cerealTypeRepository)
        {
            _cerealTypeRepository = cerealTypeRepository;
        }

        protected override async Task Handle(SaveCerealType request)
        {
            CerealType cerealType;

            if (request.ViewModel.IsNew)
            {
                cerealType = new CerealType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _cerealTypeRepository.Add(cerealType);

                return;
            }

            cerealType = await _cerealTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _cerealTypeRepository.Delete(cerealType);

                return;
            }

            cerealType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _cerealTypeRepository.Update(cerealType);
        }
    }
}
