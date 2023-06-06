using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GloveTypes;

public record SaveGloveType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveGloveType>
    {
        private readonly IDomainRepository<GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task Handle(SaveGloveType request)
        {
            GloveType gloveType;

            if (request.ViewModel.IsNew)
            {
                gloveType = new GloveType(request.ViewModel.Name, request.ViewModel.Abbreviation);
                await _gloveTypeRepository.Add(gloveType);

                return;
            }

            gloveType = await _gloveTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _gloveTypeRepository.Delete(gloveType);

                return;
            }

            gloveType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _gloveTypeRepository.Update(gloveType);
        }
    }
}
