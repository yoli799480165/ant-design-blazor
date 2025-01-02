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
    public partial class InputStyle
    {
        public static CSSObject GenHoverStyle(InputToken token)
        {
            return new CSSObject
            {
                BorderColor = token.HoverBorderColor,
                BackgroundColor = token.HoverBg,
            };
        }

        public static CSSObject GenDisabledStyle(InputToken token)
        {
            return new CSSObject
            {
                Color = token.ColorTextDisabled,
                BackgroundColor = token.ColorBgContainerDisabled,
                BorderColor = token.ColorBorder,
                BoxShadow = "none",
                Cursor = "not-allowed",
                Opacity = 1,
                ["input[disabled], textarea[disabled]"] = new CSSObject
                {
                    Cursor = "not-allowed",
                },
                ["&:hover:not([disabled])"] = new CSSObject
                {
                    ["..."] = GenHoverStyle(MergeToken(token, new object { HoverBorderColor = token.ColorBorder, HoverBg = token.ColorBgContainerDisabled, })),
                },
            };
        }

        public static CSSObject GenBaseOutlinedStyle(InputToken token,  { borderColor :  string ;  hoverBorderColor :  string ;  activeBorderColor :  string ;  activeShadow :  string ;  }
        options)
        {
            return new CSSObject
            {
                Background = token.ColorBgContainer,
                BorderWidth = token.LineWidth,
                BorderStyle = token.LineType,
                BorderColor = options.BorderColor,
                ["&:hover"] = new CSSObject
                {
                    BorderColor = options.HoverBorderColor,
                    BackgroundColor = token.HoverBg,
                },
                ["&:focus, &:focus-within"] = new CSSObject
                {
                    BorderColor = options.ActiveBorderColor,
                    BoxShadow = options.ActiveShadow,
                    Outline = 0,
                    BackgroundColor = token.ActiveBg,
                },
            };
        }

        public static CSSObject GenOutlinedStatusStyle(InputToken token,  { status :  string ;  borderColor :  string ;  hoverBorderColor :  string ;  activeBorderColor :  string ;  activeShadow :  string ;  affixColor :  string ;  }
        options)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-status-{options.Status}:not({token.ComponentCls}-disabled)"] = new CSSObject
                {
                    ["..."] = GenBaseOutlinedStyle(token, options),
                    [$@"{token.ComponentCls}-prefix, {token.ComponentCls}-suffix"] = new CSSObject
                    {
                        Color = options.AffixColor,
                    },
                },
                [$@"{token.ComponentCls}-status-{options.Status}{token.ComponentCls}-disabled"] = new CSSObject
                {
                    BorderColor = options.BorderColor,
                },
            };
        }

        public static CSSObject GenOutlinedStyle(InputToken token, CSSObject extraStyles)
        {
            return new CSSObject
            {
                ["&-outlined"] = new CSSObject
                {
                    ["..."] = GenBaseOutlinedStyle(token, new object { BorderColor = token.ColorBorder, HoverBorderColor = token.HoverBorderColor, ActiveBorderColor = token.ActiveBorderColor, ActiveShadow = token.ActiveShadow, }),
                    [$@"{token.ComponentCls}-disabled, &[disabled]"] = new CSSObject
                    {
                        ["..."] = GenDisabledStyle(token),
                    },
                    ["..."] = GenOutlinedStatusStyle(token, new object { Status = "error", BorderColor = token.ColorError, HoverBorderColor = token.ColorErrorBorderHover, ActiveBorderColor = token.ColorError, ActiveShadow = token.ErrorActiveShadow, AffixColor = token.ColorError, }),
                    ["..."] = GenOutlinedStatusStyle(token, new object { Status = "warning", BorderColor = token.ColorWarning, HoverBorderColor = token.ColorWarningBorderHover, ActiveBorderColor = token.ColorWarning, ActiveShadow = token.WarningActiveShadow, AffixColor = token.ColorWarning, }),
                    ["..."] = extraStyles,
                },
            };
        }

        public static CSSObject GenOutlinedGroupStatusStyle(InputToken token,  { status :  string ;  addonBorderColor :  string ;  addonColor :  string ;  }
        options)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-group-wrapper-status-{options.Status}"] = new CSSObject
                {
                    [$@"{token.ComponentCls}-group-addon"] = new CSSObject
                    {
                        BorderColor = options.AddonBorderColor,
                        Color = options.AddonColor,
                    },
                },
            };
        }

        public static CSSObject GenOutlinedGroupStyle(InputToken token)
        {
            return new CSSObject
            {
                ["&-outlined"] = new CSSObject
                {
                    [$@"{token.ComponentCls}-group"] = new CSSObject
                    {
                        ["&-addon"] = new CSSObject
                        {
                            Background = token.AddonBg,
                            Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                        },
                        ["&-addon:first-child"] = new CSSObject
                        {
                            BorderInlineEnd = 0,
                        },
                        ["&-addon:last-child"] = new CSSObject
                        {
                            BorderInlineStart = 0,
                        },
                    },
                    ["..."] = GenOutlinedGroupStatusStyle(token, new object { Status = "error", AddonBorderColor = token.ColorError, AddonColor = token.ColorErrorText, }),
                    ["..."] = GenOutlinedGroupStatusStyle(token, new object { Status = "warning", AddonBorderColor = token.ColorWarning, AddonColor = token.ColorWarningText, }),
                    [$@"{token.ComponentCls}-group-wrapper-disabled"] = new CSSObject
                    {
                        [$@"{token.ComponentCls}-group-addon"] = new CSSObject
                        {
                            ["..."] = GenDisabledStyle(token),
                        },
                    },
                },
            };
        }

        public static CSSObject GenBorderlessStyle(InputToken token, CSSObject extraStyles)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                ["&-borderless"] = new CSSObject
                {
                    Background = "transparent",
                    Border = "none",
                    ["&:focus, &:focus-within"] = new CSSObject
                    {
                        Outline = "none",
                    },
                    [$@"{componentCls}-disabled, &[disabled]"] = new CSSObject
                    {
                        Color = token.ColorTextDisabled,
                        Cursor = "not-allowed",
                    },
                    [$@"{componentCls}-status-error"] = new CSSObject
                    {
                        ["&, & input, & textarea"] = new CSSObject
                        {
                            Color = token.ColorError,
                        },
                    },
                    [$@"{componentCls}-status-warning"] = new CSSObject
                    {
                        ["&, & input, & textarea"] = new CSSObject
                        {
                            Color = token.ColorWarning,
                        },
                    },
                    ["..."] = extraStyles,
                },
            };
        }

        public static CSSObject GenBaseFilledStyle(InputToken token,  { bg :  string ;  hoverBg :  string ;  activeBorderColor :  string ;  inputColor ? :  string ;  }
        options)
        {
            return new CSSObject
            {
                Background = options.Bg,
                BorderWidth = token.LineWidth,
                BorderStyle = token.LineType,
                BorderColor = "transparent",
                ["input&, & input, textarea&, & textarea"] = new CSSObject
                {
                    Color = options?.InputColor,
                },
                ["&:hover"] = new CSSObject
                {
                    Background = options.HoverBg,
                },
                ["&:focus, &:focus-within"] = new CSSObject
                {
                    Outline = 0,
                    BorderColor = options.ActiveBorderColor,
                    BackgroundColor = token.ActiveBg,
                },
            };
        }

        public static CSSObject GenFilledStatusStyle(InputToken token,  { status :  string ;  bg :  string ;  hoverBg :  string ;  activeBorderColor :  string ;  affixColor :  string ;  inputColor ? :  string ;  }
        options)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-status-{options.Status}:not({token.ComponentCls}-disabled)"] = new CSSObject
                {
                    ["..."] = GenBaseFilledStyle(token, options),
                    [$@"{token.ComponentCls}-prefix, {token.ComponentCls}-suffix"] = new CSSObject
                    {
                        Color = options.AffixColor,
                    },
                },
            };
        }

        public static CSSObject GenFilledStyle(InputToken token, CSSObject extraStyles)
        {
            return new CSSObject
            {
                ["&-filled"] = new CSSObject
                {
                    ["..."] = GenBaseFilledStyle(token, new object { Bg = token.ColorFillTertiary, HoverBg = token.ColorFillSecondary, ActiveBorderColor = token.ActiveBorderColor, }),
                    [$@"{token.ComponentCls}-disabled, &[disabled]"] = new CSSObject
                    {
                        ["..."] = GenDisabledStyle(token),
                    },
                    ["..."] = GenFilledStatusStyle(token, new object { Status = "error", Bg = token.ColorErrorBg, HoverBg = token.ColorErrorBgHover, ActiveBorderColor = token.ColorError, InputColor = token.ColorErrorText, AffixColor = token.ColorError, }),
                    ["..."] = GenFilledStatusStyle(token, new object { Status = "warning", Bg = token.ColorWarningBg, HoverBg = token.ColorWarningBgHover, ActiveBorderColor = token.ColorWarning, InputColor = token.ColorWarningText, AffixColor = token.ColorWarning, }),
                    ["..."] = extraStyles,
                },
            };
        }

        public static CSSObject GenFilledGroupStatusStyle(InputToken token,  { status :  string ;  addonBg :  string ;  addonColor :  string ;  }
        options)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-group-wrapper-status-{options.Status}"] = new CSSObject
                {
                    [$@"{token.ComponentCls}-group-addon"] = new CSSObject
                    {
                        Background = options.AddonBg,
                        Color = options.AddonColor,
                    },
                },
            };
        }

        public static CSSObject GenFilledGroupStyle(InputToken token)
        {
            return new CSSObject
            {
                ["&-filled"] = new CSSObject
                {
                    [$@"{token.ComponentCls}-group"] = new CSSObject
                    {
                        ["&-addon"] = new CSSObject
                        {
                            Background = token.ColorFillTertiary,
                        },
                        [$@"{token.ComponentCls}-filled:not(:focus):not(:focus-within)"] = new CSSObject
                        {
                            ["&:not(:first-child)"] = new CSSObject
                            {
                                BorderInlineStart = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                            },
                            ["&:not(:last-child)"] = new CSSObject
                            {
                                BorderInlineEnd = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                            },
                        },
                    },
                    ["..."] = GenFilledGroupStatusStyle(token, new object { Status = "error", AddonBg = token.ColorErrorBg, AddonColor = token.ColorErrorText, }),
                    ["..."] = GenFilledGroupStatusStyle(token, new object { Status = "warning", AddonBg = token.ColorWarningBg, AddonColor = token.ColorWarningText, }),
                    [$@"{token.ComponentCls}-group-wrapper-disabled"] = new CSSObject
                    {
                        [$@"{token.ComponentCls}-group"] = new CSSObject
                        {
                            ["&-addon"] = new CSSObject
                            {
                                Background = token.ColorFillTertiary,
                                Color = token.ColorTextDisabled,
                            },
                            ["&-addon:first-child"] = new CSSObject
                            {
                                BorderInlineStart = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                                BorderTop = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                                BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                            },
                            ["&-addon:last-child"] = new CSSObject
                            {
                                BorderInlineEnd = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                                BorderTop = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                                BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                            },
                        },
                    },
                },
            };
        }
    }
}