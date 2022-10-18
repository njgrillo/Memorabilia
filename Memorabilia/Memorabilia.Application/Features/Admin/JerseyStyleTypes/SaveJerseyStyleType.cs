using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public record SaveJerseyStyleType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveJerseyStyleType>
    {
        private readonly IDomainRepository<JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task Handle(SaveJerseyStyleType request)
        {
            JerseyStyleType jerseyStyleType;

            if (request.ViewModel.IsNew)
            {
                jerseyStyleType = new JerseyStyleType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _jerseyStyleTypeRepository.Add(jerseyStyleType);

                return;
            }

            jerseyStyleType = await _jerseyStyleTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _jerseyStyleTypeRepository.Delete(jerseyStyleType);

                return;
            }

            jerseyStyleType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _jerseyStyleTypeRepository.Update(jerseyStyleType);
        }
    }
}
