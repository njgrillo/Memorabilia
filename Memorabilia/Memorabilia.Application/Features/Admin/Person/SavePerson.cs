using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Person
{
    public class SavePerson
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
                Domain.Entities.Person person;

                if (command.IsNew)
                {
                    person = new Domain.Entities.Person(command.FirstName, 
                                                        command.LastName, 
                                                        command.Suffix, 
                                                        command.FullName, 
                                                        command.Nickname, 
                                                        command.BirthDate, 
                                                        command.DeathDate, 
                                                        command.ImagePath);

                    await _personRepository.Add(person).ConfigureAwait(false);

                    return;
                }

                person = await _personRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _personRepository.Delete(person).ConfigureAwait(false);

                    return;
                }

                person.Set(command.FirstName, 
                           command.LastName, 
                           command.Suffix, 
                           command.FullName, 
                           command.Nickname, 
                           command.BirthDate, 
                           command.DeathDate, 
                           command.ImagePath);

                await _personRepository.Update(person).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SavePersonViewModel _viewModel;

            public Command(SavePersonViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public DateTime? BirthDate => _viewModel.BirthDate;

            public DateTime? DeathDate => _viewModel.DeathDate;

            public string FirstName => _viewModel.FirstName;

            public string FullName
            {
                get
                {
                    if (!string.IsNullOrWhiteSpace(_viewModel.FullName))
                        return _viewModel.FullName;

                    return $"{_viewModel.LastName}" 
                        + (!string.IsNullOrWhiteSpace(_viewModel.Suffix) ? $" {_viewModel.Suffix}, " : ", ") 
                        + $"{_viewModel.FirstName}"
                        + (!string.IsNullOrWhiteSpace(_viewModel.Nickname) ? $" ({_viewModel.Nickname})" : string.Empty);
                }               
            }

            public int Id => _viewModel.Id;

            public string ImagePath => _viewModel.ImagePath;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public string LastName => _viewModel.LastName;

            public string Nickname => _viewModel.Nickname;

            public string Suffix => _viewModel.Suffix;
        }
    }
}
