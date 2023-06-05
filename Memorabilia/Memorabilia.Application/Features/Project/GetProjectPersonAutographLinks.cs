namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographLinks(Dictionary<string, object> Parameters)
     : IQuery<AutographModel[]>
{
    public class Handler : QueryHandler<GetProjectPersonAutographLinks, AutographModel[]>
    {
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository)
        {
            _autographRepository = autographRepository;
        }

        protected override async Task<AutographModel[]> Handle(GetProjectPersonAutographLinks query)
        {
            Domain.Entities.Autograph[] autographs = await _autographRepository.GetAll(query.Parameters);

            return autographs.Any()
                ? autographs.Select(autograph => new AutographModel(autograph))
                            .ToArray()
                : Array.Empty<AutographModel>();
        }
    }
}
