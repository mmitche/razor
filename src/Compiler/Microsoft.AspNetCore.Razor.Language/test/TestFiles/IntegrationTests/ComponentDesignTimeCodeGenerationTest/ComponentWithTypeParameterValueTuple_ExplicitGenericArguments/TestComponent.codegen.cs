﻿// <auto-generated/>
#pragma warning disable 1591
namespace Test
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
    public partial class TestComponent<
#nullable restore
#line 1 "x:\dir\subdir\Test\TestComponent.cshtml"
TDomain

#line default
#line hidden
#nullable disable
    ,
#nullable restore
#line 2 "x:\dir\subdir\Test\TestComponent.cshtml"
TValue

#line default
#line hidden
#nullable disable
    > : global::Microsoft.AspNetCore.Components.ComponentBase
#nullable restore
#line 1 "x:\dir\subdir\Test\TestComponent.cshtml"
where TDomain : struct

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "x:\dir\subdir\Test\TestComponent.cshtml"
where TValue : struct

#line default
#line hidden
#nullable disable
    {
        #pragma warning disable 219
        private void __RazorDirectiveTokenHelpers__() {
        ((global::System.Action)(() => {
        }
        ))();
        ((global::System.Action)(() => {
        }
        ))();
        ((global::System.Action)(() => {
        }
        ))();
        ((global::System.Action)(() => {
        }
        ))();
        }
        #pragma warning restore 219
        #pragma warning disable 0414
        private static object __o = null;
        #pragma warning restore 0414
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __o = typeof(
#nullable restore
#line 4 "x:\dir\subdir\Test\TestComponent.cshtml"
                                    decimal

#line default
#line hidden
#nullable disable
            );
            __o = typeof(
#nullable restore
#line 4 "x:\dir\subdir\Test\TestComponent.cshtml"
                                                     decimal

#line default
#line hidden
#nullable disable
            );
            __o = global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Collections.Generic.List<(decimal Domain, decimal Value)>>(
#nullable restore
#line 4 "x:\dir\subdir\Test\TestComponent.cshtml"
                     null

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(-1, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
            }
            ));
            #pragma warning disable BL0005
            ((global::Test.TestComponent<decimal, decimal>)default).
#nullable restore
#line 4 "x:\dir\subdir\Test\TestComponent.cshtml"
               Data

#line default
#line hidden
#nullable disable
             = default;
            #pragma warning restore BL0005
#nullable restore
#line 4 "x:\dir\subdir\Test\TestComponent.cshtml"
__o = typeof(global::Test.TestComponent<,>);

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "x:\dir\subdir\Test\TestComponent.cshtml"
       
    [Parameter]
    public List<(TDomain Domain, TValue Value)> Data { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
