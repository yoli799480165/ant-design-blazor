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
    public partial class SpinStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string ContentHeight { get; set; }
            public double DotSize { get; set; }
            public double DotSizeSM { get; set; }
            public double DotSizeLG { get; set; }
        }

        public class SpinToken : ComponentToken
        {
            public string SpinDotDefault { get; set; }
        }

        public object antSpinMove = new Keyframes("antSpinMove", new object { ["to"] = new object { Opacity = 1, }, });
        public object antRotate = new Keyframes("antRotate", new object { ["to"] = new object { Transform = "rotate(405deg)", }, });
        public static CSSObject GenSpinStyle(SpinToken token)
        {
            var componentCls = token.ComponentCls;
            var calc = token.Calc;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "absolute",
                    Display = "none",
                    Color = token.ColorPrimary,
                    FontSize = 0,
                    TextAlign = "center",
                    VerticalAlign = "middle",
                    Opacity = 0,
                    Transition = $@"{token.MotionDurationSlow} {token.MotionEaseInOutCirc}",
                    ["&-spinning"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "inline-block",
                        Opacity = 1,
                    },
                    [$@"{componentCls}-text"] = new CSSObject
                    {
                        FontSize = token.FontSize,
                        PaddingTop = Calc(Calc(token.DotSize).Sub(token.FontSize)).Div(2).Add(2).Equal(),
                    },
                    ["&-fullscreen"] = new CSSObject
                    {
                        Position = "fixed",
                        Width = "100vw",
                        Height = "100vh",
                        BackgroundColor = token.ColorBgMask,
                        ZIndex = token.ZIndexPopupBase,
                        Inset = 0,
                        Display = "flex",
                        AlignItems = "center",
                        FlexDirection = "column",
                        JustifyContent = "center",
                        Opacity = 0,
                        Visibility = "hidden",
                        Transition = $@"{token.MotionDurationMid}",
                        ["&-show"] = new CSSObject
                        {
                            Opacity = 1,
                            Visibility = "visible",
                        },
                        [componentCls] = new CSSObject
                        {
                            [$@"{componentCls}-dot-holder"] = new CSSObject
                            {
                                Color = token.ColorWhite,
                            },
                            [$@"{componentCls}-text"] = new CSSObject
                            {
                                Color = token.ColorTextLightSolid,
                            },
                        },
                    },
                    ["&-nested-loading"] = new CSSObject
                    {
                        Position = "relative",
                        [$@"{componentCls}"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = 0,
                            InsetInlineStart = 0,
                            ZIndex = 4,
                            Display = "block",
                            Width = "100%",
                            Height = "100%",
                            MaxHeight = token.ContentHeight,
                            [$@"{componentCls}-dot"] = new CSSObject
                            {
                                Position = "absolute",
                                Top = "50%",
                                InsetInlineStart = "50%",
                                Margin = Calc(token.DotSize).Mul(-1).Div(2).Equal(),
                            },
                            [$@"{componentCls}-text"] = new CSSObject
                            {
                                Position = "absolute",
                                Top = "50%",
                                Width = "100%",
                                TextShadow = $@"{token.ColorBgContainer}",
                            },
                            [$@"{componentCls}-show-text {componentCls}-dot"] = new CSSObject
                            {
                                MarginTop = Calc(token.DotSize).Div(2).Mul(-1).Sub(10).Equal(),
                            },
                            ["&-sm"] = new CSSObject
                            {
                                [$@"{componentCls}-dot"] = new CSSObject
                                {
                                    Margin = Calc(token.DotSizeSM).Mul(-1).Div(2).Equal(),
                                },
                                [$@"{componentCls}-text"] = new CSSObject
                                {
                                    PaddingTop = Calc(Calc(token.DotSizeSM).Sub(token.FontSize)).Div(2).Add(2).Equal(),
                                },
                                [$@"{componentCls}-show-text {componentCls}-dot"] = new CSSObject
                                {
                                    MarginTop = Calc(token.DotSizeSM).Div(2).Mul(-1).Sub(10).Equal(),
                                },
                            },
                            ["&-lg"] = new CSSObject
                            {
                                [$@"{componentCls}-dot"] = new CSSObject
                                {
                                    Margin = Calc(token.DotSizeLG).Mul(-1).Div(2).Equal(),
                                },
                                [$@"{componentCls}-text"] = new CSSObject
                                {
                                    PaddingTop = Calc(Calc(token.DotSizeLG).Sub(token.FontSize)).Div(2).Add(2).Equal(),
                                },
                                [$@"{componentCls}-show-text {componentCls}-dot"] = new CSSObject
                                {
                                    MarginTop = Calc(token.DotSizeLG).Div(2).Mul(-1).Sub(10).Equal(),
                                },
                            },
                        },
                        [$@"{componentCls}-container"] = new CSSObject
                        {
                            Position = "relative",
                            Transition = $@"{token.MotionDurationSlow}",
                            ["&::after"] = new CSSObject
                            {
                                Position = "absolute",
                                Top = 0,
                                InsetInlineEnd = 0,
                                Bottom = 0,
                                InsetInlineStart = 0,
                                ZIndex = 10,
                                Width = "100%",
                                Height = "100%",
                                Background = token.ColorBgContainer,
                                Opacity = 0,
                                Transition = $@"{token.MotionDurationSlow}",
                                Content = "\"\"",
                                PointerEvents = "none",
                            },
                        },
                        [$@"{componentCls}-blur"] = new CSSObject
                        {
                            Clear = "both",
                            Opacity = 0.5,
                            UserSelect = "none",
                            PointerEvents = "none",
                            ["&::after"] = new CSSObject
                            {
                                Opacity = 0.4,
                                PointerEvents = "auto",
                            },
                        },
                    },
                    ["&-tip"] = new CSSObject
                    {
                        Color = token.SpinDotDefault,
                    },
                    [$@"{componentCls}-dot-holder"] = new CSSObject
                    {
                        Width = "1em",
                        Height = "1em",
                        FontSize = token.DotSize,
                        Display = "inline-block",
                        Transition = $@"{token.MotionDurationSlow} ease, opacity {token.MotionDurationSlow} ease",
                        TransformOrigin = "50% 50%",
                        LineHeight = 1,
                        Color = token.ColorPrimary,
                        ["&-hidden"] = new CSSObject
                        {
                            Transform = "scale(0.3)",
                            Opacity = 0,
                        },
                    },
                    [$@"{componentCls}-dot-progress"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = "50%",
                        Transform = "translate(-50%, -50%)",
                        InsetInlineStart = "50%",
                    },
                    [$@"{componentCls}-dot"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "inline-block",
                        FontSize = token.DotSize,
                        Width = "1em",
                        Height = "1em",
                        ["&-item"] = new CSSObject
                        {
                            Position = "absolute",
                            Display = "block",
                            Width = Calc(token.DotSize).Sub(Calc(token.MarginXXS).Div(2)).Div(2).Equal(),
                            Height = Calc(token.DotSize).Sub(Calc(token.MarginXXS).Div(2)).Div(2).Equal(),
                            Background = "currentColor",
                            BorderRadius = "100%",
                            Transform = "scale(0.75)",
                            TransformOrigin = "50% 50%",
                            Opacity = 0.3,
                            AnimationName = antSpinMove,
                            AnimationDuration = "1s",
                            AnimationIterationCount = "infinite",
                            AnimationTimingFunction = "linear",
                            AnimationDirection = "alternate",
                            ["&:nth-child(1)"] = new CSSObject
                            {
                                Top = 0,
                                InsetInlineStart = 0,
                                AnimationDelay = "0s",
                            },
                            ["&:nth-child(2)"] = new CSSObject
                            {
                                Top = 0,
                                InsetInlineEnd = 0,
                                AnimationDelay = "0.4s",
                            },
                            ["&:nth-child(3)"] = new CSSObject
                            {
                                InsetInlineEnd = 0,
                                Bottom = 0,
                                AnimationDelay = "0.8s",
                            },
                            ["&:nth-child(4)"] = new CSSObject
                            {
                                Bottom = 0,
                                InsetInlineStart = 0,
                                AnimationDelay = "1.2s",
                            },
                        },
                        ["&-spin"] = new CSSObject
                        {
                            Transform = "rotate(45deg)",
                            AnimationName = antRotate,
                            AnimationDuration = "1.2s",
                            AnimationIterationCount = "infinite",
                            AnimationTimingFunction = "linear",
                        },
                        ["&-circle"] = new CSSObject
                        {
                            StrokeLinecap = "round",
                            Transition = new object[]
                            {
                                "stroke-dashoffset",
                                "stroke-dasharray",
                                "stroke",
                                "stroke-width",
                                "opacity"
                            }.Map((object item) =>
                            {
                                return $@"{item} {token.MotionDurationSlow} ease";
                            }).Join(","),
                            FillOpacity = 0,
                            ["stroke"] = "currentcolor",
                        },
                        ["&-circle-bg"] = new CSSObject
                        {
                            ["stroke"] = token.ColorFillSecondary,
                        },
                    },
                    [$@"{componentCls}-dot"] = new CSSObject
                    {
                        ["&, &-holder"] = new CSSObject
                        {
                            FontSize = token.DotSizeSM,
                        },
                    },
                    [$@"{componentCls}-dot-holder"] = new CSSObject
                    {
                        ["i"] = new CSSObject
                        {
                            Width = Calc(Calc(token.DotSizeSM).Sub(Calc(token.MarginXXS).Div(2))).Div(2).Equal(),
                            Height = Calc(Calc(token.DotSizeSM).Sub(Calc(token.MarginXXS).Div(2))).Div(2).Equal(),
                        },
                    },
                    [$@"{componentCls}-dot"] = new CSSObject
                    {
                        ["&, &-holder"] = new CSSObject
                        {
                            FontSize = token.DotSizeLG,
                        },
                    },
                    [$@"{componentCls}-dot-holder"] = new CSSObject
                    {
                        ["i"] = new CSSObject
                        {
                            Width = Calc(Calc(token.DotSizeLG).Sub(token.MarginXXS)).Div(2).Equal(),
                            Height = Calc(Calc(token.DotSizeLG).Sub(token.MarginXXS)).Div(2).Equal(),
                        },
                    },
                    [$@"{componentCls}-show-text {componentCls}-text"] = new CSSObject
                    {
                        Display = "block",
                    },
                },
            };
        }

        public static SpinToken PrepareComponentToken(SpinToken token)
        {
            var controlHeightLG = token.ControlHeightLG;
            var controlHeight = token.ControlHeight;
            return new SpinToken
            {
                ContentHeight = 400,
                DotSize = controlHeightLG / 2,
                DotSizeSM = controlHeightLG * 0.35,
                DotSizeLG = controlHeight,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Spin", (SpinToken token) =>
            {
                var spinToken = MergeToken(token, new object { SpinDotDefault = token.ColorTextDescription, });
                return new object[]
                {
                    GenSpinStyle(spinToken)
                };
            }, PrepareComponentToken);
        }
    }
}