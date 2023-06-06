﻿namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public record SaveItemTypeGameStyle(SaveItemTypeGameStyleViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveItemTypeGameStyle>
    {
        private readonly IItemTypeGameStyleTypeRepository _itemTypeGameStyleRepository;

        public Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository)
        {
            _itemTypeGameStyleRepository = itemTypeGameStyleRepository;
        }

        protected override async Task Handle(SaveItemTypeGameStyle request)
        {
            Entity.ItemTypeGameStyleType itemTypeGameStyle;

            if (request.ViewModel.IsNew)
            {
                itemTypeGameStyle = new Entity.ItemTypeGameStyleType(request.ViewModel.ItemType.Id, request.ViewModel.GameStyleTypeId);

                await _itemTypeGameStyleRepository.Add(itemTypeGameStyle);

                return;
            }

            itemTypeGameStyle = await _itemTypeGameStyleRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _itemTypeGameStyleRepository.Delete(itemTypeGameStyle);

                return;
            }

            itemTypeGameStyle.Set(request.ViewModel.GameStyleTypeId);

            await _itemTypeGameStyleRepository.Update(itemTypeGameStyle);
        }
    }
}
