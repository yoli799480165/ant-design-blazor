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
    public partial class FloatButtonStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double DotOffsetInCircle { get; set; }
            public double DotOffsetInSquare { get; set; }
        }

        public class FloatButtonToken : ComponentToken
        {
            public string FloatButtonColor { get; set; }
            public string FloatButtonBackgroundColor { get; set; }
            public string FloatButtonHoverBackgroundColor { get; set; }
            public double FloatButtonFontSize { get; set; }
            public double FloatButtonSize { get; set; }
            public string FloatButtonIconSize { get; set; }
            public string FloatButtonBodySize { get; set; }
            public double FloatButtonBodyPadding { get; set; }
            public string BadgeOffset { get; set; }
            public double FloatButtonInsetBlockEnd { get; set; }
            public double FloatButtonInsetInlineEnd { get; set; }
        }

        public static CSSObject FloatButtonGroupStyle(FloatButtonToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var floatButtonSize = token.FloatButtonSize;
            var margin = token.Margin;
            var borderRadiusLG = token.BorderRadiusLG;
            var borderRadiusSM = token.BorderRadiusSM;
            var badgeOffset = token.BadgeOffset;
            var floatButtonBodyPadding = token.FloatButtonBodyPadding;
            var zIndexPopupBase = token.ZIndexPopupBase;
            var calc = token.Calc;
            var groupPrefixCls = $@"{componentCls}-group";
            return new CSSObject
            {
                [groupPrefixCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    ZIndex = zIndexPopupBase,
                    Display = "flex",
                    FlexDirection = "column",
                    AlignItems = "center",
                    JustifyContent = "center",
                    Border = "none",
                    Position = "fixed",
                    Height = "auto",
                    BoxShadow = "none",
                    MinWidth = floatButtonSize,
                    MinHeight = floatButtonSize,
                    InsetInlineEnd = token.FloatButtonInsetInlineEnd,
                    Bottom = token.FloatButtonInsetBlockEnd,
                    BorderRadius = borderRadiusLG,
                    [$@"{groupPrefixCls}-wrap"] = new CSSObject
                    {
                        ZIndex = -1,
                        Display = "flex",
                        JustifyContent = "center",
                        AlignItems = "center",
                        Position = "absolute",
                    },
                    [$@"{groupPrefixCls}-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [componentCls] = new CSSObject
                    {
                        Position = "static",
                    },
                },
                [$@"{groupPrefixCls}-top > {groupPrefixCls}-wrap"] = new CSSObject
                {
                    FlexDirection = "column",
                    Top = "auto",
                    Bottom = Calc(floatButtonSize).Add(margin).Equal(),
                    ["&::after"] = new CSSObject
                    {
                        Content = "\"\"",
                        Position = "absolute",
                        Width = "100%",
                        Height = margin,
                        Bottom = Calc(margin).Mul(-1).Equal(),
                    },
                },
                [$@"{groupPrefixCls}-bottom > {groupPrefixCls}-wrap"] = new CSSObject
                {
                    FlexDirection = "column",
                    Top = Calc(floatButtonSize).Add(margin).Equal(),
                    Bottom = "auto",
                    ["&::after"] = new CSSObject
                    {
                        Content = "\"\"",
                        Position = "absolute",
                        Width = "100%",
                        Height = margin,
                        Top = Calc(margin).Mul(-1).Equal(),
                    },
                },
                [$@"{groupPrefixCls}-right > {groupPrefixCls}-wrap"] = new CSSObject
                {
                    FlexDirection = "row",
                    Left = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = Calc(floatButtonSize).Add(margin).Equal(),
                    },
                    Right = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = "auto",
                    },
                    ["&::after"] = new CSSObject
                    {
                        Content = "\"\"",
                        Position = "absolute",
                        Width = margin,
                        Height = "100%",
                        Left = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = Calc(margin).Mul(-1).Equal(),
                        },
                    },
                },
                [$@"{groupPrefixCls}-left > {groupPrefixCls}-wrap"] = new CSSObject
                {
                    FlexDirection = "row",
                    Left = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = "auto",
                    },
                    Right = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = Calc(floatButtonSize).Add(margin).Equal(),
                    },
                    ["&::after"] = new CSSObject
                    {
                        Content = "\"\"",
                        Position = "absolute",
                        Width = margin,
                        Height = "100%",
                        Right = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = Calc(margin).Mul(-1).Equal(),
                        },
                    },
                },
                [$@"{groupPrefixCls}-circle"] = new CSSObject
                {
                    Gap = margin,
                    [$@"{groupPrefixCls}-wrap"] = new CSSObject
                    {
                        Gap = margin,
                    },
                },
                [$@"{groupPrefixCls}-square"] = new CSSObject
                {
                    [$@"{componentCls}-square"] = new CSSObject
                    {
                        Padding = 0,
                        BorderRadius = 0,
                        [$@"{groupPrefixCls}-trigger"] = new CSSObject
                        {
                            BorderRadius = borderRadiusLG,
                        },
                        ["&:first-child"] = new CSSObject
                        {
                            BorderStartStartRadius = borderRadiusLG,
                            BorderStartEndRadius = borderRadiusLG,
                        },
                        ["&:last-child"] = new CSSObject
                        {
                            BorderEndStartRadius = borderRadiusLG,
                            BorderEndEndRadius = borderRadiusLG,
                        },
                        ["&:not(:last-child)"] = new CSSObject
                        {
                            BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                        },
                        [$@"{antCls}-badge"] = new CSSObject
                        {
                            [$@"{antCls}-badge-count"] = new CSSObject
                            {
                                Top = Calc(Calc(floatButtonBodyPadding).Add(badgeOffset)).Mul(-1).Equal(),
                                InsetInlineEnd = Calc(Calc(floatButtonBodyPadding).Add(badgeOffset)).Mul(-1).Equal(),
                            },
                        },
                    },
                    [$@"{groupPrefixCls}-wrap"] = new CSSObject
                    {
                        BorderRadius = borderRadiusLG,
                        BoxShadow = token.BoxShadowSecondary,
                        [$@"{componentCls}-square"] = new CSSObject
                        {
                            BoxShadow = "none",
                            BorderRadius = 0,
                            Padding = floatButtonBodyPadding,
                            [$@"{componentCls}-body"] = new CSSObject
                            {
                                Width = token.FloatButtonBodySize,
                                Height = token.FloatButtonBodySize,
                                BorderRadius = borderRadiusSM,
                            },
                        },
                    },
                },
                [$@"{groupPrefixCls}-top > {groupPrefixCls}-wrap, {groupPrefixCls}-bottom > {groupPrefixCls}-wrap"] = new CSSObject
                {
                    [$@"{componentCls}-square"] = new CSSObject
                    {
                        ["&:first-child"] = new CSSObject
                        {
                            BorderStartStartRadius = borderRadiusLG,
                            BorderStartEndRadius = borderRadiusLG,
                        },
                        ["&:last-child"] = new CSSObject
                        {
                            BorderEndStartRadius = borderRadiusLG,
                            BorderEndEndRadius = borderRadiusLG,
                        },
                        ["&:not(:last-child)"] = new CSSObject
                        {
                            BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                        },
                    },
                },
                [$@"{groupPrefixCls}-left > {groupPrefixCls}-wrap, {groupPrefixCls}-right > {groupPrefixCls}-wrap"] = new CSSObject
                {
                    [$@"{componentCls}-square"] = new CSSObject
                    {
                        ["&:first-child"] = new CSSObject
                        {
                            BorderStartStartRadius = borderRadiusLG,
                            BorderEndStartRadius = borderRadiusLG,
                        },
                        ["&:last-child"] = new CSSObject
                        {
                            BorderStartEndRadius = borderRadiusLG,
                            BorderEndEndRadius = borderRadiusLG,
                        },
                        ["&:not(:last-child)"] = new CSSObject
                        {
                            BorderInlineEnd = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                        },
                    },
                },
                [$@"{groupPrefixCls}-circle-shadow"] = new CSSObject
                {
                    BoxShadow = "none",
                },
                [$@"{groupPrefixCls}-square-shadow"] = new CSSObject
                {
                    BoxShadow = token.BoxShadowSecondary,
                    [$@"{componentCls}-square"] = new CSSObject
                    {
                        BoxShadow = "none",
                        Padding = floatButtonBodyPadding,
                        [$@"{componentCls}-body"] = new CSSObject
                        {
                            Width = token.FloatButtonBodySize,
                            Height = token.FloatButtonBodySize,
                            BorderRadius = borderRadiusSM,
                        },
                    },
                },
            };
        }

        public static CSSObject SharedFloatButtonStyle(FloatButtonToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var floatButtonBodyPadding = token.FloatButtonBodyPadding;
            var floatButtonIconSize = token.FloatButtonIconSize;
            var floatButtonSize = token.FloatButtonSize;
            var borderRadiusLG = token.BorderRadiusLG;
            var badgeOffset = token.BadgeOffset;
            var dotOffsetInSquare = token.DotOffsetInSquare;
            var dotOffsetInCircle = token.DotOffsetInCircle;
            var zIndexPopupBase = token.ZIndexPopupBase;
            var calc = token.Calc;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Border = "none",
                    Position = "fixed",
                    Cursor = "pointer",
                    ZIndex = zIndexPopupBase,
                    Display = "block",
                    Width = floatButtonSize,
                    Height = floatButtonSize,
                    InsetInlineEnd = token.FloatButtonInsetInlineEnd,
                    Bottom = token.FloatButtonInsetBlockEnd,
                    BoxShadow = token.BoxShadowSecondary,
                    ["&-pure"] = new CSSObject
                    {
                        Position = "relative",
                        Inset = "auto",
                    },
                    ["&:empty"] = new CSSObject
                    {
                        Display = "none",
                    },
                    [$@"{antCls}-badge"] = new CSSObject
                    {
                        Width = "100%",
                        Height = "100%",
                        [$@"{antCls}-badge-count"] = new CSSObject
                        {
                            Transform = "translate(0, 0)",
                            TransformOrigin = "center",
                            Top = Calc(badgeOffset).Mul(-1).Equal(),
                            InsetInlineEnd = Calc(badgeOffset).Mul(-1).Equal(),
                        },
                    },
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        Width = "100%",
                        Height = "100%",
                        Display = "flex",
                        JustifyContent = "center",
                        AlignItems = "center",
                        Transition = $@"{token.MotionDurationMid}",
                        [$@"{componentCls}-content"] = new CSSObject
                        {
                            Overflow = "hidden",
                            TextAlign = "center",
                            MinHeight = floatButtonSize,
                            Display = "flex",
                            FlexDirection = "column",
                            JustifyContent = "center",
                            AlignItems = "center",
                            Padding = $@"{Unit(Calc(floatButtonBodyPadding).Div(2).Equal())} {Unit(floatButtonBodyPadding)}",
                            [$@"{componentCls}-icon"] = new CSSObject
                            {
                                TextAlign = "center",
                                Margin = "auto",
                                Width = floatButtonIconSize,
                                FontSize = floatButtonIconSize,
                                LineHeight = 1,
                            },
                        },
                    },
                },
                [$@"{componentCls}-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                },
                [$@"{componentCls}-circle"] = new CSSObject
                {
                    Height = floatButtonSize,
                    BorderRadius = "50%",
                    [$@"{antCls}-badge"] = new CSSObject
                    {
                        [$@"{antCls}-badge-dot"] = new CSSObject
                        {
                            Top = dotOffsetInCircle,
                            InsetInlineEnd = dotOffsetInCircle,
                        },
                    },
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        BorderRadius = "50%",
                    },
                },
                [$@"{componentCls}-square"] = new CSSObject
                {
                    Height = "auto",
                    MinHeight = floatButtonSize,
                    BorderRadius = borderRadiusLG,
                    [$@"{antCls}-badge"] = new CSSObject
                    {
                        [$@"{antCls}-badge-dot"] = new CSSObject
                        {
                            Top = dotOffsetInSquare,
                            InsetInlineEnd = dotOffsetInSquare,
                        },
                    },
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        Height = "auto",
                        BorderRadius = borderRadiusLG,
                    },
                },
                [$@"{componentCls}-default"] = new CSSObject
                {
                    BackgroundColor = token.FloatButtonBackgroundColor,
                    Transition = $@"{token.MotionDurationMid}",
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        BackgroundColor = token.FloatButtonBackgroundColor,
                        Transition = $@"{token.MotionDurationMid}",
                        ["&:hover"] = new CSSObject
                        {
                            BackgroundColor = token.ColorFillContent,
                        },
                        [$@"{componentCls}-content"] = new CSSObject
                        {
                            [$@"{componentCls}-icon"] = new CSSObject
                            {
                                Color = token.ColorText,
                            },
                            [$@"{componentCls}-description"] = new CSSObject
                            {
                                Display = "flex",
                                AlignItems = "center",
                                LineHeight = Unit(token.FontSizeLG),
                                Color = token.ColorText,
                                FontSize = token.FontSizeSM,
                            },
                        },
                    },
                },
                [$@"{componentCls}-primary"] = new CSSObject
                {
                    BackgroundColor = token.ColorPrimary,
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        BackgroundColor = token.ColorPrimary,
                        Transition = $@"{token.MotionDurationMid}",
                        ["&:hover"] = new CSSObject
                        {
                            BackgroundColor = token.ColorPrimaryHover,
                        },
                        [$@"{componentCls}-content"] = new CSSObject
                        {
                            [$@"{componentCls}-icon"] = new CSSObject
                            {
                                Color = token.ColorTextLightSolid,
                            },
                            [$@"{componentCls}-description"] = new CSSObject
                            {
                                Display = "flex",
                                AlignItems = "center",
                                LineHeight = Unit(token.FontSizeLG),
                                Color = token.ColorTextLightSolid,
                                FontSize = token.FontSizeSM,
                            },
                        },
                    },
                },
            };
        }

        public static FloatButtonToken PrepareComponentToken(FloatButtonToken token)
        {
            return new FloatButtonToken
            {
                DotOffsetInCircle = GetOffset(token.ControlHeightLG / 2),
                DotOffsetInSquare = GetOffset(token.BorderRadiusLG),
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("FloatButton", (FloatButtonToken token) =>
            {
                var colorTextLightSolid = token.ColorTextLightSolid;
                var colorBgElevated = token.ColorBgElevated;
                var controlHeightLG = token.ControlHeightLG;
                var marginXXL = token.MarginXXL;
                var marginLG = token.MarginLG;
                var fontSize = token.FontSize;
                var fontSizeIcon = token.FontSizeIcon;
                var controlItemBgHover = token.ControlItemBgHover;
                var paddingXXS = token.PaddingXXS;
                var calc = token.Calc;
                var floatButtonToken = MergeToken(token, new object { FloatButtonBackgroundColor = colorBgElevated, FloatButtonColor = colorTextLightSolid, FloatButtonHoverBackgroundColor = controlItemBgHover, FloatButtonFontSize = fontSize, FloatButtonIconSize = Calc(fontSizeIcon).Mul(1.5).Equal(), FloatButtonSize = controlHeightLG, FloatButtonInsetBlockEnd = marginXXL, FloatButtonInsetInlineEnd = marginLG, FloatButtonBodySize = Calc(controlHeightLG).Sub(Calc(paddingXXS).Mul(2)).Equal(), FloatButtonBodyPadding = paddingXXS, BadgeOffset = Calc(paddingXXS).Mul(1.5).Equal(), });
                return new object[]
                {
                    FloatButtonGroupStyle(floatButtonToken),
                    SharedFloatButtonStyle(floatButtonToken),
                    InitFadeMotion(token),
                    FloatButtonGroupMotion(floatButtonToken)
                };
            }, PrepareComponentToken);
        }
    }
}