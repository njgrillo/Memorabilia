using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageTypes
{
    public class ImageTypesViewModel : DomainsViewModel
    {
        public ImageTypesViewModel() { }

        public ImageTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Image Type";

        public override string PageTitle => "Image Types";

        public override string RoutePrefix => "ImageTypes";
    }
}
