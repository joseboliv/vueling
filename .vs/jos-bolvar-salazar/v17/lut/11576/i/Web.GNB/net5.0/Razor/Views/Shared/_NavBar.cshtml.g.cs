#pragma checksum "C:\Users\jose1\source\Vueling\jos-bolvar-salazar\Web.GNB\Views\Shared\_NavBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "872bc3a77995217907c92eb4b17c3615f7f1141a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NavBar), @"mvc.1.0.view", @"/Views/Shared/_NavBar.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\jose1\source\Vueling\jos-bolvar-salazar\Web.GNB\Views\_ViewImports.cshtml"
using Web.GNB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jose1\source\Vueling\jos-bolvar-salazar\Web.GNB\Views\_ViewImports.cshtml"
using Web.GNB.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\jose1\source\Vueling\jos-bolvar-salazar\Web.GNB\Views\Shared\_NavBar.cshtml"
using Web.GNB.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"872bc3a77995217907c92eb4b17c3615f7f1141a", @"/Views/Shared/_NavBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a2d3a20520de0714a6bfe8c68b88a26da862684", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__NavBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("navbar-brand module"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav class=""navbar navbar-expand-lg"">
    <div class=""container-fluid"">
        <div class=""navbar-wrapper"">
            <div class=""navbar-minimize"">
                <button id=""minimizeSidebar""
                        class=""btn btn-warning btn-fill btn-round btn-icon d-none d-lg-block"">
                    <i class=""fa fa-ellipsis-v visible-on-sidebar-regular""></i>
                    <i class=""fa fa-navicon visible-on-sidebar-mini""></i>
                </button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "872bc3a77995217907c92eb4b17c3615f7f1141a4500", async() => {
                WriteLiteral("Dashboard");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 12 "C:\Users\jose1\source\Vueling\jos-bolvar-salazar\Web.GNB\Views\Shared\_NavBar.cshtml"
                                     WriteLiteral(nameof(HomeController.Index));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <button class=""navbar-toggler navbar-toggler-right"" type=""button"" data-toggle=""collapse""
                aria-controls=""navigation-index"" aria-expanded=""false"" aria-label=""Toggle navigation"">
            <span class=""navbar-toggler-bar burger-lines""></span>
            <span class=""navbar-toggler-bar burger-lines""></span>
            <span class=""navbar-toggler-bar burger-lines""></span>
        </button>
        <div class=""collapse navbar-collapse justify-content-end"">
            <ul class=""navbar-nav"">
                <li class=""dropdown nav-item"">
                    <a href=""#"" class=""dropdown-toggle nav-link"" data-toggle=""dropdown"">
                        <i class=""nc-icon nc-bag""></i>
                        <span class=""pname"">Modules</span>
                    </a>
                    <ul class=""dropdown-menu"">
                        <li><a class=""dropdown-item"" href=""#""><i class=""nc-icon nc-ambulance""></i> Module 1</a></li>
                        <li><a class=""dropdown-ite");
            WriteLiteral(@"m"" href=""#""><i class=""nc-icon nc-cctv""></i> Module 2</a></li>
                        <li><a class=""dropdown-item"" href=""#""><i class=""nc-icon nc-delivery-fast""></i> Module 3</a></li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
</nav>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
