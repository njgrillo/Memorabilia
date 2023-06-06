using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public record SaveJerseyType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveJerseyType>
    {
        private readonly IDomainRepository<JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task Handle(SaveJerseyType request)
        {
            JerseyType jerseyType;

            if (request.ViewModel.IsNew)
            {
                jerseyType = new JerseyType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _jerseyTypeRepository.Add(jerseyType);

                return;
            }

            jerseyType = await _jerseyTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _jerseyTypeRepository.Delete(jerseyType);

                return;
            }

            jerseyType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _jerseyTypeRepository.Update(jerseyType);
        }
    }
}
