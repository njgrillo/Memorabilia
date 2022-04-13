using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls.Sport
{
    public partial class SportSelector : ComponentBase
    {
        [Parameter]
        public bool CanToggle { get; set; }

        [Parameter]
        public ItemType ItemType { get; set; }

        [Parameter]
        public int SelectedValue { get; set; }

        [Parameter]
        public int Value { get; set; }

        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }

        private bool _displaySports;
        private bool _hasSport;
        private string _itemTypeNameLabel => $"Associate {ItemType.Name} with a Sport";

        protected override void OnInitialized()
        {            
            _hasSport = SelectedValue > 0;
            _displaySports = _hasSport;
        }

        private async Task OnInputChange(int value)
        {
            await ValueChanged.InvokeAsync(value).ConfigureAwait(false);
        }

        private void SportCheckboxClicked(bool isChecked)
        {
            _displaySports = CanToggle && isChecked;

            if (!_displaySports)
            {
                SelectedValue = 0;
            }

            _hasSport = isChecked;
        }
    }
}
