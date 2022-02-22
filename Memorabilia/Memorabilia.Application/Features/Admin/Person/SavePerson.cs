using Framework.Domain.Command;
using Framework.Extension;
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
                                                        command.MiddleName,
                                                        command.Suffix, 
                                                        command.Nickname, 
                                                        command.LegalName,
                                                        command.DisplayName,
                                                        command.BirthDate, 
                                                        command.DeathDate, 
                                                        command.ImagePath);

                    await _personRepository.Add(person).ConfigureAwait(false);

                    command.Id = person.Id;

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
                           command.MiddleName,
                           command.Suffix,
                           command.Nickname,
                           command.LegalName,
                           command.DisplayName,
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
                Id = viewModel.Id;
            }

            public DateTime? BirthDate => _viewModel.BirthDate;

            public DateTime? DeathDate => _viewModel.DeathDate;

            public string DisplayName
            {
                get
                {
                    if (!_viewModel.DisplayName.IsNullOrEmpty())
                        return _viewModel.DisplayName;

                    return $"{_viewModel.LastName}"
                        + (!_viewModel.Suffix.IsNullOrEmpty() ? $" {_viewModel.Suffix}, " : ", ")
                        + (!_viewModel.Nickname.IsNullOrEmpty() ? $" {_viewModel.Nickname}" : string.Empty)
                        + (!_viewModel.FirstName.IsNullOrEmpty() 
                            ? (!_viewModel.Nickname.IsNullOrEmpty() 
                                ? $" ({_viewModel.FirstName})" 
                                : _viewModel.FirstName) 
                            : string.Empty);
                }
            }

            public string FirstName => _viewModel.FirstName;            

            public int Id { get; set; }

            public string ImagePath => _viewModel.ImagePath;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public string LastName => _viewModel.LastName;

            public string LegalName => _viewModel.LegalName;

            public string MiddleName => _viewModel.MiddleName;

            public string Nickname => _viewModel.Nickname;         

            public string Suffix => _viewModel.Suffix;
        }
    }
}
