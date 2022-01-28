namespace Memorabilia.Application.Features
{
    public class SaveViewModel : ViewModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsModified => Id > 0 && !IsDeleted;

        public bool IsNew => Id == 0;
    }
}
