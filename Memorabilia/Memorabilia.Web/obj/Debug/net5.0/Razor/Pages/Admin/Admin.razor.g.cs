#pragma checksum "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Admin.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea34076698aca80fd3cd08a6744cc9bb7d08fd2d"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.Admin
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Demo.Framework.Web;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Admin")]
    public partial class Admin : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div class=\"row\"><div class=\"col-md-12\" style=\"text-align: center\"><h1>Admin</h1></div></div>\r\n<br>\r\n");
            __builder.AddMarkupContent(1, "<div class=\"row\"><div class=\"col-md-12\" style=\"text-align: center\"><h3>Domain Items</h3></div></div>\r\n<br>\r\n");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "row");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(6);
            __builder.AddAttribute(7, "Title", "Acquisition Types");
            __builder.AddAttribute(8, "ImagePath", "images/acquisitiontypes.jpg");
            __builder.AddAttribute(9, "Description", "");
            __builder.AddAttribute(10, "Page", "AcquisitionTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(14);
            __builder.AddAttribute(15, "Title", "Authentication Companies");
            __builder.AddAttribute(16, "ImagePath", "images/beckett.jpg");
            __builder.AddAttribute(17, "Description", "");
            __builder.AddAttribute(18, "Page", "AuthenticationCompanies");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n    ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(22);
            __builder.AddAttribute(23, "Title", "Baseball Types");
            __builder.AddAttribute(24, "ImagePath", "images/baseballtypes.jpg");
            __builder.AddAttribute(25, "Description", "");
            __builder.AddAttribute(26, "Page", "BaseballTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "row");
            __builder.OpenElement(30, "div");
            __builder.AddAttribute(31, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(32);
            __builder.AddAttribute(33, "Title", "Brands");
            __builder.AddAttribute(34, "ImagePath", "images/brands.jpg");
            __builder.AddAttribute(35, "Description", "");
            __builder.AddAttribute(36, "Page", "Brands");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, " \r\n    ");
            __builder.OpenElement(38, "div");
            __builder.AddAttribute(39, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(40);
            __builder.AddAttribute(41, "Title", "Colors");
            __builder.AddAttribute(42, "ImagePath", "images/colors.png");
            __builder.AddAttribute(43, "Description", "");
            __builder.AddAttribute(44, "Page", "Colors");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n    ");
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(48);
            __builder.AddAttribute(49, "Title", "Commissioners");
            __builder.AddAttribute(50, "ImagePath", "images/conditions.jpg");
            __builder.AddAttribute(51, "Description", "");
            __builder.AddAttribute(52, "Page", "Commissioners");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n");
            __builder.OpenElement(54, "div");
            __builder.AddAttribute(55, "class", "row");
            __builder.OpenElement(56, "div");
            __builder.AddAttribute(57, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(58);
            __builder.AddAttribute(59, "Title", "Conditions");
            __builder.AddAttribute(60, "ImagePath", "images/conditions.jpg");
            __builder.AddAttribute(61, "Description", "");
            __builder.AddAttribute(62, "Page", "Conditions");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(63, " \r\n    ");
            __builder.OpenElement(64, "div");
            __builder.AddAttribute(65, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(66);
            __builder.AddAttribute(67, "Title", "Franchises");
            __builder.AddAttribute(68, "ImagePath", "images/franchises.jpg");
            __builder.AddAttribute(69, "Description", "");
            __builder.AddAttribute(70, "Page", "Franchises");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(71, " \r\n    ");
            __builder.OpenElement(72, "div");
            __builder.AddAttribute(73, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(74);
            __builder.AddAttribute(75, "Title", "Full Size Helmet Types");
            __builder.AddAttribute(76, "ImagePath", "images/fullsizehelmettypes.jpg");
            __builder.AddAttribute(77, "Description", "");
            __builder.AddAttribute(78, "Page", "FullSizeHelmetTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n");
            __builder.OpenElement(80, "div");
            __builder.AddAttribute(81, "class", "row");
            __builder.OpenElement(82, "div");
            __builder.AddAttribute(83, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(84);
            __builder.AddAttribute(85, "Title", "Glove Types");
            __builder.AddAttribute(86, "ImagePath", "images/glovetypes.jpg");
            __builder.AddAttribute(87, "Description", "");
            __builder.AddAttribute(88, "Page", "GloveTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "  \r\n    ");
            __builder.OpenElement(90, "div");
            __builder.AddAttribute(91, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(92);
            __builder.AddAttribute(93, "Title", "Helmet Types");
            __builder.AddAttribute(94, "ImagePath", "images/minihelmets.jpg");
            __builder.AddAttribute(95, "Description", "");
            __builder.AddAttribute(96, "Page", "HelmetTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(97, " \r\n    ");
            __builder.OpenElement(98, "div");
            __builder.AddAttribute(99, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(100);
            __builder.AddAttribute(101, "Title", "Inscription Types");
            __builder.AddAttribute(102, "ImagePath", "images/inscriptiontypes.jpg");
            __builder.AddAttribute(103, "Description", "");
            __builder.AddAttribute(104, "Page", "InscriptionTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(105, "\r\n");
            __builder.OpenElement(106, "div");
            __builder.AddAttribute(107, "class", "row");
            __builder.OpenElement(108, "div");
            __builder.AddAttribute(109, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(110);
            __builder.AddAttribute(111, "Title", "Item Type Brands");
            __builder.AddAttribute(112, "ImagePath", "images/brands.jpg");
            __builder.AddAttribute(113, "Description", "");
            __builder.AddAttribute(114, "Page", "ItemTypeBrands");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(115, " \r\n    ");
            __builder.OpenElement(116, "div");
            __builder.AddAttribute(117, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(118);
            __builder.AddAttribute(119, "Title", "Item Type Sizes");
            __builder.AddAttribute(120, "ImagePath", "images/sizes.jpg");
            __builder.AddAttribute(121, "Description", "");
            __builder.AddAttribute(122, "Page", "ItemTypeSizes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(123, "  \r\n    ");
            __builder.OpenElement(124, "div");
            __builder.AddAttribute(125, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(126);
            __builder.AddAttribute(127, "Title", "Item Type Sports");
            __builder.AddAttribute(128, "ImagePath", "images/sports.jpg");
            __builder.AddAttribute(129, "Description", "");
            __builder.AddAttribute(130, "Page", "ItemTypeSports");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(131, "\r\n");
            __builder.OpenElement(132, "div");
            __builder.AddAttribute(133, "class", "row");
            __builder.OpenElement(134, "div");
            __builder.AddAttribute(135, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(136);
            __builder.AddAttribute(137, "Title", "Item Type Spots");
            __builder.AddAttribute(138, "ImagePath", "images/spots.png");
            __builder.AddAttribute(139, "Description", "");
            __builder.AddAttribute(140, "Page", "ItemTypeSpots");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(141, " \r\n    ");
            __builder.OpenElement(142, "div");
            __builder.AddAttribute(143, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(144);
            __builder.AddAttribute(145, "Title", "Item Types");
            __builder.AddAttribute(146, "ImagePath", "images/itemtypes.jpg");
            __builder.AddAttribute(147, "Description", "");
            __builder.AddAttribute(148, "Page", "ItemTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(149, " \r\n    ");
            __builder.OpenElement(150, "div");
            __builder.AddAttribute(151, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(152);
            __builder.AddAttribute(153, "Title", "Jersey Level Types");
            __builder.AddAttribute(154, "ImagePath", "images/jerseytypes.jpg");
            __builder.AddAttribute(155, "Description", "");
            __builder.AddAttribute(156, "Page", "JerseyLevelTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(157, "\r\n");
            __builder.OpenElement(158, "div");
            __builder.AddAttribute(159, "class", "row");
            __builder.OpenElement(160, "div");
            __builder.AddAttribute(161, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(162);
            __builder.AddAttribute(163, "Title", "Jersey Number Types");
            __builder.AddAttribute(164, "ImagePath", "images/jerseytypes.jpg");
            __builder.AddAttribute(165, "Description", "");
            __builder.AddAttribute(166, "Page", "JerseyNumberTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(167, " \r\n    ");
            __builder.OpenElement(168, "div");
            __builder.AddAttribute(169, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(170);
            __builder.AddAttribute(171, "Title", "Jersey Types");
            __builder.AddAttribute(172, "ImagePath", "images/jerseytypes.jpg");
            __builder.AddAttribute(173, "Description", "");
            __builder.AddAttribute(174, "Page", "JerseyTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(175, " \r\n    ");
            __builder.OpenElement(176, "div");
            __builder.AddAttribute(177, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(178);
            __builder.AddAttribute(179, "Title", "Magazine Types");
            __builder.AddAttribute(180, "ImagePath", "images/magazinetypes.jpg");
            __builder.AddAttribute(181, "Description", "");
            __builder.AddAttribute(182, "Page", "MagazineTypes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(183, "\r\n");
            __builder.OpenElement(184, "div");
            __builder.AddAttribute(185, "class", "row");
            __builder.OpenElement(186, "div");
            __builder.AddAttribute(187, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(188);
            __builder.AddAttribute(189, "Title", "Occupations");
            __builder.AddAttribute(190, "ImagePath", "images/occupations.jpg");
            __builder.AddAttribute(191, "Description", "");
            __builder.AddAttribute(192, "Page", "Occupations");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(193, " \r\n    ");
            __builder.OpenElement(194, "div");
            __builder.AddAttribute(195, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(196);
            __builder.AddAttribute(197, "Title", "People");
            __builder.AddAttribute(198, "ImagePath", "images/athletes.jpg");
            __builder.AddAttribute(199, "Description", "");
            __builder.AddAttribute(200, "Page", "People");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(201, " \r\n    ");
            __builder.OpenElement(202, "div");
            __builder.AddAttribute(203, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(204);
            __builder.AddAttribute(205, "Title", "Sizes");
            __builder.AddAttribute(206, "ImagePath", "images/sizes.jpg");
            __builder.AddAttribute(207, "Description", "");
            __builder.AddAttribute(208, "Page", "Sizes");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(209, "\r\n");
            __builder.OpenElement(210, "div");
            __builder.AddAttribute(211, "class", "row");
            __builder.OpenElement(212, "div");
            __builder.AddAttribute(213, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(214);
            __builder.AddAttribute(215, "Title", "Sports");
            __builder.AddAttribute(216, "ImagePath", "images/sports.jpg");
            __builder.AddAttribute(217, "Description", "");
            __builder.AddAttribute(218, "Page", "Sports");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(219, " \r\n    ");
            __builder.OpenElement(220, "div");
            __builder.AddAttribute(221, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(222);
            __builder.AddAttribute(223, "Title", "Spots");
            __builder.AddAttribute(224, "ImagePath", "images/spots.png");
            __builder.AddAttribute(225, "Description", "");
            __builder.AddAttribute(226, "Page", "Spots");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(227, " \r\n    ");
            __builder.OpenElement(228, "div");
            __builder.AddAttribute(229, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(230);
            __builder.AddAttribute(231, "Title", "Teams");
            __builder.AddAttribute(232, "ImagePath", "images/teams.jpg");
            __builder.AddAttribute(233, "Description", "");
            __builder.AddAttribute(234, "Page", "Teams");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(235, "\r\n");
            __builder.OpenElement(236, "div");
            __builder.AddAttribute(237, "class", "row");
            __builder.OpenElement(238, "div");
            __builder.AddAttribute(239, "class", "col-md-4");
            __builder.OpenComponent<Memorabilia.Web.Controls._Summary>(240);
            __builder.AddAttribute(241, "Title", "Writing Instruments");
            __builder.AddAttribute(242, "ImagePath", "images/writinginstruments.jpg");
            __builder.AddAttribute(243, "Description", "");
            __builder.AddAttribute(244, "Page", "WritingInstruments");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 124 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Admin.razor"
       
    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private QueryRouter _queryRouter { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage _localStorage { get; set; }
    }
}
#pragma warning restore 1591
