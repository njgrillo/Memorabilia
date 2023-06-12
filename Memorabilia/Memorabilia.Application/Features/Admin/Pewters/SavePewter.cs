namespace Memorabilia.Application.Features.Admin.Pewters;

public record SavePewter(PewterEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SavePewter>
    {
        private readonly IDomainRepository<Entity.Pewter> _pewterRepository;

        public Handler(IDomainRepository<Entity.Pewter> pewterRepository)
        {
            _pewterRepository = pewterRepository;
        }

        protected override async Task Handle(SavePewter request)
        {
            Entity.Pewter pewter;

            if (request.ViewModel.IsNew)
            {
                pewter = new Entity.Pewter(request.ViewModel.Franchise.Id,
                                           request.ViewModel.TeamId,
                                           request.ViewModel.SizeId,
                                           !request.ViewModel.FileName.IsNullOrEmpty() ? Constant.ImageType.Primary.Id : null,
                                           request.ViewModel.FileName);

                await _pewterRepository.Add(pewter);

                return;
            }

            pewter = await _pewterRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _pewterRepository.Delete(pewter);

                return;
            }

            pewter.Set(request.ViewModel.Franchise.Id,
                       request.ViewModel.TeamId,
                       request.ViewModel.SizeId,
                       !request.ViewModel.FileName.IsNullOrEmpty() ? Constant.ImageType.Primary.Id : null,
                       request.ViewModel.FileName);

            await _pewterRepository.Update(pewter);
        }
    }
}
