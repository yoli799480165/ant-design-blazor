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
    public partial class DividerStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string TextPaddingInline { get; set; }
            public double OrientationMargin { get; set; }
            public string VerticalMarginInline { get; set; }
        }

        public class DividerToken : ComponentToken
        {
            public string SizePaddingEdgeHorizontal { get; set; }
            public string DividerHorizontalWithTextGutterMargin { get; set; }
            public string DividerHorizontalGutterMargin { get; set; }
        }

        public static CSSObject GenSharedDividerStyle(DividerToken token)
        {
            var componentCls = token.ComponentCls;
            var sizePaddingEdgeHorizontal = token.SizePaddingEdgeHorizontal;
            var colorSplit = token.ColorSplit;
            var lineWidth = token.LineWidth;
            var textPaddingInline = token.TextPaddingInline;
            var orientationMargin = token.OrientationMargin;
            var verticalMarginInline = token.VerticalMarginInline;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    BorderBlockStart = $@"{Unit(lineWidth)} solid {colorSplit}",
                    ["&-vertical"] = new CSSObject
                    {
                        Position = "relative",
                        Top = "-0.06em",
                        Display = "inline-block",
                        Height = "0.9em",
                        MarginInline = verticalMarginInline,
                        MarginBlock = 0,
                        VerticalAlign = "middle",
                        BorderTop = 0,
                        BorderInlineStart = $@"{Unit(lineWidth)} solid {colorSplit}",
                    },
                    ["&-horizontal"] = new CSSObject
                    {
                        Display = "flex",
                        Clear = "both",
                        Width = "100%",
                        MinWidth = "100%",
                        Margin = $@"{Unit(token.DividerHorizontalGutterMargin)} 0",
                    },
                    [$@"{componentCls}-with-text"] = new CSSObject
                    {
                        Display = "flex",
                        AlignItems = "center",
                        Margin = $@"{Unit(token.DividerHorizontalWithTextGutterMargin)} 0",
                        Color = token.ColorTextHeading,
                        FontWeight = 500,
                        FontSize = token.FontSizeLG,
                        WhiteSpace = "nowrap",
                        TextAlign = "center",
                        BorderBlockStart = $@"{colorSplit}",
                        ["&::before, &::after"] = new CSSObject
                        {
                            Position = "relative",
                            Width = "50%",
                            BorderBlockStart = $@"{Unit(lineWidth)} solid transparent",
                            BorderBlockStartColor = "inherit",
                            BorderBlockEnd = 0,
                            Transform = "translateY(50%)",
                            Content = "''",
                        },
                    },
                    [$@"{componentCls}-with-text-left"] = new CSSObject
                    {
                        ["&::before"] = new CSSObject
                        {
                            Width = $@"{orientationMargin} * 100%)",
                        },
                        ["&::after"] = new CSSObject
                        {
                            Width = $@"{orientationMargin} * 100%)",
                        },
                    },
                    [$@"{componentCls}-with-text-right"] = new CSSObject
                    {
                        ["&::before"] = new CSSObject
                        {
                            Width = $@"{orientationMargin} * 100%)",
                        },
                        ["&::after"] = new CSSObject
                        {
                            Width = $@"{orientationMargin} * 100%)",
                        },
                    },
                    [$@"{componentCls}-inner-text"] = new CSSObject
                    {
                        Display = "inline-block",
                        PaddingBlock = 0,
                        PaddingInline = textPaddingInline,
                    },
                    ["&-dashed"] = new CSSObject
                    {
                        Background = "none",
                        BorderColor = colorSplit,
                        BorderStyle = "dashed",
                        BorderWidth = $@"{Unit(lineWidth)} 0 0",
                    },
                    [$@"{componentCls}-with-text{componentCls}-dashed"] = new CSSObject
                    {
                        ["&::before, &::after"] = new CSSObject
                        {
                            BorderStyle = "dashed none none",
                        },
                    },
                    [$@"{componentCls}-dashed"] = new CSSObject
                    {
                        BorderInlineStartWidth = lineWidth,
                        BorderInlineEnd = 0,
                        BorderBlockStart = 0,
                        BorderBlockEnd = 0,
                    },
                    ["&-dotted"] = new CSSObject
                    {
                        Background = "none",
                        BorderColor = colorSplit,
                        BorderStyle = "dotted",
                        BorderWidth = $@"{Unit(lineWidth)} 0 0",
                    },
                    [$@"{componentCls}-with-text{componentCls}-dotted"] = new CSSObject
                    {
                        ["&::before, &::after"] = new CSSObject
                        {
                            BorderStyle = "dotted none none",
                        },
                    },
                    [$@"{componentCls}-dotted"] = new CSSObject
                    {
                        BorderInlineStartWidth = lineWidth,
                        BorderInlineEnd = 0,
                        BorderBlockStart = 0,
                        BorderBlockEnd = 0,
                    },
                    [$@"{componentCls}-with-text"] = new CSSObject
                    {
                        Color = token.ColorText,
                        FontWeight = "normal",
                        FontSize = token.FontSize,
                    },
                    [$@"{componentCls}-with-text-left{componentCls}-no-default-orientation-margin-left"] = new CSSObject
                    {
                        ["&::before"] = new CSSObject
                        {
                            Width = 0,
                        },
                        ["&::after"] = new CSSObject
                        {
                            Width = "100%",
                        },
                        [$@"{componentCls}-inner-text"] = new CSSObject
                        {
                            PaddingInlineStart = sizePaddingEdgeHorizontal,
                        },
                    },
                    [$@"{componentCls}-with-text-right{componentCls}-no-default-orientation-margin-right"] = new CSSObject
                    {
                        ["&::before"] = new CSSObject
                        {
                            Width = "100%",
                        },
                        ["&::after"] = new CSSObject
                        {
                            Width = 0,
                        },
                        [$@"{componentCls}-inner-text"] = new CSSObject
                        {
                            PaddingInlineEnd = sizePaddingEdgeHorizontal,
                        },
                    },
                },
            };
        }

        public static DividerToken PrepareComponentToken(DividerToken token)
        {
            return new DividerToken
            {
                TextPaddingInline = "1em",
                OrientationMargin = 0.05,
                VerticalMarginInline = token.MarginXS,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Divider", (DividerToken token) =>
            {
                var dividerToken = MergeToken(token, new object { DividerHorizontalWithTextGutterMargin = token.Margin, DividerHorizontalGutterMargin = token.MarginLG, SizePaddingEdgeHorizontal = 0, });
                return new object[]
                {
                    GenSharedDividerStyle(dividerToken)
                };
            }, prepareComponentToken, new object { Unitless = new object { OrientationMargin = true, }, });
        }
    }
}