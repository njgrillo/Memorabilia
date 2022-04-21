using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonAllStarEditor : ComponentBase
    {
        [Parameter]
        public List<int> AllStarYears { get; set; } = new();

        private int _year;

        private void Add()
        {
            AllStarYears.Add(_year);

            _year = 0;
        }

        private void Remove(int year)
        {
            AllStarYears.Remove(year);
        }
    }
}
