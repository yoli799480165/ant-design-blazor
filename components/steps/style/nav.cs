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
        public static CSSObject GenStepsNavStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var navContentMaxWidth = token.NavContentMaxWidth;
            var navArrowColor = token.NavArrowColor;
            var stepsNavActiveColor = token.StepsNavActiveColor;
            var motionDurationSlow = token.MotionDurationSlow;
            return new CSSObject
            {
                [$@"{componentCls}-navigation"] = new CSSObject
                {
                    PaddingTop = token.PaddingSM,
                    [$@"{componentCls}-small"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            ["&-container"] = new CSSObject
                            {
                                MarginInlineStart = token.Calc(token.MarginSM).Mul(-1).Equal(),
                            },
                        },
                    },
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        Overflow = "visible",
                        TextAlign = "center",
                        ["&-container"] = new CSSObject
                        {
                            Display = "inline-block",
                            Height = "100%",
                            MarginInlineStart = token.Calc(token.Margin).Mul(-1).Equal(),
                            PaddingBottom = token.PaddingSM,
                            TextAlign = "start",
                            Transition = $@"{motionDurationSlow}",
                            [$@"{componentCls}-item-content"] = new CSSObject
                            {
                                MaxWidth = navContentMaxWidth,
                            },
                            [$@"{componentCls}-item-title"] = new CSSObject
                            {
                                MaxWidth = "100%",
                                PaddingInlineEnd = 0,
                                ["..."] = textEllipsis,
                                ["&::after"] = new CSSObject
                                {
                                    Display = "none",
                                },
                            },
                        },
                        [$@"{componentCls}-item-active)"] = new CSSObject
                        {
                            [$@"{componentCls}-item-container[role='button']"] = new CSSObject
                            {
                                Cursor = "pointer",
                                ["&:hover"] = new CSSObject
                                {
                                    Opacity = 0.85,
                                },
                            },
                        },
                        ["&:last-child"] = new CSSObject
                        {
                            Flex = 1,
                            ["&::after"] = new CSSObject
                            {
                                Display = "none",
                            },
                        },
                        ["&::after"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = $@"{Unit(token.Calc(token.PaddingSM).Div(2).Equal())})",
                            InsetInlineStart = "100%",
                            Display = "inline-block",
                            Width = token.FontSizeIcon,
                            Height = token.FontSizeIcon,
                            BorderTop = $@"{Unit(token.LineWidth)} {token.LineType} {navArrowColor}",
                            BorderBottom = "none",
                            BorderInlineStart = "none",
                            BorderInlineEnd = $@"{Unit(token.LineWidth)} {token.LineType} {navArrowColor}",
                            Transform = "translateY(-50%) translateX(-50%) rotate(45deg)",
                            Content = "\"\"",
                        },
                        ["&::before"] = new CSSObject
                        {
                            Position = "absolute",
                            Bottom = 0,
                            InsetInlineStart = "50%",
                            Display = "inline-block",
                            Width = 0,
                            Height = token.LineWidthBold,
                            BackgroundColor = stepsNavActiveColor,
                            Transition = $@"{motionDurationSlow}, inset-inline-start {motionDurationSlow}",
                            TransitionTimingFunction = "ease-out",
                            Content = "\"\"",
                        },
                    },
                    [$@"{componentCls}-item{componentCls}-item-active::before"] = new CSSObject
                    {
                        InsetInlineStart = 0,
                        Width = "100%",
                    },
                },
                [$@"{componentCls}-navigation{componentCls}-vertical"] = new CSSObject
                {
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        MarginInlineEnd = 0,
                        ["&::before"] = new CSSObject
                        {
                            Display = "none",
                        },
                        [$@"{componentCls}-item-active::before"] = new CSSObject
                        {
                            Top = 0,
                            InsetInlineEnd = 0,
                            InsetInlineStart = "unset",
                            Display = "block",
                            Width = token.Calc(token.LineWidth).Mul(3).Equal(),
                            Height = $@"{Unit(token.MarginLG)})",
                        },
                        ["&::after"] = new CSSObject
                        {
                            Position = "relative",
                            InsetInlineStart = "50%",
                            Display = "block",
                            Width = token.Calc(token.ControlHeight).Mul(0.25).Equal(),
                            Height = token.Calc(token.ControlHeight).Mul(0.25).Equal(),
                            MarginBottom = token.MarginXS,
                            TextAlign = "center",
                            Transform = "translateY(-50%) translateX(-50%) rotate(135deg)",
                        },
                        ["&:last-child"] = new CSSObject
                        {
                            ["&::after"] = new CSSObject
                            {
                                Display = "none",
                            },
                        },
                        [$@"{componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                        {
                            Visibility = "hidden",
                        },
                    },
                },
                [$@"{componentCls}-navigation{componentCls}-horizontal"] = new CSSObject
                {
                    [$@"{componentCls}-item > {componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                    {
                        Visibility = "hidden",
                    },
                },
            };
        }

        public static object NavDefault()
        {
            return GenStepsNavStyle;
        }
    }
}