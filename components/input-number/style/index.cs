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
    public partial class InputNumberStyle
    {
        public static CSSObject GenRadiusStyle(InputNumberToken { componentCls, borderRadiusSM, borderRadiusLG },  'lg' | 'sm'  size)
        {
            var borderRadius = size == "lg" ? borderRadiusLG : borderRadiusSM;
            return new CSSObject
            {
                [$@"{size}"] = new CSSObject
                {
                    [$@"{componentCls}-handler-wrap"] = new CSSObject
                    {
                        BorderStartEndRadius = borderRadius,
                        BorderEndEndRadius = borderRadius,
                    },
                    [$@"{componentCls}-handler-up"] = new CSSObject
                    {
                        BorderStartEndRadius = borderRadius,
                    },
                    [$@"{componentCls}-handler-down"] = new CSSObject
                    {
                        BorderEndEndRadius = borderRadius,
                    },
                },
            };
        }

        public static object GenInputNumberStyles(InputNumberToken token)
        {
            var componentCls = token.ComponentCls;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var borderRadius = token.BorderRadius;
            var inputFontSizeSM = token.InputFontSizeSM;
            var inputFontSizeLG = token.InputFontSizeLG;
            var controlHeightLG = token.ControlHeightLG;
            var controlHeightSM = token.ControlHeightSM;
            var colorError = token.ColorError;
            var paddingInlineSM = token.PaddingInlineSM;
            var paddingBlockSM = token.PaddingBlockSM;
            var paddingBlockLG = token.PaddingBlockLG;
            var paddingInlineLG = token.PaddingInlineLG;
            var colorTextDescription = token.ColorTextDescription;
            var motionDurationMid = token.MotionDurationMid;
            var handleHoverColor = token.HandleHoverColor;
            var handleOpacity = token.HandleOpacity;
            var paddingInline = token.PaddingInline;
            var paddingBlock = token.PaddingBlock;
            var handleBg = token.HandleBg;
            var handleActiveBg = token.HandleActiveBg;
            var colorTextDisabled = token.ColorTextDisabled;
            var borderRadiusSM = token.BorderRadiusSM;
            var borderRadiusLG = token.BorderRadiusLG;
            var controlWidth = token.ControlWidth;
            var handleBorderColor = token.HandleBorderColor;
            var filledHandleBg = token.FilledHandleBg;
            var lineHeightLG = token.LineHeightLG;
            var calc = token.Calc;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        ["..."] = GenBasicInputStyle(token),
                        Display = "inline-block",
                        Width = controlWidth,
                        Margin = 0,
                        Padding = 0,
                        ["..."] = GenOutlinedStyle(token, new object { [$@"{componentCls}-handler-wrap"] = new object { Background = handleBg, [$@"{componentCls}-handler-down"] = new object { BorderBlockStart = $@"{Unit(lineWidth)} {lineType} {handleBorderColor}", }, }, }),
                        ["..."] = GenFilledStyle(token, new object { [$@"{componentCls}-handler-wrap"] = new object { Background = filledHandleBg, [$@"{componentCls}-handler-down"] = new object { BorderBlockStart = $@"{Unit(lineWidth)} {lineType} {handleBorderColor}", }, }, ["&:focus-within"] = new object { [$@"{componentCls}-handler-wrap"] = new object { Background = handleBg, }, }, }),
                        ["..."] = GenBorderlessStyle(token),
                        ["&-rtl"] = new object
                        {
                            Direction = "rtl",
                            [$@"{componentCls}-input"] = new object
                            {
                                Direction = "rtl",
                            },
                        },
                        ["&-lg"] = new object
                        {
                            Padding = 0,
                            FontSize = inputFontSizeLG,
                            LineHeight = lineHeightLG,
                            BorderRadius = borderRadiusLG,
                            [$@"{componentCls}-input"] = new object
                            {
                                Height = Calc(controlHeightLG).Sub(Calc(lineWidth).Mul(2)).Equal(),
                                Padding = $@"{Unit(paddingBlockLG)} {Unit(paddingInlineLG)}",
                            },
                        },
                        ["&-sm"] = new object
                        {
                            Padding = 0,
                            FontSize = inputFontSizeSM,
                            BorderRadius = borderRadiusSM,
                            [$@"{componentCls}-input"] = new object
                            {
                                Height = Calc(controlHeightSM).Sub(Calc(lineWidth).Mul(2)).Equal(),
                                Padding = $@"{Unit(paddingBlockSM)} {Unit(paddingInlineSM)}",
                            },
                        },
                        ["&-out-of-range"] = new object
                        {
                            [$@"{componentCls}-input-wrap"] = new object
                            {
                                ["input"] = new object
                                {
                                    Color = colorError,
                                },
                            },
                        },
                        ["&-group"] = new object
                        {
                            ["..."] = ResetComponent(token),
                            ["..."] = GenInputGroupStyle(token),
                            ["&-wrapper"] = new object
                            {
                                Display = "inline-block",
                                TextAlign = "start",
                                VerticalAlign = "top",
                                [$@"{componentCls}-affix-wrapper"] = new object
                                {
                                    Width = "100%",
                                },
                                ["&-lg"] = new object
                                {
                                    [$@"{componentCls}-group-addon"] = new object
                                    {
                                        BorderRadius = borderRadiusLG,
                                        FontSize = token.FontSizeLG,
                                    },
                                },
                                ["&-sm"] = new object
                                {
                                    [$@"{componentCls}-group-addon"] = new object
                                    {
                                        BorderRadius = borderRadiusSM,
                                    },
                                },
                                ["..."] = GenOutlinedGroupStyle(token),
                                ["..."] = GenFilledGroupStyle(token),
                                [$@"{componentCls}-compact-first-item):not({componentCls}-compact-last-item){componentCls}-compact-item"] = new object
                                {
                                    [$@"{componentCls}, {componentCls}-group-addon"] = new object
                                    {
                                        BorderRadius = 0,
                                    },
                                },
                                [$@"{componentCls}-compact-last-item){componentCls}-compact-first-item"] = new object
                                {
                                    [$@"{componentCls}, {componentCls}-group-addon"] = new object
                                    {
                                        BorderStartEndRadius = 0,
                                        BorderEndEndRadius = 0,
                                    },
                                },
                                [$@"{componentCls}-compact-first-item){componentCls}-compact-last-item"] = new object
                                {
                                    [$@"{componentCls}, {componentCls}-group-addon"] = new object
                                    {
                                        BorderStartStartRadius = 0,
                                        BorderEndStartRadius = 0,
                                    },
                                },
                            },
                        },
                        [$@"{componentCls}-input"] = new object
                        {
                            Cursor = "not-allowed",
                        },
                        [componentCls] = new object
                        {
                            ["&-input"] = new object
                            {
                                ["..."] = ResetComponent(token),
                                Width = "100%",
                                Padding = $@"{Unit(paddingBlock)} {Unit(paddingInline)}",
                                TextAlign = "start",
                                BackgroundColor = "transparent",
                                Border = 0,
                                Outline = 0,
                                Transition = $@"{motionDurationMid} linear",
                                Appearance = "textfield",
                                FontSize = "inherit",
                                ["..."] = GenPlaceholderStyle(token.ColorTextPlaceholder),
                                ["&[type=\"number\"]::-webkit-inner-spin-button, &[type=\"number\"]::-webkit-outer-spin-button"] = new object
                                {
                                    Margin = 0,
                                    WebkitAppearance = "none",
                                    Appearance = "none",
                                },
                            },
                        },
                        [$@"{componentCls}-handler-wrap, &-focused {componentCls}-handler-wrap"] = new object
                        {
                            Width = token.HandleWidth,
                            Opacity = 1,
                        },
                    },
                },
                new object
                {
                    [componentCls] = new object
                    {
                        [$@"{componentCls}-handler-wrap"] = new object
                        {
                            Position = "absolute",
                            InsetBlockStart = 0,
                            InsetInlineEnd = 0,
                            Width = token.HandleVisibleWidth,
                            Opacity = handleOpacity,
                            Height = "100%",
                            BorderStartStartRadius = 0,
                            BorderStartEndRadius = borderRadius,
                            BorderEndEndRadius = borderRadius,
                            BorderEndStartRadius = 0,
                            Display = "flex",
                            FlexDirection = "column",
                            AlignItems = "stretch",
                            Transition = $@"{motionDurationMid}",
                            Overflow = "hidden",
                            [$@"{componentCls}-handler"] = new object
                            {
                                Display = "flex",
                                AlignItems = "center",
                                JustifyContent = "center",
                                Flex = "auto",
                                Height = "40%",
                                [$@"{componentCls}-handler-up-inner,
              {componentCls}-handler-down-inner
            "] = new object
                                {
                                    MarginInlineEnd = 0,
                                    FontSize = token.HandleFontSize,
                                },
                            },
                        },
                        [$@"{componentCls}-handler"] = new object
                        {
                            Height = "50%",
                            Overflow = "hidden",
                            Color = colorTextDescription,
                            FontWeight = "bold",
                            LineHeight = 0,
                            TextAlign = "center",
                            Cursor = "pointer",
                            BorderInlineStart = $@"{Unit(lineWidth)} {lineType} {handleBorderColor}",
                            Transition = $@"{motionDurationMid} linear",
                            ["&:active"] = new object
                            {
                                Background = handleActiveBg,
                            },
                            ["&:hover"] = new object
                            {
                                Height = "60%",
                                [$@"{componentCls}-handler-up-inner,
              {componentCls}-handler-down-inner
            "] = new object
                                {
                                    Color = handleHoverColor,
                                },
                            },
                            ["&-up-inner, &-down-inner"] = new object
                            {
                                ["..."] = ResetIcon(),
                                Color = colorTextDescription,
                                Transition = $@"{motionDurationMid} linear",
                                UserSelect = "none",
                            },
                        },
                        [$@"{componentCls}-handler-up"] = new object
                        {
                            BorderStartEndRadius = borderRadius,
                        },
                        [$@"{componentCls}-handler-down"] = new object
                        {
                            BorderEndEndRadius = borderRadius,
                        },
                        ["..."] = GenRadiusStyle(token, "lg"),
                        ["..."] = GenRadiusStyle(token, "sm"),
                        ["&-disabled, &-readonly"] = new object
                        {
                            [$@"{componentCls}-handler-wrap"] = new object
                            {
                                Display = "none",
                            },
                            [$@"{componentCls}-input"] = new object
                            {
                                Color = "inherit",
                            },
                        },
                        [$@"{componentCls}-handler-up-disabled,
          {componentCls}-handler-down-disabled
        "] = new object
                        {
                            Cursor = "not-allowed",
                        },
                        [$@"{componentCls}-handler-up-disabled:hover &-handler-up-inner,
          {componentCls}-handler-down-disabled:hover &-handler-down-inner
        "] = new object
                        {
                            Color = colorTextDisabled,
                        },
                    },
                }
            };
        }

        public static object GenAffixWrapperStyles(InputNumberToken token)
        {
            var componentCls = token.ComponentCls;
            var paddingBlock = token.PaddingBlock;
            var paddingInline = token.PaddingInline;
            var inputAffixPadding = token.InputAffixPadding;
            var controlWidth = token.ControlWidth;
            var borderRadiusLG = token.BorderRadiusLG;
            var borderRadiusSM = token.BorderRadiusSM;
            var paddingInlineLG = token.PaddingInlineLG;
            var paddingInlineSM = token.PaddingInlineSM;
            var paddingBlockLG = token.PaddingBlockLG;
            var paddingBlockSM = token.PaddingBlockSM;
            var motionDurationMid = token.MotionDurationMid;
            return new object
            {
                [$@"{componentCls}-affix-wrapper"] = new object
                {
                    [$@"{componentCls}-input"] = new object
                    {
                        Padding = $@"{Unit(paddingBlock)} 0",
                    },
                    ["..."] = GenBasicInputStyle(token),
                    Position = "relative",
                    Display = "inline-flex",
                    AlignItems = "center",
                    Width = controlWidth,
                    Padding = 0,
                    PaddingInlineStart = paddingInline,
                    ["&-lg"] = new object
                    {
                        BorderRadius = borderRadiusLG,
                        PaddingInlineStart = paddingInlineLG,
                        [$@"{componentCls}-input"] = new object
                        {
                            Padding = $@"{Unit(paddingBlockLG)} 0",
                        },
                    },
                    ["&-sm"] = new object
                    {
                        BorderRadius = borderRadiusSM,
                        PaddingInlineStart = paddingInlineSM,
                        [$@"{componentCls}-input"] = new object
                        {
                            Padding = $@"{Unit(paddingBlockSM)} 0",
                        },
                    },
                    [$@"{componentCls}-disabled):hover"] = new object
                    {
                        ZIndex = 1,
                    },
                    ["&-focused, &:focus"] = new object
                    {
                        ZIndex = 1,
                    },
                    [$@"{componentCls}-disabled"] = new object
                    {
                        Background = "transparent",
                    },
                    [$@"{componentCls}"] = new object
                    {
                        Width = "100%",
                        Border = "none",
                        Outline = "none",
                        [$@"{componentCls}-focused"] = new object
                        {
                            BoxShadow = "none !important",
                        },
                    },
                    ["&::before"] = new object
                    {
                        Display = "inline-block",
                        Width = 0,
                        Visibility = "hidden",
                        Content = "\"\\a0\"",
                    },
                    [$@"{componentCls}-handler-wrap"] = new object
                    {
                        ZIndex = 2,
                    },
                    [componentCls] = new object
                    {
                        Position = "static",
                        Color = "inherit",
                        ["&-prefix, &-suffix"] = new object
                        {
                            Display = "flex",
                            Flex = "none",
                            AlignItems = "center",
                            PointerEvents = "none",
                        },
                        ["&-prefix"] = new object
                        {
                            MarginInlineEnd = inputAffixPadding,
                        },
                        ["&-suffix"] = new object
                        {
                            InsetBlockStart = 0,
                            InsetInlineEnd = 0,
                            Height = "100%",
                            MarginInlineEnd = paddingInline,
                            MarginInlineStart = inputAffixPadding,
                            Transition = $@"{motionDurationMid}",
                        },
                    },
                    [$@"{componentCls}-handler-wrap, &-focused {componentCls}-handler-wrap"] = new object
                    {
                        Width = token.HandleWidth,
                        Opacity = 1,
                    },
                    [$@"{componentCls}-affix-wrapper-without-controls):hover {componentCls}-suffix"] = new object
                    {
                        MarginInlineEnd = token.Calc(token.HandleWidth).Add(paddingInline).Equal(),
                    },
                },
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("InputNumber", (InputNumberToken token) =>
            {
                var inputNumberToken = MergeToken(token, InitInputToken(token));
                return new object[]
                {
                    GenInputNumberStyles(inputNumberToken),
                    GenAffixWrapperStyles(inputNumberToken),
                    GenCompactItemStyle(inputNumberToken)
                };
            }, PrepareComponentToken, new object { Unitless = new object { HandleOpacity = true, }, });
        }
    }
}