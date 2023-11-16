namespace Memorabilia.Application.Validators.SignatureIdentification;

public class SignatureIdentificationValidator 
    : AbstractValidator<SaveSignatureIdentification.Command>
{
    public SignatureIdentificationValidator()
    {
        RuleFor(x => x.CreatedUserId)
            .GreaterThan(0)
            .WithName("CreatedUserId")
            .WithMessage("CreatedUserId is required.");

        RuleFor(x => x)
            .Must(x => x.Images.HasAny())
            .WithName("Images")
            .WithMessage("Must upload at least one image.");

        RuleForEach(x => x.Images)
            .SetValidator(new SignatureIdentificationImageValidator());
    }
}
