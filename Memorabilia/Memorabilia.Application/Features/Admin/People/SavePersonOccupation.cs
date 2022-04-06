using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonOccupation
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IPersonRepository _personRepository;

            public Handler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            protected override async Task Handle(Command command)
            {
                var person = await _personRepository.Get(command.PersonId).ConfigureAwait(false);

                if (command.DeletedOccupationIds.Any())
                    person.RemoveOccupations(command.DeletedOccupationIds);

                foreach (var occupation in command.Occupations.Where(occupation => !occupation.IsDeleted))
                {
                    person.SetOccupation(occupation.OccupationId, occupation.OccupationTypeId);
                }

                await _personRepository.Update(person).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            public Command(int personId, IEnumerable<SavePersonOccupationViewModel> occupations)
            {
                PersonId = personId;
                Occupations = occupations.ToArray();
            }

            public int[] DeletedOccupationIds => Occupations.Where(occupation => occupation.IsDeleted).Select(occupation => occupation.Id).ToArray();

            public SavePersonOccupationViewModel[] Occupations { get; }

            public int PersonId { get; }
        }
    }
}
