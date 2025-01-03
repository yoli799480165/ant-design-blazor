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
    public partial class TimelineStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string TailColor { get; set; }
            public string TailWidth { get; set; }
            public string DotBorderWidth { get; set; }
            public string DotBg { get; set; }
            public double ItemPaddingBottom { get; set; }
        }

        public class TimelineToken : ComponentToken
        {
            public double ItemHeadSize { get; set; }
            public double CustomHeadPaddingVertical { get; set; }
            public double PaddingInlineEnd { get; set; }
        }

        public static CSSObject GenTimelineStyle(TimelineToken token)
        {
            var componentCls = token.ComponentCls;
            var calc = token.Calc;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Margin = 0,
                    Padding = 0,
                    ListStyle = "none",
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        Position = "relative",
                        Margin = 0,
                        PaddingBottom = token.ItemPaddingBottom,
                        FontSize = token.FontSize,
                        ListStyle = "none",
                        ["&-tail"] = new CSSObject
                        {
                            Position = "absolute",
                            InsetBlockStart = token.ItemHeadSize,
                            InsetInlineStart = Calc(Calc(token.ItemHeadSize).Sub(token.TailWidth)).Div(2).Equal(),
                            Height = $@"{Unit(token.ItemHeadSize)})",
                            BorderInlineStart = $@"{Unit(token.TailWidth)} {token.LineType} {token.TailColor}",
                        },
                        ["&-pending"] = new CSSObject
                        {
                            [$@"{componentCls}-item-head"] = new CSSObject
                            {
                                FontSize = token.FontSizeSM,
                                BackgroundColor = "transparent",
                            },
                            [$@"{componentCls}-item-tail"] = new CSSObject
                            {
                                Display = "none",
                            },
                        },
                        ["&-head"] = new CSSObject
                        {
                            Position = "absolute",
                            Width = token.ItemHeadSize,
                            Height = token.ItemHeadSize,
                            BackgroundColor = token.DotBg,
                            Border = $@"{Unit(token.DotBorderWidth)} {token.LineType} transparent",
                            BorderRadius = "50%",
                            ["&-blue"] = new CSSObject
                            {
                                Color = token.ColorPrimary,
                                BorderColor = token.ColorPrimary,
                            },
                            ["&-red"] = new CSSObject
                            {
                                Color = token.ColorError,
                                BorderColor = token.ColorError,
                            },
                            ["&-green"] = new CSSObject
                            {
                                Color = token.ColorSuccess,
                                BorderColor = token.ColorSuccess,
                            },
                            ["&-gray"] = new CSSObject
                            {
                                Color = token.ColorTextDisabled,
                                BorderColor = token.ColorTextDisabled,
                            },
                        },
                        ["&-head-custom"] = new CSSObject
                        {
                            Position = "absolute",
                            InsetBlockStart = Calc(token.ItemHeadSize).Div(2).Equal(),
                            InsetInlineStart = Calc(token.ItemHeadSize).Div(2).Equal(),
                            Width = "auto",
                            Height = "auto",
                            MarginBlockStart = 0,
                            PaddingBlock = token.CustomHeadPaddingVertical,
                            LineHeight = 1,
                            TextAlign = "center",
                            Border = 0,
                            BorderRadius = 0,
                            Transform = "translate(-50%, -50%)",
                        },
                        ["&-content"] = new CSSObject
                        {
                            Position = "relative",
                            InsetBlockStart = Calc(Calc(token.FontSize).Mul(token.LineHeight).Sub(token.FontSize)).Mul(-1).Add(token.LineWidth).Equal(),
                            MarginInlineStart = Calc(token.Margin).Add(token.ItemHeadSize).Equal(),
                            MarginInlineEnd = 0,
                            MarginBlockStart = 0,
                            MarginBlockEnd = 0,
                            WordBreak = "break-word",
                        },
                        ["&-last"] = new CSSObject
                        {
                            [$@"{componentCls}-item-tail"] = new CSSObject
                            {
                                Display = "none",
                            },
                            [$@"{componentCls}-item-content"] = new CSSObject
                            {
                                MinHeight = Calc(token.ControlHeightLG).Mul(1.2).Equal(),
                            },
                        },
                    },
                    [$@"{componentCls}-alternate,
        &{componentCls}-right,
        &{componentCls}-label"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            ["&-tail, &-head, &-head-custom"] = new CSSObject
                            {
                                InsetInlineStart = "50%",
                            },
                            ["&-head"] = new CSSObject
                            {
                                MarginInlineStart = Calc(token.MarginXXS).Mul(-1).Equal(),
                                ["&-custom"] = new CSSObject
                                {
                                    MarginInlineStart = Calc(token.TailWidth).Div(2).Equal(),
                                },
                            },
                            ["&-left"] = new CSSObject
                            {
                                [$@"{componentCls}-item-content"] = new CSSObject
                                {
                                    InsetInlineStart = $@"{Unit(token.MarginXXS)})",
                                    Width = $@"{Unit(token.MarginSM)})",
                                    TextAlign = "start",
                                },
                            },
                            ["&-right"] = new CSSObject
                            {
                                [$@"{componentCls}-item-content"] = new CSSObject
                                {
                                    Width = $@"{Unit(token.MarginSM)})",
                                    Margin = 0,
                                    TextAlign = "end",
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-right"] = new CSSObject
                    {
                        [$@"{componentCls}-item-right"] = new CSSObject
                        {
                            [$@"{componentCls}-item-tail,
            {componentCls}-item-head,
            {componentCls}-item-head-custom"] = new CSSObject
                            {
                                InsetInlineStart = $@"{Unit(Calc(Calc(token.ItemHeadSize).Add(token.TailWidth)).Div(2).Equal())})",
                            },
                            [$@"{componentCls}-item-content"] = new CSSObject
                            {
                                Width = $@"{Unit(Calc(token.ItemHeadSize).Add(token.MarginXS).Equal())})",
                            },
                        },
                    },
                    [$@"{componentCls}-pending
        {componentCls}-item-last
        {componentCls}-item-tail"] = new CSSObject
                    {
                        Display = "block",
                        Height = $@"{Unit(token.Margin)})",
                        BorderInlineStart = $@"{Unit(token.TailWidth)} dotted {token.TailColor}",
                    },
                    [$@"{componentCls}-reverse
        {componentCls}-item-last
        {componentCls}-item-tail"] = new CSSObject
                    {
                        Display = "none",
                    },
                    [$@"{componentCls}-reverse {componentCls}-item-pending"] = new CSSObject
                    {
                        [$@"{componentCls}-item-tail"] = new CSSObject
                        {
                            InsetBlockStart = token.Margin,
                            Display = "block",
                            Height = $@"{Unit(token.Margin)})",
                            BorderInlineStart = $@"{Unit(token.TailWidth)} dotted {token.TailColor}",
                        },
                        [$@"{componentCls}-item-content"] = new CSSObject
                        {
                            MinHeight = Calc(token.ControlHeightLG).Mul(1.2).Equal(),
                        },
                    },
                    [$@"{componentCls}-label"] = new CSSObject
                    {
                        [$@"{componentCls}-item-label"] = new CSSObject
                        {
                            Position = "absolute",
                            InsetBlockStart = Calc(Calc(token.FontSize).Mul(token.LineHeight).Sub(token.FontSize)).Mul(-1).Add(token.TailWidth).Equal(),
                            Width = $@"{Unit(token.MarginSM)})",
                            TextAlign = "end",
                        },
                        [$@"{componentCls}-item-right"] = new CSSObject
                        {
                            [$@"{componentCls}-item-label"] = new CSSObject
                            {
                                InsetInlineStart = $@"{Unit(token.MarginSM)})",
                                Width = $@"{Unit(token.MarginSM)})",
                                TextAlign = "start",
                            },
                        },
                    },
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                        [$@"{componentCls}-item-head-custom"] = new CSSObject
                        {
                            Transform = "translate(50%, -50%)",
                        },
                    },
                },
            };
        }

        public static TimelineToken PrepareComponentToken(TimelineToken token)
        {
            return new TimelineToken
            {
                TailColor = token.ColorSplit,
                TailWidth = token.LineWidthBold,
                DotBorderWidth = token.Wireframe ? token.LineWidthBold : token.LineWidth * 3,
                DotBg = token.ColorBgContainer,
                ItemPaddingBottom = token.Padding * 1.25,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Timeline", (TimelineToken token) =>
            {
                var timeLineToken = MergeToken(token, new object { ItemHeadSize = 10, CustomHeadPaddingVertical = token.PaddingXXS, PaddingInlineEnd = 2, });
                return new object[]
                {
                    GenTimelineStyle(timeLineToken)
                };
            }, PrepareComponentToken);
        }
    }
}