﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brands;

public class SaveBrand
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Brand> _brandRepository;

        public Handler(IDomainRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task Handle(Command command)
        {
            Brand brand;

            if (command.IsNew)
            {
                brand = new Brand(command.Name, command.Abbreviation);

                await _brandRepository.Add(brand);

                return;
            }

            brand = await _brandRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _brandRepository.Delete(brand);

                return;
            }

            brand.Set(command.Name, command.Abbreviation);

            await _brandRepository.Update(brand);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
