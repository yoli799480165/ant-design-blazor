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
    public partial class MenuStyle
    {
        public static CSSObject GetHorizontalStyle(MenuToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var horizontalLineHeight = token.HorizontalLineHeight;
            var colorSplit = token.ColorSplit;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var itemPaddingInline = token.ItemPaddingInline;
            return new CSSObject
            {
                [$@"{componentCls}-horizontal"] = new CSSObject
                {
                    LineHeight = horizontalLineHeight,
                    Border = 0,
                    BorderBottom = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                    BoxShadow = "none",
                    ["&::after"] = new CSSObject
                    {
                        Display = "block",
                        Clear = "both",
                        Height = 0,
                        Content = "\"\\20\"",
                    },
                    [$@"{componentCls}-item, {componentCls}-submenu"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "inline-block",
                        VerticalAlign = "bottom",
                        PaddingInline = itemPaddingInline,
                    },
                    [$@"{componentCls}-item:hover,
        > {componentCls}-item-active,
        > {componentCls}-submenu {componentCls}-submenu-title:hover"] = new CSSObject
                    {
                        BackgroundColor = "transparent",
                    },
                    [$@"{componentCls}-item, {componentCls}-submenu-title"] = new CSSObject
                    {
                        Transition = [`border-color ${motionDurationSlow}`, `background ${motionDurationSlow}`].Join(","),
                    },
                    [$@"{componentCls}-submenu-arrow"] = new CSSObject
                    {
                        Display = "none",
                    },
                },
            };
        }

        public static object HorizontalDefault()
        {
            return getHorizontalStyle;
        }
    }
}