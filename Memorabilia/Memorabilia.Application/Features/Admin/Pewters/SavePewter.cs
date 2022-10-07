﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Pewters;

public class SavePewter
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Pewter> _pewterRepository;

        public Handler(IDomainRepository<Pewter> pewterRepository)
        {
            _pewterRepository = pewterRepository;
        }

        protected override async Task Handle(Command command)
        {
            Pewter pewter;

            if (command.IsNew)
            {
                pewter = new Pewter(command.FranchiseId,
                                    command.TeamId,
                                    command.SizeId,
                                    command.ImageTypeId,
                                    command.ImagePath);

                await _pewterRepository.Add(pewter);

                return;
            }

            pewter = await _pewterRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _pewterRepository.Delete(pewter);

                return;
            }

            pewter.Set(command.FranchiseId,
                       command.TeamId,
                       command.SizeId,
                       command.ImageTypeId,
                       command.ImagePath);

            await _pewterRepository.Update(pewter);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SavePewterViewModel _viewModel;

        public Command(SavePewterViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int FranchiseId => _viewModel.FranchiseId;

        public int Id => _viewModel.Id;            

        public string ImagePath => _viewModel.ImagePath;

        public int? ImageTypeId => !_viewModel.ImagePath.IsNullOrEmpty() ? Domain.Constants.ImageType.Primary.Id : null;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;            

        public int SizeId => _viewModel.SizeId;

        public int TeamId => _viewModel.TeamId;
    }
}
