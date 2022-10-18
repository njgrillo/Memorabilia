using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public record SaveBaseballType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveBaseballType>
    {
        private readonly IDomainRepository<BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task Handle(SaveBaseballType request)
        {
            BaseballType baseballType;

            if (request.ViewModel.IsNew)
            {
                baseballType = new BaseballType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _baseballTypeRepository.Add(baseballType);

                return;
            }

            baseballType = await _baseballTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _baseballTypeRepository.Delete(baseballType);

                return;
            }

            baseballType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _baseballTypeRepository.Update(baseballType);
        }
    }
}
