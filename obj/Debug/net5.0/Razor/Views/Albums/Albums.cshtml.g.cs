#pragma checksum "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92b378f1c248200bb86c1315df88065f4cede376"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Albums_Albums), @"mvc.1.0.view", @"/Views/Albums/Albums.cshtml")]
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
#line 1 "C:\Users\vadal\Desktop\MusicPlayer\Views\_ViewImports.cshtml"
using MusicPlayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vadal\Desktop\MusicPlayer\Views\_ViewImports.cshtml"
using MusicPlayer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92b378f1c248200bb86c1315df88065f4cede376", @"/Views/Albums/Albums.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d40ea72157faa5556a2fa3397b379fd5f7e63836", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Albums_Albums : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Album>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("runat", new global::Microsoft.AspNetCore.Html.HtmlString("server"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
  
    ViewData["Title"] = "Альбомы";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Альбомы</h1>\r\n</div>\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "92b378f1c248200bb86c1315df88065f4cede3763846", async() => {
                WriteLiteral(@"
            <div class=""form-inline form-group"">
                <label class=""control-label"">Название: </label>
                <input name=""albumName"" class=""form-control"" />
                <label class=""control-label"">Автор: </label>
                <input name=""authorName"" class=""form-control"" />
                <input type=""submit"" value=""Найти"" class=""btn btn-primary"" />
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"d-flex flex-column w-100\">\r\n");
#nullable restore
#line 21 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <details>\r\n            <summary>");
#nullable restore
#line 24 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
                Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" — ");
#nullable restore
#line 24 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
                             Write(item.Songs.FirstOrDefault().Author.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" — <span>");
#nullable restore
#line 24 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
                                                                              Write(item.Date.ToString("MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></summary>\r\n");
#nullable restore
#line 25 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
             foreach (var el in item.Songs)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"d-flex flex-row w-100\">\r\n                    <div class=\"p-2\" style=\"width: 100px\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1017, "\"", 1037, 2);
            WriteAttributeValue("", 1023, "/", 1023, 1, true);
#nullable restore
#line 29 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
WriteAttributeValue("", 1024, el.CoverPath, 1024, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\" alt=\"Responsive image\">\r\n                    </div>\r\n                    <div class=\"p-2\">\r\n                        <span class=\"font-weight-bold\">");
#nullable restore
#line 32 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
                                                  Write(el.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "92b378f1c248200bb86c1315df88065f4cede3767850", async() => {
                WriteLiteral("\r\n                            <audio controls>\r\n                              <source");
                BeginWriteAttribute("src", " src=\"", 1351, "\"", 1370, 2);
                WriteAttributeValue("", 1357, "/", 1357, 1, true);
#nullable restore
#line 35 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
WriteAttributeValue("", 1358, el.FilePath, 1358, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"audio/mpeg\">\r\n                            </audio>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"d-flex flex-wrap align-content-center\">\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 42 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </details>\r\n");
#nullable restore
#line 44 "C:\Users\vadal\Desktop\MusicPlayer\Views\Albums\Albums.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Album>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591