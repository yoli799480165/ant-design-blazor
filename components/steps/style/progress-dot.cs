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
        public static CSSObject GenStepsProgressDotStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var descriptionMaxWidth = token.DescriptionMaxWidth;
            var lineHeight = token.LineHeight;
            var dotCurrentSize = token.DotCurrentSize;
            var dotSize = token.DotSize;
            var motionDurationSlow = token.MotionDurationSlow;
            return new CSSObject
            {
                [$@"{componentCls}-dot, &{componentCls}-dot{componentCls}-small"] = new CSSObject
                {
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        ["&-title"] = new CSSObject
                        {
                        },
                        ["&-tail"] = new CSSObject
                        {
                            Top = token.Calc(token.DotSize).Sub(token.Calc(token.LineWidth).Mul(3).Equal()).Div(2).Equal(),
                            Width = "100%",
                            MarginTop = 0,
                            MarginBottom = 0,
                            MarginInline = $@"{Unit(token.Calc(descriptionMaxWidth).Div(2).Equal())} 0",
                            Padding = 0,
                            ["&::after"] = new CSSObject
                            {
                                Width = $@"{Unit(token.Calc(token.MarginSM).Mul(2).Equal())})",
                                Height = token.Calc(token.LineWidth).Mul(3).Equal(),
                                MarginInlineStart = token.MarginSM,
                            },
                        },
                        ["&-icon"] = new CSSObject
                        {
                            Width = dotSize,
                            Height = dotSize,
                            MarginInlineStart = token.Calc(token.DescriptionMaxWidth).Sub(dotSize).Div(2).Equal(),
                            PaddingInlineEnd = 0,
                            LineHeight = Unit(dotSize),
                            Background = "transparent",
                            Border = 0,
                            [$@"{componentCls}-icon-dot"] = new CSSObject
                            {
                                Position = "relative",
                                Float = "left",
                                Width = "100%",
                                Height = "100%",
                                BorderRadius = 100,
                                Transition = $@"{motionDurationSlow}",
                                ["&::after"] = new CSSObject
                                {
                                    Position = "absolute",
                                    Top = token.Calc(token.MarginSM).Mul(-1).Equal(),
                                    InsetInlineStart = token.Calc(dotSize).Sub(token.Calc(token.ControlHeightLG).Mul(1.5).Equal()).Div(2).Equal(),
                                    Width = token.Calc(token.ControlHeightLG).Mul(1.5).Equal(),
                                    Height = token.ControlHeight,
                                    Background = "transparent",
                                    Content = "\"\"",
                                },
                            },
                        },
                        ["&-content"] = new CSSObject
                        {
                            Width = descriptionMaxWidth,
                        },
                        [$@"{componentCls}-item-icon"] = new CSSObject
                        {
                            Position = "relative",
                            Top = token.Calc(dotSize).Sub(dotCurrentSize).Div(2).Equal(),
                            Width = dotCurrentSize,
                            Height = dotCurrentSize,
                            LineHeight = Unit(dotCurrentSize),
                            Background = "none",
                            MarginInlineStart = token.Calc(token.DescriptionMaxWidth).Sub(dotCurrentSize).Div(2).Equal(),
                        },
                        [$@"{componentCls}-icon"] = new CSSObject
                        {
                            [$@"{componentCls}-icon-dot"] = new CSSObject
                            {
                                InsetInlineStart = 0,
                            },
                        },
                    },
                },
                [$@"{componentCls}-vertical{componentCls}-dot"] = new CSSObject
                {
                    [$@"{componentCls}-item-icon"] = new CSSObject
                    {
                        MarginTop = token.Calc(token.ControlHeight).Sub(dotSize).Div(2).Equal(),
                        MarginInlineStart = 0,
                        Background = "none",
                    },
                    [$@"{componentCls}-item-process {componentCls}-item-icon"] = new CSSObject
                    {
                        MarginTop = token.Calc(token.ControlHeight).Sub(dotCurrentSize).Div(2).Equal(),
                        Top = 0,
                        InsetInlineStart = token.Calc(dotSize).Sub(dotCurrentSize).Div(2).Equal(),
                        MarginInlineStart = 0,
                    },
                    [$@"{componentCls}-item > {componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                    {
                        Top = token.Calc(token.ControlHeight).Sub(dotSize).Div(2).Equal(),
                        InsetInlineStart = 0,
                        Margin = 0,
                        Padding = $@"{Unit(token.Calc(dotSize).Add(token.PaddingXS).Equal())} 0 {Unit(token.PaddingXS)}",
                        ["&::after"] = new CSSObject
                        {
                            MarginInlineStart = token.Calc(dotSize).Sub(token.LineWidth).Div(2).Equal(),
                        },
                    },
                    [$@"{componentCls}-small"] = new CSSObject
                    {
                        [$@"{componentCls}-item-icon"] = new CSSObject
                        {
                            MarginTop = token.Calc(token.ControlHeightSM).Sub(dotSize).Div(2).Equal(),
                        },
                        [$@"{componentCls}-item-process {componentCls}-item-icon"] = new CSSObject
                        {
                            MarginTop = token.Calc(token.ControlHeightSM).Sub(dotCurrentSize).Div(2).Equal(),
                        },
                        [$@"{componentCls}-item > {componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                        {
                            Top = token.Calc(token.ControlHeightSM).Sub(dotSize).Div(2).Equal(),
                        },
                    },
                    [$@"{componentCls}-item:first-child {componentCls}-icon-dot"] = new CSSObject
                    {
                        InsetInlineStart = 0,
                    },
                    [$@"{componentCls}-item-content"] = new CSSObject
                    {
                        Width = "inherit",
                    },
                },
            };
        }

        public static object ProgressDotDefault()
        {
            return GenStepsProgressDotStyle;
        }
    }
}