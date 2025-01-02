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
        public static CSSObject GenSelectorStyle(SelectToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                Position = "relative",
                Transition = $@"{token.MotionDurationMid} {token.MotionEaseInOut}",
                ["input"] = new CSSObject
                {
                    Cursor = "pointer",
                },
                [$@"{componentCls}-show-search&"] = new CSSObject
                {
                    Cursor = "text",
                    ["input"] = new CSSObject
                    {
                        Cursor = "auto",
                        Color = "inherit",
                        Height = "100%",
                    },
                },
                [$@"{componentCls}-disabled&"] = new CSSObject
                {
                    Cursor = "not-allowed",
                    ["input"] = new CSSObject
                    {
                        Cursor = "not-allowed",
                    },
                },
            };
        }

        public static CSSObject GetSearchInputWithoutBorderStyle(SelectToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-selection-search-input"] = new CSSObject
                {
                    Margin = 0,
                    Padding = 0,
                    Background = "transparent",
                    Border = "none",
                    Outline = "none",
                    Appearance = "none",
                    FontFamily = "inherit",
                    ["&::-webkit-search-cancel-button"] = new CSSObject
                    {
                        Display = "none",
                        ["-webkit-appearance"] = "none",
                    },
                },
            };
        }

        public static CSSObject GenBaseStyle(SelectToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var inputPaddingHorizontalBase = token.InputPaddingHorizontalBase;
            var iconCls = token.IconCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "relative",
                    Display = "inline-flex",
                    Cursor = "pointer",
                    [$@"{componentCls}-customize-input) {componentCls}-selector"] = new CSSObject
                    {
                        ["..."] = GenSelectorStyle(token),
                        ["..."] = GetSearchInputWithoutBorderStyle(token),
                    },
                    [$@"{componentCls}-selection-item"] = new CSSObject
                    {
                        Flex = 1,
                        FontWeight = "normal",
                        Position = "relative",
                        UserSelect = "none",
                        ["..."] = textEllipsis,
                        [$@"{antCls}-typography"] = new CSSObject
                        {
                            Display = "inline",
                        },
                    },
                    [$@"{componentCls}-selection-placeholder"] = new CSSObject
                    {
                        ["..."] = textEllipsis,
                        Flex = 1,
                        Color = token.ColorTextPlaceholder,
                        PointerEvents = "none",
                    },
                    [$@"{componentCls}-arrow"] = new CSSObject
                    {
                        ["..."] = ResetIcon(),
                        Position = "absolute",
                        Top = "50%",
                        InsetInlineStart = "auto",
                        InsetInlineEnd = inputPaddingHorizontalBase,
                        Height = token.FontSizeIcon,
                        MarginTop = token.calc(token.fontSizeIcon).mul(-1).div(2).Equal(),
                        Color = token.ColorTextQuaternary,
                        FontSize = token.FontSizeIcon,
                        LineHeight = 1,
                        TextAlign = "center",
                        PointerEvents = "none",
                        Display = "flex",
                        AlignItems = "center",
                        Transition = $@"{token.MotionDurationSlow} ease",
                        [iconCls] = new CSSObject
                        {
                            VerticalAlign = "top",
                            Transition = $@"{token.MotionDurationSlow}",
                            ["> svg"] = new CSSObject
                            {
                                VerticalAlign = "top",
                            },
                            [$@"{componentCls}-suffix)"] = new CSSObject
                            {
                                PointerEvents = "auto",
                            },
                        },
                        [$@"{componentCls}-disabled &"] = new CSSObject
                        {
                            Cursor = "not-allowed",
                        },
                        ["> *:not(:last-child)"] = new CSSObject
                        {
                            MarginInlineEnd = 8,
                        },
                    },
                    [$@"{componentCls}-selection-wrap"] = new CSSObject
                    {
                        Display = "flex",
                        Width = "100%",
                        Position = "relative",
                        MinWidth = 0,
                        ["&:after"] = new CSSObject
                        {
                            Content = "\"\\a0\"",
                            Width = 0,
                            Overflow = "hidden",
                        },
                    },
                    [$@"{componentCls}-prefix"] = new CSSObject
                    {
                        Flex = "none",
                        MarginInlineEnd = token.SelectAffixPadding,
                    },
                    [$@"{componentCls}-clear"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = "50%",
                        InsetInlineStart = "auto",
                        InsetInlineEnd = inputPaddingHorizontalBase,
                        ZIndex = 1,
                        Display = "inline-block",
                        Width = token.FontSizeIcon,
                        Height = token.FontSizeIcon,
                        MarginTop = token.calc(token.fontSizeIcon).mul(-1).div(2).Equal(),
                        Color = token.ColorTextQuaternary,
                        FontSize = token.FontSizeIcon,
                        FontStyle = "normal",
                        LineHeight = 1,
                        TextAlign = "center",
                        TextTransform = "none",
                        Cursor = "pointer",
                        Opacity = 0,
                        Transition = $@"{token.MotionDurationMid} ease, opacity {token.MotionDurationSlow} ease",
                        TextRendering = "auto",
                        ["&:before"] = new CSSObject
                        {
                            Display = "block",
                        },
                        ["&:hover"] = new CSSObject
                        {
                            Color = token.ColorTextTertiary,
                        },
                    },
                    [$@"{componentCls}-clear"] = new CSSObject
                    {
                        Opacity = 1,
                        Background = token.ColorBgBase,
                        BorderRadius = "50%",
                    },
                },
                [$@"{componentCls}-status"] = new CSSObject
                {
                    ["&-error, &-warning, &-success, &-validating"] = new CSSObject
                    {
                        [$@"{componentCls}-has-feedback"] = new CSSObject
                        {
                            [$@"{componentCls}-clear"] = new CSSObject
                            {
                                InsetInlineEnd = token
              .calc(inputPaddingHorizontalBase)
              .add(token.fontSize)
              .add(token.paddingXS).Equal(),
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenSelectStyle(SelectToken token)
        {
            var componentCls = token.ComponentCls;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        [$@"{componentCls}-in-form-item"] = new object
                        {
                            Width = "100%",
                        },
                    },
                },
                GenBaseStyle(token),
                GenSingleStyle(token),
                GenMultipleStyle(token),
                GenDropdownStyle(token),
                new object
                {
                    [$@"{componentCls}-rtl"] = new object
                    {
                        Direction = "rtl",
                    },
                },
                GenCompactItemStyle(token, new object { BorderElCls = $@"{componentCls}-selector", FocusElCls = $@"{componentCls}-focused", })
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Select", (SelectToken token, object { rootPrefixCls }) =>
            {
                var selectToken = MergeToken(token, new object { InputPaddingHorizontalBase = token.calc(token.paddingSM).sub(1).Equal(), MultipleSelectItemHeight = token.MultipleItemHeight, SelectHeight = token.ControlHeight, });
                return new object[]
                {
                    GenSelectStyle(selectToken),
                    GenVariantsStyle(selectToken)
                };
            }, prepareComponentToken, new object { Unitless = new object { OptionLineHeight = true, OptionSelectedFontWeight = true, }, });
        }
    }
}