namespace Memorabilia.Application.Features.Admin.Commissioners;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveCommissioner(CommissionerEditModel Commissioner) : ICommand
{
    public class Handler(ICommissionerRepository commissionerRepository) 
        : CommandHandler<SaveCommissioner>
    {
        protected override async Task Handle(SaveCommissioner request)
        {
            Entity.Commissioner commissioner;

            if (request.Commissioner.IsNew)
            {
                commissioner = new Entity.Commissioner(request.Commissioner.SportLeagueLevelId,
                                                       request.Commissioner.Person.Id,
                                                       request.Commissioner.BeginYear,
                                                       request.Commissioner.EndYear);

                await commissionerRepository.Add(commissioner);

                return;
            }

            commissioner = await commissionerRepository.Get(request.Commissioner.Id);

            if (request.Commissioner.IsDeleted)
            {
                await commissionerRepository.Delete(commissioner);

                return;
            }

            commissioner.Set(request.Commissioner.BeginYear, 
                             request.Commissioner.EndYear);

            await commissionerRepository.Update(commissioner);
        }
    }
}
