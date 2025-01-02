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
    public partial class PaginationStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string ItemBg { get; set; }
            public double ItemSize { get; set; }
            public string ItemActiveBg { get; set; }
            public double ItemSizeSM { get; set; }
            public string ItemLinkBg { get; set; }
            public string ItemActiveBgDisabled { get; set; }
            public string ItemActiveColorDisabled { get; set; }
            public string ItemInputBg { get; set; }
            public double MiniOptionsSizeChangerTop { get; set; }
        }

        public class PaginationToken : ComponentToken, SharedComponentToken, SharedInputToken
        {
            public double InputOutlineOffset { get; set; }
            public string PaginationMiniOptionsMarginInlineStart { get; set; }
            public string PaginationMiniQuickJumperInputWidth { get; set; }
            public string PaginationItemPaddingInline { get; set; }
            public string PaginationEllipsisLetterSpacing { get; set; }
            public string PaginationEllipsisTextIndent { get; set; }
            public double PaginationSlashMarginInlineStart { get; set; }
            public double PaginationSlashMarginInlineEnd { get; set; }
        }

        public static CSSObject GenPaginationDisabledStyle(PaginationToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-disabled"] = new CSSObject
                {
                    ["&, &:hover"] = new CSSObject
                    {
                        Cursor = "not-allowed",
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            Color = token.ColorTextDisabled,
                            Cursor = "not-allowed",
                        },
                    },
                    ["&:focus-visible"] = new CSSObject
                    {
                        Cursor = "not-allowed",
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            Color = token.ColorTextDisabled,
                            Cursor = "not-allowed",
                        },
                    },
                },
                [$@"{componentCls}-disabled"] = new CSSObject
                {
                    Cursor = "not-allowed",
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        Cursor = "not-allowed",
                        ["&:hover, &:active"] = new CSSObject
                        {
                            BackgroundColor = "transparent",
                        },
                        ["a"] = new CSSObject
                        {
                            Color = token.ColorTextDisabled,
                            BackgroundColor = "transparent",
                            Border = "none",
                            Cursor = "not-allowed",
                        },
                        ["&-active"] = new CSSObject
                        {
                            BorderColor = token.ColorBorder,
                            BackgroundColor = token.ItemActiveBgDisabled,
                            ["&:hover, &:active"] = new CSSObject
                            {
                                BackgroundColor = token.ItemActiveBgDisabled,
                            },
                            ["a"] = new CSSObject
                            {
                                Color = token.ItemActiveColorDisabled,
                            },
                        },
                    },
                    [$@"{componentCls}-item-link"] = new CSSObject
                    {
                        Color = token.ColorTextDisabled,
                        Cursor = "not-allowed",
                        ["&:hover, &:active"] = new CSSObject
                        {
                            BackgroundColor = "transparent",
                        },
                        [$@"{componentCls}-simple&"] = new CSSObject
                        {
                            BackgroundColor = "transparent",
                            ["&:hover, &:active"] = new CSSObject
                            {
                                BackgroundColor = "transparent",
                            },
                        },
                    },
                    [$@"{componentCls}-simple-pager"] = new CSSObject
                    {
                        Color = token.ColorTextDisabled,
                    },
                    [$@"{componentCls}-jump-prev, {componentCls}-jump-next"] = new CSSObject
                    {
                        [$@"{componentCls}-item-link-icon"] = new CSSObject
                        {
                            Opacity = 0,
                        },
                        [$@"{componentCls}-item-ellipsis"] = new CSSObject
                        {
                            Opacity = 1,
                        },
                    },
                },
                [$@"{componentCls}-simple"] = new CSSObject
                {
                    [$@"{componentCls}-prev, {componentCls}-next"] = new CSSObject
                    {
                        [$@"{componentCls}-disabled {componentCls}-item-link"] = new CSSObject
                        {
                            ["&:hover, &:active"] = new CSSObject
                            {
                                BackgroundColor = "transparent",
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenPaginationMiniStyle(PaginationToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-mini {componentCls}-total-text, &{componentCls}-mini {componentCls}-simple-pager"] = new CSSObject
                {
                    Height = token.ItemSizeSM,
                    LineHeight = Unit(token.ItemSizeSM),
                },
                [$@"{componentCls}-mini {componentCls}-item"] = new CSSObject
                {
                    MinWidth = token.ItemSizeSM,
                    Height = token.ItemSizeSM,
                    Margin = 0,
                    LineHeight = Unit(token.calc(token.itemSizeSM).sub(2).Equal()),
                },
                [$@"{componentCls}-mini:not({componentCls}-disabled) {componentCls}-item:not({componentCls}-item-active)"] = new CSSObject
                {
                    BackgroundColor = "transparent",
                    BorderColor = "transparent",
                    ["&:hover"] = new CSSObject
                    {
                        BackgroundColor = token.ColorBgTextHover,
                    },
                    ["&:active"] = new CSSObject
                    {
                        BackgroundColor = token.ColorBgTextActive,
                    },
                },
                [$@"{componentCls}-mini {componentCls}-prev, &{componentCls}-mini {componentCls}-next"] = new CSSObject
                {
                    MinWidth = token.ItemSizeSM,
                    Height = token.ItemSizeSM,
                    Margin = 0,
                    LineHeight = Unit(token.ItemSizeSM),
                },
                [$@"{componentCls}-mini:not({componentCls}-disabled)"] = new CSSObject
                {
                    [$@"{componentCls}-prev, {componentCls}-next"] = new CSSObject
                    {
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgTextHover,
                        },
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgTextActive,
                        },
                        [$@"{componentCls}-disabled:hover {componentCls}-item-link"] = new CSSObject
                        {
                            BackgroundColor = "transparent",
                        },
                    },
                },
                [$@"{componentCls}-mini {componentCls}-prev {componentCls}-item-link,
    &{componentCls}-mini {componentCls}-next {componentCls}-item-link
    "] = new CSSObject
                {
                    BackgroundColor = "transparent",
                    BorderColor = "transparent",
                    ["&::after"] = new CSSObject
                    {
                        Height = token.ItemSizeSM,
                        LineHeight = Unit(token.ItemSizeSM),
                    },
                },
                [$@"{componentCls}-mini {componentCls}-jump-prev, &{componentCls}-mini {componentCls}-jump-next"] = new CSSObject
                {
                    Height = token.ItemSizeSM,
                    MarginInlineEnd = 0,
                    LineHeight = Unit(token.ItemSizeSM),
                },
                [$@"{componentCls}-mini {componentCls}-options"] = new CSSObject
                {
                    MarginInlineStart = token.PaginationMiniOptionsMarginInlineStart,
                    ["&-size-changer"] = new CSSObject
                    {
                        Top = token.MiniOptionsSizeChangerTop,
                    },
                    ["&-quick-jumper"] = new CSSObject
                    {
                        Height = token.ItemSizeSM,
                        LineHeight = Unit(token.ItemSizeSM),
                        ["input"] = new CSSObject
                        {
                            ["..."] = GenInputSmallStyle(token),
                            Width = token.PaginationMiniQuickJumperInputWidth,
                            Height = token.ControlHeightSM,
                        },
                    },
                },
            };
        }

        public static CSSObject GenPaginationSimpleStyle(PaginationToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-simple {componentCls}-prev,
    &{componentCls}-simple {componentCls}-next
    "] = new CSSObject
                {
                    Height = token.ItemSizeSM,
                    LineHeight = Unit(token.ItemSizeSM),
                    VerticalAlign = "top",
                    [$@"{componentCls}-item-link"] = new CSSObject
                    {
                        Height = token.ItemSizeSM,
                        BackgroundColor = "transparent",
                        Border = 0,
                        ["&:hover"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgTextHover,
                        },
                        ["&:active"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgTextActive,
                        },
                        ["&::after"] = new CSSObject
                        {
                            Height = token.ItemSizeSM,
                            LineHeight = Unit(token.ItemSizeSM),
                        },
                    },
                },
                [$@"{componentCls}-simple {componentCls}-simple-pager"] = new CSSObject
                {
                    Display = "inline-block",
                    Height = token.ItemSizeSM,
                    MarginInlineEnd = token.MarginXS,
                    ["input"] = new CSSObject
                    {
                        BoxSizing = "border-box",
                        Height = "100%",
                        Padding = $@"{Unit(token.PaginationItemPaddingInline)}",
                        TextAlign = "center",
                        BackgroundColor = token.ItemInputBg,
                        Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                        BorderRadius = token.BorderRadius,
                        Outline = "none",
                        Transition = $@"{token.MotionDurationMid}",
                        Color = "inherit",
                        ["&:hover"] = new CSSObject
                        {
                            BorderColor = token.ColorPrimary,
                        },
                        ["&:focus"] = new CSSObject
                        {
                            BorderColor = token.ColorPrimaryHover,
                            BoxShadow = $@"{Unit(token.InputOutlineOffset)} 0 {Unit(token.ControlOutlineWidth)} {token.ControlOutline}",
                        },
                        ["&[disabled]"] = new CSSObject
                        {
                            Color = token.ColorTextDisabled,
                            BackgroundColor = token.ColorBgContainerDisabled,
                            BorderColor = token.ColorBorder,
                            Cursor = "not-allowed",
                        },
                    },
                },
            };
        }

        public static CSSObject GenPaginationJumpStyle(PaginationToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-jump-prev, {componentCls}-jump-next"] = new CSSObject
                {
                    Outline = 0,
                    [$@"{componentCls}-item-container"] = new CSSObject
                    {
                        Position = "relative",
                        [$@"{componentCls}-item-link-icon"] = new CSSObject
                        {
                            Color = token.ColorPrimary,
                            FontSize = token.FontSizeSM,
                            Opacity = 0,
                            Transition = $@"{token.MotionDurationMid}",
                            ["&-svg"] = new CSSObject
                            {
                                Top = 0,
                                InsetInlineEnd = 0,
                                Bottom = 0,
                                InsetInlineStart = 0,
                                Margin = "auto",
                            },
                        },
                        [$@"{componentCls}-item-ellipsis"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = 0,
                            InsetInlineEnd = 0,
                            Bottom = 0,
                            InsetInlineStart = 0,
                            Display = "block",
                            Margin = "auto",
                            Color = token.ColorTextDisabled,
                            LetterSpacing = token.PaginationEllipsisLetterSpacing,
                            TextAlign = "center",
                            TextIndent = token.PaginationEllipsisTextIndent,
                            Opacity = 1,
                            Transition = $@"{token.MotionDurationMid}",
                        },
                    },
                    ["&:hover"] = new CSSObject
                    {
                        [$@"{componentCls}-item-link-icon"] = new CSSObject
                        {
                            Opacity = 1,
                        },
                        [$@"{componentCls}-item-ellipsis"] = new CSSObject
                        {
                            Opacity = 0,
                        },
                    },
                },
                [$@"{componentCls}-prev,
    {componentCls}-jump-prev,
    {componentCls}-jump-next
    "] = new CSSObject
                {
                    MarginInlineEnd = token.MarginXS,
                },
                [$@"{componentCls}-prev,
    {componentCls}-next,
    {componentCls}-jump-prev,
    {componentCls}-jump-next
    "] = new CSSObject
                {
                    Display = "inline-block",
                    MinWidth = token.ItemSize,
                    Height = token.ItemSize,
                    Color = token.ColorText,
                    FontFamily = token.FontFamily,
                    LineHeight = Unit(token.ItemSize),
                    TextAlign = "center",
                    VerticalAlign = "middle",
                    ListStyle = "none",
                    BorderRadius = token.BorderRadius,
                    Cursor = "pointer",
                    Transition = $@"{token.MotionDurationMid}",
                },
                [$@"{componentCls}-prev, {componentCls}-next"] = new CSSObject
                {
                    Outline = 0,
                    ["button"] = new CSSObject
                    {
                        Color = token.ColorText,
                        Cursor = "pointer",
                        UserSelect = "none",
                    },
                    [$@"{componentCls}-item-link"] = new CSSObject
                    {
                        Display = "block",
                        Width = "100%",
                        Height = "100%",
                        Padding = 0,
                        FontSize = token.FontSizeSM,
                        TextAlign = "center",
                        BackgroundColor = "transparent",
                        Border = $@"{Unit(token.LineWidth)} {token.LineType} transparent",
                        BorderRadius = token.BorderRadius,
                        Outline = "none",
                        Transition = $@"{token.MotionDurationMid}",
                    },
                    [$@"{componentCls}-item-link"] = new CSSObject
                    {
                        BackgroundColor = token.ColorBgTextHover,
                    },
                    [$@"{componentCls}-item-link"] = new CSSObject
                    {
                        BackgroundColor = token.ColorBgTextActive,
                    },
                    [$@"{componentCls}-disabled:hover"] = new CSSObject
                    {
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            BackgroundColor = "transparent",
                        },
                    },
                },
                [$@"{componentCls}-slash"] = new CSSObject
                {
                    MarginInlineEnd = token.PaginationSlashMarginInlineEnd,
                    MarginInlineStart = token.PaginationSlashMarginInlineStart,
                },
                [$@"{componentCls}-options"] = new CSSObject
                {
                    Display = "inline-block",
                    MarginInlineStart = token.Margin,
                    VerticalAlign = "middle",
                    ["&-size-changer"] = new CSSObject
                    {
                        Display = "inline-block",
                        Width = "auto",
                    },
                    ["&-quick-jumper"] = new CSSObject
                    {
                        Display = "inline-block",
                        Height = token.ControlHeight,
                        MarginInlineStart = token.MarginXS,
                        LineHeight = Unit(token.ControlHeight),
                        VerticalAlign = "top",
                        ["input"] = new CSSObject
                        {
                            ["..."] = GenBasicInputStyle(token),
                            ["..."] = GenBaseOutlinedStyle(token, new object { BorderColor = token.ColorBorder, HoverBorderColor = token.ColorPrimaryHover, ActiveBorderColor = token.ColorPrimary, ActiveShadow = token.ActiveShadow, }),
                            ["&[disabled]"] = new CSSObject
                            {
                                ["..."] = GenDisabledStyle(token),
                            },
                            Width = token.calc(token.controlHeightLG).mul(1.25).Equal(),
                            Height = token.ControlHeight,
                            BoxSizing = "border-box",
                            Margin = 0,
                            MarginInlineStart = token.MarginXS,
                            MarginInlineEnd = token.MarginXS,
                        },
                    },
                },
            };
        }

        public static CSSObject GenPaginationItemStyle(PaginationToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-item"] = new CSSObject
                {
                    Display = "inline-block",
                    MinWidth = token.ItemSize,
                    Height = token.ItemSize,
                    MarginInlineEnd = token.MarginXS,
                    FontFamily = token.FontFamily,
                    LineHeight = Unit(token.calc(token.itemSize).sub(2).Equal()),
                    TextAlign = "center",
                    VerticalAlign = "middle",
                    ListStyle = "none",
                    BackgroundColor = token.ItemBg,
                    Border = $@"{Unit(token.LineWidth)} {token.LineType} transparent",
                    BorderRadius = token.BorderRadius,
                    Outline = 0,
                    Cursor = "pointer",
                    UserSelect = "none",
                    ["a"] = new CSSObject
                    {
                        Display = "block",
                        Padding = $@"{Unit(token.PaginationItemPaddingInline)}",
                        Color = token.ColorText,
                        ["&:hover"] = new CSSObject
                        {
                            TextDecoration = "none",
                        },
                    },
                    [$@"{componentCls}-item-active)"] = new CSSObject
                    {
                        ["&:hover"] = new CSSObject
                        {
                            Transition = $@"{token.MotionDurationMid}",
                            BackgroundColor = token.ColorBgTextHover,
                        },
                        ["&:active"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgTextActive,
                        },
                    },
                    ["&-active"] = new CSSObject
                    {
                        FontWeight = token.FontWeightStrong,
                        BackgroundColor = token.ItemActiveBg,
                        BorderColor = token.ColorPrimary,
                        ["a"] = new CSSObject
                        {
                            Color = token.ColorPrimary,
                        },
                        ["&:hover"] = new CSSObject
                        {
                            BorderColor = token.ColorPrimaryHover,
                        },
                        ["&:hover a"] = new CSSObject
                        {
                            Color = token.ColorPrimaryHover,
                        },
                    },
                },
            };
        }

        public static CSSObject GenPaginationStyle(PaginationToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "flex",
                    ["&-start"] = new CSSObject
                    {
                        JustifyContent = "start",
                    },
                    ["&-center"] = new CSSObject
                    {
                        JustifyContent = "center",
                    },
                    ["&-end"] = new CSSObject
                    {
                        JustifyContent = "end",
                    },
                    ["ul, ol"] = new CSSObject
                    {
                        Margin = 0,
                        Padding = 0,
                        ListStyle = "none",
                    },
                    ["&::after"] = new CSSObject
                    {
                        Display = "block",
                        Clear = "both",
                        Height = 0,
                        Overflow = "hidden",
                        Visibility = "hidden",
                        Content = "\"\"",
                    },
                    [$@"{componentCls}-total-text"] = new CSSObject
                    {
                        Display = "inline-block",
                        Height = token.ItemSize,
                        MarginInlineEnd = token.MarginXS,
                        LineHeight = Unit(token.calc(token.itemSize).sub(2).Equal()),
                        VerticalAlign = "middle",
                    },
                    ["..."] = GenPaginationItemStyle(token),
                    ["..."] = GenPaginationJumpStyle(token),
                    ["..."] = GenPaginationSimpleStyle(token),
                    ["..."] = GenPaginationMiniStyle(token),
                    ["..."] = GenPaginationDisabledStyle(token),
                    [$@"{token.ScreenLG}px)"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            ["&-after-jump-prev, &-before-jump-next"] = new CSSObject
                            {
                                Display = "none",
                            },
                        },
                    },
                    [$@"{token.ScreenSM}px)"] = new CSSObject
                    {
                        [$@"{componentCls}-options"] = new CSSObject
                        {
                            Display = "none",
                        },
                    },
                },
                [$@"{token.ComponentCls}-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                },
            };
        }

        public static CSSObject GenPaginationFocusStyle(PaginationToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}:not({componentCls}-disabled)"] = new CSSObject
                {
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        ["..."] = GenFocusStyle(token),
                    },
                    [$@"{componentCls}-jump-prev, {componentCls}-jump-next"] = new CSSObject
                    {
                        ["&:focus-visible"] = new CSSObject
                        {
                            [$@"{componentCls}-item-link-icon"] = new CSSObject
                            {
                                Opacity = 1,
                            },
                            [$@"{componentCls}-item-ellipsis"] = new CSSObject
                            {
                                Opacity = 0,
                            },
                            ["..."] = GenFocusOutline(token),
                        },
                    },
                    [$@"{componentCls}-prev, {componentCls}-next"] = new CSSObject
                    {
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            ["..."] = GenFocusOutline(token),
                        },
                    },
                },
            };
        }

        public static PaginationToken PrepareComponentToken(PaginationToken token)
        {
            return new PaginationToken
            {
                ItemBg = token.ColorBgContainer,
                ItemSize = token.ControlHeight,
                ItemSizeSM = token.ControlHeightSM,
                ItemActiveBg = token.ColorBgContainer,
                ItemLinkBg = token.ColorBgContainer,
                ItemActiveColorDisabled = token.ColorTextDisabled,
                ItemActiveBgDisabled = token.ControlItemBgActiveDisabled,
                ItemInputBg = token.ColorBgContainer,
                MiniOptionsSizeChangerTop = 0,
                ["..."] = InitComponentToken(token),
            };
        }

        public static object PrepareToken(Parameters<GenStyleFn< 'Pagination' >>[0] token)
        {
            return MergeToken(token, new object { InputOutlineOffset = 0, PaginationMiniOptionsMarginInlineStart = token.calc(token.marginXXS).div(2).Equal(), PaginationMiniQuickJumperInputWidth = token.calc(token.controlHeightLG).mul(1.1).Equal(), PaginationItemPaddingInline = token.calc(token.marginXXS).mul(1.5).Equal(), PaginationEllipsisLetterSpacing = token.calc(token.marginXXS).div(2).Equal(), PaginationSlashMarginInlineStart = token.MarginSM, PaginationSlashMarginInlineEnd = token.MarginSM, PaginationEllipsisTextIndent = "0.13em", }, InitInputToken(token));
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Pagination", (PaginationToken token) =>
            {
                var paginationToken = PrepareToken(token);
                return new object[]
                {
                    GenPaginationStyle(paginationToken),
                    GenPaginationFocusStyle(paginationToken)
                };
            }, prepareComponentToken);
        }
    }
}