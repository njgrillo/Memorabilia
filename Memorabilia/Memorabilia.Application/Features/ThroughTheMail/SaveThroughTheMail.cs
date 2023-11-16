namespace Memorabilia.Application.Features.ThroughTheMail;

[AuthorizeByPermission(Enum.Permission.ThroughTheMail)]
public class SaveThroughTheMail
{
    public class Handler(IThroughTheMailRepository throughTheMailRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.ThroughTheMail throughTheMail;

            if (command.IsNew)
            {
                throughTheMail = new Entity.ThroughTheMail(command.PersonId,
                                                           command.AddressId,
                                                           command.SentDate,
                                                           command.ReceivedDate,
                                                           command.Notes,
                                                           command.SelfAddressedStampedEnvelopeTrackingNumber,
                                                           command.ThroughTheMailFailureTypeId,
                                                           command.TrackingNumber,
                                                           command.UserId);

                if (!command.SingleLineAddress.IsNullOrEmpty())
                    SetAddress(throughTheMail, command);

                SetMemorabilia(throughTheMail, command);

                await throughTheMailRepository.Add(throughTheMail);

                command.Id = throughTheMail.Id;

                return;
            }

            throughTheMail = await throughTheMailRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await throughTheMailRepository.Delete(throughTheMail);

                return;
            }

            throughTheMail.Set(command.AddressId,
                               command.SentDate,
                               command.ReceivedDate,  
                               command.TrackingNumber,
                               command.SelfAddressedStampedEnvelopeTrackingNumber,
                               command.Notes,
                               command.ThroughTheMailFailureTypeId);

            SetAddress(throughTheMail, command);

            DeleteMemorabilia(throughTheMail, command);
            SetMemorabilia(throughTheMail, command);

            await throughTheMailRepository.Update(throughTheMail);
        }

        private static void DeleteMemorabilia(Entity.ThroughTheMail throughTheMail, Command command)
        {
            if (command.DeleteMemorabiliaIds.Length == 0)
                return;

            throughTheMail.RemoveMemorabilia(command.DeleteMemorabiliaIds);
        }

        private static void SetAddress(Entity.ThroughTheMail throughTheMail, Command command)
        {
            throughTheMail.SetAddress(command.Address.AddressLine1,
                                      command.Address.AddressLine2,
                                      command.Address.City,
                                      command.Address.Country,
                                      command.Address.PostalCode,
                                      command.SingleLineAddress,
                                      command.Address.StateProvidence);
        }

        private static void SetMemorabilia(Entity.ThroughTheMail throughTheMail, Command command)
        {
            foreach (ThroughTheMailMemorabiliaEditModel throughTheMailMemorabilia in command.Memorabilia.Where(item => !item.IsDeleted))
            {
                throughTheMail.SetMemorabilia(throughTheMailMemorabilia.Id,
                                              throughTheMailMemorabilia.ThroughTheMailId,
                                              throughTheMailMemorabilia.MemorabiliaId,
                                              throughTheMailMemorabilia.AutographId,
                                              throughTheMailMemorabilia.Cost,
                                              throughTheMailMemorabilia.IsExtraReceived);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly ThroughTheMailEditModel _editModel;

        public Command(ThroughTheMailEditModel editModel)
        {
            _editModel = editModel;
            Id = _editModel.Id;
        }

        public AddressEditModel Address
            => _editModel.Address;

        public int? AddressId
            => _editModel.AddressId;

        public int[] DeleteMemorabiliaIds
            => _editModel.Memorabilia
                         .Where(throughTheMailMemorabilia => throughTheMailMemorabilia.IsDeleted)
                         .Select(throughTheMailMemorabilia => throughTheMailMemorabilia.MemorabiliaId)
                         .ToArray();

        public int Id { get; set; }

        public bool IsDeleted
            => _editModel.IsDeleted;

        public bool IsNew
            => _editModel.IsNew;

        public ThroughTheMailMemorabiliaEditModel[] Memorabilia
            => _editModel.Memorabilia
                         .ToArray();

        public string Notes
            => _editModel.Notes;

        public int PersonId
            => _editModel.Person.Id;

        public DateTime? ReceivedDate
            => _editModel.ReceivedDate;

        public string SelfAddressedStampedEnvelopeTrackingNumber
            => _editModel.SelfAddressedStampedEnvelopeTrackingNumber;

        public DateTime? SentDate
            => _editModel.SentDate;

        public string SingleLineAddress
        {
            get
            {
                string address = Address.AddressLine1;

                if (!Address.AddressLine2.IsNullOrEmpty())
                    address += " " + Address.AddressLine2;

                address += " " + $"{Address.City} {Address.StateProvidence} {Address.PostalCode} {Address.Country}";

                return address;
            }
        }

        public int? ThroughTheMailFailureTypeId
            => _editModel.ThroughTheMailFailureTypeId;

        public string TrackingNumber
            => _editModel.TrackingNumber;

        public int UserId
            => _editModel.UserId;
    }
}
