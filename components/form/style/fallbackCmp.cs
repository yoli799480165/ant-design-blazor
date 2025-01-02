using System;
using AntDesign;
using CssInCSharp;
using CssInCSharp.Colors;
using static CssInCSharp.Css.CSSUtil;
using static AntDesign.GlobalStyle;
using static AntDesign.Theme;
using static AntDesign.StyleUtil;
using Keyframes = CssInCSharp.Keyframe;

namespace AntDesign.Styles
{
    public partial class FormStyle
    {
        public static CSSObject GenFallbackStyle(FormToken token)
        {
            var formItemCls = token.FormItemCls;
            return new CSSObject
            {
                ["@media screen and (-ms-high-contrast: active), (-ms-high-contrast: none)"] = new CSSObject
                {
                    [$@"{formItemCls}-control"] = new CSSObject
                    {
                        Display = "flex",
                    },
                },
            };
        }

        public static object FallbackCmpDefault()
        {
            return GenSubStyleComponent(new object[] { "Form", "item-item" }, (FormToken token, object { rootPrefixCls }) =>
            {
                var formToken = PrepareToken(token, rootPrefixCls);
                return new object[]
                {
                    GenFallbackStyle(formToken)
                };
            });
        }
    }
}