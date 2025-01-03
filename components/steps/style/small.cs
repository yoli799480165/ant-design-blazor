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
    public partial class StepsStyle
    {
        public static CSSObject GenStepsSmallStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var iconSizeSM = token.IconSizeSM;
            var fontSizeSM = token.FontSizeSM;
            var fontSize = token.FontSize;
            var colorTextDescription = token.ColorTextDescription;
            return new CSSObject
            {
                [$@"{componentCls}-small"] = new CSSObject
                {
                    [$@"{componentCls}-horizontal:not({componentCls}-label-vertical) {componentCls}-item"] = new CSSObject
                    {
                        PaddingInlineStart = token.PaddingSM,
                        ["&:first-child"] = new CSSObject
                        {
                            PaddingInlineStart = 0,
                        },
                    },
                    [$@"{componentCls}-item-icon"] = new CSSObject
                    {
                        Width = iconSizeSM,
                        Height = iconSizeSM,
                        MarginTop = 0,
                        MarginBottom = 0,
                        MarginInline = $@"{Unit(token.MarginXS)}",
                        FontSize = fontSizeSM,
                        LineHeight = Unit(iconSizeSM),
                        TextAlign = "center",
                        BorderRadius = iconSizeSM,
                    },
                    [$@"{componentCls}-item-title"] = new CSSObject
                    {
                        PaddingInlineEnd = token.PaddingSM,
                        LineHeight = Unit(iconSizeSM),
                        ["&::after"] = new CSSObject
                        {
                            Top = token.Calc(iconSizeSM).Div(2).Equal(),
                        },
                    },
                    [$@"{componentCls}-item-description"] = new CSSObject
                    {
                        Color = colorTextDescription,
                    },
                    [$@"{componentCls}-item-tail"] = new CSSObject
                    {
                        Top = token.Calc(iconSizeSM).Div(2).Sub(token.PaddingXXS).Equal(),
                    },
                    [$@"{componentCls}-item-custom {componentCls}-item-icon"] = new CSSObject
                    {
                        Width = "inherit",
                        Height = "inherit",
                        LineHeight = "inherit",
                        Background = "none",
                        Border = 0,
                        BorderRadius = 0,
                        [$@"{componentCls}-icon"] = new CSSObject
                        {
                            FontSize = iconSizeSM,
                            LineHeight = Unit(iconSizeSM),
                            Transform = "none",
                        },
                    },
                },
            };
        }

        public static object SmallDefault()
        {
            return GenStepsSmallStyle;
        }
    }
}