using Framework.Library.Extension;

namespace Memorabilia.MinimalAPI.Handlers.Admin.People;

public class Get
    : RequestHandler<PersonRequest>, IRequestHandler<PersonRequest, IResult>
{
    private readonly ImageService _imageService;

    public Get(QueryRouter queryRouter, ImageService imageService) : base(queryRouter) 
    { 
        _imageService = imageService;
    }

    public override async Task<IResult> Handle(PersonRequest request,
                                               CancellationToken cancellationToken)
    {
        Entity.Person person = await QueryRouter.Send(new GetPerson(request.Id));

        if (person == null)
            return Results.NotFound(new Response<PersonApiModel>(new PersonApiModel()));

        PersonApiModel personApiModel = person.ToModel();

        if (person.ImageFileName.IsNullOrEmpty())
            return Results.Ok(new Response<PersonApiModel>(personApiModel));

        personApiModel.ImageData = _imageService.GetPersonImageData(person.ImageFileName);

        return Results.Ok(new Response<PersonApiModel>(personApiModel));
    }
}
