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
    public partial class SwitchStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string TrackHeight { get; set; }
            public string TrackHeightSM { get; set; }
            public string TrackMinWidth { get; set; }
            public string TrackMinWidthSM { get; set; }
            public double TrackPadding { get; set; }
            public string HandleBg { get; set; }
            public string HandleShadow { get; set; }
            public double HandleSize { get; set; }
            public double HandleSizeSM { get; set; }
            public double InnerMinMargin { get; set; }
            public double InnerMaxMargin { get; set; }
            public double InnerMinMarginSM { get; set; }
            public double InnerMaxMarginSM { get; set; }
        }

        public class SwitchToken : ComponentToken
        {
            public string SwitchDuration { get; set; }
            public string SwitchColor { get; set; }
            public double SwitchDisabledOpacity { get; set; }
            public string SwitchLoadingIconSize { get; set; }
            public string SwitchLoadingIconColor { get; set; }
            public string SwitchHandleActiveInset { get; set; }
        }

        public static CSSObject GenSwitchSmallStyle(SwitchToken token)
        {
            var componentCls = token.ComponentCls;
            var trackHeightSM = token.TrackHeightSM;
            var trackPadding = token.TrackPadding;
            var trackMinWidthSM = token.TrackMinWidthSM;
            var innerMinMarginSM = token.InnerMinMarginSM;
            var innerMaxMarginSM = token.InnerMaxMarginSM;
            var handleSizeSM = token.HandleSizeSM;
            var calc = token.Calc;
            var switchInnerCls = $@"{componentCls}-inner";
            var trackPaddingCalc = Unit(Calc(handleSizeSM).Add(Calc(trackPadding).Mul(2)).Equal());
            var innerMaxMarginCalc = Unit(Calc(innerMaxMarginSM).Mul(2).Equal());
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    [$@"{componentCls}-small"] = new CSSObject
                    {
                        MinWidth = trackMinWidthSM,
                        Height = trackHeightSM,
                        LineHeight = Unit(trackHeightSM),
                        [$@"{componentCls}-inner"] = new CSSObject
                        {
                            PaddingInlineStart = innerMaxMarginSM,
                            PaddingInlineEnd = innerMinMarginSM,
                            [$@"{switchInnerCls}-checked, {switchInnerCls}-unchecked"] = new CSSObject
                            {
                                MinHeight = trackHeightSM,
                            },
                            [$@"{switchInnerCls}-checked"] = new CSSObject
                            {
                                MarginInlineStart = $@"{trackPaddingCalc} - {innerMaxMarginCalc})",
                                MarginInlineEnd = $@"{trackPaddingCalc} + {innerMaxMarginCalc})",
                            },
                            [$@"{switchInnerCls}-unchecked"] = new CSSObject
                            {
                                MarginTop = Calc(trackHeightSM).Mul(-1).Equal(),
                                MarginInlineStart = 0,
                                MarginInlineEnd = 0,
                            },
                        },
                        [$@"{componentCls}-handle"] = new CSSObject
                        {
                            Width = handleSizeSM,
                            Height = handleSizeSM,
                        },
                        [$@"{componentCls}-loading-icon"] = new CSSObject
                        {
                            Top = Calc(Calc(handleSizeSM).Sub(token.SwitchLoadingIconSize)).Div(2).Equal(),
                            FontSize = token.SwitchLoadingIconSize,
                        },
                        [$@"{componentCls}-checked"] = new CSSObject
                        {
                            [$@"{componentCls}-inner"] = new CSSObject
                            {
                                PaddingInlineStart = innerMinMarginSM,
                                PaddingInlineEnd = innerMaxMarginSM,
                                [$@"{switchInnerCls}-checked"] = new CSSObject
                                {
                                    MarginInlineStart = 0,
                                    MarginInlineEnd = 0,
                                },
                                [$@"{switchInnerCls}-unchecked"] = new CSSObject
                                {
                                    MarginInlineStart = $@"{trackPaddingCalc} + {innerMaxMarginCalc})",
                                    MarginInlineEnd = $@"{trackPaddingCalc} - {innerMaxMarginCalc})",
                                },
                            },
                            [$@"{componentCls}-handle"] = new CSSObject
                            {
                                InsetInlineStart = $@"{Unit(Calc(handleSizeSM).Add(trackPadding).Equal())})",
                            },
                        },
                        [$@"{componentCls}-disabled):active"] = new CSSObject
                        {
                            [$@"{componentCls}-checked) {switchInnerCls}"] = new CSSObject
                            {
                                [$@"{switchInnerCls}-unchecked"] = new CSSObject
                                {
                                    MarginInlineStart = Calc(token.MarginXXS).Div(2).Equal(),
                                    MarginInlineEnd = Calc(token.MarginXXS).Mul(-1).Div(2).Equal(),
                                },
                            },
                            [$@"{componentCls}-checked {switchInnerCls}"] = new CSSObject
                            {
                                [$@"{switchInnerCls}-checked"] = new CSSObject
                                {
                                    MarginInlineStart = Calc(token.MarginXXS).Mul(-1).Div(2).Equal(),
                                    MarginInlineEnd = Calc(token.MarginXXS).Div(2).Equal(),
                                },
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenSwitchLoadingStyle(SwitchToken token)
        {
            var componentCls = token.ComponentCls;
            var handleSize = token.HandleSize;
            var calc = token.Calc;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    [$@"{componentCls}-loading-icon{token.IconCls}"] = new CSSObject
                    {
                        Position = "relative",
                        Top = Calc(Calc(handleSize).Sub(token.FontSize)).Div(2).Equal(),
                        Color = token.SwitchLoadingIconColor,
                        VerticalAlign = "top",
                    },
                    [$@"{componentCls}-checked {componentCls}-loading-icon"] = new CSSObject
                    {
                        Color = token.SwitchColor,
                    },
                },
            };
        }

        public static CSSObject GenSwitchHandleStyle(SwitchToken token)
        {
            var componentCls = token.ComponentCls;
            var trackPadding = token.TrackPadding;
            var handleBg = token.HandleBg;
            var handleShadow = token.HandleShadow;
            var handleSize = token.HandleSize;
            var calc = token.Calc;
            var switchHandleCls = $@"{componentCls}-handle";
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    [switchHandleCls] = new CSSObject
                    {
                        Position = "absolute",
                        Top = trackPadding,
                        InsetInlineStart = trackPadding,
                        Width = handleSize,
                        Height = handleSize,
                        Transition = $@"{token.SwitchDuration} ease-in-out",
                        ["&::before"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = 0,
                            InsetInlineEnd = 0,
                            Bottom = 0,
                            InsetInlineStart = 0,
                            BackgroundColor = handleBg,
                            BorderRadius = Calc(handleSize).Div(2).Equal(),
                            BoxShadow = handleShadow,
                            Transition = $@"{token.SwitchDuration} ease-in-out",
                            Content = "\"\"",
                        },
                    },
                    [$@"{componentCls}-checked {switchHandleCls}"] = new CSSObject
                    {
                        InsetInlineStart = $@"{Unit(Calc(handleSize).Add(trackPadding).Equal())})",
                    },
                    [$@"{componentCls}-disabled):active"] = new CSSObject
                    {
                        [$@"{switchHandleCls}::before"] = new CSSObject
                        {
                            InsetInlineEnd = token.SwitchHandleActiveInset,
                            InsetInlineStart = 0,
                        },
                        [$@"{componentCls}-checked {switchHandleCls}::before"] = new CSSObject
                        {
                            InsetInlineEnd = 0,
                            InsetInlineStart = token.SwitchHandleActiveInset,
                        },
                    },
                },
            };
        }

        public static CSSObject GenSwitchInnerStyle(SwitchToken token)
        {
            var componentCls = token.ComponentCls;
            var trackHeight = token.TrackHeight;
            var trackPadding = token.TrackPadding;
            var innerMinMargin = token.InnerMinMargin;
            var innerMaxMargin = token.InnerMaxMargin;
            var handleSize = token.HandleSize;
            var calc = token.Calc;
            var switchInnerCls = $@"{componentCls}-inner";
            var trackPaddingCalc = Unit(Calc(handleSize).Add(Calc(trackPadding).Mul(2)).Equal());
            var innerMaxMarginCalc = Unit(Calc(innerMaxMargin).Mul(2).Equal());
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    [switchInnerCls] = new CSSObject
                    {
                        Display = "block",
                        Overflow = "hidden",
                        BorderRadius = 100,
                        Height = "100%",
                        PaddingInlineStart = innerMaxMargin,
                        PaddingInlineEnd = innerMinMargin,
                        Transition = $@"{token.SwitchDuration} ease-in-out, padding-inline-end {token.SwitchDuration} ease-in-out",
                        [$@"{switchInnerCls}-checked, {switchInnerCls}-unchecked"] = new CSSObject
                        {
                            Display = "block",
                            Color = token.ColorTextLightSolid,
                            FontSize = token.FontSizeSM,
                            Transition = $@"{token.SwitchDuration} ease-in-out, margin-inline-end {token.SwitchDuration} ease-in-out",
                            PointerEvents = "none",
                            MinHeight = trackHeight,
                        },
                        [$@"{switchInnerCls}-checked"] = new CSSObject
                        {
                            MarginInlineStart = $@"{trackPaddingCalc} - {innerMaxMarginCalc})",
                            MarginInlineEnd = $@"{trackPaddingCalc} + {innerMaxMarginCalc})",
                        },
                        [$@"{switchInnerCls}-unchecked"] = new CSSObject
                        {
                            MarginTop = Calc(trackHeight).Mul(-1).Equal(),
                            MarginInlineStart = 0,
                            MarginInlineEnd = 0,
                        },
                    },
                    [$@"{componentCls}-checked {switchInnerCls}"] = new CSSObject
                    {
                        PaddingInlineStart = innerMinMargin,
                        PaddingInlineEnd = innerMaxMargin,
                        [$@"{switchInnerCls}-checked"] = new CSSObject
                        {
                            MarginInlineStart = 0,
                            MarginInlineEnd = 0,
                        },
                        [$@"{switchInnerCls}-unchecked"] = new CSSObject
                        {
                            MarginInlineStart = $@"{trackPaddingCalc} + {innerMaxMarginCalc})",
                            MarginInlineEnd = $@"{trackPaddingCalc} - {innerMaxMarginCalc})",
                        },
                    },
                    [$@"{componentCls}-disabled):active"] = new CSSObject
                    {
                        [$@"{componentCls}-checked) {switchInnerCls}"] = new CSSObject
                        {
                            [$@"{switchInnerCls}-unchecked"] = new CSSObject
                            {
                                MarginInlineStart = Calc(trackPadding).Mul(2).Equal(),
                                MarginInlineEnd = Calc(trackPadding).Mul(-1).Mul(2).Equal(),
                            },
                        },
                        [$@"{componentCls}-checked {switchInnerCls}"] = new CSSObject
                        {
                            [$@"{switchInnerCls}-checked"] = new CSSObject
                            {
                                MarginInlineStart = Calc(trackPadding).Mul(-1).Mul(2).Equal(),
                                MarginInlineEnd = Calc(trackPadding).Mul(2).Equal(),
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenSwitchStyle(SwitchToken token)
        {
            var componentCls = token.ComponentCls;
            var trackHeight = token.TrackHeight;
            var trackMinWidth = token.TrackMinWidth;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "relative",
                    Display = "inline-block",
                    BoxSizing = "border-box",
                    MinWidth = trackMinWidth,
                    Height = trackHeight,
                    LineHeight = Unit(trackHeight),
                    VerticalAlign = "middle",
                    Background = token.ColorTextQuaternary,
                    Border = "0",
                    BorderRadius = 100,
                    Cursor = "pointer",
                    Transition = $@"{token.MotionDurationMid}",
                    UserSelect = "none",
                    [$@"{componentCls}-disabled)"] = new CSSObject
                    {
                        Background = token.ColorTextTertiary,
                    },
                    ["..."] = GenFocusStyle(token),
                    [$@"{componentCls}-checked"] = new CSSObject
                    {
                        Background = token.SwitchColor,
                        [$@"{componentCls}-disabled)"] = new CSSObject
                        {
                            Background = token.ColorPrimaryHover,
                        },
                    },
                    [$@"{componentCls}-loading, &{componentCls}-disabled"] = new CSSObject
                    {
                        Cursor = "not-allowed",
                        Opacity = token.SwitchDisabledOpacity,
                        ["*"] = new CSSObject
                        {
                            BoxShadow = "none",
                            Cursor = "not-allowed",
                        },
                    },
                    [$@"{componentCls}-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                },
            };
        }

        public static SwitchToken PrepareComponentToken(SwitchToken token)
        {
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            var controlHeight = token.ControlHeight;
            var colorWhite = token.ColorWhite;
            var height = fontSize * lineHeight;
            var heightSM = controlHeight / 2;
            var padding = 2;
            var handleSize = height - padding * 2;
            var handleSizeSM = heightSM - padding * 2;
            return new SwitchToken
            {
                TrackHeight = height,
                TrackHeightSM = heightSM,
                TrackMinWidth = handleSize * 2 + padding * 4,
                TrackMinWidthSM = handleSizeSM * 2 + padding * 2,
                TrackPadding = padding,
                HandleBg = colorWhite,
                HandleShadow = $@"{new FastColor("#00230b").SetA(0.2).ToRgbString()}",
                InnerMinMargin = handleSize / 2,
                InnerMaxMargin = handleSize + padding + padding * 2,
                InnerMinMarginSM = handleSizeSM / 2,
                InnerMaxMarginSM = handleSizeSM + padding + padding * 2,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Switch", (SwitchToken token) =>
            {
                var switchToken = MergeToken(token, new object { SwitchDuration = token.MotionDurationMid, SwitchColor = token.ColorPrimary, SwitchDisabledOpacity = token.OpacityLoading, SwitchLoadingIconSize = token.Calc(token.FontSizeIcon).Mul(0.75).Equal(), SwitchLoadingIconColor = $@"{token.OpacityLoading})", SwitchHandleActiveInset = "-30%", });
                return new object[]
                {
                    GenSwitchStyle(switchToken),
                    GenSwitchInnerStyle(switchToken),
                    GenSwitchHandleStyle(switchToken),
                    GenSwitchLoadingStyle(switchToken),
                    GenSwitchSmallStyle(switchToken)
                };
            }, PrepareComponentToken);
        }
    }
}