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
    public partial class CascaderStyle
    {
        public static CSSObject GenPanelStyle(CascaderToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-panel"] = new object[]
                {
                    GetColumnsStyle(token),
                    new object
                    {
                        Display = "inline-flex",
                        Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                        BorderRadius = token.BorderRadiusLG,
                        OverflowX = "auto",
                        MaxWidth = "100%",
                        [$@"{componentCls}-menus"] = new object
                        {
                            AlignItems = "stretch",
                        },
                        [$@"{componentCls}-menu"] = new object
                        {
                            Height = "auto",
                        },
                        ["&-empty"] = new object
                        {
                            Padding = token.PaddingXXS,
                        },
                    }
                },
            };
        }

        public static object PanelDefault()
        {
            return GenComponentStyleHook(new object[] { "Cascader", "Panel" }, (CascaderToken token) =>
            {
                return GenPanelStyle(token);
            }, PrepareComponentToken);
        }
    }
}