using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Pewters;

public record SavePewter(SavePewterViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SavePewter>
    {
        private readonly IDomainRepository<Pewter> _pewterRepository;

        public Handler(IDomainRepository<Pewter> pewterRepository)
        {
            _pewterRepository = pewterRepository;
        }

        protected override async Task Handle(SavePewter request)
        {
            Pewter pewter;

            if (request.ViewModel.IsNew)
            {
                pewter = new Pewter(request.ViewModel.FranchiseId,
                                    request.ViewModel.TeamId,
                                    request.ViewModel.SizeId,
                                    !request.ViewModel.ImagePath.IsNullOrEmpty() ? Domain.Constants.ImageType.Primary.Id : null,
                                    request.ViewModel.ImagePath);

                await _pewterRepository.Add(pewter);

                return;
            }

            pewter = await _pewterRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _pewterRepository.Delete(pewter);

                return;
            }

            pewter.Set(request.ViewModel.FranchiseId,
                       request.ViewModel.TeamId,
                       request.ViewModel.SizeId,
                       !request.ViewModel.ImagePath.IsNullOrEmpty() ? Domain.Constants.ImageType.Primary.Id : null,
                       request.ViewModel.ImagePath);

            await _pewterRepository.Update(pewter);
        }
    }
}
