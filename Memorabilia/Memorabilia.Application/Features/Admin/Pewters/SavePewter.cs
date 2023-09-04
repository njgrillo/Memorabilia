namespace Memorabilia.Application.Features.Admin.Pewters;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SavePewter(PewterEditModel EditModel) : ICommand
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

            if (request.EditModel.IsNew)
            {
                pewter = new Entity.Pewter(request.EditModel.Franchise.Id,
                                           request.EditModel.TeamId,
                                           request.EditModel.SizeId,
                                           !request.EditModel.FileName.IsNullOrEmpty() ? Constant.ImageType.Primary.Id : null,
                                           request.EditModel.FileName);

                await _pewterRepository.Add(pewter);

                return;
            }

            pewter = await _pewterRepository.Get(request.EditModel.Id);

            if (request.EditModel.IsDeleted)
            {
                await _pewterRepository.Delete(pewter);

                return;
            }

            pewter.Set(request.EditModel.Franchise.Id,
                       request.EditModel.TeamId,
                       request.EditModel.SizeId,
                       !request.EditModel.FileName.IsNullOrEmpty() ? Constant.ImageType.Primary.Id : null,
                       request.EditModel.FileName);

            await _pewterRepository.Update(pewter);
        }
    }
}
