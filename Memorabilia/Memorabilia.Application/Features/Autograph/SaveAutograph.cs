using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Application.Features.Autograph.Authentication;
using Memorabilia.Application.Features.Autograph.Inscription;
using Memorabilia.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph
{
    public class SaveAutograph
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Autograph autograph;

                if (command.IsNew)
                {
                    autograph = new Domain.Entities.Autograph(command.AcquiredDate,
                                                              command.AcquisitionTypeId,
                                                              command.ColorId,
                                                              command.ConditionId,
                                                              command.Cost,
                                                              command.EstimatedValue,
                                                              command.Grade,
                                                              command.Greeting,
                                                              command.MemorabiliaId,
                                                              command.PersonalizationText,
                                                              command.PersonId,
                                                              command.PurchaseTypeId,
                                                              command.WritingInstrumentId);

                    UpdateAuthentications(autograph, command.Authentications);
                    UpdateInscriptions(autograph, command.Inscriptions);

                    await _autographRepository.Add(autograph).ConfigureAwait(false);

                    return;
                }

                autograph = await _autographRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _autographRepository.Delete(autograph).ConfigureAwait(false);

                    return;
                }

                autograph.Set(command.AcquiredDate,
                              command.AcquisitionTypeId,
                              command.ColorId,
                              command.ConditionId,
                              command.Cost,
                              command.EstimatedValue,
                              command.Grade,
                              command.Greeting,
                              command.PersonalizationText,
                              command.PersonId,
                              command.PurchaseTypeId,
                              command.WritingInstrumentId);

                UpdateAuthentications(autograph, command.Authentications);
                UpdateInscriptions(autograph, command.Inscriptions);

                await _autographRepository.Update(autograph).ConfigureAwait(false);
            }

            private static void UpdateAuthentications(Domain.Entities.Autograph autograph, ICollection<SaveAuthenticationViewModel> authentications)
            {
                foreach (var authentication in authentications)
                {
                    autograph.SetAuthentication(authentication.Id,
                                                authentication.AuthenticationCompanyId,
                                                authentication.HasHologram,
                                                authentication.HasLetter,
                                                authentication.Verification);
                }
            }

            private static void UpdateInscriptions(Domain.Entities.Autograph autograph, ICollection<SaveInscriptionViewModel> inscriptions)
            {
                foreach (var inscription in inscriptions)
                {
                    autograph.SetInscription(inscription.Id, inscription.InscriptionTypeId, inscription.InscriptionText);
                }
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveAutographViewModel _viewModel;

            public Command(SaveAutographViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public DateTime? AcquiredDate => _viewModel.AcquiredDate;

            public int AcquisitionTypeId => _viewModel.AcquisitionTypeId;

            public ICollection<SaveAuthenticationViewModel> Authentications => _viewModel.Authentications;

            public int ColorId => _viewModel.ColorId;

            public int ConditionId => _viewModel.ConditionId;

            public decimal? Cost => _viewModel.Cost;

            public DateTime CreateDate => _viewModel.CreateDate;

            public decimal? EstimatedValue => _viewModel.EstimatedValue;

            public string Grade => _viewModel.Grade;

            public string Greeting => _viewModel.Greeting;

            public int Id => _viewModel.Id;

            public ICollection<SaveInscriptionViewModel> Inscriptions => _viewModel.Inscriptions;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public DateTime? LastModifiedDate => _viewModel.LastModifiedDate;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public string PersonalizationText => _viewModel.PersonalizationText;

            public int PersonId => _viewModel.PersonId;

            public int? PurchaseTypeId => _viewModel.PurchaseTypeId > 0 ? _viewModel.PurchaseTypeId : null;

            public int WritingInstrumentId => _viewModel.WritingInstrumentId;
        }
    }
}
