#pragma checksum "E:\iti\Project\ECommerce_.NetCore_MVC\Code\Ecommerce\Ecommerce\Views\Home\Shop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d325a21ef535932365b09c14a42fa2d61399159b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Shop), @"mvc.1.0.view", @"/Views/Home/Shop.cshtml")]
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
#line 1 "E:\iti\Project\ECommerce_.NetCore_MVC\Code\Ecommerce\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\iti\Project\ECommerce_.NetCore_MVC\Code\Ecommerce\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d325a21ef535932365b09c14a42fa2d61399159b", @"/Views/Home/Shop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Shop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("search-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\iti\Project\ECommerce_.NetCore_MVC\Code\Ecommerce\Ecommerce\Views\Home\Shop.cshtml"
  
    ViewData["Title"] = "Shop";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<!-- Page title -->
<div class=""page-title parallax parallax1"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""page-title-heading"">
                    <h1 class=""title"">Slidebar Shop</h1>
                </div><!-- /.page-title-heading -->
                <div class=""breadcrumbs"">
                    <ul>
                        <li><a href=""index.html"">Home</a></li>
                        <li><a href=""shop-3col.html"">Shop</a></li>
                        <li><a href=""shop-3col-slide.html"">Slidebarshop</a></li>
                    </ul>
                </div><!-- /.breadcrumbs -->
            </div><!-- /.col-md-12 -->
        </div><!-- /.row -->
    </div><!-- /.container -->
</div><!-- /.page-title -->

<section class=""flat-row main-shop shop-slidebar"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-3"">
                <div class=""sidebar slidebar-shop"">
            ");
            WriteLiteral("        <div class=\"widget widget-search\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d325a21ef535932365b09c14a42fa2d61399159b5955", async() => {
                WriteLiteral("\r\n                            <label>\r\n                                <input type=\"search\" class=\"search-field\" placeholder=\"Search …\"");
                BeginWriteAttribute("value", " value=\"", 1333, "\"", 1341, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"s\">\r\n                            </label>\r\n                            <input type=\"submit\" class=\"search-submit\" value=\"Search\">\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div><!-- /.widget-search -->
                    <div class=""widget widget-sort-by"">
                        <h5 class=""widget-title"">
                            Sort By
                        </h5>
                        <ul>
                            <li><a href=""#"" class=""active"">Default</a></li>
                            <li><a href=""#"">Popularity</a></li>
                            <li><a href=""#"">Average rating</a></li>
                            <li><a href=""#"">Newness</a></li>
                            <li><a href=""#"">Price: low to high</a></li>
                            <li><a href=""#"">Price: high to low</a></li>
                        </ul>
                    </div><!-- /.widget-sort-by -->
                  
                   
                    <div class=""widget widget-price"">
                        <h5 class=""widget-title"">Filter by price</h5>
                        <div class=""price-filter"">
                            <div id=""slide");
            WriteLiteral("-range\"></div>\r\n                            <p class=\"amount\">\r\n                                Price: <input type=\"text\" id=\"amount\"");
            BeginWriteAttribute("disabled", " disabled=\"", 2668, "\"", 2679, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </p>\r\n                        </div>\r\n                    </div>\r\n                \r\n");
            WriteLiteral(@"                    <div class=""widget widget_tag"">
                        <h5 class=""widget-title"">
                            Tags
                        </h5>
                        <div class=""tag-list"">
                            <a href=""#"">Categories</a>
                            <a href=""#"" class=""active"">Woman</a>
                            <a href=""#"">Men</a>
                            <a href=""#"">Kids</a>
                            <a href=""#"">Accessories</a>
                            <a href=""#"">Tie</a>
                            <a href=""#"">Furniture</a>
                            <a href=""#"">Accesories</a>
                        </div>
                    </div><!-- /.widget -->
                </div><!-- /.sidebar -->
            </div><!-- /.col-md-3 -->
            <div class=""col-md-9"">
                <div class=""filter-shop clearfix"">
                    <p class=""showing-product float-right"">
                        Showing 1–12 of 56 Products
         ");
            WriteLiteral(@"           </p>
                </div><!-- /.filte-shop -->
                <div class=""product-content product-threecolumn product-slidebar clearfix"">
                    <ul class=""product style2 sd1"">
                        <li class=""product-item"">
                            <div class=""product-thumb clearfix"">
                                <a href=""#"">
                                    <img src=""images/shop/sh-4/2.jpg"" alt=""image"">
                                </a>
                                <span class=""new"">New</span>
                            </div>
                            <div class=""product-info clearfix"">
                                <span class=""product-title"">Cotton White Underweaer Block Out Edition</span>
                                <div class=""price"">
                                    <ins>
                                        <span class=""amount"">$10.00</span>
                                    </ins>
                                </div>
  ");
            WriteLiteral(@"                          </div>
                            <div class=""add-to-cart text-center"">
                                <a href=""#"">ADD TO CART</a>
                            </div>
                            <a href=""#"" class=""like""><i class=""fa fa-heart-o""></i></a>
                        </li>
                        <li class=""product-item"">
                            <div class=""product-thumb clearfix"">
                                <a href=""#"" class=""product-thumb"">
                                    <img src=""images/shop/sh-4/3.jpg"" alt=""image"">
                                </a>
                            </div>
                            <div class=""product-info clearfix"">
                                <span class=""product-title"">Cotton White Underweaer Block Out Edition</span>
                                <div class=""price"">
                                    <ins>
                                        <span class=""amount"">$20.00</span>
                 ");
            WriteLiteral(@"                   </ins>
                                </div>
                            </div>
                            <div class=""add-to-cart text-center"">
                                <a href=""#"">ADD TO CART</a>
                            </div>
                            <a href=""#"" class=""like""><i class=""fa fa-heart-o""></i></a>
                        </li>
                        <li class=""product-item"">
                            <div class=""product-thumb clearfix"">
                                <a href=""#"">
                                    <img src=""images/shop/sh-4/2.jpg"" alt=""image"">
                                </a>
                                <span class=""new"">New</span>
                            </div>
                            <div class=""product-info clearfix"">
                                <span class=""product-title"">Cotton White Underweaer Block Out Edition</span>
                                <div class=""price"">
                           ");
            WriteLiteral(@"         <ins>
                                        <span class=""amount"">$10.00</span>
                                    </ins>
                                </div>
                            </div>
                            <div class=""add-to-cart text-center"">
                                <a href=""#"">ADD TO CART</a>
                            </div>
                            <a href=""#"" class=""like""><i class=""fa fa-heart-o""></i></a>
                        </li>
                        <li class=""product-item"">
                            <div class=""product-thumb clearfix"">
                                <a href=""#"" class=""product-thumb"">
                                    <img src=""images/shop/sh-4/6.jpg"" alt=""image"">
                                </a>
                                <span class=""new sale"">Sale</span>
                            </div>
                            <div class=""product-info clearfix"">
                                <span class=""product-");
            WriteLiteral(@"title"">Cotton White Underweaer Block Out Edition</span>
                                <div class=""price"">
                                    <del>
                                        <span class=""regular"">$150.00</span>
                                    </del>
                                    <ins>
                                        <span class=""amount"">$120.00</span>
                                    </ins>
                                </div>
                                <ul class=""flat-color-list"">
                                    <li>
                                        <a href=""#"" class=""red""></a>
                                    </li>
                                    <li>
                                        <a href=""#"" class=""blue""></a>
                                    </li>
                                    <li>
                                        <a href=""#"" class=""black""></a>
                                    </li>
               ");
            WriteLiteral(@"                 </ul>
                            </div>
                            <div class=""add-to-cart text-center"">
                                <a href=""#"">ADD TO CART</a>
                            </div>
                            <a href=""#"" class=""like""><i class=""fa fa-heart-o""></i></a>
                        </li>
                        <li class=""product-item"">
                            <div class=""product-thumb clearfix"">
                                <a href=""#"" class=""product-thumb"">
                                    <img src=""images/shop/sh-4/7.jpg"" alt=""image"">
                                </a>
                            </div>
                            <div class=""product-info clearfix"">
                                <span class=""product-title"">Cotton White Underweaer Block Out Edition</span>
                                <div class=""price"">
                                    <ins>
                                        <span class=""amount"">$110.0");
            WriteLiteral(@"0</span>
                                    </ins>
                                </div>
                            </div>
                            <div class=""add-to-cart text-center"">
                                <a href=""#"">ADD TO CART</a>
                            </div>
                            <a href=""#"" class=""like""><i class=""fa fa-heart-o""></i></a>
                        </li>
                        <li class=""product-item"">
                            <div class=""product-thumb clearfix"">
                                <a href=""#"" class=""product-thumb"">
                                    <img src=""images/shop/sh-4/6.jpg"" alt=""image"">
                                </a>
                                <span class=""new sale"">Sale</span>
                            </div>
                            <div class=""product-info clearfix"">
                                <span class=""product-title"">Cotton White Underweaer Block Out Edition</span>
                         ");
            WriteLiteral(@"       <div class=""price"">
                                    <del>
                                        <span class=""regular"">$150.00</span>
                                    </del>
                                    <ins>
                                        <span class=""amount"">$120.00</span>
                                    </ins>
                                </div>
                                <ul class=""flat-color-list"">
                                    <li>
                                        <a href=""#"" class=""red""></a>
                                    </li>
                                    <li>
                                        <a href=""#"" class=""blue""></a>
                                    </li>
                                    <li>
                                        <a href=""#"" class=""black""></a>
                                    </li>
                                </ul>
                            </div>
                      ");
            WriteLiteral(@"      <div class=""add-to-cart text-center"">
                                <a href=""#"">ADD TO CART</a>
                            </div>
                            <a href=""#"" class=""like""><i class=""fa fa-heart-o""></i></a>
                        </li>
                        <li class=""product-item"">
                            <div class=""product-thumb clearfix"">
                                <a href=""#"" class=""product-thumb"">
                                    <img src=""images/shop/sh-4/10.jpg"" alt=""image"">
                                </a>
                                <span class=""new sale"">Sale</span>
                            </div>
                            <div class=""product-info clearfix"">
                                <span class=""product-title"">Cotton White Underweaer Block Out Edition</span>
                                <div class=""price"">
                                    <del>
                                        <span class=""regular"">$150.00</span>
  ");
            WriteLiteral(@"                                  </del>
                                    <ins>
                                        <span class=""amount"">$120.00</span>
                                    </ins>
                                </div>
                                <ul class=""flat-color-list"">
                                    <li>
                                        <a href=""#"" class=""red""></a>
                                    </li>
                                    <li>
                                        <a href=""#"" class=""blue""></a>
                                    </li>
                                    <li>
                                        <a href=""#"" class=""black""></a>
                                    </li>
                                </ul>
                            </div>
                            <div class=""add-to-cart text-center"">
                                <a href=""#"">ADD TO CART</a>
                            </div>
         ");
            WriteLiteral(@"                   <a href=""#"" class=""like""><i class=""fa fa-heart-o""></i></a>
                        </li>
                        <li class=""product-item"">
                            <div class=""product-thumb clearfix"">
                                <a href=""#"" class=""product-thumb"">
                                    <img src=""images/shop/sh-4/11.jpg"" alt=""image"">
                                </a>
                            </div>
                            <div class=""product-info clearfix"">
                                <span class=""product-title"">Cotton White Underweaer Block Out Edition</span>
                                <div class=""price"">
                                    <ins>
                                        <span class=""amount"">$110.00</span>
                                    </ins>
                                </div>
                            </div>
                            <div class=""add-to-cart text-center"">
                                <a ");
            WriteLiteral(@"href=""#"">ADD TO CART</a>
                            </div>
                            <a href=""#"" class=""like""><i class=""fa fa-heart-o""></i></a>
                        </li>
                        <li class=""product-item"">
                            <div class=""product-thumb clearfix"">
                                <a href=""#"" class=""product-thumb"">
                                    <img src=""images/shop/sh-4/10.jpg"" alt=""image"">
                                </a>
                                <span class=""new sale"">Sale</span>
                            </div>
                            <div class=""product-info clearfix"">
                                <span class=""product-title"">Cotton White Underweaer Block Out Edition</span>
                                <div class=""price"">
                                    <del>
                                        <span class=""regular"">$150.00</span>
                                    </del>
                                    <i");
            WriteLiteral(@"ns>
                                        <span class=""amount"">$120.00</span>
                                    </ins>
                                </div>
                                <ul class=""flat-color-list"">
                                    <li>
                                        <a href=""#"" class=""red""></a>
                                    </li>
                                    <li>
                                        <a href=""#"" class=""blue""></a>
                                    </li>
                                    <li>
                                        <a href=""#"" class=""black""></a>
                                    </li>
                                </ul>
                            </div>
                            <div class=""add-to-cart text-center"">
                                <a href=""#"">ADD TO CART</a>
                            </div>
                            <a href=""#"" class=""like""><i class=""fa fa-heart-o""></i></a>
 ");
            WriteLiteral(@"                       </li>
                    </ul><!-- /.product -->
                </div><!-- /.product-content -->
                <div class=""product-pagination text-center clearfix"">
                    <ul class=""flat-pagination"">
                        <li class=""prev"">
                            <a href=""#""><i class=""fa fa-angle-left""></i></a>
                        </li>
                        <li><a href=""#"">1</a></li>
                        <li class=""active""><a href=""#""");
            BeginWriteAttribute("title", " title=\"", 17688, "\"", 17696, 0);
            EndWriteAttribute();
            WriteLiteral(@">2</a></li>
                        <li><a href=""#"">3</a></li>
                        <li><a href=""#""><i class=""fa fa-angle-right""></i></a></li>
                    </ul><!-- /.flat-pagination -->
                </div>
            </div><!-- /.col-md-9 -->
        </div><!-- /.row -->
    </div><!-- /.container -->
</section><!-- /.flat-row -->


");
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
