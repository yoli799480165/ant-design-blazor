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
        public static CSSObject GenStepsVerticalStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var iconSizeSM = token.IconSizeSM;
            var iconSize = token.IconSize;
            return new CSSObject
            {
                [$@"{componentCls}-vertical"] = new CSSObject
                {
                    Display = "flex",
                    FlexDirection = "column",
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        Display = "block",
                        Flex = "1 0 auto",
                        PaddingInlineStart = 0,
                        Overflow = "visible",
                        [$@"{componentCls}-item-icon"] = new CSSObject
                        {
                            Float = "left",
                            MarginInlineEnd = token.Margin,
                        },
                        [$@"{componentCls}-item-content"] = new CSSObject
                        {
                            Display = "block",
                            MinHeight = token.calc(token.controlHeight).mul(1.5).Equal(),
                            Overflow = "hidden",
                        },
                        [$@"{componentCls}-item-title"] = new CSSObject
                        {
                            LineHeight = Unit(iconSize),
                        },
                        [$@"{componentCls}-item-description"] = new CSSObject
                        {
                            PaddingBottom = token.PaddingSM,
                        },
                    },
                    [$@"{componentCls}-item > {componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = 0,
                        InsetInlineStart = token.calc(iconSize).div(2).sub(token.lineWidth).Equal(),
                        Width = token.LineWidth,
                        Height = "100%",
                        Padding = $@"{Unit(token.calc(token.marginXXS).mul(1.5).add(iconSize).Equal())} 0 {Unit(token.calc(token.marginXXS).mul(1.5).Equal())}",
                        ["&::after"] = new CSSObject
                        {
                            Width = token.LineWidth,
                            Height = "100%",
                        },
                    },
                    [$@"{componentCls}-item:not(:last-child) > {componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                    {
                        Display = "block",
                    },
                    [$@"{componentCls}-item > {componentCls}-item-container > {componentCls}-item-content > {componentCls}-item-title"] = new CSSObject
                    {
                        ["&::after"] = new CSSObject
                        {
                            Display = "none",
                        },
                    },
                    [$@"{componentCls}-small {componentCls}-item-container"] = new CSSObject
                    {
                        [$@"{componentCls}-item-tail"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = 0,
                            InsetInlineStart = token.calc(iconSizeSM).div(2).sub(token.lineWidth).Equal(),
                            Padding = $@"{Unit(token.calc(token.marginXXS).mul(1.5).add(iconSizeSM).Equal())} 0 {Unit(token.calc(token.marginXXS).mul(1.5).Equal())}",
                        },
                        [$@"{componentCls}-item-title"] = new CSSObject
                        {
                            LineHeight = Unit(iconSizeSM),
                        },
                    },
                },
            };
        }

        public static object VerticalDefault()
        {
            return genStepsVerticalStyle;
        }
    }
}