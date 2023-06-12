namespace Memorabilia.Application.Features.Admin.Sizes;

public record SaveSize(DomainEditModel Size) : ICommand
{
    public class Handler : CommandHandler<SaveSize>
    {
        private readonly IDomainRepository<Entity.Size> _sizeRepository;

        public Handler(IDomainRepository<Entity.Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task Handle(SaveSize request)
        {
            Entity.Size size;

            if (request.Size.IsNew)
            {
                size = new Entity.Size(request.Size.Name, 
                                       request.Size.Abbreviation);

                await _sizeRepository.Add(size);

                return;
            }

            size = await _sizeRepository.Get(request.Size.Id);

            if (request.Size.IsDeleted)
            {
                await _sizeRepository.Delete(size);

                return;
            }

            size.Set(request.Size.Name, 
                     request.Size.Abbreviation);

            await _sizeRepository.Update(size);
        }
    }
}
