using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public record SaveHelmetFinish(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveHelmetFinish>
    {
        private readonly IDomainRepository<HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task Handle(SaveHelmetFinish request)
        {
            HelmetFinish helmetFinish;

            if (request.ViewModel.IsNew)
            {
                helmetFinish = new HelmetFinish(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _helmetFinishRepository.Add(helmetFinish);

                return;
            }

            helmetFinish = await _helmetFinishRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _helmetFinishRepository.Delete(helmetFinish);

                return;
            }

            helmetFinish.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _helmetFinishRepository.Update(helmetFinish);
        }
    }
}
