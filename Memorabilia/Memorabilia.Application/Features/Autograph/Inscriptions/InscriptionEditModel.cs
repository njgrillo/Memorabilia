namespace Memorabilia.Application.Features.Autograph.Inscriptions;

public class InscriptionEditModel : EditModel
{
    public InscriptionEditModel() { }

    public InscriptionEditModel(InscriptionModel model)
    {
        AutographId = model.AutographId;
        Id = model.Id;
        InscriptionText = model.InscriptionText;
        InscriptionTypeId = model.InscriptionTypeId;
    }

    public int AutographId { get; set; }   

    public string InscriptionText { get; set; }

    public int InscriptionTypeId { get; set; }

    public string InscriptionTypeName 
        => Constant.InscriptionType.Find(InscriptionTypeId)?.Name;
}
