using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Commissioners;

public record SaveCommissioner(SaveCommissionerViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveCommissioner>
    {
        private readonly ICommissionerRepository _commissionerRepository;

        public Handler(ICommissionerRepository commissionerRepository)
        {
            _commissionerRepository = commissionerRepository;
        }

        protected override async Task Handle(SaveCommissioner request)
        {
            Commissioner commissioner;

            if (request.ViewModel.IsNew)
            {
                commissioner = new Commissioner(request.ViewModel.SportLeagueLevelId,
                                                request.ViewModel.Person.Id,
                                                request.ViewModel.BeginYear,
                                                request.ViewModel.EndYear);

                await _commissionerRepository.Add(commissioner);

                return;
            }

            commissioner = await _commissionerRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _commissionerRepository.Delete(commissioner);

                return;
            }

            commissioner.Set(request.ViewModel.BeginYear, request.ViewModel.EndYear);

            await _commissionerRepository.Update(commissioner);
        }
    }
}
