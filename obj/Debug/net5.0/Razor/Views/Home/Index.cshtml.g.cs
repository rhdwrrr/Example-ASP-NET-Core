#pragma checksum "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9012e3d5e6099108a23472e9d12e4b701679ea63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9012e3d5e6099108a23472e9d12e4b701679ea63", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b60e0196d3626a4445bee9a344c3c55f8dd6a6ba", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    <!-- Welcome Message -->\r\n        <div class=\"row my-2 \">\r\n            <div class=\"col-sm-12 \">\r\n                <h1 class=\"text-center display-6 \">Welcome to OrigamiEdu</h1>\r\n                <h1 class=\"text-center display-6 \">");
#nullable restore
#line 10 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Home\Index.cshtml"
                                              Write(ViewBag.UTCTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                \r\n                <h2 class=\"text-center  \">");
#nullable restore
#line 12 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Home\Index.cshtml"
                                     Write(DateTime.UtcNow.ToString("dd MMM yyyy hh:mm 'UTC'z"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <h3 class=\"text-center  \">");
#nullable restore
#line 13 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Home\Index.cshtml"
                                     Write(DateTime.Now.ToString("dd MMM yyyy hh:mm 'UTC'z"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
            </div>
        </div>

        

        <div class=""row my-4 d-flex align-items-center "">
            <!-- <div class=""d-flex align-items-center ""> -->
            <div style=""transition: .3s; "" class=""col-sm-12 col-md-5 p-2 shadow-none "" id=""coverM1 "" onmouseover=""hoverCover() "" onmouseout=""hoverOut() "">
                <img src=""./img/pexels-pixabay-220201.jpg "" alt="" "" class=""img-fluid rounded "" style=""object-fit: cover; "">
            </div>
            <div class=""col-sm-12 col-md-7 p-2 "">

                <h3 class=""text-center mb-3 "">Di OrigamiEdu, tidak hanya latihan TO</h3>
                <p class=""mt-2 "" style=""text-align: justify; "">Lorem ipsum dolor sit amet consectetur adipisicing elit. Sit eos est molestiae provident reprehenderit quae similique! Animi inventore nihil sunt possimus, voluptatibus minima, iusto molestiae quas, voluptas placeat labore natus sapiente
                    exercitationem tenetur recusandae perspiciatis ratione iure libero! Fugiat sequ");
            WriteLiteral(@"i aut eius vero cum impedit, aperiam voluptas, ipsam quis nemo molestiae neque, atque recusandae laboriosam unde explicabo similique exercitationem modi
                    odio non minima expedita suscipit quia. Facere in a id nulla libero facilis inventore ad?</p>
            </div>
            <!-- </div> -->
        </div>
");
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        if(!(\"");
#nullable restore
#line 42 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Home\Index.cshtml"
         Write(TempData["message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" === \"\"))\r\n        {\r\n            alert(\"");
#nullable restore
#line 44 "D:\Codes\repo pribadi\Example-ASP-NET-Core\Views\Home\Index.cshtml"
              Write(TempData["message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n        }\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
