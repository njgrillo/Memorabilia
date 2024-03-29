﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonTeam
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

                if (command.DeletedTeamIds.Any())
                    person.RemoveTeams(command.DeletedTeamIds);

                foreach (var team in command.Teams.Where(x => !x.IsDeleted))
                {
                    person.SetTeam(team.TeamId, team.BeginYear, team.EndYear);
                }

                await _personRepository.Update(person).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            public Command(int personId, IEnumerable<SavePersonTeamViewModel> teams)
            {
                PersonId = personId;
                Teams = teams.ToArray();
            }

            public int[] DeletedTeamIds => Teams.Where(team => team.IsDeleted).Select(team => team.Id).ToArray();

            public SavePersonTeamViewModel[] Teams { get; }

            public int PersonId { get; }
        }
    }
}
