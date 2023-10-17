namespace Memorabilia.MinimalAPI.Handlers.Admin.People;

public class Get
    : RequestHandler<PersonRequest>, IRequestHandler<PersonRequest, IResult>
{
    private readonly ImageService _imageService;

    public Get(IMediator mediator, ImageService imageService) : base(mediator) 
    { 
        _imageService = imageService;
    }

    public override async Task<IResult> Handle(PersonRequest request,
                                               CancellationToken cancellationToken)
    {
        Entity.Person person = await Mediator.Send(new GetPerson(request.Id));

        if (person == null)
            return Results.NotFound(new Response<PersonApiModel>(new PersonApiModel()));

        PersonApiModel personApiModel = person.ToModel();

        if (person.ImageFileName.IsNullOrEmpty())
            return Results.Ok(new Response<PersonApiModel>(personApiModel));

        personApiModel.ImageData = _imageService.GetPersonImageData(person.ImageFileName);

        return Results.Ok(new Response<PersonApiModel>(personApiModel));
    }
}
