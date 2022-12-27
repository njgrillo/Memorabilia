namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    private void SetLevelType(int levelTypeId)
    {
        if (LevelType == null)
        {
            LevelType = new MemorabiliaLevelType(Id, levelTypeId);
            return;
        }

        LevelType.Set(levelTypeId);
    }
}
