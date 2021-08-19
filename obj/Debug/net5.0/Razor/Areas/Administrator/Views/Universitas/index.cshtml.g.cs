#pragma checksum "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "035d965eb67876201c967b9861cdbe8f24677955"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_Universitas_index), @"mvc.1.0.view", @"/Areas/Administrator/Views/Universitas/index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"035d965eb67876201c967b9861cdbe8f24677955", @"/Areas/Administrator/Views/Universitas/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c34ba0ace254a924342bf606902964017a590ecf", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    public class Areas_Administrator_Views_Universitas_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
  
    ViewData["Title"] = "Data Universitas";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col"">
        <h1 class=""mt-4"">Data Kategori Universitas</h1>
        <hr>
        <div class=""float-right"">
            <div class=""form-inline"">
                <div class=""form group"" style=""width: auto;"">
                    <input type=""text"" id=""searchQueryKtg"" name=""query"" class=""form-control"" placeholder=""Cari"">
                </div>
            </div>
        </div>
        <a style=""margin-bottom: 10pt;""");
            BeginWriteAttribute("href", " href=\'", 515, "\'", 606, 1);
#nullable restore
#line 15 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
WriteAttributeValue("", 522, Url.Action("tambahKategoriUniversitas", "Universitas", new{Area = "Administrator"}), 522, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-outline-primary"">
                <img width=""20px"" src=""/svgs/regular/plus-square.svg"" alt=""Tambah"">
                Tambah Kategori Universitas
        </a>
        <table class=""table table-hover"" id=""tableKtgUniversitas"">
            <thead>
                <th class=""text-center align-middle"">Kategori</th>
                <th class=""text-center align-middle"">Aksi</th>
            </thead>
            <tbody>
");
#nullable restore
#line 25 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
                 foreach (var item in @ViewBag.kategoriUniversitas)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"baris_tabel\">\r\n                        <td class=\"text-center align-middle\">");
#nullable restore
#line 28 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
                                                        Write(item.katgUniv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center align-middle\">\r\n                            <a style=\"color: black;\"");
            BeginWriteAttribute("href", " href=\'", 1381, "\'", 1496, 1);
#nullable restore
#line 30 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
WriteAttributeValue("", 1388, Url.Action("editKategoriUniversitas", "Universitas", new{Area = "Administrator", ID = @item.ID.ToString()}), 1388, 108, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-warning\"><img style=\"border-right: 10px;\" width=\"20px\" src=\"/svgs/regular/edit.svg\" alt=\"Edit\">Edit</a>\r\n                            <a style=\"color: black;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1678, "\"", 1724, 3);
            WriteAttributeValue("", 1688, "hapusKategori(\'", 1688, 15, true);
#nullable restore
#line 31 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
WriteAttributeValue("", 1703, item.ID.ToString(), 1703, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1722, "\')", 1722, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-warning\"><img style=\"border-right: 10px;\" width=\"20px\" src=\"/svgs/regular/trash-alt.svg\" alt=\"Hapus\">Hapus</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 34 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
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
        <h1 class=""mt-4"">Data Universitas</h1>
        <hr>
        <div class=""float-right"">
            <div class=""form-inline"">
                <div class=""form group"" style=""width: auto;"">
                    <input type=""text"" id=""searchQuery"" name=""query"" class=""form-control"" placeholder=""Cari"">
                </div>
            </div>
        </div>
        <a style=""margin-bottom: 10pt;""");
            BeginWriteAttribute("href", " href=\'", 2449, "\'", 2532, 1);
#nullable restore
#line 50 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
WriteAttributeValue("", 2456, Url.Action("tambahUniversitas", "Universitas", new{Area = "Administrator"}), 2456, 76, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\">\r\n                <img width=\"20px\" src=\"/svgs/regular/plus-square.svg\" alt=\"Tambah\">\r\n                Tambah Universitas\r\n        </a>\r\n        <h5 class=\"mt-2 text-info\">Saat ini terdapat ");
#nullable restore
#line 54 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
                                                Write(ViewBag.countAll);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" sekolah terdaftar</h5>
        <table class=""table table-hover"" id=""tableUniversitas"">
            <thead>
                <th class=""text-center align-middle"">Universitas</th>
                <th class=""text-center align-middle"">Provinsi</th>
                <th class=""text-center align-middle"">Kategori Universitas</th>
                <th class=""text-center align-middle"">Aksi</th>
            </thead>
            <tbody>
");
#nullable restore
#line 63 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
                 foreach (var item in @ViewBag.Universitas)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"baris_tabel\">\r\n                        <td class=\"text-center align-middle\">");
#nullable restore
#line 66 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
                                                        Write(item.universitas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center align-middle\">");
#nullable restore
#line 67 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
                                                        Write(item.mst_fkProvinsi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center align-middle\">");
#nullable restore
#line 68 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
                                                        Write(item.mst_fkKatUniv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center align-middle\">\r\n                            <a style=\"color: black;\"");
            BeginWriteAttribute("href", " href=\'", 3711, "\'", 3818, 1);
#nullable restore
#line 70 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
WriteAttributeValue("", 3718, Url.Action("updateStatistik", "Universitas", new{Area = "Administrator", ID = @item.ID.ToString()}), 3718, 100, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-info\"><img style=\"border-right: 10px;\" width=\"20px\" src=\"/svgs/regular/edit.svg\" alt=\"Edit\">Statistik</a>\r\n                            <a style=\"color: black;\"");
            BeginWriteAttribute("href", " href=\'", 4002, "\'", 4109, 1);
#nullable restore
#line 71 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
WriteAttributeValue("", 4009, Url.Action("editUniversitas", "Universitas", new{Area = "Administrator", ID = @item.ID.ToString()}), 4009, 100, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-warning\"><img style=\"border-right: 10px;\" width=\"20px\" src=\"/svgs/regular/edit.svg\" alt=\"Edit\">Edit</a>\r\n                            <a style=\"color: black;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4291, "\"", 4329, 3);
            WriteAttributeValue("", 4301, "hapus(\'", 4301, 7, true);
#nullable restore
#line 72 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
WriteAttributeValue("", 4308, item.ID.ToString(), 4308, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4327, "\')", 4327, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-warning\"><img style=\"border-right: 10px;\" width=\"20px\" src=\"/svgs/regular/trash-alt.svg\" alt=\"Hapus\">Hapus</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 75 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        if(!(\"");
#nullable restore
#line 85 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
         Write(TempData["message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" === \"\"))\r\n        {\r\n            alert(\"");
#nullable restore
#line 87 "D:\Personal Data\OrigamiEdu\Areas\Administrator\Views\Universitas\index.cshtml"
              Write(TempData["message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n        }\r\n\r\n\r\n\r\n        $(document).ready(function(){\r\n            var schTable = $(\"#tableUniversitas\").DataTable({\r\n");
                WriteLiteral("                \"dom\":\' ltp\'\r\n            });\r\n            $(\'#searchQuery\').keyup(function(){\r\n                schTable.search($(this).val()).draw() ;\r\n            });\r\n            var ktgTable = $(\"#tableKtgUniversitas\").DataTable({\r\n");
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
                window.location.href = 'Universitas/hapusUniversitas/' + param;
            }
        }

        let hapusKategori = function()
        {
            if(window.confirm(""Yakin ingin menghapus data ini?""))
            {
                window.location.href = 'Universitas/hapusKategoriUniversitas/' + param;
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
