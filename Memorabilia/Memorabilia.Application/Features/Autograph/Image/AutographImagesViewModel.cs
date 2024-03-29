﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph.Image
{
    public class AutographImagesViewModel : ViewModel
    {
        public AutographImagesViewModel() { }

        public AutographImagesViewModel(IEnumerable<AutographImage> images)
        {
            Images = images.Select(image => new AutographImageViewModel(image));
        }

        public IEnumerable<AutographImageViewModel> Images { get; set; } = Enumerable.Empty<AutographImageViewModel>();

        public override string PageTitle => "Autograph Images";
    }
}
