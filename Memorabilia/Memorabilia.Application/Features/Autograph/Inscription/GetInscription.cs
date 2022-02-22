using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph.Inscription
{
    public class GetInscription
    {
        //public class Handler : QueryHandler<Query, InscriptionViewModel>
        //{
        //    private readonly I _inscriptionRepository;

        //    public Handler(IAutographRepository autographRepository)
        //    {
        //        _inscriptionRepository = autographRepository;
        //    }

        //    protected override async Task<InscriptionViewModel> Handle(Query query)
        //    {
        //        var autograph = await _inscriptionRepository.Get(query.Id).ConfigureAwait(false);

        //        var viewModel = new InscriptionViewModel(autograph);

        //        return viewModel;
        //    }
        //}

        //public class Query : IQuery<InscriptionViewModel>
        //{
        //    public Query(int autographId)
        //    {
        //        AutographId = autographId;
        //    }

        //    public int AutographId { get; }
        //}
    }
}
