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
    public partial class SelectStyle
    {
        public static CSSObject GenBaseOutlinedStyle(SelectToken token,  { borderColor :  string ;  hoverBorderHover :  string ;  activeBorderColor :  string ;  activeOutlineColor :  string ;  color :  string ;  }
        options)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var controlOutlineWidth = token.ControlOutlineWidth;
            return new CSSObject
            {
                [$@"{componentCls}-customize-input) {componentCls}-selector"] = new CSSObject
                {
                    Border = $@"{Unit(token.LineWidth)} {token.LineType} {options.BorderColor}",
                    Background = token.SelectorBg,
                },
                [$@"{componentCls}-disabled):not({componentCls}-customize-input):not({antCls}-pagination-size-changer)"] = new CSSObject
                {
                    [$@"{componentCls}-selector"] = new CSSObject
                    {
                        BorderColor = options.HoverBorderHover,
                    },
                    [$@"{componentCls}-focused& {componentCls}-selector"] = new CSSObject
                    {
                        BorderColor = options.ActiveBorderColor,
                        BoxShadow = $@"{Unit(controlOutlineWidth)} {options.ActiveOutlineColor}",
                        Outline = 0,
                    },
                    [$@"{componentCls}-prefix"] = new CSSObject
                    {
                        Color = options.Color,
                    },
                },
            };
        }

        public static CSSObject GenOutlinedStatusStyle(SelectToken token,  { status :  string ;  borderColor :  string ;  hoverBorderHover :  string ;  activeBorderColor :  string ;  activeOutlineColor :  string ;  color :  string ;  }
        options)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-status-{options.Status}"] = new CSSObject
                {
                    ["..."] = GenBaseOutlinedStyle(token, options),
                },
            };
        }

        public static CSSObject GenOutlinedStyle(SelectToken token)
        {
            return new CSSObject
            {
                ["&-outlined"] = new CSSObject
                {
                    ["..."] = GenBaseOutlinedStyle(token, new object { BorderColor = token.ColorBorder, HoverBorderHover = token.HoverBorderColor, ActiveBorderColor = token.ActiveBorderColor, ActiveOutlineColor = token.ActiveOutlineColor, Color = token.ColorText, }),
                    ["..."] = GenOutlinedStatusStyle(token, new object { Status = "error", BorderColor = token.ColorError, HoverBorderHover = token.ColorErrorHover, ActiveBorderColor = token.ColorError, ActiveOutlineColor = token.ColorErrorOutline, Color = token.ColorError, }),
                    ["..."] = GenOutlinedStatusStyle(token, new object { Status = "warning", BorderColor = token.ColorWarning, HoverBorderHover = token.ColorWarningHover, ActiveBorderColor = token.ColorWarning, ActiveOutlineColor = token.ColorWarningOutline, Color = token.ColorWarning, }),
                    [$@"{token.ComponentCls}-disabled"] = new CSSObject
                    {
                        [$@"{token.ComponentCls}-customize-input) {token.ComponentCls}-selector"] = new CSSObject
                        {
                            Background = token.ColorBgContainerDisabled,
                            Color = token.ColorTextDisabled,
                        },
                    },
                    [$@"{token.ComponentCls}-multiple {token.ComponentCls}-selection-item"] = new CSSObject
                    {
                        Background = token.MultipleItemBg,
                        Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.MultipleItemBorderColor}",
                    },
                },
            };
        }

        public static CSSObject GenBaseFilledStyle(SelectToken token,  { bg :  string ;  hoverBg :  string ;  activeBorderColor :  string ;  color :  string ;  }
        options)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            return new CSSObject
            {
                [$@"{componentCls}-customize-input) {componentCls}-selector"] = new CSSObject
                {
                    Background = options.Bg,
                    Border = $@"{Unit(token.LineWidth)} {token.LineType} transparent",
                    Color = options.Color,
                },
                [$@"{componentCls}-disabled):not({componentCls}-customize-input):not({antCls}-pagination-size-changer)"] = new CSSObject
                {
                    [$@"{componentCls}-selector"] = new CSSObject
                    {
                        Background = options.HoverBg,
                    },
                    [$@"{componentCls}-focused& {componentCls}-selector"] = new CSSObject
                    {
                        Background = token.SelectorBg,
                        BorderColor = options.ActiveBorderColor,
                        Outline = 0,
                    },
                },
            };
        }

        public static CSSObject GenFilledStatusStyle(SelectToken token,  { status :  string ;  bg :  string ;  hoverBg :  string ;  activeBorderColor :  string ;  color :  string ;  }
        options)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}-status-{options.Status}"] = new CSSObject
                {
                    ["..."] = GenBaseFilledStyle(token, options),
                },
            };
        }

        public static CSSObject GenFilledStyle(SelectToken token)
        {
            return new CSSObject
            {
                ["&-filled"] = new CSSObject
                {
                    ["..."] = GenBaseFilledStyle(token, new object { Bg = token.ColorFillTertiary, HoverBg = token.ColorFillSecondary, ActiveBorderColor = token.ActiveBorderColor, Color = token.ColorText, }),
                    ["..."] = GenFilledStatusStyle(token, new object { Status = "error", Bg = token.ColorErrorBg, HoverBg = token.ColorErrorBgHover, ActiveBorderColor = token.ColorError, Color = token.ColorError, }),
                    ["..."] = GenFilledStatusStyle(token, new object { Status = "warning", Bg = token.ColorWarningBg, HoverBg = token.ColorWarningBgHover, ActiveBorderColor = token.ColorWarning, Color = token.ColorWarning, }),
                    [$@"{token.ComponentCls}-disabled"] = new CSSObject
                    {
                        [$@"{token.ComponentCls}-customize-input) {token.ComponentCls}-selector"] = new CSSObject
                        {
                            BorderColor = token.ColorBorder,
                            Background = token.ColorBgContainerDisabled,
                            Color = token.ColorTextDisabled,
                        },
                    },
                    [$@"{token.ComponentCls}-multiple {token.ComponentCls}-selection-item"] = new CSSObject
                    {
                        Background = token.ColorBgContainer,
                        Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                    },
                },
            };
        }

        public static CSSObject GenBorderlessStyle(SelectToken token)
        {
            return new CSSObject
            {
                ["&-borderless"] = new CSSObject
                {
                    [$@"{token.ComponentCls}-selector"] = new CSSObject
                    {
                        Background = "transparent",
                        Border = $@"{Unit(token.LineWidth)} {token.LineType} transparent",
                    },
                    [$@"{token.ComponentCls}-disabled"] = new CSSObject
                    {
                        [$@"{token.ComponentCls}-customize-input) {token.ComponentCls}-selector"] = new CSSObject
                        {
                            Color = token.ColorTextDisabled,
                        },
                    },
                    [$@"{token.ComponentCls}-multiple {token.ComponentCls}-selection-item"] = new CSSObject
                    {
                        Background = token.MultipleItemBg,
                        Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.MultipleItemBorderColor}",
                    },
                    [$@"{token.ComponentCls}-status-error"] = new CSSObject
                    {
                        [$@"{token.ComponentCls}-prefix, {token.ComponentCls}-selection-item"] = new CSSObject
                        {
                            Color = token.ColorError,
                        },
                    },
                    [$@"{token.ComponentCls}-status-warning"] = new CSSObject
                    {
                        [$@"{token.ComponentCls}-prefix, {token.ComponentCls}-selection-item"] = new CSSObject
                        {
                            Color = token.ColorWarning,
                        },
                    },
                },
            };
        }

        public static CSSObject GenVariantsStyle(SelectToken token)
        {
            return new CSSObject
            {
                [token.ComponentCls] = new CSSObject
                {
                    ["..."] = GenOutlinedStyle(token),
                    ["..."] = GenFilledStyle(token),
                    ["..."] = GenBorderlessStyle(token),
                },
            };
        }

        public static object VariantsDefault()
        {
            return genVariantsStyle;
        }
    }
}