#pragma checksum "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "883d5c15f6b0ebfb1604840d06b671f9b7af76c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kelas_gabung), @"mvc.1.0.view", @"/Views/Kelas/gabung.cshtml")]
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
#line 1 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\_ViewImports.cshtml"
using OrigamiEdu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\_ViewImports.cshtml"
using OrigamiEdu.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"883d5c15f6b0ebfb1604840d06b671f9b7af76c8", @"/Views/Kelas/gabung.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b60e0196d3626a4445bee9a344c3c55f8dd6a6ba", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Kelas_gabung : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<joinGrupView>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-check-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("agree1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "gabung", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
  
    ViewData["Title"] = "Gabung ke kelas";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row d-flex my-2\">\r\n    <div class=\"col-12 mx-auto\">\r\n        <div class=\"text-center\">\r\n            <h5 class=\"display-6\">");
#nullable restore
#line 9 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
                             Write(Model.namaKelas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 11 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
             if(Model.isAccesingByCode){

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"fs-5 text-muted font-monospace\">");
#nullable restore
#line 12 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
                                                        Write(Model.IDKelas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 13 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <small class=\"text-muted\">Kelas dibuat oleh ");
#nullable restore
#line 14 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
                                                   Write(Model.kreator);

#line default
#line hidden
#nullable disable
            WriteLiteral(" pada ");
#nullable restore
#line 14 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
                                                                       Write(Model.createdDate.ToString("dd/MM/yyyy HH:mm 'WIB'"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row d-flex my-1 align-items-end\">\r\n    <div class=\"p-2 col-sm-12 col-md-8\">\r\n        <div class=\"text-start\">\r\n            <h3 class=\"text-uppercase\">Peraturan Kelas ");
#nullable restore
#line 22 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
                                                  Write(Model.namaKelas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <p class=\"my-2\">\r\n                ");
#nullable restore
#line 24 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
           Write(Model.userGuide);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n    </div>\r\n    <div class=\"p-2 col-sm-12 col-md-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "883d5c15f6b0ebfb1604840d06b671f9b7af76c88489", async() => {
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "883d5c15f6b0ebfb1604840d06b671f9b7af76c88805", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 31 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IDKelas);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "883d5c15f6b0ebfb1604840d06b671f9b7af76c810513", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 32 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.isAgree);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                <label class=\"form-check-label\" for=\"agree1\">Saya setuju dengan peraturan kelas ");
#nullable restore
#line 33 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
                                                                                           Write(Model.namaKelas);

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>. </span>Saya berjanji akan mematuhi setiap poin peraturan yang telah dibuat.</label>\r\n            </div>\r\n");
#nullable restore
#line 35 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
             if (Model.isAccesingByCode)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <button type=\"submit\" class=\"btn btn-outline-primary\">Gabung</button>\r\n");
#nullable restore
#line 38 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
            }else{

#line default
#line hidden
#nullable disable
                WriteLiteral("                <button type=\"submit\" class=\"btn btn-outline-primary\">Minta untuk bergabung</button>\r\n");
#nullable restore
#line 40 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-codeAcc", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Kelas\gabung.cshtml"
                                                       WriteLiteral(Model.isAccesingByCode);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["codeAcc"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-codeAcc", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["codeAcc"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<joinGrupView> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
