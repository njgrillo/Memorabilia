namespace Memorabilia.Application.Features.Autograph.Inscriptions;

public class InscriptionEditModel : SaveViewModel
{
    public InscriptionEditModel() { }

    public InscriptionEditModel(InscriptionModel viewModel)
    {
        AutographId = viewModel.AutographId;
        Id = viewModel.Id;
        InscriptionText = viewModel.InscriptionText;
        InscriptionTypeId = viewModel.InscriptionTypeId;
    }

    public int AutographId { get; set; }   

    public string InscriptionText { get; set; }

    public int InscriptionTypeId { get; set; }

    public string InscriptionTypeName 
        => Constant.InscriptionType.Find(InscriptionTypeId)?.Name;
}
