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
        public static CSSObject GenPlaceholderStyle(string color)
        {
            return new CSSObject
            {
                ["&::-moz-placeholder"] = new CSSObject
                {
                    Opacity = 1,
                },
                ["&::placeholder"] = new CSSObject
                {
                    UserSelect = "none",
                },
                ["&:placeholder-shown"] = new CSSObject
                {
                    TextOverflow = "ellipsis",
                },
            };
        }

        public static CSSObject GenActiveStyle(InputToken token)
        {
            return new CSSObject
            {
                BorderColor = token.ActiveBorderColor,
                BoxShadow = token.ActiveShadow,
                Outline = 0,
                BackgroundColor = token.ActiveBg,
            };
        }

        public static CSSObject GenInputLargeStyle(InputToken token)
        {
            var paddingBlockLG = token.PaddingBlockLG;
            var lineHeightLG = token.LineHeightLG;
            var borderRadiusLG = token.BorderRadiusLG;
            var paddingInlineLG = token.PaddingInlineLG;
            return new CSSObject
            {
                Padding = $@"{Unit(paddingBlockLG)} {Unit(paddingInlineLG)}",
                FontSize = token.InputFontSizeLG,
                LineHeight = lineHeightLG,
                BorderRadius = borderRadiusLG,
            };
        }

        public static CSSObject GenInputSmallStyle(InputToken token)
        {
            return new CSSObject
            {
                Padding = $@"{Unit(token.PaddingBlockSM)} {Unit(token.PaddingInlineSM)}",
                FontSize = token.InputFontSizeSM,
                BorderRadius = token.BorderRadiusSM,
            };
        }

        public static CSSObject GenBasicInputStyle(InputToken token)
        {
            return new CSSObject
            {
                Position = "relative",
                Display = "inline-block",
                Width = "100%",
                MinWidth = 0,
                Padding = $@"{Unit(token.PaddingBlock)} {Unit(token.PaddingInline)}",
                Color = token.ColorText,
                FontSize = token.InputFontSize,
                LineHeight = token.LineHeight,
                BorderRadius = token.BorderRadius,
                Transition = $@"{token.MotionDurationMid}",
                ["..."] = GenPlaceholderStyle(token.ColorTextPlaceholder),
                ["textarea&"] = new CSSObject
                {
                    MaxWidth = "100%",
                    Height = "auto",
                    MinHeight = token.ControlHeight,
                    LineHeight = token.LineHeight,
                    VerticalAlign = "bottom",
                    Transition = $@"{token.MotionDurationSlow}, height 0s",
                    Resize = "vertical",
                },
                ["&-lg"] = new CSSObject
                {
                    ["..."] = GenInputLargeStyle(token),
                },
                ["&-sm"] = new CSSObject
                {
                    ["..."] = GenInputSmallStyle(token),
                },
                ["&-rtl, &-textarea-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                },
            };
        }

        public static CSSObject GenInputGroupStyle(InputToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            return new CSSObject
            {
                Position = "relative",
                Display = "table",
                Width = "100%",
                BorderCollapse = "separate",
                BorderSpacing = 0,
                ["&[class*='col-']"] = new CSSObject
                {
                    PaddingInlineEnd = token.PaddingXS,
                    ["&:last-child"] = new CSSObject
                    {
                        PaddingInlineEnd = 0,
                    },
                },
                [$@"{componentCls}, &-lg > {componentCls}-group-addon"] = new CSSObject
                {
                    ["..."] = GenInputLargeStyle(token),
                },
                [$@"{componentCls}, &-sm > {componentCls}-group-addon"] = new CSSObject
                {
                    ["..."] = GenInputSmallStyle(token),
                },
                [$@"{antCls}-select-single {antCls}-select-selector"] = new CSSObject
                {
                    Height = token.ControlHeightLG,
                },
                [$@"{antCls}-select-single {antCls}-select-selector"] = new CSSObject
                {
                    Height = token.ControlHeightSM,
                },
                [$@"{componentCls}"] = new CSSObject
                {
                    Display = "table-cell",
                    ["&:not(:first-child):not(:last-child)"] = new CSSObject
                    {
                        BorderRadius = 0,
                    },
                },
                [$@"{componentCls}-group"] = new CSSObject
                {
                    ["&-addon, &-wrap"] = new CSSObject
                    {
                        Display = "table-cell",
                        Width = 1,
                        WhiteSpace = "nowrap",
                        VerticalAlign = "middle",
                        ["&:not(:first-child):not(:last-child)"] = new CSSObject
                        {
                            BorderRadius = 0,
                        },
                    },
                    ["&-wrap > *"] = new CSSObject
                    {
                        Display = "block !important",
                    },
                    ["&-addon"] = new CSSObject
                    {
                        Position = "relative",
                        Padding = $@"{Unit(token.PaddingInline)}",
                        Color = token.ColorText,
                        FontWeight = "normal",
                        FontSize = token.InputFontSize,
                        TextAlign = "center",
                        BorderRadius = token.BorderRadius,
                        Transition = $@"{token.MotionDurationSlow}",
                        LineHeight = 1,
                        [$@"{antCls}-select"] = new CSSObject
                        {
                            Margin = $@"{Unit(token.calc(token.paddingBlock).add(1).mul(-1).Equal())} {Unit(token.calc(token.paddingInline).mul(-1).Equal())}",
                            [$@"{antCls}-select-single:not({antCls}-select-customize-input):not({antCls}-pagination-size-changer)"] = new CSSObject
                            {
                                [$@"{antCls}-select-selector"] = new CSSObject
                                {
                                    BackgroundColor = "inherit",
                                    Border = $@"{Unit(token.LineWidth)} {token.LineType} transparent",
                                    BoxShadow = "none",
                                },
                            },
                        },
                        [$@"{antCls}-cascader-picker"] = new CSSObject
                        {
                            Margin = $@"{Unit(token.calc(token.paddingInline).mul(-1).Equal())}",
                            BackgroundColor = "transparent",
                            [$@"{antCls}-cascader-input"] = new CSSObject
                            {
                                TextAlign = "start",
                                Border = 0,
                                BoxShadow = "none",
                            },
                        },
                    },
                },
                [componentCls] = new CSSObject
                {
                    Width = "100%",
                    MarginBottom = 0,
                    TextAlign = "inherit",
                    ["&:focus"] = new CSSObject
                    {
                        ZIndex = 1,
                        BorderInlineEndWidth = 1,
                    },
                    ["&:hover"] = new CSSObject
                    {
                        ZIndex = 1,
                        BorderInlineEndWidth = 1,
                        [$@"{componentCls}-search-with-button &"] = new CSSObject
                        {
                            ZIndex = 0,
                        },
                    },
                },
                [$@"{componentCls}:first-child, {componentCls}-group-addon:first-child"] = new CSSObject
                {
                    BorderStartEndRadius = 0,
                    BorderEndEndRadius = 0,
                    [$@"{antCls}-select {antCls}-select-selector"] = new CSSObject
                    {
                        BorderStartEndRadius = 0,
                        BorderEndEndRadius = 0,
                    },
                },
                [$@"{componentCls}-affix-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}"] = new CSSObject
                    {
                        BorderStartStartRadius = 0,
                        BorderEndStartRadius = 0,
                    },
                    [$@"{componentCls}"] = new CSSObject
                    {
                        BorderStartEndRadius = 0,
                        BorderEndEndRadius = 0,
                    },
                },
                [$@"{componentCls}:last-child, {componentCls}-group-addon:last-child"] = new CSSObject
                {
                    BorderStartStartRadius = 0,
                    BorderEndStartRadius = 0,
                    [$@"{antCls}-select {antCls}-select-selector"] = new CSSObject
                    {
                        BorderStartStartRadius = 0,
                        BorderEndStartRadius = 0,
                    },
                },
                [$@"{componentCls}-affix-wrapper"] = new CSSObject
                {
                    ["&:not(:last-child)"] = new CSSObject
                    {
                        BorderStartEndRadius = 0,
                        BorderEndEndRadius = 0,
                        [$@"{componentCls}-search &"] = new CSSObject
                        {
                            BorderStartStartRadius = token.BorderRadius,
                            BorderEndStartRadius = token.BorderRadius,
                        },
                    },
                    [$@"{componentCls}-search &:not(:first-child)"] = new CSSObject
                    {
                        BorderStartStartRadius = 0,
                        BorderEndStartRadius = 0,
                    },
                },
                [$@"{componentCls}-group-compact"] = new CSSObject
                {
                    Display = "block",
                    ["..."] = ClearFix(),
                    [$@"{componentCls}-group-addon, {componentCls}-group-wrap, > {componentCls}"] = new CSSObject
                    {
                        ["&:not(:first-child):not(:last-child)"] = new CSSObject
                        {
                            BorderInlineEndWidth = token.LineWidth,
                            ["&:hover, &:focus"] = new CSSObject
                            {
                                ZIndex = 1,
                            },
                        },
                    },
                    ["& > *"] = new CSSObject
                    {
                        Display = "inline-flex",
                        Float = "none",
                        VerticalAlign = "top",
                        BorderRadius = 0,
                    },
                    [$@"{componentCls}-affix-wrapper,
        & > {componentCls}-number-affix-wrapper,
        & > {antCls}-picker-range
      "] = new CSSObject
                    {
                        Display = "inline-flex",
                    },
                    ["& > *:not(:last-child)"] = new CSSObject
                    {
                        MarginInlineEnd = token.calc(token.lineWidth).mul(-1).Equal(),
                        BorderInlineEndWidth = token.LineWidth,
                    },
                    [componentCls] = new CSSObject
                    {
                        Float = "none",
                    },
                    [$@"{antCls}-select > {antCls}-select-selector,
      & > {antCls}-select-auto-complete {componentCls},
      & > {antCls}-cascader-picker {componentCls},
      & > {componentCls}-group-wrapper {componentCls}"] = new CSSObject
                    {
                        BorderInlineEndWidth = token.LineWidth,
                        BorderRadius = 0,
                        ["&:hover, &:focus"] = new CSSObject
                        {
                            ZIndex = 1,
                        },
                    },
                    [$@"{antCls}-select-focused"] = new CSSObject
                    {
                        ZIndex = 1,
                    },
                    [$@"{antCls}-select > {antCls}-select-arrow"] = new CSSObject
                    {
                        ZIndex = 1,
                    },
                    [$@"{antCls}-select:first-child > {antCls}-select-selector,
      & > {antCls}-select-auto-complete:first-child {componentCls},
      & > {antCls}-cascader-picker:first-child {componentCls}"] = new CSSObject
                    {
                        BorderStartStartRadius = token.BorderRadius,
                        BorderEndStartRadius = token.BorderRadius,
                    },
                    [$@"{antCls}-select:last-child > {antCls}-select-selector,
      & > {antCls}-cascader-picker:last-child {componentCls},
      & > {antCls}-cascader-picker-focused:last-child {componentCls}"] = new CSSObject
                    {
                        BorderInlineEndWidth = token.LineWidth,
                        BorderStartEndRadius = token.BorderRadius,
                        BorderEndEndRadius = token.BorderRadius,
                    },
                    [$@"{antCls}-select-auto-complete {componentCls}"] = new CSSObject
                    {
                        VerticalAlign = "top",
                    },
                    [$@"{componentCls}-group-wrapper + {componentCls}-group-wrapper"] = new CSSObject
                    {
                        MarginInlineStart = token.calc(token.lineWidth).mul(-1).Equal(),
                        [$@"{componentCls}-affix-wrapper"] = new CSSObject
                        {
                            BorderRadius = 0,
                        },
                    },
                    [$@"{componentCls}-group-wrapper:not(:last-child)"] = new CSSObject
                    {
                        [$@"{componentCls}-search > {componentCls}-group"] = new CSSObject
                        {
                            [$@"{componentCls}-group-addon > {componentCls}-search-button"] = new CSSObject
                            {
                                BorderRadius = 0,
                            },
                            [$@"{componentCls}"] = new CSSObject
                            {
                                BorderStartStartRadius = token.BorderRadius,
                                BorderStartEndRadius = 0,
                                BorderEndEndRadius = 0,
                                BorderEndStartRadius = token.BorderRadius,
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenInputStyle(InputToken token)
        {
            var componentCls = token.ComponentCls;
            var controlHeightSM = token.ControlHeightSM;
            var lineWidth = token.LineWidth;
            var calc = token.Calc;
            var FIXED_CHROME_COLOR_HEIGHT = 16;
            var colorSmallPadding = calc(controlHeightSM)
    .sub(calc(lineWidth).mul(2))
    .sub(FIXED_CHROME_COLOR_HEIGHT)
    .div(2).Equal();
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    ["..."] = GenBasicInputStyle(token),
                    ["..."] = GenOutlinedStyle(token),
                    ["..."] = GenFilledStyle(token),
                    ["..."] = GenBorderlessStyle(token),
                    ["&[type=\"color\"]"] = new CSSObject
                    {
                        Height = token.ControlHeight,
                        [$@"{componentCls}-lg"] = new CSSObject
                        {
                            Height = token.ControlHeightLG,
                        },
                        [$@"{componentCls}-sm"] = new CSSObject
                        {
                            Height = controlHeightSM,
                            PaddingTop = colorSmallPadding,
                            PaddingBottom = colorSmallPadding,
                        },
                    },
                    ["&[type=\"search\"]::-webkit-search-cancel-button, &[type=\"search\"]::-webkit-search-decoration"] = new CSSObject
                    {
                        ["-webkit-appearance"] = "none",
                    },
                },
            };
        }

        public static CSSObject GenAllowClearStyle(InputToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-clear-icon"] = new CSSObject
                {
                    Margin = 0,
                    LineHeight = 0,
                    Color = token.ColorTextQuaternary,
                    FontSize = token.FontSizeIcon,
                    VerticalAlign = -1,
                    Cursor = "pointer",
                    Transition = $@"{token.MotionDurationSlow}",
                    ["&:hover"] = new CSSObject
                    {
                        Color = token.ColorTextTertiary,
                    },
                    ["&:active"] = new CSSObject
                    {
                        Color = token.ColorText,
                    },
                    ["&-hidden"] = new CSSObject
                    {
                        Visibility = "hidden",
                    },
                    ["&-has-suffix"] = new CSSObject
                    {
                        Margin = $@"{Unit(token.InputAffixPadding)}",
                    },
                },
            };
        }

        public static CSSObject GenAffixStyle(InputToken token)
        {
            var componentCls = token.ComponentCls;
            var inputAffixPadding = token.InputAffixPadding;
            var colorTextDescription = token.ColorTextDescription;
            var motionDurationSlow = token.MotionDurationSlow;
            var colorIcon = token.ColorIcon;
            var colorIconHover = token.ColorIconHover;
            var iconCls = token.IconCls;
            var affixCls = $@"{componentCls}-affix-wrapper";
            var affixClsDisabled = $@"{componentCls}-affix-wrapper-disabled";
            return new CSSObject
            {
                [affixCls] = new CSSObject
                {
                    ["..."] = GenBasicInputStyle(token),
                    Display = "inline-flex",
                    [$@"{componentCls}-disabled):hover"] = new CSSObject
                    {
                        ZIndex = 1,
                        [$@"{componentCls}-search-with-button &"] = new CSSObject
                        {
                            ZIndex = 0,
                        },
                    },
                    ["&-focused, &:focus"] = new CSSObject
                    {
                        ZIndex = 1,
                    },
                    [$@"{componentCls}"] = new CSSObject
                    {
                        Padding = 0,
                    },
                    [$@"{componentCls}, > textarea{componentCls}"] = new CSSObject
                    {
                        FontSize = "inherit",
                        Border = "none",
                        BorderRadius = 0,
                        Outline = "none",
                        Background = "transparent",
                        Color = "inherit",
                        ["&::-ms-reveal"] = new CSSObject
                        {
                            Display = "none",
                        },
                        ["&:focus"] = new CSSObject
                        {
                            BoxShadow = "none !important",
                        },
                    },
                    ["&::before"] = new CSSObject
                    {
                        Display = "inline-block",
                        Width = 0,
                        Visibility = "hidden",
                        Content = "\"\\a0\"",
                    },
                    [componentCls] = new CSSObject
                    {
                        ["&-prefix, &-suffix"] = new CSSObject
                        {
                            Display = "flex",
                            Flex = "none",
                            AlignItems = "center",
                            ["> *:not(:last-child)"] = new CSSObject
                            {
                                MarginInlineEnd = token.PaddingXS,
                            },
                        },
                        ["&-show-count-suffix"] = new CSSObject
                        {
                            Color = colorTextDescription,
                        },
                        ["&-show-count-has-suffix"] = new CSSObject
                        {
                            MarginInlineEnd = token.PaddingXXS,
                        },
                        ["&-prefix"] = new CSSObject
                        {
                            MarginInlineEnd = inputAffixPadding,
                        },
                        ["&-suffix"] = new CSSObject
                        {
                            MarginInlineStart = inputAffixPadding,
                        },
                    },
                    ["..."] = GenAllowClearStyle(token),
                    [$@"{iconCls}{componentCls}-password-icon"] = new CSSObject
                    {
                        Color = colorIcon,
                        Cursor = "pointer",
                        Transition = $@"{motionDurationSlow}",
                        ["&:hover"] = new CSSObject
                        {
                            Color = colorIconHover,
                        },
                    },
                },
                [affixClsDisabled] = new CSSObject
                {
                    [$@"{iconCls}{componentCls}-password-icon"] = new CSSObject
                    {
                        Color = colorIcon,
                        Cursor = "not-allowed",
                        ["&:hover"] = new CSSObject
                        {
                            Color = colorIcon,
                        },
                    },
                },
            };
        }

        public static CSSObject GenGroupStyle(InputToken token)
        {
            var componentCls = token.ComponentCls;
            var borderRadiusLG = token.BorderRadiusLG;
            var borderRadiusSM = token.BorderRadiusSM;
            return new CSSObject
            {
                [$@"{componentCls}-group"] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    ["..."] = GenInputGroupStyle(token),
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    ["&-wrapper"] = new CSSObject
                    {
                        Display = "inline-block",
                        Width = "100%",
                        TextAlign = "start",
                        VerticalAlign = "top",
                        ["&-rtl"] = new CSSObject
                        {
                            Direction = "rtl",
                        },
                        ["&-lg"] = new CSSObject
                        {
                            [$@"{componentCls}-group-addon"] = new CSSObject
                            {
                                BorderRadius = borderRadiusLG,
                                FontSize = token.InputFontSizeLG,
                            },
                        },
                        ["&-sm"] = new CSSObject
                        {
                            [$@"{componentCls}-group-addon"] = new CSSObject
                            {
                                BorderRadius = borderRadiusSM,
                            },
                        },
                        ["..."] = GenOutlinedGroupStyle(token),
                        ["..."] = GenFilledGroupStyle(token),
                        [$@"{componentCls}-compact-first-item):not({componentCls}-compact-last-item){componentCls}-compact-item"] = new CSSObject
                        {
                            [$@"{componentCls}, {componentCls}-group-addon"] = new CSSObject
                            {
                                BorderRadius = 0,
                            },
                        },
                        [$@"{componentCls}-compact-last-item){componentCls}-compact-first-item"] = new CSSObject
                        {
                            [$@"{componentCls}, {componentCls}-group-addon"] = new CSSObject
                            {
                                BorderStartEndRadius = 0,
                                BorderEndEndRadius = 0,
                            },
                        },
                        [$@"{componentCls}-compact-first-item){componentCls}-compact-last-item"] = new CSSObject
                        {
                            [$@"{componentCls}, {componentCls}-group-addon"] = new CSSObject
                            {
                                BorderStartStartRadius = 0,
                                BorderEndStartRadius = 0,
                            },
                        },
                        [$@"{componentCls}-compact-last-item){componentCls}-compact-item"] = new CSSObject
                        {
                            [$@"{componentCls}-affix-wrapper"] = new CSSObject
                            {
                                BorderStartEndRadius = 0,
                                BorderEndEndRadius = 0,
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenSearchInputStyle(InputToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var searchPrefixCls = $@"{componentCls}-search";
            return new CSSObject
            {
                [searchPrefixCls] = new CSSObject
                {
                    [componentCls] = new CSSObject
                    {
                        ["&:hover, &:focus"] = new CSSObject
                        {
                            [$@"{componentCls}-group-addon {searchPrefixCls}-button:not({antCls}-btn-primary)"] = new CSSObject
                            {
                                BorderInlineStartColor = token.ColorPrimaryHover,
                            },
                        },
                    },
                    [$@"{componentCls}-affix-wrapper"] = new CSSObject
                    {
                        Height = token.ControlHeight,
                        BorderRadius = 0,
                    },
                    [$@"{componentCls}-lg"] = new CSSObject
                    {
                        LineHeight = token.calc(token.lineHeightLG).sub(0.0002).Equal(),
                    },
                    [$@"{componentCls}-group"] = new CSSObject
                    {
                        [$@"{componentCls}-group-addon:last-child"] = new CSSObject
                        {
                            InsetInlineStart = -1,
                            Padding = 0,
                            Border = 0,
                            [$@"{searchPrefixCls}-button"] = new CSSObject
                            {
                                MarginInlineEnd = -1,
                                BorderStartStartRadius = 0,
                                BorderEndStartRadius = 0,
                                BoxShadow = "none",
                            },
                            [$@"{searchPrefixCls}-button:not({antCls}-btn-primary)"] = new CSSObject
                            {
                                Color = token.ColorTextDescription,
                                ["&:hover"] = new CSSObject
                                {
                                    Color = token.ColorPrimaryHover,
                                },
                                ["&:active"] = new CSSObject
                                {
                                    Color = token.ColorPrimaryActive,
                                },
                                [$@"{antCls}-btn-loading::before"] = new CSSObject
                                {
                                    InsetInlineStart = 0,
                                    InsetInlineEnd = 0,
                                    InsetBlockStart = 0,
                                    InsetBlockEnd = 0,
                                },
                            },
                        },
                    },
                    [$@"{searchPrefixCls}-button"] = new CSSObject
                    {
                        Height = token.ControlHeight,
                        ["&:hover, &:focus"] = new CSSObject
                        {
                            ZIndex = 1,
                        },
                    },
                    ["&-large"] = new CSSObject
                    {
                        [$@"{componentCls}-affix-wrapper, {searchPrefixCls}-button"] = new CSSObject
                        {
                            Height = token.ControlHeightLG,
                        },
                    },
                    ["&-small"] = new CSSObject
                    {
                        [$@"{componentCls}-affix-wrapper, {searchPrefixCls}-button"] = new CSSObject
                        {
                            Height = token.ControlHeightSM,
                        },
                    },
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [$@"{componentCls}-compact-item"] = new CSSObject
                    {
                        [$@"{componentCls}-compact-last-item)"] = new CSSObject
                        {
                            [$@"{componentCls}-group-addon"] = new CSSObject
                            {
                                [$@"{componentCls}-search-button"] = new CSSObject
                                {
                                    MarginInlineEnd = token.calc(token.lineWidth).mul(-1).Equal(),
                                    BorderRadius = 0,
                                },
                            },
                        },
                        [$@"{componentCls}-compact-first-item)"] = new CSSObject
                        {
                            [$@"{componentCls},{componentCls}-affix-wrapper"] = new CSSObject
                            {
                                BorderRadius = 0,
                            },
                        },
                        [$@"{componentCls}-group-addon {componentCls}-search-button,
        > {componentCls},
        {componentCls}-affix-wrapper"] = new CSSObject
                        {
                            ["&:hover, &:focus, &:active"] = new CSSObject
                            {
                                ZIndex = 2,
                            },
                        },
                        [$@"{componentCls}-affix-wrapper-focused"] = new CSSObject
                        {
                            ZIndex = 2,
                        },
                    },
                },
            };
        }

        public static CSSObject GenTextAreaStyle(InputToken token)
        {
            var componentCls = token.ComponentCls;
            var paddingLG = token.PaddingLG;
            var textareaPrefixCls = $@"{componentCls}-textarea";
            return new CSSObject
            {
                [textareaPrefixCls] = new CSSObject
                {
                    Position = "relative",
                    ["&-show-count"] = new CSSObject
                    {
                        [$@"{componentCls}"] = new CSSObject
                        {
                            Height = "100%",
                        },
                        [$@"{componentCls}-data-count"] = new CSSObject
                        {
                            Position = "absolute",
                            Bottom = token.calc(token.fontSize).mul(token.lineHeight).mul(-1).Equal(),
                            InsetInlineEnd = 0,
                            Color = token.ColorTextDescription,
                            WhiteSpace = "nowrap",
                            PointerEvents = "none",
                        },
                    },
                    [$@"{componentCls},
        &-affix-wrapper{textareaPrefixCls}-has-feedback {componentCls}
      "] = new CSSObject
                    {
                        PaddingInlineEnd = paddingLG,
                    },
                    [$@"{componentCls}-affix-wrapper"] = new CSSObject
                    {
                        Padding = 0,
                        [$@"{componentCls}"] = new CSSObject
                        {
                            FontSize = "inherit",
                            Border = "none",
                            Outline = "none",
                            Background = "transparent",
                            ["&:focus"] = new CSSObject
                            {
                                BoxShadow = "none !important",
                            },
                        },
                        [$@"{componentCls}-suffix"] = new CSSObject
                        {
                            Margin = 0,
                            ["> *:not(:last-child)"] = new CSSObject
                            {
                                MarginInline = 0,
                            },
                            [$@"{componentCls}-clear-icon"] = new CSSObject
                            {
                                Position = "absolute",
                                InsetInlineEnd = token.PaddingInline,
                                InsetBlockStart = token.PaddingXS,
                            },
                            [$@"{textareaPrefixCls}-suffix"] = new CSSObject
                            {
                                Position = "absolute",
                                Top = 0,
                                InsetInlineEnd = token.PaddingInline,
                                Bottom = 0,
                                ZIndex = 1,
                                Display = "inline-flex",
                                AlignItems = "center",
                                Margin = "auto",
                                PointerEvents = "none",
                            },
                        },
                    },
                    [$@"{componentCls}-affix-wrapper-sm"] = new CSSObject
                    {
                        [$@"{componentCls}-suffix"] = new CSSObject
                        {
                            [$@"{componentCls}-clear-icon"] = new CSSObject
                            {
                                InsetInlineEnd = token.PaddingInlineSM,
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenRangeStyle(InputToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-out-of-range"] = new CSSObject
                {
                    [$@"{componentCls}-show-count-suffix, {componentCls}-data-count"] = new CSSObject
                    {
                        Color = token.ColorError,
                    },
                },
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Input", (InputToken token) =>
            {
                var inputToken = MergeToken(token, InitInputToken(token));
                return new object[]
                {
                    GenInputStyle(inputToken),
                    GenTextAreaStyle(inputToken),
                    GenAffixStyle(inputToken),
                    GenGroupStyle(inputToken),
                    GenSearchInputStyle(inputToken),
                    GenRangeStyle(inputToken),
                    GenCompactItemStyle(inputToken)
                };
            }, initComponentToken, new object { ResetFont = false, });
        }
    }
}