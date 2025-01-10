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
    public partial class ButtonStyle
    {
        public static CSSObject GenSharedButtonStyle(ButtonToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var fontWeight = token.FontWeight;
            var opacityLoading = token.OpacityLoading;
            var motionDurationSlow = token.MotionDurationSlow;
            var motionEaseInOut = token.MotionEaseInOut;
            var marginXS = token.MarginXS;
            var calc = token.Calc;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Outline = "none",
                    Position = "relative",
                    Display = "inline-flex",
                    Gap = token.MarginXS,
                    AlignItems = "center",
                    JustifyContent = "center",
                    WhiteSpace = "nowrap",
                    TextAlign = "center",
                    BackgroundImage = "none",
                    Background = "transparent",
                    Border = $@"{Unit(token.LineWidth)} {token.LineType} transparent",
                    Cursor = "pointer",
                    Transition = $@"{token.MotionDurationMid} {token.MotionEaseInOut}",
                    UserSelect = "none",
                    TouchAction = "manipulation",
                    Color = token.ColorText,
                    ["&:disabled > *"] = new CSSObject
                    {
                        PointerEvents = "none",
                    },
                    [$@"{componentCls}-icon > svg"] = ResetIcon(),
                    ["> a"] = new CSSObject
                    {
                        Color = "currentColor",
                    },
                    ["&:not(:disabled)"] = GenFocusStyle(token),
                    [$@"{componentCls}-two-chinese-chars::first-letter"] = new CSSObject
                    {
                        LetterSpacing = "0.34em",
                    },
                    [$@"{componentCls}-two-chinese-chars > *:not({iconCls})"] = new CSSObject
                    {
                        MarginInlineEnd = "-0.34em",
                        LetterSpacing = "0.34em",
                    },
                    [$@"{componentCls}-icon-only"] = new CSSObject
                    {
                        PaddingInline = 0,
                        [$@"{componentCls}-compact-item"] = new CSSObject
                        {
                            Flex = "none",
                        },
                        [$@"{componentCls}-round"] = new CSSObject
                        {
                            Width = "auto",
                        },
                    },
                    [$@"{componentCls}-loading"] = new CSSObject
                    {
                        Opacity = opacityLoading,
                        Cursor = "default",
                    },
                    [$@"{componentCls}-loading-icon"] = new CSSObject
                    {
                        Transition = new object[]
                        {
                            "width",
                            "opacity",
                            "margin"
                        }.Map((object transition) =>
                        {
                            return $@"{transition} {motionDurationSlow} {motionEaseInOut}";
                        }).Join(","),
                    },
                    [$@"{componentCls}-icon-end)"] = new CSSObject
                    {
                        [$@"{componentCls}-loading-icon-motion"] = new CSSObject
                        {
                            ["&-appear-start, &-enter-start"] = new CSSObject
                            {
                                MarginInlineEnd = Calc(marginXS).Mul(-1).Equal(),
                            },
                            ["&-appear-active, &-enter-active"] = new CSSObject
                            {
                                MarginInlineEnd = 0,
                            },
                            ["&-leave-start"] = new CSSObject
                            {
                                MarginInlineEnd = 0,
                            },
                            ["&-leave-active"] = new CSSObject
                            {
                                MarginInlineEnd = Calc(marginXS).Mul(-1).Equal(),
                            },
                        },
                    },
                    ["&-icon-end"] = new CSSObject
                    {
                        FlexDirection = "row-reverse",
                        [$@"{componentCls}-loading-icon-motion"] = new CSSObject
                        {
                            ["&-appear-start, &-enter-start"] = new CSSObject
                            {
                                MarginInlineStart = Calc(marginXS).Mul(-1).Equal(),
                            },
                            ["&-appear-active, &-enter-active"] = new CSSObject
                            {
                                MarginInlineStart = 0,
                            },
                            ["&-leave-start"] = new CSSObject
                            {
                                MarginInlineStart = 0,
                            },
                            ["&-leave-active"] = new CSSObject
                            {
                                MarginInlineStart = Calc(marginXS).Mul(-1).Equal(),
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenHoverActiveButtonStyle(string btnCls, CSSObject hoverStyle, CSSObject activeStyle)
        {
            return new CSSObject
            {
                [$@"{btnCls}-disabled)"] = new CSSObject
                {
                    ["&:hover"] = hoverStyle,
                    ["&:active"] = activeStyle,
                },
            };
        }

        public static CSSObject GenCircleButtonStyle(ButtonToken token)
        {
            return new CSSObject
            {
                MinWidth = token.ControlHeight,
                PaddingInlineStart = 0,
                PaddingInlineEnd = 0,
                BorderRadius = "50%",
            };
        }

        public static CSSObject GenRoundButtonStyle(ButtonToken token)
        {
            return new CSSObject
            {
                BorderRadius = token.ControlHeight,
                PaddingInlineStart = token.Calc(token.ControlHeight).Div(2).Equal(),
                PaddingInlineEnd = token.Calc(token.ControlHeight).Div(2).Equal(),
            };
        }

        public static CSSObject GenDisabledStyle(ButtonToken token)
        {
            return new CSSObject
            {
                Cursor = "not-allowed",
                BorderColor = token.BorderColorDisabled,
                Color = token.ColorTextDisabled,
                Background = token.ColorBgContainerDisabled,
                BoxShadow = "none",
            };
        }

        public static CSSObject GenGhostButtonStyle(string btnCls, string background, string | false  textColor, string | false  borderColor, string | false  textColorDisabled, string | false  borderColorDisabled, CSSObject hoverStyle, CSSObject activeStyle)
        {
            return new CSSObject
            {
                [$@"{btnCls}-background-ghost"] = new CSSObject
                {
                    Color = textColor ?? undefined,
                    BorderColor = borderColor ?? undefined,
                    BoxShadow = "none",
                    ["..."] = GenHoverActiveButtonStyle(btnCls, new object { ["..."] = hoverStyle, }, new object { ["..."] = activeStyle, }),
                    ["&:disabled"] = new CSSObject
                    {
                        Cursor = "not-allowed",
                        Color = textColorDisabled ?? undefined,
                        BorderColor = borderColorDisabled ?? undefined,
                    },
                },
            };
        }

        public static CSSObject GenSolidDisabledButtonStyle(ButtonToken token)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-disabled"] = new CSSObject
                {
                    ["..."] = GenDisabledStyle(token),
                },
            };
        }

        public static CSSObject GenPureDisabledButtonStyle(ButtonToken token)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-disabled"] = new CSSObject
                {
                    Cursor = "not-allowed",
                    Color = token.ColorTextDisabled,
                },
            };
        }

        public static CSSObject GenVariantButtonStyle(ButtonToken token, CSSObject hoverStyle, CSSObject activeStyle, ButtonVariantType variant)
        {
            var isPureDisabled = variant && new object[]
            {
                "link",
                "text"
            }.Includes(variant);
            var genDisabledButtonStyle = isPureDisabled ? GenPureDisabledButtonStyle : GenSolidDisabledButtonStyle;
            return new CSSObject
            {
                ["..."] = GenDisabledButtonStyle(token),
                ["..."] = GenHoverActiveButtonStyle(token.ComponentCls, hoverStyle, activeStyle),
            };
        }

        public static CSSObject GenSolidButtonStyle(ButtonToken token, string textColor, string background, CSSObject hoverStyle, CSSObject activeStyle)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-variant-solid"] = new CSSObject
                {
                    Color = textColor,
                    ["..."] = GenVariantButtonStyle(token, hoverStyle, activeStyle),
                },
            };
        }

        public static CSSObject GenOutlinedDashedButtonStyle(ButtonToken token, string borderColor, string background, CSSObject hoverStyle, CSSObject activeStyle)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-variant-outlined, &{token.ComponentCls}-variant-dashed"] = new CSSObject
                {
                    ["..."] = GenVariantButtonStyle(token, hoverStyle, activeStyle),
                },
            };
        }

        public static CSSObject GenDashedButtonStyle(ButtonToken token)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-variant-dashed"] = new CSSObject
                {
                    BorderStyle = "dashed",
                },
            };
        }

        public static CSSObject GenFilledButtonStyle(ButtonToken token, string background, CSSObject hoverStyle, CSSObject activeStyle)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-variant-filled"] = new CSSObject
                {
                    BoxShadow = "none",
                    ["..."] = GenVariantButtonStyle(token, hoverStyle, activeStyle),
                },
            };
        }

        public static CSSObject GenTextLinkButtonStyle(ButtonToken token, string textColor,  'text' | 'link'  variant, CSSObject hoverStyle, CSSObject activeStyle)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-variant-{variant}"] = new CSSObject
                {
                    Color = textColor,
                    BoxShadow = "none",
                    ["..."] = GenVariantButtonStyle(token, hoverStyle, activeStyle, variant),
                },
            };
        }

        public static CSSObject GenPresetColorStyle(ButtonToken token)
        {
            var componentCls = token.ComponentCls;
            return PresetColors.Reduce((CSSObject prev, PresetColorKey colorKey) =>
            {
                var darkColor = token[$@"{colorKey}6"];
                var lightColor = token[$@"{colorKey}1"];
                var hoverColor = token[$@"{colorKey}5"];
                var lightHoverColor = token[$@"{colorKey}2"];
                var lightBorderColor = token[$@"{colorKey}3"];
                var activeColor = token[$@"{colorKey}7"];
                var boxShadow = $@"{token.ControlOutlineWidth} 0 {token[$@"{colorKey}1"]}";
                return new object
                {
                    ["..."] = prev,
                    [$@"{componentCls}-color-{colorKey}"] = new object
                    {
                        Color = darkColor,
                        ["..."] = GenSolidButtonStyle(token, token.ColorTextLightSolid, darkColor, new object { Background = hoverColor, }, new object { Background = activeColor, }),
                        ["..."] = GenOutlinedDashedButtonStyle(token, darkColor, token.ColorBgContainer, new object { Color = hoverColor, BorderColor = hoverColor, Background = token.ColorBgContainer, }, new object { Color = activeColor, BorderColor = activeColor, Background = token.ColorBgContainer, }),
                        ["..."] = GenDashedButtonStyle(token),
                        ["..."] = GenFilledButtonStyle(token, lightColor, new object { Background = lightHoverColor, }, new object { Background = lightBorderColor, }),
                        ["..."] = GenTextLinkButtonStyle(token, darkColor, "link", new object { Color = hoverColor, }, new object { Color = activeColor, }),
                        ["..."] = GenTextLinkButtonStyle(token, darkColor, "text", new object { Color = hoverColor, Background = lightColor, }, new object { Color = activeColor, Background = lightBorderColor, }),
                    },
                };
            }, new object { });
        }

        public static CSSObject GenDefaultButtonStyle(ButtonToken token)
        {
            return new CSSObject
            {
                Color = token.DefaultColor,
                BoxShadow = token.DefaultShadow,
                ["..."] = GenSolidButtonStyle(token, token.SolidTextColor, token.ColorBgSolid, new object { Color = token.SolidTextColor, Background = token.ColorBgSolidHover, }, new object { Color = token.SolidTextColor, Background = token.ColorBgSolidActive, }),
                ["..."] = GenDashedButtonStyle(token),
                ["..."] = GenFilledButtonStyle(token, token.ColorFillTertiary, new object { Background = token.ColorFillSecondary, }, new object { Background = token.ColorFill, }),
                ["..."] = GenTextLinkButtonStyle(token, token.TextTextColor, "link", new object { Color = token.ColorLinkHover, Background = token.LinkHoverBg, }, new object { Color = token.ColorLinkActive, }),
                ["..."] = GenGhostButtonStyle(token.ComponentCls, token.GhostBg, token.DefaultGhostColor, token.DefaultGhostBorderColor, token.ColorTextDisabled, token.ColorBorder),
            };
        }

        public static CSSObject GenPrimaryButtonStyle(ButtonToken token)
        {
            return new CSSObject
            {
                Color = token.ColorPrimary,
                BoxShadow = token.PrimaryShadow,
                ["..."] = GenOutlinedDashedButtonStyle(token, token.ColorPrimary, token.ColorBgContainer, new object { Color = token.ColorPrimaryTextHover, BorderColor = token.ColorPrimaryHover, Background = token.ColorBgContainer, }, new object { Color = token.ColorPrimaryTextActive, BorderColor = token.ColorPrimaryActive, Background = token.ColorBgContainer, }),
                ["..."] = GenDashedButtonStyle(token),
                ["..."] = GenFilledButtonStyle(token, token.ColorPrimaryBg, new object { Background = token.ColorPrimaryBgHover, }, new object { Background = token.ColorPrimaryBorder, }),
                ["..."] = GenTextLinkButtonStyle(token, token.ColorLink, "text", new object { Color = token.ColorPrimaryTextHover, Background = token.ColorPrimaryBg, }, new object { Color = token.ColorPrimaryTextActive, Background = token.ColorPrimaryBorder, }),
                ["..."] = GenGhostButtonStyle(token.ComponentCls, token.GhostBg, token.ColorPrimary, token.ColorPrimary, token.ColorTextDisabled, token.ColorBorder, new object { Color = token.ColorPrimaryHover, BorderColor = token.ColorPrimaryHover, }, new object { Color = token.ColorPrimaryActive, BorderColor = token.ColorPrimaryActive, }),
            };
        }

        public static CSSObject GenDangerousStyle(ButtonToken token)
        {
            return new CSSObject
            {
                Color = token.ColorError,
                BoxShadow = token.DangerShadow,
                ["..."] = GenSolidButtonStyle(token, token.DangerColor, token.ColorError, new object { Background = token.ColorErrorHover, }, new object { Background = token.ColorErrorActive, }),
                ["..."] = GenOutlinedDashedButtonStyle(token, token.ColorError, token.ColorBgContainer, new object { Color = token.ColorErrorHover, BorderColor = token.ColorErrorBorderHover, }, new object { Color = token.ColorErrorActive, BorderColor = token.ColorErrorActive, }),
                ["..."] = GenDashedButtonStyle(token),
                ["..."] = GenFilledButtonStyle(token, token.ColorErrorBg, new object { Background = token.ColorErrorBgFilledHover, }, new object { Background = token.ColorErrorBgActive, }),
                ["..."] = GenTextLinkButtonStyle(token, token.ColorError, "text", new object { Color = token.ColorErrorHover, Background = token.ColorErrorBg, }, new object { Color = token.ColorErrorHover, Background = token.ColorErrorBgActive, }),
                ["..."] = GenTextLinkButtonStyle(token, token.ColorError, "link", new object { Color = token.ColorErrorHover, }, new object { Color = token.ColorErrorActive, }),
                ["..."] = GenGhostButtonStyle(token.ComponentCls, token.GhostBg, token.ColorError, token.ColorError, token.ColorTextDisabled, token.ColorBorder, new object { Color = token.ColorErrorHover, BorderColor = token.ColorErrorHover, }, new object { Color = token.ColorErrorActive, BorderColor = token.ColorErrorActive, }),
            };
        }

        public static CSSObject GenColorButtonStyle(ButtonToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-color-default"] = GenDefaultButtonStyle(token),
                [$@"{componentCls}-color-primary"] = GenPrimaryButtonStyle(token),
                [$@"{componentCls}-color-dangerous"] = GenDangerousStyle(token),
                ["..."] = GenPresetColorStyle(token),
            };
        }

        public static CSSObject GenCompatibleButtonStyle(ButtonToken token)
        {
            return new CSSObject
            {
                ["..."] = GenOutlinedDashedButtonStyle(token, token.DefaultBorderColor, token.DefaultBg, new object { Color = token.DefaultHoverColor, BorderColor = token.DefaultHoverBorderColor, Background = token.DefaultHoverBg, }, new object { Color = token.DefaultActiveColor, BorderColor = token.DefaultActiveBorderColor, Background = token.DefaultActiveBg, }),
                ["..."] = GenTextLinkButtonStyle(token, token.TextTextColor, "text", new object { Color = token.TextTextHoverColor, Background = token.TextHoverBg, }, new object { Color = token.TextTextActiveColor, Background = token.ColorBgTextActive, }),
                ["..."] = GenSolidButtonStyle(token, token.PrimaryColor, token.ColorPrimary, new object { Background = token.ColorPrimaryHover, Color = token.PrimaryColor, }, new object { Background = token.ColorPrimaryActive, Color = token.PrimaryColor, }),
                ["..."] = GenTextLinkButtonStyle(token, token.ColorLink, "link", new object { Color = token.ColorLinkHover, Background = token.LinkHoverBg, }, new object { Color = token.ColorLinkActive, }),
            };
        }

        public static CSSInterpolation GenButtonStyle(ButtonToken token, object prefixCls)
        {
            var componentCls = token.ComponentCls;
            var controlHeight = token.ControlHeight;
            var fontSize = token.FontSize;
            var borderRadius = token.BorderRadius;
            var buttonPaddingHorizontal = token.ButtonPaddingHorizontal;
            var iconCls = token.IconCls;
            var buttonPaddingVertical = token.ButtonPaddingVertical;
            var buttonIconOnlyFontSize = token.ButtonIconOnlyFontSize;
            return new object[]
            {
                new object
                {
                    [prefixCls] = new object
                    {
                        Height = controlHeight,
                        Padding = $@"{Unit(buttonPaddingVertical!)} {Unit(buttonPaddingHorizontal!)}",
                        [$@"{componentCls}-icon-only"] = new object
                        {
                            Width = controlHeight,
                            [iconCls] = new object
                            {
                                FontSize = buttonIconOnlyFontSize,
                                VerticalAlign = "calc(-0.125em - 1px)",
                            },
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}{componentCls}-circle{prefixCls}"] = GenCircleButtonStyle(token),
                },
                new object
                {
                    [$@"{componentCls}{componentCls}-round{prefixCls}"] = GenRoundButtonStyle(token),
                }
            };
        }

        public static CSSObject GenSizeBaseButtonStyle(ButtonToken token)
        {
            var baseToken = MergeToken(token, new object { FontSize = token.ContentFontSize, });
            return GenButtonStyle(baseToken, token.ComponentCls);
        }

        public static CSSObject GenSizeSmallButtonStyle(ButtonToken token)
        {
            var smallToken = MergeToken(token, new object { ControlHeight = token.ControlHeightSM, FontSize = token.ContentFontSizeSM, Padding = token.PaddingXS, ButtonPaddingHorizontal = token.PaddingInlineSM, ButtonPaddingVertical = 0, BorderRadius = token.BorderRadiusSM, ButtonIconOnlyFontSize = token.OnlyIconSizeSM, });
            return GenButtonStyle(smallToken, $@"{token.ComponentCls}-sm");
        }

        public static CSSObject GenSizeLargeButtonStyle(ButtonToken token)
        {
            var largeToken = MergeToken(token, new object { ControlHeight = token.ControlHeightLG, FontSize = token.ContentFontSizeLG, ButtonPaddingHorizontal = token.PaddingInlineLG, ButtonPaddingVertical = 0, BorderRadius = token.BorderRadiusLG, ButtonIconOnlyFontSize = token.OnlyIconSizeLG, });
            return GenButtonStyle(largeToken, $@"{token.ComponentCls}-lg");
        }

        public static CSSObject GenBlockButtonStyle(ButtonToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    [$@"{componentCls}-block"] = new CSSObject
                    {
                        Width = "100%",
                    },
                },
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Button", (ButtonToken token) =>
            {
                var buttonToken = PrepareToken(token);
                return new object[]
                {
                    GenSharedButtonStyle(buttonToken),
                    GenSizeBaseButtonStyle(buttonToken),
                    GenSizeSmallButtonStyle(buttonToken),
                    GenSizeLargeButtonStyle(buttonToken),
                    GenBlockButtonStyle(buttonToken),
                    GenColorButtonStyle(buttonToken),
                    GenCompatibleButtonStyle(buttonToken),
                    GenGroupStyle(buttonToken)
                };
            }, PrepareComponentToken, new object { Unitless = new object { FontWeight = true, ContentLineHeight = true, ContentLineHeightSM = true, ContentLineHeightLG = true, }, });
        }
    }
}