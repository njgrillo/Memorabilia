namespace Memorabilia.Domain.Entities
{
    public class Inscription : Framework.Domain.Entity.DomainEntity
    {
        public Inscription() { }

        public Inscription(int autographId, int inscriptionTypeId, string text)
        {
            AutographId = autographId;
            InscriptionTypeId = inscriptionTypeId;
            Text = text;
        }        

        public int AutographId { get; private set; }

        public int InscriptionTypeId { get; private set; }

        public string Text { get; private set; }

        public void Set(int inscriptionTypeId, string text)
        {
            InscriptionTypeId = inscriptionTypeId;
            Text = text;
        }
    }
}
