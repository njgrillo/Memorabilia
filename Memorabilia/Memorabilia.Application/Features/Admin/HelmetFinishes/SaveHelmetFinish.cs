namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public record SaveHelmetFinish(DomainEditModel HelmetFinish) : ICommand
{
    public class Handler : CommandHandler<SaveHelmetFinish>
    {
        private readonly IDomainRepository<Entity.HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<Entity.HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task Handle(SaveHelmetFinish request)
        {
            Entity.HelmetFinish helmetFinish;

            if (request.HelmetFinish.IsNew)
            {
                helmetFinish = new Entity.HelmetFinish(request.HelmetFinish.Name, 
                                                       request.HelmetFinish.Abbreviation);

                await _helmetFinishRepository.Add(helmetFinish);

                return;
            }

            helmetFinish = await _helmetFinishRepository.Get(request.HelmetFinish.Id);

            if (request.HelmetFinish.IsDeleted)
            {
                await _helmetFinishRepository.Delete(helmetFinish);

                return;
            }

            helmetFinish.Set(request.HelmetFinish.Name, 
                             request.HelmetFinish.Abbreviation);

            await _helmetFinishRepository.Update(helmetFinish);
        }
    }
}
