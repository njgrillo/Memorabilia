namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveHelmetFinish(DomainEditModel HelmetFinish) : ICommand
{
    public class Handler(IDomainRepository<Entity.HelmetFinish> helmetFinishRepository) 
        : CommandHandler<SaveHelmetFinish>
    {
        protected override async Task Handle(SaveHelmetFinish request)
        {
            Entity.HelmetFinish helmetFinish;

            if (request.HelmetFinish.IsNew)
            {
                helmetFinish = new Entity.HelmetFinish(request.HelmetFinish.Name, 
                                                       request.HelmetFinish.Abbreviation);

                await helmetFinishRepository.Add(helmetFinish);

                return;
            }

            helmetFinish = await helmetFinishRepository.Get(request.HelmetFinish.Id);

            if (request.HelmetFinish.IsDeleted)
            {
                await helmetFinishRepository.Delete(helmetFinish);

                return;
            }

            helmetFinish.Set(request.HelmetFinish.Name, 
                             request.HelmetFinish.Abbreviation);

            await helmetFinishRepository.Update(helmetFinish);
        }
    }
}
