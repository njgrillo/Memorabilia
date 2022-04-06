using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeBrand
{
    public class SaveItemTypeBrand
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IItemTypeBrandRepository _itemTypeBrandRepository;

            public Handler(IItemTypeBrandRepository itemTypeBrandRepository)
            {
                _itemTypeBrandRepository = itemTypeBrandRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.ItemTypeBrand itemTypeBrand;

                if (command.IsNew)
                {
                    itemTypeBrand = new Domain.Entities.ItemTypeBrand(command.ItemTypeId, command.BrandId);

                    await _itemTypeBrandRepository.Add(itemTypeBrand).ConfigureAwait(false);

                    return;
                }

                itemTypeBrand = await _itemTypeBrandRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _itemTypeBrandRepository.Delete(itemTypeBrand).ConfigureAwait(false);

                    return;
                }

                itemTypeBrand.Set(command.BrandId);

                await _itemTypeBrandRepository.Update(itemTypeBrand).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveItemTypeBrandViewModel _viewModel;

            public Command(SaveItemTypeBrandViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int BrandId => _viewModel.BrandId;

            public int Id => _viewModel.Id;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public int ItemTypeId => _viewModel.ItemTypeId;            
        }
    }
}
