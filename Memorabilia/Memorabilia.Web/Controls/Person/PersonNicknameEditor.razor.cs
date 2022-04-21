using Framework.Extension;
using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonNicknameEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonNicknameViewModel> Nicknames { get; set; } = new();

        private SavePersonNicknameViewModel _viewModel = new();

        private void Add()
        {
            if (_viewModel.Nickname.IsNullOrEmpty())
                return;

            Nicknames.Add(_viewModel);

            _viewModel = new SavePersonNicknameViewModel();
        }

        private void Remove(string nickname)
        {
            var existingNickname = Nicknames.SingleOrDefault(personNickname => personNickname.Nickname == nickname);

            if (existingNickname == null)
                return;

            existingNickname.IsDeleted = true;
        }
    }
}
