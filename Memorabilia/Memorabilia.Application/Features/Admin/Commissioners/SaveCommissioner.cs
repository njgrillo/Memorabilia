namespace Memorabilia.Application.Features.Admin.Commissioners;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveCommissioner(CommissionerEditModel Commissioner) : ICommand
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
            Entity.Commissioner commissioner;

            if (request.Commissioner.IsNew)
            {
                commissioner = new Entity.Commissioner(request.Commissioner.SportLeagueLevelId,
                                                       request.Commissioner.Person.Id,
                                                       request.Commissioner.BeginYear,
                                                       request.Commissioner.EndYear);

                await _commissionerRepository.Add(commissioner);

                return;
            }

            commissioner = await _commissionerRepository.Get(request.Commissioner.Id);

            if (request.Commissioner.IsDeleted)
            {
                await _commissionerRepository.Delete(commissioner);

                return;
            }

            commissioner.Set(request.Commissioner.BeginYear, 
                             request.Commissioner.EndYear);

            await _commissionerRepository.Update(commissioner);
        }
    }
}
