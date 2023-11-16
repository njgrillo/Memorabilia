namespace Memorabilia.Application.Features.Admin.Pewters;

[AuthorizeByRole(Enum.Role.Admin)]
public record SavePewter(PewterEditModel EditModel) : ICommand
{
    public class Handler(IDomainRepository<Entity.Pewter> pewterRepository) 
        : CommandHandler<SavePewter>
    {
        protected override async Task Handle(SavePewter request)
        {
            Entity.Pewter pewter;

            if (request.EditModel.IsNew)
            {
                pewter = new Entity.Pewter(request.EditModel.Franchise.Id,
                                           request.EditModel.TeamId,
                                           request.EditModel.SizeId,
                                           !request.EditModel.FileName.IsNullOrEmpty() ? Constant.ImageType.Primary.Id : null,
                                           request.EditModel.FileName);

                await pewterRepository.Add(pewter);

                return;
            }

            pewter = await pewterRepository.Get(request.EditModel.Id);

            if (request.EditModel.IsDeleted)
            {
                await pewterRepository.Delete(pewter);

                return;
            }

            pewter.Set(request.EditModel.Franchise.Id,
                       request.EditModel.TeamId,
                       request.EditModel.SizeId,
                       !request.EditModel.FileName.IsNullOrEmpty() ? Constant.ImageType.Primary.Id : null,
                       request.EditModel.FileName);

            await pewterRepository.Update(pewter);
        }
    }
}
