﻿namespace Memorabilia.Blazor.Pages.SignatureIdentification;

public partial class SignatureIdentificationImageCarouselViewerDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int SignatureIdentificationId { get; set; }

    protected SignatureIdentificationImageModel[] Images { get; set; }
        = Array.Empty<SignatureIdentificationImageModel>();

    protected override async Task OnInitializedAsync()
    {
        if (SignatureIdentificationId == 0)
            return;

        Entity.SignatureIdentification signatureIdentification
            = await QueryRouter.Send(new GetSignatureIdentification(SignatureIdentificationId));

        Images = signatureIdentification.Images
                                        .Select(image => new SignatureIdentificationImageModel(image))
                                        .ToArray();
    }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
