using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class DashboardItemViewModel
    {
        public DashboardItemViewModel() { }

        public DashboardItem DashboardItem { get; set; }

        public List<List<object>> Data { get; set; }

        public double[] DataNew { get; set; }

        public string[] Labels { get; set; }
    }
}
