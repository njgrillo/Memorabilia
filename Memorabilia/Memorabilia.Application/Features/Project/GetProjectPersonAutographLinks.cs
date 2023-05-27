namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographLinks(Dictionary<string, object> Parameters)
     : IQuery<AutographViewModel[]>
{
    public class Handler : QueryHandler<GetProjectPersonAutographLinks, AutographViewModel[]>
    {
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository)
        {
            _autographRepository = autographRepository;
        }

        protected override async Task<AutographViewModel[]> Handle(GetProjectPersonAutographLinks query)
        {
            Domain.Entities.Autograph[] autographs = await _autographRepository.GetAll(query.Parameters);

            return autographs.Any()
                ? autographs.Select(autograph => new AutographViewModel(autograph))
                            .ToArray()
                : Array.Empty<AutographViewModel>();
        }
    }
}
