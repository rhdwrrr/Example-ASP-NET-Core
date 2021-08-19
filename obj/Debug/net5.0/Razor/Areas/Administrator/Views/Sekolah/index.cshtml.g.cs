#pragma checksum "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7d9a92d91e12195635598f497b571a188670cf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_Sekolah_index), @"mvc.1.0.view", @"/Areas/Administrator/Views/Sekolah/index.cshtml")]
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
#line 1 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\_ViewImports.cshtml"
using OrigamiEdu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\_ViewImports.cshtml"
using OrigamiEdu.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\_ViewImports.cshtml"
using OrigamiEdu.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7d9a92d91e12195635598f497b571a188670cf0", @"/Areas/Administrator/Views/Sekolah/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c34ba0ace254a924342bf606902964017a590ecf", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    public class Areas_Administrator_Views_Sekolah_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-bottom: 10pt; width: auto;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "dihapus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Sekolah", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Administrator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
  
    ViewData["Title"] = "Data Sekolah";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col"">
        <h1 class=""mt-4"">Data Kategori Sekolah</h1>
        <hr>
        <div class=""float-right"">
            <div class=""form-inline"">
                <div class=""form group"" style=""width: auto;"">
                    <input type=""text"" id=""searchQueryKtg"" name=""query"" class=""form-control"" placeholder=""Cari"">
                </div>
            </div>
        </div>
        <a style=""margin-bottom: 10pt;""");
            BeginWriteAttribute("href", " href=\'", 507, "\'", 583, 1);
#nullable restore
#line 15 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
WriteAttributeValue("", 514, Url.Action("tambahKategori", "Sekolah", new{Area = "Administrator"}), 514, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-outline-primary"">
                <img width=""20px"" src=""/svgs/regular/plus-square.svg"" alt=""Tambah"">
                Tambah Kategori Sekolah
        </a>
        <table class=""table table-hover"" id=""tableKtgSekolah"">
            <thead>
                <th class=""text-center align-middle"">Kategori</th>
                <th class=""text-center align-middle"">Aksi</th>
            </thead>
            <tbody>
");
#nullable restore
#line 25 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
                 foreach (var item in @ViewBag.dataKtg)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"baris_tabel\">\r\n                        <td class=\"text-center align-middle\">");
#nullable restore
#line 28 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
                                                        Write(item.namaKategori);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center align-middle\">\r\n                            <a style=\"color: black;\"");
            BeginWriteAttribute("href", " href=\'", 1342, "\'", 1442, 1);
#nullable restore
#line 30 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
WriteAttributeValue("", 1349, Url.Action("editKategori", "Sekolah", new{Area = "Administrator", ID = @item.ID.ToString()}), 1349, 93, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-warning\"><img style=\"border-right: 10px;\" width=\"20px\" src=\"/svgs/regular/edit.svg\" alt=\"Edit\">Edit</a>\r\n                            <a style=\"color: black;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1624, "\"", 1670, 3);
            WriteAttributeValue("", 1634, "hapusKategori(\'", 1634, 15, true);
#nullable restore
#line 31 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
WriteAttributeValue("", 1649, item.ID.ToString(), 1649, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1668, "\')", 1668, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-warning\"><img style=\"border-right: 10px;\" width=\"20px\" src=\"/svgs/regular/trash-alt.svg\" alt=\"Hapus\">Hapus</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 34 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<div class=""row"">
    <div class=""col"">
        <h1 class=""mt-4"">Data Sekolah</h1>
        <hr>
        <div class=""float-right"">
            <div class=""form-inline"">
                <div class=""form group"" style=""width: auto;"">
                    <input type=""text"" id=""searchQuery"" name=""query"" class=""form-control"" placeholder=""Cari"">
                </div>
            </div>
        </div>
        <a style=""margin-bottom: 10pt;""");
            BeginWriteAttribute("href", " href=\'", 2391, "\'", 2459, 1);
#nullable restore
#line 50 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
WriteAttributeValue("", 2398, Url.Action("tambah", "Sekolah", new{Area = "Administrator"}), 2398, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\">\r\n                <img width=\"20px\" src=\"/svgs/regular/plus-square.svg\" alt=\"Tambah\">\r\n                Tambah Sekolah\r\n        </a>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7d9a92d91e12195635598f497b571a188670cf010199", async() => {
                WriteLiteral("\r\n                Data Sekolah dihapus\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <h5 class=\"mt-2 text-info\">Saat ini terdapat ");
#nullable restore
#line 57 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
                                                Write(ViewBag.countAll);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" sekolah terdaftar</h5>
        <table class=""table table-hover"" id=""tableSekolah"">
            <thead>
                <th class=""text-center align-middle"">Sekolah</th>
                <th class=""text-center align-middle"">Lokasi</th>
                <th class=""text-center align-middle"">Kategori Sekolah</th>
                <th class=""text-center align-middle"">Aksi</th>
            </thead>
            <tbody>
");
#nullable restore
#line 66 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
                 foreach (var item in @ViewBag.datasch)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"baris_tabel\">\r\n                        <td class=\"text-center align-middle\">");
#nullable restore
#line 69 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
                                                        Write(item.sekolah);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center align-middle\">");
#nullable restore
#line 70 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
                                                        Write(item.mst_loc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center align-middle\">");
#nullable restore
#line 71 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
                                                        Write(item.mst_KatgName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center align-middle\">\r\n                            <a style=\"color: black;\"");
            BeginWriteAttribute("href", " href=\'", 3814, "\'", 3895, 1);
#nullable restore
#line 73 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
WriteAttributeValue("", 3821, Url.Action("edit", "Sekolah", new{Area = "Administrator", ID = @item.ID}), 3821, 74, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-warning\"><img style=\"border-right: 10px;\" width=\"20px\" src=\"/svgs/regular/edit.svg\" alt=\"Edit\">Edit</a>\r\n                            <a style=\"color: black;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4077, "\"", 4104, 3);
            WriteAttributeValue("", 4087, "hapus(\'", 4087, 7, true);
#nullable restore
#line 74 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
WriteAttributeValue("", 4094, item.ID, 4094, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4102, "\')", 4102, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-warning\"><img style=\"border-right: 10px;\" width=\"20px\" src=\"/svgs/regular/trash-alt.svg\" alt=\"Hapus\">Hapus</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 77 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        if(!(\"");
#nullable restore
#line 87 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
         Write(TempData["message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" === \"\"))\r\n        {\r\n            alert(\"");
#nullable restore
#line 89 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Sekolah\index.cshtml"
              Write(TempData["message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n        }\r\n\r\n\r\n\r\n        $(document).ready(function(){\r\n            var schTable = $(\"#tableSekolah\").DataTable({\r\n");
                WriteLiteral("                \"dom\":\' ltp\'\r\n            });\r\n            $(\'#searchQuery\').keyup(function(){\r\n                schTable.search($(this).val()).draw() ;\r\n            });\r\n            var ktgTable = $(\"#tableKtgSekolah\").DataTable({\r\n");
                WriteLiteral(@"                ""dom"":' ltp'
            });
            $('#searchQueryKtg').keyup(function(){
                ktgTable.search($(this).val()).draw() ;
            });
        })


        let hapus = function(param)
        {
            if(window.confirm(""Yakin ingin menghapus data ini?""))
            {
                window.location.href = 'Sekolah/hapusSekolah/' + param;
            }
        }

        let hapusKategori = function()
        {
            if(window.confirm(""Yakin ingin menghapus data ini?""))
            {
                window.location.href = 'Sekolah/hapusKategori/' + param;
            }
        }

        
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591