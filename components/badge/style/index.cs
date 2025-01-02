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
    public partial class BadgeStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string IndicatorZIndex { get; set; }
            public string IndicatorHeight { get; set; }
            public string IndicatorHeightSM { get; set; }
            public double DotSize { get; set; }
            public double TextFontSize { get; set; }
            public double TextFontSizeSM { get; set; }
            public string TextFontWeight { get; set; }
            public double StatusSize { get; set; }
        }

        public class BadgeToken : ComponentToken
        {
            public double BadgeFontHeight { get; set; }
            public string BadgeTextColor { get; set; }
            public string BadgeColor { get; set; }
            public string BadgeColorHover { get; set; }
            public double BadgeShadowSize { get; set; }
            public string BadgeShadowColor { get; set; }
            public string BadgeProcessingDuration { get; set; }
            public double BadgeRibbonOffset { get; set; }
            public string BadgeRibbonCornerTransform { get; set; }
            public string BadgeRibbonCornerFilter { get; set; }
        }

        public object antStatusProcessing = new Keyframes("antStatusProcessing", new object { ["0%"] = new object { Transform = "scale(0.8)", Opacity = 0.5, }, ["100%"] = new object { Transform = "scale(2.4)", Opacity = 0, }, });
        public object antZoomBadgeIn = new Keyframes("antZoomBadgeIn", new object { ["0%"] = new object { Transform = "scale(0) translate(50%, -50%)", Opacity = 0, }, ["100%"] = new object { Transform = "scale(1) translate(50%, -50%)", }, });
        public object antZoomBadgeOut = new Keyframes("antZoomBadgeOut", new object { ["0%"] = new object { Transform = "scale(1) translate(50%, -50%)", }, ["100%"] = new object { Transform = "scale(0) translate(50%, -50%)", Opacity = 0, }, });
        public object antNoWrapperZoomBadgeIn = new Keyframes("antNoWrapperZoomBadgeIn", new object { ["0%"] = new object { Transform = "scale(0)", Opacity = 0, }, ["100%"] = new object { Transform = "scale(1)", }, });
        public object antNoWrapperZoomBadgeOut = new Keyframes("antNoWrapperZoomBadgeOut", new object { ["0%"] = new object { Transform = "scale(1)", }, ["100%"] = new object { Transform = "scale(0)", Opacity = 0, }, });
        public object antBadgeLoadingCircle = new Keyframes("antBadgeLoadingCircle", new object { ["0%"] = new object { TransformOrigin = "50%", }, ["100%"] = new object { Transform = "translate(50%, -50%) rotate(360deg)", TransformOrigin = "50%", }, });
        public static CSSObject GenSharedBadgeStyle(BadgeToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var antCls = token.AntCls;
            var badgeShadowSize = token.BadgeShadowSize;
            var textFontSize = token.TextFontSize;
            var textFontSizeSM = token.TextFontSizeSM;
            var statusSize = token.StatusSize;
            var dotSize = token.DotSize;
            var textFontWeight = token.TextFontWeight;
            var indicatorHeight = token.IndicatorHeight;
            var indicatorHeightSM = token.IndicatorHeightSM;
            var marginXS = token.MarginXS;
            var calc = token.Calc;
            var numberPrefixCls = $@"{antCls}-scroll-number";
            var colorPreset = GenPresetColor(token, (object colorKey, object { darkColor }) =>
            {
                return new object
                {
                    [$@"{componentCls} {componentCls}-color-{colorKey}"] = new object
                    {
                        Background = darkColor,
                        [$@"{componentCls}-count)"] = new object
                        {
                            Color = darkColor,
                        },
                        ["a:hover &"] = new object
                        {
                            Background = darkColor,
                        },
                    },
                };
            });
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "relative",
                    Display = "inline-block",
                    Width = "fit-content",
                    LineHeight = 1,
                    [$@"{componentCls}-count"] = new CSSObject
                    {
                        Display = "inline-flex",
                        JustifyContent = "center",
                        ZIndex = token.IndicatorZIndex,
                        MinWidth = indicatorHeight,
                        Height = indicatorHeight,
                        Color = token.BadgeTextColor,
                        FontWeight = textFontWeight,
                        FontSize = textFontSize,
                        LineHeight = Unit(indicatorHeight),
                        WhiteSpace = "nowrap",
                        TextAlign = "center",
                        Background = token.BadgeColor,
                        BorderRadius = calc(indicatorHeight).div(2).Equal(),
                        BoxShadow = $@"{Unit(badgeShadowSize)} {token.BadgeShadowColor}",
                        Transition = $@"{token.MotionDurationMid}",
                        ["a"] = new CSSObject
                        {
                            Color = token.BadgeTextColor,
                        },
                        ["a:hover"] = new CSSObject
                        {
                            Color = token.BadgeTextColor,
                        },
                        ["a:hover &"] = new CSSObject
                        {
                            Background = token.BadgeColorHover,
                        },
                    },
                    [$@"{componentCls}-count-sm"] = new CSSObject
                    {
                        MinWidth = indicatorHeightSM,
                        Height = indicatorHeightSM,
                        FontSize = textFontSizeSM,
                        LineHeight = Unit(indicatorHeightSM),
                        BorderRadius = calc(indicatorHeightSM).div(2).Equal(),
                    },
                    [$@"{componentCls}-multiple-words"] = new CSSObject
                    {
                        Padding = $@"{Unit(token.PaddingXS)}",
                        ["bdi"] = new CSSObject
                        {
                            UnicodeBidi = "plaintext",
                        },
                    },
                    [$@"{componentCls}-dot"] = new CSSObject
                    {
                        ZIndex = token.IndicatorZIndex,
                        Width = dotSize,
                        MinWidth = dotSize,
                        Height = dotSize,
                        Background = token.BadgeColor,
                        BorderRadius = "100%",
                        BoxShadow = $@"{Unit(badgeShadowSize)} {token.BadgeShadowColor}",
                    },
                    [$@"{componentCls}-count, {componentCls}-dot, {numberPrefixCls}-custom-component"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = 0,
                        InsetInlineEnd = 0,
                        Transform = "translate(50%, -50%)",
                        TransformOrigin = "100% 0%",
                        [$@"{iconCls}-spin"] = new CSSObject
                        {
                            AnimationName = antBadgeLoadingCircle,
                            AnimationDuration = "1s",
                            AnimationIterationCount = "infinite",
                            AnimationTimingFunction = "linear",
                        },
                    },
                    [$@"{componentCls}-status"] = new CSSObject
                    {
                        LineHeight = "inherit",
                        VerticalAlign = "baseline",
                        [$@"{componentCls}-status-dot"] = new CSSObject
                        {
                            Position = "relative",
                            Top = -1,
                            Display = "inline-block",
                            Width = statusSize,
                            Height = statusSize,
                            VerticalAlign = "middle",
                            BorderRadius = "50%",
                        },
                        [$@"{componentCls}-status-success"] = new CSSObject
                        {
                            BackgroundColor = token.ColorSuccess,
                        },
                        [$@"{componentCls}-status-processing"] = new CSSObject
                        {
                            Overflow = "visible",
                            Color = token.ColorInfo,
                            BackgroundColor = token.ColorInfo,
                            BorderColor = "currentcolor",
                            ["&::after"] = new CSSObject
                            {
                                Position = "absolute",
                                Top = 0,
                                InsetInlineStart = 0,
                                Width = "100%",
                                Height = "100%",
                                BorderWidth = badgeShadowSize,
                                BorderStyle = "solid",
                                BorderColor = "inherit",
                                BorderRadius = "50%",
                                AnimationName = antStatusProcessing,
                                AnimationDuration = token.BadgeProcessingDuration,
                                AnimationIterationCount = "infinite",
                                AnimationTimingFunction = "ease-in-out",
                                Content = "\"\"",
                            },
                        },
                        [$@"{componentCls}-status-default"] = new CSSObject
                        {
                            BackgroundColor = token.ColorTextPlaceholder,
                        },
                        [$@"{componentCls}-status-error"] = new CSSObject
                        {
                            BackgroundColor = token.ColorError,
                        },
                        [$@"{componentCls}-status-warning"] = new CSSObject
                        {
                            BackgroundColor = token.ColorWarning,
                        },
                        [$@"{componentCls}-status-text"] = new CSSObject
                        {
                            MarginInlineStart = marginXS,
                            Color = token.ColorText,
                            FontSize = token.FontSize,
                        },
                    },
                    ["..."] = colorPreset,
                    [$@"{componentCls}-zoom-appear, {componentCls}-zoom-enter"] = new CSSObject
                    {
                        AnimationName = antZoomBadgeIn,
                        AnimationDuration = token.MotionDurationSlow,
                        AnimationTimingFunction = token.MotionEaseOutBack,
                        AnimationFillMode = "both",
                    },
                    [$@"{componentCls}-zoom-leave"] = new CSSObject
                    {
                        AnimationName = antZoomBadgeOut,
                        AnimationDuration = token.MotionDurationSlow,
                        AnimationTimingFunction = token.MotionEaseOutBack,
                        AnimationFillMode = "both",
                    },
                    [$@"{componentCls}-not-a-wrapper"] = new CSSObject
                    {
                        [$@"{componentCls}-zoom-appear, {componentCls}-zoom-enter"] = new CSSObject
                        {
                            AnimationName = antNoWrapperZoomBadgeIn,
                            AnimationDuration = token.MotionDurationSlow,
                            AnimationTimingFunction = token.MotionEaseOutBack,
                        },
                        [$@"{componentCls}-zoom-leave"] = new CSSObject
                        {
                            AnimationName = antNoWrapperZoomBadgeOut,
                            AnimationDuration = token.MotionDurationSlow,
                            AnimationTimingFunction = token.MotionEaseOutBack,
                        },
                        [$@"{componentCls}-status)"] = new CSSObject
                        {
                            VerticalAlign = "middle",
                        },
                        [$@"{numberPrefixCls}-custom-component, {componentCls}-count"] = new CSSObject
                        {
                            Transform = "none",
                        },
                        [$@"{numberPrefixCls}-custom-component, {numberPrefixCls}"] = new CSSObject
                        {
                            Position = "relative",
                            Top = "auto",
                            Display = "block",
                            TransformOrigin = "50% 50%",
                        },
                    },
                    [numberPrefixCls] = new CSSObject
                    {
                        Overflow = "hidden",
                        Transition = $@"{token.MotionDurationMid} {token.MotionEaseOutBack}",
                        [$@"{numberPrefixCls}-only"] = new CSSObject
                        {
                            Position = "relative",
                            Display = "inline-block",
                            Height = indicatorHeight,
                            Transition = $@"{token.MotionDurationSlow} {token.MotionEaseOutBack}",
                            WebkitTransformStyle = "preserve-3d",
                            WebkitBackfaceVisibility = "hidden",
                            [$@"{numberPrefixCls}-only-unit"] = new CSSObject
                            {
                                Height = indicatorHeight,
                                Margin = 0,
                                WebkitTransformStyle = "preserve-3d",
                                WebkitBackfaceVisibility = "hidden",
                            },
                        },
                        [$@"{numberPrefixCls}-symbol"] = new CSSObject
                        {
                            VerticalAlign = "top",
                        },
                    },
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                        [$@"{componentCls}-count, {componentCls}-dot, {numberPrefixCls}-custom-component"] = new CSSObject
                        {
                            Transform = "translate(-50%, -50%)",
                        },
                    },
                },
            };
        }

        public static object PrepareToken(BadgeToken token)
        {
            var fontHeight = token.FontHeight;
            var lineWidth = token.LineWidth;
            var marginXS = token.MarginXS;
            var colorBorderBg = token.ColorBorderBg;
            var badgeFontHeight = fontHeight;
            var badgeShadowSize = lineWidth;
            var badgeTextColor = token.ColorTextLightSolid;
            var badgeColor = token.ColorError;
            var badgeColorHover = token.ColorErrorHover;
            var badgeToken = MergeToken(token, new object { BadgeShadowColor = colorBorderBg, BadgeProcessingDuration = "1.2s", BadgeRibbonOffset = marginXS, BadgeRibbonCornerTransform = "scaleY(0.75)", BadgeRibbonCornerFilter = "brightness(75%)", });
            return badgeToken;
        }

        public static BadgeToken PrepareComponentToken(BadgeToken token)
        {
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            var fontSizeSM = token.FontSizeSM;
            var lineWidth = token.LineWidth;
            return new BadgeToken
            {
                IndicatorZIndex = "auto",
                IndicatorHeight = Math.Round(fontSize * lineHeight) - 2 * lineWidth,
                IndicatorHeightSM = fontSize,
                DotSize = fontSizeSM / 2,
                TextFontSize = fontSizeSM,
                TextFontSizeSM = fontSizeSM,
                TextFontWeight = "normal",
                StatusSize = fontSizeSM / 2,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Badge", (BadgeToken token) =>
            {
                var badgeToken = PrepareToken(token);
                return GenSharedBadgeStyle(badgeToken);
            }, prepareComponentToken);
        }
    }
}