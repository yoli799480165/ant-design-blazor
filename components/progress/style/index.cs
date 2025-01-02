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
    public partial class ProgressStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string DefaultColor { get; set; }
            public string RemainingColor { get; set; }
            public string CircleTextColor { get; set; }
            public double LineBorderRadius { get; set; }
            public string CircleTextFontSize { get; set; }
            public string CircleIconFontSize { get; set; }
        }

        public object LineStrokeColorVar = "--progress-line-stroke-color";
        public object Percent = "--progress-percent";
        public class ProgressToken : ComponentToken
        {
            public string ProgressStepMinWidth { get; set; }
            public string ProgressStepMarginInlineEnd { get; set; }
            public string ProgressActiveMotionDuration { get; set; }
        }

        public static object GenAntProgressActive(boolean isRtl)
        {
            var direction = isRtl ? "100%" : "-100%";
            return new Keyframes($@"{isRtl ? "RTL" : "LTR"}Active", new object { ["0%"] = new object { Transform = $@"{direction}) scaleX(0)", Opacity = 0.1, }, ["20%"] = new object { Transform = $@"{direction}) scaleX(0)", Opacity = 0.5, }, ["to"] = new object { Transform = "translateX(0) scaleX(1)", Opacity = 0, }, });
        }

        public static CSSObject GenBaseStyle(ProgressToken token)
        {
            var progressCls = token.ComponentCls;
            var iconPrefixCls = token.IconCls;
            return new CSSObject
            {
                [progressCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "inline-block",
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    ["&-line"] = new CSSObject
                    {
                        Position = "relative",
                        Width = "100%",
                        FontSize = token.FontSize,
                    },
                    [$@"{progressCls}-outer"] = new CSSObject
                    {
                        Display = "inline-flex",
                        AlignItems = "center",
                        Width = "100%",
                    },
                    [$@"{progressCls}-inner"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "inline-block",
                        Width = "100%",
                        Flex = 1,
                        Overflow = "hidden",
                        VerticalAlign = "middle",
                        BackgroundColor = token.RemainingColor,
                        BorderRadius = token.LineBorderRadius,
                    },
                    [$@"{progressCls}-inner:not({progressCls}-circle-gradient)"] = new CSSObject
                    {
                        [$@"{progressCls}-circle-path"] = new CSSObject
                        {
                            ["stroke"] = token.DefaultColor,
                        },
                    },
                    [$@"{progressCls}-success-bg, {progressCls}-bg"] = new CSSObject
                    {
                        Position = "relative",
                        Background = token.DefaultColor,
                        BorderRadius = token.LineBorderRadius,
                        Transition = $@"{token.MotionDurationSlow} {token.MotionEaseInOutCirc}",
                    },
                    [$@"{progressCls}-layout-bottom"] = new CSSObject
                    {
                        Display = "flex",
                        FlexDirection = "column",
                        AlignItems = "center",
                        JustifyContent = "center",
                        [$@"{progressCls}-text"] = new CSSObject
                        {
                            Width = "max-content",
                            MarginInlineStart = 0,
                            MarginTop = token.MarginXXS,
                        },
                    },
                    [$@"{progressCls}-bg"] = new CSSObject
                    {
                        Overflow = "hidden",
                        ["&::after"] = new CSSObject
                        {
                            Content = "\"\"",
                            Background = new CSSObject
                            {
                                _multi_value_ = true,
                                Value = new object[]
                                {
                                    "inherit",
                                    $@"{LineStrokeColorVar})"
                                },
                            },
                            Height = "100%",
                            Width = $@"{Percent}) * 100%)",
                            Display = "block",
                        },
                        [$@"{progressCls}-bg-inner"] = new CSSObject
                        {
                            MinWidth = "max-content",
                            ["&::after"] = new CSSObject
                            {
                                Content = "none",
                            },
                            [$@"{progressCls}-text-inner"] = new CSSObject
                            {
                                Color = token.ColorWhite,
                                [$@"{progressCls}-text-bright"] = new CSSObject
                                {
                                    Color = "rgba(0, 0, 0, 0.45)",
                                },
                            },
                        },
                    },
                    [$@"{progressCls}-success-bg"] = new CSSObject
                    {
                        Position = "absolute",
                        InsetBlockStart = 0,
                        InsetInlineStart = 0,
                        BackgroundColor = token.ColorSuccess,
                    },
                    [$@"{progressCls}-text"] = new CSSObject
                    {
                        Display = "inline-block",
                        MarginInlineStart = token.MarginXS,
                        Color = token.ColorText,
                        LineHeight = 1,
                        Width = "2em",
                        WhiteSpace = "nowrap",
                        TextAlign = "start",
                        VerticalAlign = "middle",
                        WordBreak = "normal",
                        [iconPrefixCls] = new CSSObject
                        {
                            FontSize = token.FontSize,
                        },
                        [$@"{progressCls}-text-outer"] = new CSSObject
                        {
                            Width = "max-content",
                        },
                        [$@"{progressCls}-text-outer{progressCls}-text-start"] = new CSSObject
                        {
                            Width = "max-content",
                            MarginInlineStart = 0,
                            MarginInlineEnd = token.MarginXS,
                        },
                    },
                    [$@"{progressCls}-text-inner"] = new CSSObject
                    {
                        Display = "flex",
                        JustifyContent = "center",
                        AlignItems = "center",
                        Width = "100%",
                        Height = "100%",
                        MarginInlineStart = 0,
                        Padding = $@"{Unit(token.PaddingXXS)}",
                        [$@"{progressCls}-text-start"] = new CSSObject
                        {
                            JustifyContent = "start",
                        },
                        [$@"{progressCls}-text-end"] = new CSSObject
                        {
                            JustifyContent = "end",
                        },
                    },
                    [$@"{progressCls}-status-active"] = new CSSObject
                    {
                        [$@"{progressCls}-bg::before"] = new CSSObject
                        {
                            Position = "absolute",
                            Inset = 0,
                            BackgroundColor = token.ColorBgContainer,
                            BorderRadius = token.LineBorderRadius,
                            Opacity = 0,
                            AnimationName = GenAntProgressActive(),
                            AnimationDuration = token.ProgressActiveMotionDuration,
                            AnimationTimingFunction = token.MotionEaseOutQuint,
                            AnimationIterationCount = "infinite",
                            Content = "\"\"",
                        },
                    },
                    [$@"{progressCls}-rtl{progressCls}-status-active"] = new CSSObject
                    {
                        [$@"{progressCls}-bg::before"] = new CSSObject
                        {
                            AnimationName = GenAntProgressActive(true),
                        },
                    },
                    [$@"{progressCls}-status-exception"] = new CSSObject
                    {
                        [$@"{progressCls}-bg"] = new CSSObject
                        {
                            BackgroundColor = token.ColorError,
                        },
                        [$@"{progressCls}-text"] = new CSSObject
                        {
                            Color = token.ColorError,
                        },
                    },
                    [$@"{progressCls}-status-exception {progressCls}-inner:not({progressCls}-circle-gradient)"] = new CSSObject
                    {
                        [$@"{progressCls}-circle-path"] = new CSSObject
                        {
                            ["stroke"] = token.ColorError,
                        },
                    },
                    [$@"{progressCls}-status-success"] = new CSSObject
                    {
                        [$@"{progressCls}-bg"] = new CSSObject
                        {
                            BackgroundColor = token.ColorSuccess,
                        },
                        [$@"{progressCls}-text"] = new CSSObject
                        {
                            Color = token.ColorSuccess,
                        },
                    },
                    [$@"{progressCls}-status-success {progressCls}-inner:not({progressCls}-circle-gradient)"] = new CSSObject
                    {
                        [$@"{progressCls}-circle-path"] = new CSSObject
                        {
                            ["stroke"] = token.ColorSuccess,
                        },
                    },
                },
            };
        }

        public static CSSObject GenCircleStyle(ProgressToken token)
        {
            var progressCls = token.ComponentCls;
            var iconPrefixCls = token.IconCls;
            return new CSSObject
            {
                [progressCls] = new CSSObject
                {
                    [$@"{progressCls}-circle-trail"] = new CSSObject
                    {
                        ["stroke"] = token.RemainingColor,
                    },
                    [$@"{progressCls}-circle {progressCls}-inner"] = new CSSObject
                    {
                        Position = "relative",
                        LineHeight = 1,
                        BackgroundColor = "transparent",
                    },
                    [$@"{progressCls}-circle {progressCls}-text"] = new CSSObject
                    {
                        Position = "absolute",
                        InsetBlockStart = "50%",
                        InsetInlineStart = 0,
                        Width = "100%",
                        Margin = 0,
                        Padding = 0,
                        Color = token.CircleTextColor,
                        FontSize = token.CircleTextFontSize,
                        LineHeight = 1,
                        WhiteSpace = "normal",
                        TextAlign = "center",
                        Transform = "translateY(-50%)",
                        [iconPrefixCls] = new CSSObject
                        {
                            FontSize = token.CircleIconFontSize,
                        },
                    },
                    [$@"{progressCls}-circle&-status-exception"] = new CSSObject
                    {
                        [$@"{progressCls}-text"] = new CSSObject
                        {
                            Color = token.ColorError,
                        },
                    },
                    [$@"{progressCls}-circle&-status-success"] = new CSSObject
                    {
                        [$@"{progressCls}-text"] = new CSSObject
                        {
                            Color = token.ColorSuccess,
                        },
                    },
                },
                [$@"{progressCls}-inline-circle"] = new CSSObject
                {
                    LineHeight = 1,
                    [$@"{progressCls}-inner"] = new CSSObject
                    {
                        VerticalAlign = "bottom",
                    },
                },
            };
        }

        public static CSSObject GenStepStyle(ProgressToken token)
        {
            var progressCls = token.ComponentCls;
            return new CSSObject
            {
                [progressCls] = new CSSObject
                {
                    [$@"{progressCls}-steps"] = new CSSObject
                    {
                        Display = "inline-block",
                        ["&-outer"] = new CSSObject
                        {
                            Display = "flex",
                            FlexDirection = "row",
                            AlignItems = "center",
                        },
                        ["&-item"] = new CSSObject
                        {
                            FlexShrink = 0,
                            MinWidth = token.ProgressStepMinWidth,
                            MarginInlineEnd = token.ProgressStepMarginInlineEnd,
                            BackgroundColor = token.RemainingColor,
                            Transition = $@"{token.MotionDurationSlow}",
                            ["&-active"] = new CSSObject
                            {
                                BackgroundColor = token.DefaultColor,
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenSmallLine(ProgressToken token)
        {
            var progressCls = token.ComponentCls;
            var iconPrefixCls = token.IconCls;
            return new CSSObject
            {
                [progressCls] = new CSSObject
                {
                    [$@"{progressCls}-small&-line, {progressCls}-small&-line {progressCls}-text {iconPrefixCls}"] = new CSSObject
                    {
                        FontSize = token.FontSizeSM,
                    },
                },
            };
        }

        public static ProgressToken PrepareComponentToken(ProgressToken token)
        {
            return new ProgressToken
            {
                CircleTextColor = token.ColorText,
                DefaultColor = token.ColorInfo,
                RemainingColor = token.ColorFillSecondary,
                LineBorderRadius = 100,
                CircleTextFontSize = "1em",
                CircleIconFontSize = $@"{token.FontSize / token.FontSizeSM}em",
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Progress", (ProgressToken token) =>
            {
                var progressStepMarginInlineEnd = token.calc(token.marginXXS).div(2).Equal();
                var progressToken = MergeToken(token, new object { ProgressStepMinWidth = progressStepMarginInlineEnd, ProgressActiveMotionDuration = "2.4s", });
                return new object[]
                {
                    GenBaseStyle(progressToken),
                    GenCircleStyle(progressToken),
                    GenStepStyle(progressToken),
                    GenSmallLine(progressToken)
                };
            }, prepareComponentToken);
        }
    }
}