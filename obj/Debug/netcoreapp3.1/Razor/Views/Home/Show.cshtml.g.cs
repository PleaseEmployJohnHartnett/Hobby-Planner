#pragma checksum "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\Home\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c555e23e7fb5fa0935227ca7dbaab5819ac13761"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Show), @"mvc.1.0.view", @"/Views/Home/Show.cshtml")]
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
#line 1 "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\_ViewImports.cshtml"
using BeltExam;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\_ViewImports.cshtml"
using BeltExam.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c555e23e7fb5fa0935227ca7dbaab5819ac13761", @"/Views/Home/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a84119000702c45f5036e3e300b27d647b6aca13", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Hobby>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1 class=\"card text-center\">");
#nullable restore
#line 3 "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\Home\Show.cshtml"
                        Write(Model.Activity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h1>\r\n<h1>Coordinated by: ");
#nullable restore
#line 4 "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\Home\Show.cshtml"
               Write(Model.Planner.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 4 "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\Home\Show.cshtml"
                                        Write(Model.Planner.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h1>Description: ");
#nullable restore
#line 5 "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\Home\Show.cshtml"
            Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<p>Enthusiasts: <p>");
#nullable restore
#line 7 "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\Home\Show.cshtml"
                    foreach(var f in Model.Attendees){

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\Home\Show.cshtml"
                                                 Write(f.HobbyMember.FirstName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\airso\Desktop\The_Folder\C#\BeltExam\Views\Home\Show.cshtml"
                                                                              }

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></p> \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hobby> Html { get; private set; }
    }
}
#pragma warning restore 1591
