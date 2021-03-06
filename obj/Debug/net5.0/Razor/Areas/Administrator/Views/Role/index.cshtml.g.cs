#pragma checksum "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b35f6f31ecb558d8334a342b66be411e71dd24f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_Role_index), @"mvc.1.0.view", @"/Areas/Administrator/Views/Role/index.cshtml")]
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
#line 1 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\_ViewImports.cshtml"
using OrigamiEdu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\_ViewImports.cshtml"
using OrigamiEdu.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\_ViewImports.cshtml"
using OrigamiEdu.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b35f6f31ecb558d8334a342b66be411e71dd24f", @"/Areas/Administrator/Views/Role/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c34ba0ace254a924342bf606902964017a590ecf", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Administrator_Views_Role_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Role", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Administrator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
  
    ViewData["Title"] = "Admin/Role";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 class=\"text-center\"><i>Roles</i> Data</h1>\r\n\r\n\r\n");
#nullable restore
#line 8 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
 if(Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a style=\"width: auto;\"");
            BeginWriteAttribute("href", " href=\'", 180, "\'", 245, 1);
#nullable restore
#line 10 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
WriteAttributeValue("", 187, Url.Action("tambah", "Role", new{Area = "Administrator"}), 187, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\">Tambah <i>Role</i> baru</a>\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 12 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
     foreach (var item in Model)
    {
        var stringID = item.Id.ToCharArray();

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-4\" style=\"margin-top: 1rem;\">\r\n");
            WriteLiteral("            <div class=\"card\">\r\n                <div class=\"card-header\">\r\n                    <i>Unique Key</i>: ");
#nullable restore
#line 19 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
                                        for (int i = 0; i < stringID.Length; i++){if(i < 12){

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>");
#nullable restore
#line 19 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
                                                                                              Write(stringID[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 19 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
                                                                                                                      continue;}

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>...</span>");
#nullable restore
#line 19 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
                                                                                                                                                break;}

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">\r\n                        ");
#nullable restore
#line 23 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h5>\r\n                </div>\r\n                <div class=\"card-footer\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b35f6f31ecb558d8334a342b66be411e71dd24f8273", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1371, "\"", 1378, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-danger\">Hapus</a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 33 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 35 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
    
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""card"">
        <div class=""card-header"">
            Tidak ada <i>Roles</i> untuk ditampilkan
        </div>
        <div class=""card-body"">
            <h5 class=""card-title"">
                Tekan tombol dibawah untuk membuat <i>Role</i>
            </h5>
            <a style=""width: auto;""");
            BeginWriteAttribute("href", " href=\'", 1836, "\'", 1901, 1);
#nullable restore
#line 47 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
WriteAttributeValue("", 1843, Url.Action("tambah", "Role", new{Area = "Administrator"}), 1843, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\">Tambah <i>Role</i> baru</a>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 50 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        if(!(\"");
#nullable restore
#line 54 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
         Write(TempData["message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" === \"\"))\r\n        {\r\n            alert(\"");
#nullable restore
#line 56 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Areas\Administrator\Views\Role\index.cshtml"
              Write(TempData["message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\")\r\n        }\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
