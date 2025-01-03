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
    public partial class RadioStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double RadioSize { get; set; }
            public double DotSize { get; set; }
            public string DotColorDisabled { get; set; }
            public string ButtonBg { get; set; }
            public string ButtonCheckedBg { get; set; }
            public string ButtonColor { get; set; }
            public double ButtonPaddingInline { get; set; }
            public string ButtonCheckedBgDisabled { get; set; }
            public string ButtonCheckedColorDisabled { get; set; }
            public string ButtonSolidCheckedColor { get; set; }
            public string ButtonSolidCheckedBg { get; set; }
            public string ButtonSolidCheckedHoverBg { get; set; }
            public string ButtonSolidCheckedActiveBg { get; set; }
            public double WrapperMarginInlineEnd { get; set; }
            public string RadioColor { get; set; }
            public string RadioBgColor { get; set; }
        }

        public class RadioToken : ComponentToken
        {
            public string RadioFocusShadow { get; set; }
            public string RadioButtonFocusShadow { get; set; }
        }

        public static CSSObject GetGroupRadioStyle(RadioToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var groupPrefixCls = $@"{componentCls}-group";
            return new CSSObject
            {
                [groupPrefixCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "inline-block",
                    FontSize = 0,
                    [$@"{groupPrefixCls}-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [$@"{groupPrefixCls}-block"] = new CSSObject
                    {
                        Display = "flex",
                    },
                    [$@"{antCls}-badge {antCls}-badge-count"] = new CSSObject
                    {
                        ZIndex = 1,
                    },
                    [$@"{antCls}-badge:not(:first-child) > {antCls}-button-wrapper"] = new CSSObject
                    {
                        BorderInlineStart = "none",
                    },
                },
            };
        }

        public static CSSObject GetRadioBasicStyle(RadioToken token)
        {
            var componentCls = token.ComponentCls;
            var wrapperMarginInlineEnd = token.WrapperMarginInlineEnd;
            var colorPrimary = token.ColorPrimary;
            var radioSize = token.RadioSize;
            var motionDurationSlow = token.MotionDurationSlow;
            var motionDurationMid = token.MotionDurationMid;
            var motionEaseInOutCirc = token.MotionEaseInOutCirc;
            var colorBgContainer = token.ColorBgContainer;
            var colorBorder = token.ColorBorder;
            var lineWidth = token.LineWidth;
            var colorBgContainerDisabled = token.ColorBgContainerDisabled;
            var colorTextDisabled = token.ColorTextDisabled;
            var paddingXS = token.PaddingXS;
            var dotColorDisabled = token.DotColorDisabled;
            var lineType = token.LineType;
            var radioColor = token.RadioColor;
            var radioBgColor = token.RadioBgColor;
            var calc = token.Calc;
            var radioInnerPrefixCls = $@"{componentCls}-inner";
            var dotPadding = 4;
            var radioDotDisabledSize = Calc(radioSize).Sub(Calc(dotPadding).Mul(2));
            var radioSizeCalc = Calc(1).Mul(radioSize).Equal(new object { Unit = true, });
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "inline-flex",
                    AlignItems = "baseline",
                    MarginInlineStart = 0,
                    MarginInlineEnd = wrapperMarginInlineEnd,
                    Cursor = "pointer",
                    [$@"{componentCls}-wrapper-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    ["&-disabled"] = new CSSObject
                    {
                        Cursor = "not-allowed",
                        Color = token.ColorTextDisabled,
                    },
                    ["&::after"] = new CSSObject
                    {
                        Display = "inline-block",
                        Width = 0,
                        Overflow = "hidden",
                        Content = "\"\\a0\"",
                    },
                    ["&-block"] = new CSSObject
                    {
                        Flex = 1,
                        JustifyContent = "center",
                    },
                    [$@"{componentCls}-checked::after"] = new CSSObject
                    {
                        Position = "absolute",
                        InsetBlockStart = 0,
                        InsetInlineStart = 0,
                        Width = "100%",
                        Height = "100%",
                        Border = $@"{Unit(lineWidth)} {lineType} {colorPrimary}",
                        BorderRadius = "50%",
                        Visibility = "hidden",
                        Opacity = 0,
                        Content = "\"\"",
                    },
                    [componentCls] = new CSSObject
                    {
                        ["..."] = ResetComponent(token),
                        Position = "relative",
                        Display = "inline-block",
                        Outline = "none",
                        Cursor = "pointer",
                        AlignSelf = "center",
                        BorderRadius = "50%",
                    },
                    [$@"{componentCls}-wrapper:hover &,
        &:hover {radioInnerPrefixCls}"] = new CSSObject
                    {
                        BorderColor = colorPrimary,
                    },
                    [$@"{componentCls}-input:focus-visible + {radioInnerPrefixCls}"] = new CSSObject
                    {
                        ["..."] = GenFocusOutline(token),
                    },
                    [$@"{componentCls}:hover::after, {componentCls}-wrapper:hover &::after"] = new CSSObject
                    {
                        Visibility = "visible",
                    },
                    [$@"{componentCls}-inner"] = new CSSObject
                    {
                        ["&::after"] = new CSSObject
                        {
                            BoxSizing = "border-box",
                            Position = "absolute",
                            InsetBlockStart = "50%",
                            InsetInlineStart = "50%",
                            Display = "block",
                            Width = radioSizeCalc,
                            Height = radioSizeCalc,
                            MarginBlockStart = Calc(1).Mul(radioSize).Div(-2).Equal(new object { Unit = true, }),
                            MarginInlineStart = Calc(1).Mul(radioSize).Div(-2).Equal(new object { Unit = true, }),
                            BackgroundColor = radioColor,
                            BorderBlockStart = 0,
                            BorderInlineStart = 0,
                            BorderRadius = radioSizeCalc,
                            Transform = "scale(0)",
                            Opacity = 0,
                            Transition = $@"{motionDurationSlow} {motionEaseInOutCirc}",
                            Content = "\"\"",
                        },
                        BoxSizing = "border-box",
                        Position = "relative",
                        InsetBlockStart = 0,
                        InsetInlineStart = 0,
                        Display = "block",
                        Width = radioSizeCalc,
                        Height = radioSizeCalc,
                        BackgroundColor = colorBgContainer,
                        BorderColor = colorBorder,
                        BorderStyle = "solid",
                        BorderWidth = lineWidth,
                        BorderRadius = "50%",
                        Transition = $@"{motionDurationMid}",
                    },
                    [$@"{componentCls}-input"] = new CSSObject
                    {
                        Position = "absolute",
                        Inset = 0,
                        ZIndex = 1,
                        Cursor = "pointer",
                        Opacity = 0,
                    },
                    [$@"{componentCls}-checked"] = new CSSObject
                    {
                        [radioInnerPrefixCls] = new CSSObject
                        {
                            BorderColor = colorPrimary,
                            BackgroundColor = radioBgColor,
                            ["&::after"] = new CSSObject
                            {
                                Transform = $@"{token.Calc(token.DotSize).Div(radioSize).Equal()})",
                                Opacity = 1,
                                Transition = $@"{motionDurationSlow} {motionEaseInOutCirc}",
                            },
                        },
                    },
                    [$@"{componentCls}-disabled"] = new CSSObject
                    {
                        Cursor = "not-allowed",
                        [radioInnerPrefixCls] = new CSSObject
                        {
                            BackgroundColor = colorBgContainerDisabled,
                            BorderColor = colorBorder,
                            Cursor = "not-allowed",
                            ["&::after"] = new CSSObject
                            {
                                BackgroundColor = dotColorDisabled,
                            },
                        },
                        [$@"{componentCls}-input"] = new CSSObject
                        {
                            Cursor = "not-allowed",
                        },
                        [$@"{componentCls}-disabled + span"] = new CSSObject
                        {
                            Color = colorTextDisabled,
                            Cursor = "not-allowed",
                        },
                        [$@"{componentCls}-checked"] = new CSSObject
                        {
                            [radioInnerPrefixCls] = new CSSObject
                            {
                                ["&::after"] = new CSSObject
                                {
                                    Transform = $@"{Calc(radioDotDisabledSize).Div(radioSize).Equal()})",
                                },
                            },
                        },
                    },
                    [$@"{componentCls} + *"] = new CSSObject
                    {
                        PaddingInlineStart = paddingXS,
                        PaddingInlineEnd = paddingXS,
                    },
                },
            };
        }

        public static CSSObject GetRadioButtonStyle(RadioToken token)
        {
            var buttonColor = token.ButtonColor;
            var controlHeight = token.ControlHeight;
            var componentCls = token.ComponentCls;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var colorBorder = token.ColorBorder;
            var motionDurationSlow = token.MotionDurationSlow;
            var motionDurationMid = token.MotionDurationMid;
            var buttonPaddingInline = token.ButtonPaddingInline;
            var fontSize = token.FontSize;
            var buttonBg = token.ButtonBg;
            var fontSizeLG = token.FontSizeLG;
            var controlHeightLG = token.ControlHeightLG;
            var controlHeightSM = token.ControlHeightSM;
            var paddingXS = token.PaddingXS;
            var borderRadius = token.BorderRadius;
            var borderRadiusSM = token.BorderRadiusSM;
            var borderRadiusLG = token.BorderRadiusLG;
            var buttonCheckedBg = token.ButtonCheckedBg;
            var buttonSolidCheckedColor = token.ButtonSolidCheckedColor;
            var colorTextDisabled = token.ColorTextDisabled;
            var colorBgContainerDisabled = token.ColorBgContainerDisabled;
            var buttonCheckedBgDisabled = token.ButtonCheckedBgDisabled;
            var buttonCheckedColorDisabled = token.ButtonCheckedColorDisabled;
            var colorPrimary = token.ColorPrimary;
            var colorPrimaryHover = token.ColorPrimaryHover;
            var colorPrimaryActive = token.ColorPrimaryActive;
            var buttonSolidCheckedBg = token.ButtonSolidCheckedBg;
            var buttonSolidCheckedHoverBg = token.ButtonSolidCheckedHoverBg;
            var buttonSolidCheckedActiveBg = token.ButtonSolidCheckedActiveBg;
            var calc = token.Calc;
            return new CSSObject
            {
                [$@"{componentCls}-button-wrapper"] = new CSSObject
                {
                    Position = "relative",
                    Display = "inline-block",
                    Height = controlHeight,
                    Margin = 0,
                    PaddingInline = buttonPaddingInline,
                    PaddingBlock = 0,
                    Color = buttonColor,
                    LineHeight = Unit(Calc(controlHeight).Sub(Calc(lineWidth).Mul(2)).Equal()),
                    Background = buttonBg,
                    Border = $@"{Unit(lineWidth)} {lineType} {colorBorder}",
                    BorderBlockStartWidth = Calc(lineWidth).Add(0.02).Equal(),
                    BorderInlineStartWidth = 0,
                    BorderInlineEndWidth = lineWidth,
                    Cursor = "pointer",
                    Transition = new object[]
                    {
                        $@"{motionDurationMid}",
                        $@"{motionDurationMid}",
                        $@"{motionDurationMid}"
                    }.Join(","),
                    ["a"] = new CSSObject
                    {
                        Color = buttonColor,
                    },
                    [$@"{componentCls}-button"] = new CSSObject
                    {
                        Position = "absolute",
                        InsetBlockStart = 0,
                        InsetInlineStart = 0,
                        ZIndex = -1,
                        Width = "100%",
                        Height = "100%",
                    },
                    ["&:not(:first-child)"] = new CSSObject
                    {
                        ["&::before"] = new CSSObject
                        {
                            Position = "absolute",
                            InsetBlockStart = Calc(lineWidth).Mul(-1).Equal(),
                            InsetInlineStart = Calc(lineWidth).Mul(-1).Equal(),
                            Display = "block",
                            BoxSizing = "content-box",
                            Width = 1,
                            Height = "100%",
                            PaddingBlock = lineWidth,
                            PaddingInline = 0,
                            BackgroundColor = colorBorder,
                            Transition = $@"{motionDurationSlow}",
                            Content = "\"\"",
                        },
                    },
                    ["&:first-child"] = new CSSObject
                    {
                        BorderInlineStart = $@"{Unit(lineWidth)} {lineType} {colorBorder}",
                        BorderStartStartRadius = borderRadius,
                        BorderEndStartRadius = borderRadius,
                    },
                    ["&:last-child"] = new CSSObject
                    {
                        BorderStartEndRadius = borderRadius,
                        BorderEndEndRadius = borderRadius,
                    },
                    ["&:first-child:last-child"] = new CSSObject
                    {
                    },
                    [$@"{componentCls}-group-large &"] = new CSSObject
                    {
                        Height = controlHeightLG,
                        FontSize = fontSizeLG,
                        LineHeight = Unit(Calc(controlHeightLG).Sub(Calc(lineWidth).Mul(2)).Equal()),
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
                    },
                    [$@"{componentCls}-group-small &"] = new CSSObject
                    {
                        Height = controlHeightSM,
                        PaddingInline = Calc(paddingXS).Sub(lineWidth).Equal(),
                        PaddingBlock = 0,
                        LineHeight = Unit(Calc(controlHeightSM).Sub(Calc(lineWidth).Mul(2)).Equal()),
                        ["&:first-child"] = new CSSObject
                        {
                            BorderStartStartRadius = borderRadiusSM,
                            BorderEndStartRadius = borderRadiusSM,
                        },
                        ["&:last-child"] = new CSSObject
                        {
                            BorderStartEndRadius = borderRadiusSM,
                            BorderEndEndRadius = borderRadiusSM,
                        },
                    },
                    ["&:hover"] = new CSSObject
                    {
                        Position = "relative",
                        Color = colorPrimary,
                    },
                    ["&:has(:focus-visible)"] = new CSSObject
                    {
                        ["..."] = GenFocusOutline(token),
                    },
                    [$@"{componentCls}-inner, input[type='checkbox'], input[type='radio']"] = new CSSObject
                    {
                        Width = 0,
                        Height = 0,
                        Opacity = 0,
                        PointerEvents = "none",
                    },
                    [$@"{componentCls}-button-wrapper-disabled)"] = new CSSObject
                    {
                        ZIndex = 1,
                        Color = colorPrimary,
                        Background = buttonCheckedBg,
                        BorderColor = colorPrimary,
                        ["&::before"] = new CSSObject
                        {
                            BackgroundColor = colorPrimary,
                        },
                        ["&:first-child"] = new CSSObject
                        {
                            BorderColor = colorPrimary,
                        },
                        ["&:hover"] = new CSSObject
                        {
                            Color = colorPrimaryHover,
                            BorderColor = colorPrimaryHover,
                            ["&::before"] = new CSSObject
                            {
                                BackgroundColor = colorPrimaryHover,
                            },
                        },
                        ["&:active"] = new CSSObject
                        {
                            Color = colorPrimaryActive,
                            BorderColor = colorPrimaryActive,
                            ["&::before"] = new CSSObject
                            {
                                BackgroundColor = colorPrimaryActive,
                            },
                        },
                    },
                    [$@"{componentCls}-group-solid &-checked:not({componentCls}-button-wrapper-disabled)"] = new CSSObject
                    {
                        Color = buttonSolidCheckedColor,
                        Background = buttonSolidCheckedBg,
                        BorderColor = buttonSolidCheckedBg,
                        ["&:hover"] = new CSSObject
                        {
                            Color = buttonSolidCheckedColor,
                            Background = buttonSolidCheckedHoverBg,
                            BorderColor = buttonSolidCheckedHoverBg,
                        },
                        ["&:active"] = new CSSObject
                        {
                            Color = buttonSolidCheckedColor,
                            Background = buttonSolidCheckedActiveBg,
                            BorderColor = buttonSolidCheckedActiveBg,
                        },
                    },
                    ["&-disabled"] = new CSSObject
                    {
                        Color = colorTextDisabled,
                        BackgroundColor = colorBgContainerDisabled,
                        BorderColor = colorBorder,
                        Cursor = "not-allowed",
                        ["&:first-child, &:hover"] = new CSSObject
                        {
                            Color = colorTextDisabled,
                            BackgroundColor = colorBgContainerDisabled,
                            BorderColor = colorBorder,
                        },
                    },
                    [$@"{componentCls}-button-wrapper-checked"] = new CSSObject
                    {
                        Color = buttonCheckedColorDisabled,
                        BackgroundColor = buttonCheckedBgDisabled,
                        BorderColor = colorBorder,
                        BoxShadow = "none",
                    },
                    ["&-block"] = new CSSObject
                    {
                        Flex = 1,
                        TextAlign = "center",
                    },
                },
            };
        }

        public static RadioToken PrepareComponentToken(RadioToken token)
        {
            var wireframe = token.Wireframe;
            var padding = token.Padding;
            var marginXS = token.MarginXS;
            var lineWidth = token.LineWidth;
            var fontSizeLG = token.FontSizeLG;
            var colorText = token.ColorText;
            var colorBgContainer = token.ColorBgContainer;
            var colorTextDisabled = token.ColorTextDisabled;
            var controlItemBgActiveDisabled = token.ControlItemBgActiveDisabled;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var colorPrimary = token.ColorPrimary;
            var colorPrimaryHover = token.ColorPrimaryHover;
            var colorPrimaryActive = token.ColorPrimaryActive;
            var colorWhite = token.ColorWhite;
            var dotPadding = 4;
            var radioSize = fontSizeLG;
            var radioDotSize = wireframe ? radioSize - dotPadding * 2 : radioSize - (dotPadding + lineWidth) * 2;
            return new RadioToken
            {
                DotSize = radioDotSize,
                DotColorDisabled = colorTextDisabled,
                ButtonSolidCheckedColor = colorTextLightSolid,
                ButtonSolidCheckedBg = colorPrimary,
                ButtonSolidCheckedHoverBg = colorPrimaryHover,
                ButtonSolidCheckedActiveBg = colorPrimaryActive,
                ButtonBg = colorBgContainer,
                ButtonCheckedBg = colorBgContainer,
                ButtonColor = colorText,
                ButtonCheckedBgDisabled = controlItemBgActiveDisabled,
                ButtonCheckedColorDisabled = colorTextDisabled,
                ButtonPaddingInline = padding - lineWidth,
                WrapperMarginInlineEnd = marginXS,
                RadioColor = wireframe ? colorPrimary : colorWhite,
                RadioBgColor = wireframe ? colorBgContainer : colorPrimary,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Radio", (RadioToken token) =>
            {
                var controlOutline = token.ControlOutline;
                var controlOutlineWidth = token.ControlOutlineWidth;
                var radioFocusShadow = $@"{Unit(controlOutlineWidth)} {controlOutline}";
                var radioButtonFocusShadow = radioFocusShadow;
                var radioToken = MergeToken(token, new object { });
                return new object[]
                {
                    GetGroupRadioStyle(radioToken),
                    GetRadioBasicStyle(radioToken),
                    GetRadioButtonStyle(radioToken)
                };
            }, PrepareComponentToken, new object { Unitless = new object { RadioSize = true, DotSize = true, }, });
        }
    }
}