using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Photo
{
    public class SavePhoto
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task Handle(Command command)
            {
                var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId).ConfigureAwait(false);

                memorabilia.SetPhoto(command.BrandId,
                                     command.Framed,
                                     command.OrientationId,
                                     command.PersonIds,
                                     command.PhotoTypeId,
                                     command.SizeId,
                                     command.SportIds,
                                     command.TeamIds);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SavePhotoViewModel _viewModel;

            public Command(SavePhotoViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int BrandId => _viewModel.BrandId;

            public bool Framed => _viewModel.Framed;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int OrientationId => _viewModel.OrientationId;

            public int[] PersonIds => _viewModel.People.Select(person => person.Id).ToArray();

            public int PhotoTypeId => _viewModel.PhotoTypeId;

            public int SizeId => _viewModel.SizeId;

            public int[] SportIds => _viewModel.Sports.Select(team => team.Id).ToArray();

            public int[] TeamIds => _viewModel.Teams.Select(team => team.Id).ToArray();
        }
    }
}
