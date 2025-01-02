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
    public partial class TagStyle
    {
        public static CSSInterpolation GenTagStatusStyle(TagToken token,  'success' | 'processing' | 'error' | 'warning'  status, CssVariableType cssVariableType)
        {
            var capitalizedCssVariableType = Capitalize(cssVariableType);
            return new CSSInterpolation
            {
                [$@"{token.ComponentCls}{token.ComponentCls}-{status}"] = new CSSInterpolation
                {
                    Color = token[$@"{cssVariableType}"],
                    Background = token[$@"{capitalizedCssVariableType}Bg"],
                    BorderColor = token[$@"{capitalizedCssVariableType}Border"],
                    [$@"{token.ComponentCls}-borderless"] = new CSSInterpolation
                    {
                        BorderColor = "transparent",
                    },
                },
            };
        }

        public static object StatusCmpDefault()
        {
            return GenSubStyleComponent(new object[] { "Tag", "status" }, (TagToken token) =>
            {
                var tagToken = PrepareToken(token);
                return new object[]
                {
                    GenTagStatusStyle(tagToken, "success", "Success"),
                    GenTagStatusStyle(tagToken, "processing", "Info"),
                    GenTagStatusStyle(tagToken, "error", "Error"),
                    GenTagStatusStyle(tagToken, "warning", "Warning")
                };
            }, prepareComponentToken);
        }
    }
}