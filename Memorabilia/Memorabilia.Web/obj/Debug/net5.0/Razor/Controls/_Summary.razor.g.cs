#pragma checksum "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Controls\_Summary.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99ecfb090ecbfad60acaf9472f80f25cf03d9d36"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Controls
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Demo.Framework.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Framework.Extension;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Domain.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
    public partial class _Summary : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", 
#nullable restore
#line 3 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Controls\_Summary.razor"
              !string.IsNullOrEmpty(Page) ? "can-click" : string.Empty

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(2, "style", "border: 1px solid black; margin-top: 5%; margin-bottom: 5%; margin-left: 5%; margin-right: 5%;");
            __builder.AddAttribute(3, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Controls\_Summary.razor"
              OnClick

#line default
#line hidden
#nullable disable
            ));
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "row");
            __builder.AddAttribute(6, "style", "margin-top: 5%; margin-bottom: 5%; margin-left: 5%; margin-right: 5%;");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "col-lg-12");
            __builder.AddAttribute(9, "style", "text-align: center;");
            __builder.OpenElement(10, "h2");
#nullable restore
#line 8 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Controls\_Summary.razor"
__builder.AddContent(11, Title);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n    ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "row");
            __builder.AddAttribute(15, "style", "margin-top: 1%; margin-bottom: 1%; margin-left: 1%; margin-right: 1%;");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "col-lg-12");
            __builder.AddAttribute(18, "style", "text-align: center;");
            __builder.OpenElement(19, "img");
            __builder.AddAttribute(20, "src", 
#nullable restore
#line 13 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Controls\_Summary.razor"
                       ImagePath

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(21, "alt", "Image");
            __builder.AddAttribute(22, "height", "150");
            __builder.AddAttribute(23, "width", "150");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n    ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "row");
            __builder.AddAttribute(27, "style", "margin-top: 1%; margin-bottom: 1%; margin-left: 1%; margin-right: 1%;");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "col-lg-12");
            __builder.AddAttribute(30, "style", "text-align: center;");
            __builder.OpenElement(31, "h4");
#nullable restore
#line 18 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Controls\_Summary.razor"
__builder.AddContent(32, Description);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 23 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Controls\_Summary.razor"
       
    [Parameter]
    public string Description { get; set; }  

    [Parameter]
    public string ImagePath { get; set; } 
    
    [Parameter]
    public string Page { get; set; }  

    [Parameter]
    public string Title { get; set; }   

    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }
    
    protected void OnClick()
    {
        _navigation.NavigateTo(Page);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigation { get; set; }
    }
}
#pragma warning restore 1591
