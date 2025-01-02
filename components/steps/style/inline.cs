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
        public static CSSObject GenStepsInlineStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var inlineDotSize = token.InlineDotSize;
            var inlineTitleColor = token.InlineTitleColor;
            var inlineTailColor = token.InlineTailColor;
            var containerPaddingTop = token.calc(token.paddingXS).add(token.lineWidth).Equal();
            var titleStyle = new object
            {
                [$@"{componentCls}-item-container {componentCls}-item-content {componentCls}-item-title"] = new object
                {
                    Color = inlineTitleColor,
                },
            };
            return new CSSObject
            {
                [$@"{componentCls}-inline"] = new CSSObject
                {
                    Width = "auto",
                    Display = "inline-flex",
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        Flex = "none",
                        ["&-container"] = new CSSObject
                        {
                            Padding = $@"{Unit(containerPaddingTop)} {Unit(token.PaddingXXS)} 0",
                            Margin = $@"{Unit(token.calc(token.marginXXS).div(2).Equal())}",
                            BorderRadius = token.BorderRadiusSM,
                            Cursor = "pointer",
                            Transition = $@"{token.MotionDurationMid}",
                            ["&:hover"] = new CSSObject
                            {
                                Background = token.ControlItemBgHover,
                            },
                            ["&[role='button']:hover"] = new CSSObject
                            {
                                Opacity = 1,
                            },
                        },
                        ["&-icon"] = new CSSObject
                        {
                            Width = inlineDotSize,
                            Height = inlineDotSize,
                            MarginInlineStart = $@"{Unit(token.calc(inlineDotSize).div(2).Equal())})",
                            [$@"{componentCls}-icon"] = new CSSObject
                            {
                                Top = 0,
                            },
                            [$@"{componentCls}-icon-dot"] = new CSSObject
                            {
                                BorderRadius = token.calc(token.fontSizeSM).div(4).Equal(),
                                ["&::after"] = new CSSObject
                                {
                                    Display = "none",
                                },
                            },
                        },
                        ["&-content"] = new CSSObject
                        {
                            Width = "auto",
                            MarginTop = token.calc(token.marginXS).sub(token.lineWidth).Equal(),
                        },
                        ["&-title"] = new CSSObject
                        {
                            Color = inlineTitleColor,
                            FontSize = token.FontSizeSM,
                            LineHeight = token.LineHeightSM,
                            FontWeight = "normal",
                            MarginBottom = token.calc(token.marginXXS).div(2).Equal(),
                        },
                        ["&-description"] = new CSSObject
                        {
                            Display = "none",
                        },
                        ["&-tail"] = new CSSObject
                        {
                            MarginInlineStart = 0,
                            Top = token.calc(inlineDotSize).div(2).add(containerPaddingTop).Equal(),
                            Transform = "translateY(-50%)",
                            ["&:after"] = new CSSObject
                            {
                                Width = "100%",
                                Height = token.LineWidth,
                                BorderRadius = 0,
                                MarginInlineStart = 0,
                                Background = inlineTailColor,
                            },
                        },
                        [$@"{componentCls}-item-tail"] = new CSSObject
                        {
                            Width = "50%",
                            MarginInlineStart = "50%",
                        },
                        [$@"{componentCls}-item-tail"] = new CSSObject
                        {
                            Display = "block",
                            Width = "50%",
                        },
                        ["&-wait"] = new CSSObject
                        {
                            [$@"{componentCls}-item-icon {componentCls}-icon {componentCls}-icon-dot"] = new CSSObject
                            {
                                BackgroundColor = token.ColorBorderBg,
                                Border = $@"{Unit(token.LineWidth)} {token.LineType} {inlineTailColor}",
                            },
                            ["..."] = titleStyle,
                        },
                        ["&-finish"] = new CSSObject
                        {
                            [$@"{componentCls}-item-tail::after"] = new CSSObject
                            {
                                BackgroundColor = inlineTailColor,
                            },
                            [$@"{componentCls}-item-icon {componentCls}-icon {componentCls}-icon-dot"] = new CSSObject
                            {
                                BackgroundColor = inlineTailColor,
                                Border = $@"{Unit(token.LineWidth)} {token.LineType} {inlineTailColor}",
                            },
                            ["..."] = titleStyle,
                        },
                        ["&-error"] = titleStyle,
                        ["&-active, &-process"] = new CSSObject
                        {
                            [$@"{componentCls}-item-icon"] = new CSSObject
                            {
                                Width = inlineDotSize,
                                Height = inlineDotSize,
                                MarginInlineStart = $@"{Unit(token.calc(inlineDotSize).div(2).Equal())})",
                                Top = 0,
                            },
                            ["..."] = titleStyle,
                        },
                        [$@"{componentCls}-item-active) > {componentCls}-item-container[role='button']:hover"] = new CSSObject
                        {
                            [$@"{componentCls}-item-title"] = new CSSObject
                            {
                                Color = inlineTitleColor,
                            },
                        },
                    },
                },
            };
        }

        public static object InlineDefault()
        {
            return genStepsInlineStyle;
        }
    }
}