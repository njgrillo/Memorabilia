namespace Memorabilia.Domain.Entities
{
    public class Pewter : Framework.Domain.Entity.DomainEntity
    {
        public Pewter() { }

        public Pewter(int franchaseId, int teamId, int sizeId, int? imageTypeId, string imagePath)
        {
            FranchiseId = franchaseId;
            TeamId = teamId;
            SizeId = sizeId;
            ImageTypeId = imageTypeId;
            ImagePath = imagePath;
        }

        public int FranchiseId { get; private set; }

        public string FranchiseName => Constants.Franchise.Find(FranchiseId)?.Name;

        public string ImagePath { get; private set; }

        public int? ImageTypeId { get; private set; }

        public string ImageTypeName => Constants.ImageType.Find(ImageTypeId ?? 0)?.Name;

        public int SizeId { get; private set; }

        public string SizeName => Constants.Size.Find(SizeId)?.Name;

        public virtual Team Team { get; private set; }

        public int TeamId { get; private set; }     

        public void Set(int franchaseId, int teamId, int sizeId, int? imageTypeId, string imagePath)
        {
            FranchiseId = franchaseId;
            TeamId = teamId;
            SizeId = sizeId;
            ImageTypeId = imageTypeId;
            ImagePath = imagePath;
        }
    }
}
