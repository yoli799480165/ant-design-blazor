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
                            Top = token
            .calc(token.dotSize)
            .sub(token.calc(token.lineWidth).mul(3).equal())
            .div(2).Equal(),
                            Width = "100%",
                            MarginTop = 0,
                            MarginBottom = 0,
                            MarginInline = $@"{Unit(token.calc(descriptionMaxWidth).div(2).Equal())} 0",
                            Padding = 0,
                            ["&::after"] = new CSSObject
                            {
                                Width = $@"{Unit(token.calc(token.marginSM).mul(2).Equal())})",
                                Height = token.calc(token.lineWidth).mul(3).Equal(),
                                MarginInlineStart = token.MarginSM,
                            },
                        },
                        ["&-icon"] = new CSSObject
                        {
                            Width = dotSize,
                            Height = dotSize,
                            MarginInlineStart = token.calc(token.descriptionMaxWidth).sub(dotSize).div(2).Equal(),
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
                                    Top = token.calc(token.marginSM).mul(-1).Equal(),
                                    InsetInlineStart = token
                .calc(dotSize)
                .sub(token.calc(token.controlHeightLG).mul(1.5).equal())
                .div(2).Equal(),
                                    Width = token.calc(token.controlHeightLG).mul(1.5).Equal(),
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
                            Top = token.calc(dotSize).sub(dotCurrentSize).div(2).Equal(),
                            Width = dotCurrentSize,
                            Height = dotCurrentSize,
                            LineHeight = Unit(dotCurrentSize),
                            Background = "none",
                            MarginInlineStart = token
            .calc(token.descriptionMaxWidth)
            .sub(dotCurrentSize)
            .div(2).Equal(),
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
                        MarginTop = token.calc(token.controlHeight).sub(dotSize).div(2).Equal(),
                        MarginInlineStart = 0,
                        Background = "none",
                    },
                    [$@"{componentCls}-item-process {componentCls}-item-icon"] = new CSSObject
                    {
                        MarginTop = token.calc(token.controlHeight).sub(dotCurrentSize).div(2).Equal(),
                        Top = 0,
                        InsetInlineStart = token.calc(dotSize).sub(dotCurrentSize).div(2).Equal(),
                        MarginInlineStart = 0,
                    },
                    [$@"{componentCls}-item > {componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                    {
                        Top = token.calc(token.controlHeight).sub(dotSize).div(2).Equal(),
                        InsetInlineStart = 0,
                        Margin = 0,
                        Padding = $@"{Unit(token.calc(dotSize).add(token.paddingXS).Equal())} 0 {Unit(token.PaddingXS)}",
                        ["&::after"] = new CSSObject
                        {
                            MarginInlineStart = token.calc(dotSize).sub(token.lineWidth).div(2).Equal(),
                        },
                    },
                    [$@"{componentCls}-small"] = new CSSObject
                    {
                        [$@"{componentCls}-item-icon"] = new CSSObject
                        {
                            MarginTop = token.calc(token.controlHeightSM).sub(dotSize).div(2).Equal(),
                        },
                        [$@"{componentCls}-item-process {componentCls}-item-icon"] = new CSSObject
                        {
                            MarginTop = token.calc(token.controlHeightSM).sub(dotCurrentSize).div(2).Equal(),
                        },
                        [$@"{componentCls}-item > {componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                        {
                            Top = token.calc(token.controlHeightSM).sub(dotSize).div(2).Equal(),
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
            return genStepsProgressDotStyle;
        }
    }
}