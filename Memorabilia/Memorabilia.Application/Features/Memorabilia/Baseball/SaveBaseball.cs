using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class SaveBaseball
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IMemorabiliaBaseballTypeRepository _memorabiliaBaseballTypeRepository;
            private readonly IMemorabiliaCommissionerRepository _memorabiliaCommissionerRepository;
            private readonly IMemorabiliaPersonRepository _memorabiliaPersonRepository;
            private readonly IMemorabiliaRepository _memorabiliaRepository;
            private readonly IMemorabiliaTeamRepository _memorabiliaTeamRepository;

            public Handler(IMemorabiliaBaseballTypeRepository memorabiliaBaseballTypeRepository, 
                           IMemorabiliaCommissionerRepository memorabiliaCommissionerRepository,
                           IMemorabiliaPersonRepository memorabiliaPersonRepository, 
                           IMemorabiliaRepository memorabiliaRepository,
                           IMemorabiliaTeamRepository memorabiliaTeamRepository)
            {
                _memorabiliaBaseballTypeRepository = memorabiliaBaseballTypeRepository;
                _memorabiliaCommissionerRepository = memorabiliaCommissionerRepository;
                _memorabiliaPersonRepository = memorabiliaPersonRepository;
                _memorabiliaRepository = memorabiliaRepository;
                _memorabiliaTeamRepository = memorabiliaTeamRepository;
            }

            protected override async Task Handle(Command command)
            {
                var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId).ConfigureAwait(false);

                memorabilia.SetBrand(command.MemorabiliaBrandId, command.BrandId);
                memorabilia.SetSize(command.MemorabiliaSizeId, command.SizeId);
                memorabilia.SetSports(command.SportId);

                if (command.CommissionerId > 0)
                {
                    memorabilia.SetCommissioner(command.MemorabiliaCommissionerId, command.CommissionerId);
                }
                else
                {
                    if (memorabilia.Commissioner?.Id > 0)
                        await _memorabiliaCommissionerRepository.Delete(memorabilia.Commissioner).ConfigureAwait(false);
                }
                              
                              

                if (command.BaseballTypeId.HasValue)
                {
                    memorabilia.SetBaseballType(command.MemorabiliaBaseballTypeId ?? 0,
                                                command.BaseballTypeId.Value,
                                                command.BaseballTypeYear,
                                                command.BaseballTypeAnniversary);
                }
                else
                {
                    if (memorabilia.BaseballType?.Id > 0)
                        await _memorabiliaBaseballTypeRepository.Delete(memorabilia.BaseballType).ConfigureAwait(false);
                }  

                if (command.PersonId.HasValue)
                {
                    memorabilia.SetPeople(command.PersonId.Value);
                }
                else
                {
                    if (memorabilia.People.Any())
                        await _memorabiliaPersonRepository.Delete(memorabilia.People).ConfigureAwait(false);

                    memorabilia.RemovePeople();
                }

                if (command.TeamId.HasValue)
                {
                    memorabilia.SetTeams(command.TeamId.Value);
                }                    
                else
                {
                    if (memorabilia.Teams.Any())
                        await _memorabiliaTeamRepository.Delete(memorabilia.Teams).ConfigureAwait(false);

                    memorabilia.RemoveTeams();
                }                    

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveBaseballViewModel _viewModel;

            public Command(int memorabiliaId, SaveBaseballViewModel viewModel)
            {
                MemorabiliaId = memorabiliaId;
                _viewModel = viewModel;
            }

            public string BaseballTypeAnniversary => _viewModel.BaseballTypeAnniversary;

            public int? BaseballTypeId => _viewModel.BaseballTypeId > 0 ? _viewModel.BaseballTypeId : null;

            public int? BaseballTypeYear => _viewModel.BaseballTypeYear;

            public int BrandId => _viewModel.BrandId;

            public int CommissionerId => _viewModel.CommissionerId;

            public int? MemorabiliaBaseballTypeId => _viewModel.MemorabiliaBaseballTypeId;

            public int MemorabiliaBrandId => _viewModel.MemorabiliaBrandId;

            public int MemorabiliaCommissionerId => _viewModel.MemorabiliaCommissionerId;

            public int MemorabiliaId { get; set; }

            public int MemorabiliaSizeId => _viewModel.MemorabiliaSizeId;

            public int? PersonId => _viewModel.PersonId > 0 ? _viewModel.PersonId : null;

            public int SizeId => _viewModel.SizeId;

            public int SportId => Domain.Constants.Sport.Baseball.Id;

            public int? TeamId => _viewModel.TeamId > 0 ? _viewModel.TeamId : null;
        }
    }
}
