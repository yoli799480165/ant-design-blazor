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
    public partial class DescriptionsStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string LabelBg { get; set; }
            public string TitleColor { get; set; }
            public double TitleMarginBottom { get; set; }
            public double ItemPaddingBottom { get; set; }
            public double ItemPaddingEnd { get; set; }
            public double ColonMarginRight { get; set; }
            public double ColonMarginLeft { get; set; }
            public string ContentColor { get; set; }
            public string ExtraColor { get; set; }
        }

        public class DescriptionsToken : ComponentToken
        {
        }

        public static CSSObject GenBorderedStyle(DescriptionsToken token)
        {
            var componentCls = token.ComponentCls;
            var labelBg = token.LabelBg;
            return new CSSObject
            {
                [$@"{componentCls}-bordered"] = new CSSObject
                {
                    [$@"{componentCls}-view"] = new CSSObject
                    {
                        Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                        ["> table"] = new CSSObject
                        {
                            TableLayout = "auto",
                        },
                        [$@"{componentCls}-row"] = new CSSObject
                        {
                            BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                            ["&:last-child"] = new CSSObject
                            {
                                BorderBottom = "none",
                            },
                            [$@"{componentCls}-item-label, > {componentCls}-item-content"] = new CSSObject
                            {
                                Padding = $@"{Unit(token.Padding)} {Unit(token.PaddingLG)}",
                                BorderInlineEnd = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                                ["&:last-child"] = new CSSObject
                                {
                                    BorderInlineEnd = "none",
                                },
                            },
                            [$@"{componentCls}-item-label"] = new CSSObject
                            {
                                Color = token.ColorTextSecondary,
                                BackgroundColor = labelBg,
                                ["&::after"] = new CSSObject
                                {
                                    Display = "none",
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-middle"] = new CSSObject
                    {
                        [$@"{componentCls}-row"] = new CSSObject
                        {
                            [$@"{componentCls}-item-label, > {componentCls}-item-content"] = new CSSObject
                            {
                                Padding = $@"{Unit(token.PaddingSM)} {Unit(token.PaddingLG)}",
                            },
                        },
                    },
                    [$@"{componentCls}-small"] = new CSSObject
                    {
                        [$@"{componentCls}-row"] = new CSSObject
                        {
                            [$@"{componentCls}-item-label, > {componentCls}-item-content"] = new CSSObject
                            {
                                Padding = $@"{Unit(token.PaddingXS)} {Unit(token.Padding)}",
                            },
                        },
                    },
                },
            };
        }

        public static object GenDescriptionStyles(DescriptionsToken token)
        {
            var componentCls = token.ComponentCls;
            var extraColor = token.ExtraColor;
            var itemPaddingBottom = token.ItemPaddingBottom;
            var itemPaddingEnd = token.ItemPaddingEnd;
            var colonMarginRight = token.ColonMarginRight;
            var colonMarginLeft = token.ColonMarginLeft;
            var titleMarginBottom = token.TitleMarginBottom;
            return new object
            {
                [componentCls] = new object
                {
                    ["..."] = ResetComponent(token),
                    ["..."] = GenBorderedStyle(token),
                    ["&-rtl"] = new object
                    {
                        Direction = "rtl",
                    },
                    [$@"{componentCls}-header"] = new object
                    {
                        Display = "flex",
                        AlignItems = "center",
                        MarginBottom = titleMarginBottom,
                    },
                    [$@"{componentCls}-title"] = new object
                    {
                        ["..."] = textEllipsis,
                        Flex = "auto",
                        Color = token.TitleColor,
                        FontWeight = token.FontWeightStrong,
                        FontSize = token.FontSizeLG,
                        LineHeight = token.LineHeightLG,
                    },
                    [$@"{componentCls}-extra"] = new object
                    {
                        MarginInlineStart = "auto",
                        Color = extraColor,
                        FontSize = token.FontSize,
                    },
                    [$@"{componentCls}-view"] = new object
                    {
                        Width = "100%",
                        BorderRadius = token.BorderRadiusLG,
                        ["table"] = new object
                        {
                            Width = "100%",
                            TableLayout = "fixed",
                            BorderCollapse = "collapse",
                        },
                    },
                    [$@"{componentCls}-row"] = new object
                    {
                        ["> th, > td"] = new object
                        {
                            PaddingBottom = itemPaddingBottom,
                            PaddingInlineEnd = itemPaddingEnd,
                        },
                        ["> th:last-child, > td:last-child"] = new object
                        {
                            PaddingInlineEnd = 0,
                        },
                        ["&:last-child"] = new object
                        {
                            BorderBottom = "none",
                            ["> th, > td"] = new object
                            {
                                PaddingBottom = 0,
                            },
                        },
                    },
                    [$@"{componentCls}-item-label"] = new object
                    {
                        Color = token.ColorTextTertiary,
                        FontWeight = "normal",
                        FontSize = token.FontSize,
                        LineHeight = token.LineHeight,
                        TextAlign = "start",
                        ["&::after"] = new object
                        {
                            Content = "\":\"",
                            Position = "relative",
                            Top = -0.5,
                            MarginInline = $@"{Unit(colonMarginLeft)} {Unit(colonMarginRight)}",
                        },
                        [$@"{componentCls}-item-no-colon::after"] = new object
                        {
                            Content = "\"\"",
                        },
                    },
                    [$@"{componentCls}-item-no-label"] = new object
                    {
                        ["&::after"] = new object
                        {
                            Margin = 0,
                            Content = "\"\"",
                        },
                    },
                    [$@"{componentCls}-item-content"] = new object
                    {
                        Display = "table-cell",
                        Flex = 1,
                        Color = token.ContentColor,
                        FontSize = token.FontSize,
                        LineHeight = token.LineHeight,
                        WordBreak = "break-word",
                        OverflowWrap = "break-word",
                    },
                    [$@"{componentCls}-item"] = new object
                    {
                        PaddingBottom = 0,
                        VerticalAlign = "top",
                        ["&-container"] = new object
                        {
                            Display = "flex",
                            [$@"{componentCls}-item-label"] = new object
                            {
                                Display = "inline-flex",
                                AlignItems = "baseline",
                            },
                            [$@"{componentCls}-item-content"] = new object
                            {
                                Display = "inline-flex",
                                AlignItems = "baseline",
                                MinWidth = "1em",
                            },
                        },
                    },
                    ["&-middle"] = new object
                    {
                        [$@"{componentCls}-row"] = new object
                        {
                            ["> th, > td"] = new object
                            {
                                PaddingBottom = token.PaddingSM,
                            },
                        },
                    },
                    ["&-small"] = new object
                    {
                        [$@"{componentCls}-row"] = new object
                        {
                            ["> th, > td"] = new object
                            {
                                PaddingBottom = token.PaddingXS,
                            },
                        },
                    },
                },
            };
        }

        public static DescriptionsToken PrepareComponentToken(DescriptionsToken token)
        {
            return new DescriptionsToken
            {
                LabelBg = token.ColorFillAlter,
                TitleColor = token.ColorText,
                TitleMarginBottom = token.FontSizeSM * token.LineHeightSM,
                ItemPaddingBottom = token.Padding,
                ItemPaddingEnd = token.Padding,
                ColonMarginRight = token.MarginXS,
                ColonMarginLeft = token.MarginXXS / 2,
                ContentColor = token.ColorText,
                ExtraColor = token.ColorText,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Descriptions", (DescriptionsToken token) =>
            {
                var descriptionToken = MergeToken(token, new object { });
                return GenDescriptionStyles(descriptionToken);
            }, PrepareComponentToken);
        }
    }
}