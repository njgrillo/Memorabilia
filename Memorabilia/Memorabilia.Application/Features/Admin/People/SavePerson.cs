namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
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
            Entity.Person person;

            if (command.IsNew)
            {
                person = new Entity.Person(command.FirstName, 
                                           command.LastName, 
                                           command.MiddleName,
                                           command.Suffix, 
                                           command.Nickname, 
                                           command.LegalName,
                                           command.DisplayName,
                                           command.ProfileName,
                                           command.BirthDate, 
                                           command.DeathDate,
                                           command.Nicknames);

                await _personRepository.Add(person);

                command.Id = person.Id;

                return;
            }

            person = await _personRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _personRepository.Delete(person);

                return;
            }

            person.Set(command.FirstName, 
                       command.LastName,
                       command.MiddleName,
                       command.Suffix,
                       command.Nickname,
                       command.LegalName,
                       command.DisplayName,
                       command.ProfileName,
                       command.BirthDate, 
                       command.DeathDate,
                       command.Nicknames);

            await _personRepository.Update(person);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly PersonEditModel _editModel;

        public Command(PersonEditModel editModel)
        {
            _editModel = editModel;
            Id = editModel.Id;
        }

        public DateTime? BirthDate 
            => _editModel.BirthDate;

        public DateTime? DeathDate 
            => _editModel.DeathDate;

        public string DisplayName
        {
            get
            {
                if (!_editModel.DisplayName.IsNullOrEmpty())
                    return _editModel.DisplayName;

                return $"{_editModel.LastName}"
                    + (!_editModel.Suffix.IsNullOrEmpty() ? $" {_editModel.Suffix}, " : ", ")
                    + (!_editModel.Nickname.IsNullOrEmpty() ? $" {_editModel.Nickname}" : string.Empty)
                    + (!_editModel.FirstName.IsNullOrEmpty() 
                        ? (!_editModel.Nickname.IsNullOrEmpty() 
                            ? $" ({_editModel.FirstName})" 
                            : _editModel.FirstName) 
                        : string.Empty);
            }
        }

        public string FirstName 
            => _editModel.FirstName;            

        public int Id { get; set; }

        public bool IsDeleted 
            => _editModel.IsDeleted;

        public bool IsNew 
            => _editModel.IsNew;

        public string LastName 
            => _editModel.LastName;

        public string LegalName 
            => _editModel.LegalName;

        public string MiddleName 
            => _editModel.MiddleName;

        public string Nickname 
            => _editModel.Nickname;

        public string[] Nicknames 
            => _editModel.Nicknames
                         .Select(nickname => nickname.Nickname)
                         .ToArray();

        public string  ProfileName
        {
            get
            {
                if (!_editModel.ProfileName.IsNullOrEmpty())
                    return _editModel.ProfileName;

                return $"{(!_editModel.Nickname.IsNullOrEmpty() ? _editModel.Nickname : _editModel.FirstName)}"
                    + $" {_editModel.LastName}"
                    + (!_editModel.Suffix.IsNullOrEmpty() ? $" {_editModel.Suffix}" : string.Empty);
            }
        }

        public string Suffix 
            => _editModel.Suffix;
    }
}
