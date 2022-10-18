using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public record SavePriorityType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SavePriorityType>
    {
        private readonly IDomainRepository<PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task Handle(SavePriorityType request)
        {
            PriorityType priorityType;

            if (request.ViewModel.IsNew)
            {
                priorityType = new PriorityType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _priorityTypeRepository.Add(priorityType);

                return;
            }

            priorityType = await _priorityTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _priorityTypeRepository.Delete(priorityType);

                return;
            }

            priorityType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _priorityTypeRepository.Update(priorityType);
        }
    }
}
