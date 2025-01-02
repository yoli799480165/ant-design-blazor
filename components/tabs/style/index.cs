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
    public partial class TabsStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ZIndexPopup { get; set; }
            public string CardBg { get; set; }
            public string CardHeight { get; set; }
            public string CardPadding { get; set; }
            public string CardPaddingSM { get; set; }
            public string CardPaddingLG { get; set; }
            public double TitleFontSize { get; set; }
            public double TitleFontSizeLG { get; set; }
            public double TitleFontSizeSM { get; set; }
            public string InkBarColor { get; set; }
            public string HorizontalMargin { get; set; }
            public double HorizontalItemGutter { get; set; }
            public string HorizontalItemMargin { get; set; }
            public string HorizontalItemMarginRTL { get; set; }
            public string HorizontalItemPadding { get; set; }
            public string HorizontalItemPaddingLG { get; set; }
            public string HorizontalItemPaddingSM { get; set; }
            public string VerticalItemPadding { get; set; }
            public string VerticalItemMargin { get; set; }
            public string ItemColor { get; set; }
            public string ItemActiveColor { get; set; }
            public string ItemHoverColor { get; set; }
            public string ItemSelectedColor { get; set; }
            public double CardGutter { get; set; }
        }

        public class TabsToken : ComponentToken
        {
            public string TabsCardPadding { get; set; }
            public double DropdownEdgeChildVerticalPadding { get; set; }
            public double TabsNavWrapPseudoWidth { get; set; }
            public string TabsActiveTextShadow { get; set; }
            public string TabsDropdownHeight { get; set; }
            public string TabsDropdownWidth { get; set; }
            public string TabsHorizontalItemMargin { get; set; }
            public string TabsHorizontalItemMarginRTL { get; set; }
        }

        public static CSSObject GenCardStyle(TabsToken token)
        {
            var componentCls = token.ComponentCls;
            var tabsCardPadding = token.TabsCardPadding;
            var cardBg = token.CardBg;
            var cardGutter = token.CardGutter;
            var colorBorderSecondary = token.ColorBorderSecondary;
            var itemSelectedColor = token.ItemSelectedColor;
            return new CSSObject
            {
                [$@"{componentCls}-card"] = new CSSObject
                {
                    [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                    {
                        [$@"{componentCls}-tab"] = new CSSObject
                        {
                            Margin = 0,
                            Padding = tabsCardPadding,
                            Background = cardBg,
                            Border = $@"{Unit(token.LineWidth)} {token.LineType} {colorBorderSecondary}",
                            Transition = $@"{token.MotionDurationSlow} {token.MotionEaseInOut}",
                        },
                        [$@"{componentCls}-tab-active"] = new CSSObject
                        {
                            Color = itemSelectedColor,
                            Background = token.ColorBgContainer,
                        },
                        [$@"{componentCls}-ink-bar"] = new CSSObject
                        {
                            Visibility = "hidden",
                        },
                    },
                    [$@"{componentCls}-top, &{componentCls}-bottom"] = new CSSObject
                    {
                        [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab + {componentCls}-tab"] = new CSSObject
                            {
                                MarginLeft = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = Unit(cardGutter),
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-top"] = new CSSObject
                    {
                        [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab"] = new CSSObject
                            {
                                BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)} 0 0",
                            },
                            [$@"{componentCls}-tab-active"] = new CSSObject
                            {
                                BorderBottomColor = token.ColorBgContainer,
                            },
                        },
                    },
                    [$@"{componentCls}-bottom"] = new CSSObject
                    {
                        [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab"] = new CSSObject
                            {
                                BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)}",
                            },
                            [$@"{componentCls}-tab-active"] = new CSSObject
                            {
                                BorderTopColor = token.ColorBgContainer,
                            },
                        },
                    },
                    [$@"{componentCls}-left, &{componentCls}-right"] = new CSSObject
                    {
                        [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab + {componentCls}-tab"] = new CSSObject
                            {
                                MarginTop = Unit(cardGutter),
                            },
                        },
                    },
                    [$@"{componentCls}-left"] = new CSSObject
                    {
                        [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab"] = new CSSObject
                            {
                                BorderRadius = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = $@"{Unit(token.BorderRadiusLG)} 0 0 {Unit(token.BorderRadiusLG)}",
                                },
                            },
                            [$@"{componentCls}-tab-active"] = new CSSObject
                            {
                                BorderRightColor = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = token.ColorBgContainer,
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-right"] = new CSSObject
                    {
                        [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab"] = new CSSObject
                            {
                                BorderRadius = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)} 0",
                                },
                            },
                            [$@"{componentCls}-tab-active"] = new CSSObject
                            {
                                BorderLeftColor = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = token.ColorBgContainer,
                                },
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenDropdownStyle(TabsToken token)
        {
            var componentCls = token.ComponentCls;
            var itemHoverColor = token.ItemHoverColor;
            var dropdownEdgeChildVerticalPadding = token.DropdownEdgeChildVerticalPadding;
            return new CSSObject
            {
                [$@"{componentCls}-dropdown"] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "absolute",
                    Top = -9999,
                    Left = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = -9999,
                    },
                    ZIndex = token.ZIndexPopup,
                    Display = "block",
                    ["&-hidden"] = new CSSObject
                    {
                        Display = "none",
                    },
                    [$@"{componentCls}-dropdown-menu"] = new CSSObject
                    {
                        MaxHeight = token.TabsDropdownHeight,
                        Margin = 0,
                        Padding = $@"{Unit(dropdownEdgeChildVerticalPadding)} 0",
                        OverflowX = "hidden",
                        OverflowY = "auto",
                        TextAlign = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = "left",
                        },
                        ListStyleType = "none",
                        BackgroundColor = token.ColorBgContainer,
                        BackgroundClip = "padding-box",
                        BorderRadius = token.BorderRadiusLG,
                        Outline = "none",
                        BoxShadow = token.BoxShadowSecondary,
                        ["&-item"] = new CSSObject
                        {
                            ["..."] = textEllipsis,
                            Display = "flex",
                            AlignItems = "center",
                            MinWidth = token.TabsDropdownWidth,
                            Margin = 0,
                            Padding = $@"{Unit(token.PaddingXXS)} {Unit(token.PaddingSM)}",
                            Color = token.ColorText,
                            FontWeight = "normal",
                            FontSize = token.FontSize,
                            LineHeight = token.LineHeight,
                            Cursor = "pointer",
                            Transition = $@"{token.MotionDurationSlow}",
                            ["> span"] = new CSSObject
                            {
                                Flex = 1,
                                WhiteSpace = "nowrap",
                            },
                            ["&-remove"] = new CSSObject
                            {
                                Flex = "none",
                                MarginLeft = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = token.MarginSM,
                                },
                                Color = token.ColorTextDescription,
                                FontSize = token.FontSizeSM,
                                Background = "transparent",
                                Border = 0,
                                Cursor = "pointer",
                                ["&:hover"] = new CSSObject
                                {
                                    Color = itemHoverColor,
                                },
                            },
                            ["&:hover"] = new CSSObject
                            {
                                Background = token.ControlItemBgHover,
                            },
                            ["&-disabled"] = new CSSObject
                            {
                                ["&, &:hover"] = new CSSObject
                                {
                                    Color = token.ColorTextDisabled,
                                    Background = "transparent",
                                    Cursor = "not-allowed",
                                },
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenPositionStyle(TabsToken token)
        {
            var componentCls = token.ComponentCls;
            var margin = token.Margin;
            var colorBorderSecondary = token.ColorBorderSecondary;
            var horizontalMargin = token.HorizontalMargin;
            var verticalItemPadding = token.VerticalItemPadding;
            var verticalItemMargin = token.VerticalItemMargin;
            var calc = token.Calc;
            return new CSSObject
            {
                [$@"{componentCls}-top, {componentCls}-bottom"] = new CSSObject
                {
                    FlexDirection = "column",
                    [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                    {
                        Margin = horizontalMargin,
                        ["&::before"] = new CSSObject
                        {
                            Position = "absolute",
                            Right = new CSSObject
                            {
                                _skip_check_ = true,
                                Value = 0,
                            },
                            Left = new CSSObject
                            {
                                _skip_check_ = true,
                                Value = 0,
                            },
                            BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {colorBorderSecondary}",
                            Content = "''",
                        },
                        [$@"{componentCls}-ink-bar"] = new CSSObject
                        {
                            Height = token.LineWidthBold,
                            ["&-animated"] = new CSSObject
                            {
                                Transition = $@"{token.MotionDurationSlow}, left {token.MotionDurationSlow},
            right {token.MotionDurationSlow}",
                            },
                        },
                        [$@"{componentCls}-nav-wrap"] = new CSSObject
                        {
                            ["&::before, &::after"] = new CSSObject
                            {
                                Top = 0,
                                Bottom = 0,
                                Width = token.ControlHeight,
                            },
                            ["&::before"] = new CSSObject
                            {
                                Left = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = 0,
                                },
                                BoxShadow = token.BoxShadowTabsOverflowLeft,
                            },
                            ["&::after"] = new CSSObject
                            {
                                Right = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = 0,
                                },
                                BoxShadow = token.BoxShadowTabsOverflowRight,
                            },
                            [$@"{componentCls}-nav-wrap-ping-left::before"] = new CSSObject
                            {
                                Opacity = 1,
                            },
                            [$@"{componentCls}-nav-wrap-ping-right::after"] = new CSSObject
                            {
                                Opacity = 1,
                            },
                        },
                    },
                },
                [$@"{componentCls}-top"] = new CSSObject
                {
                    [$@"{componentCls}-nav,
        > div > {componentCls}-nav"] = new CSSObject
                    {
                        ["&::before"] = new CSSObject
                        {
                            Bottom = 0,
                        },
                        [$@"{componentCls}-ink-bar"] = new CSSObject
                        {
                            Bottom = 0,
                        },
                    },
                },
                [$@"{componentCls}-bottom"] = new CSSObject
                {
                    [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                    {
                        Order = 1,
                        MarginTop = margin,
                        MarginBottom = 0,
                        ["&::before"] = new CSSObject
                        {
                            Top = 0,
                        },
                        [$@"{componentCls}-ink-bar"] = new CSSObject
                        {
                            Top = 0,
                        },
                    },
                    [$@"{componentCls}-content-holder, > div > {componentCls}-content-holder"] = new CSSObject
                    {
                        Order = 0,
                    },
                },
                [$@"{componentCls}-left, {componentCls}-right"] = new CSSObject
                {
                    [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                    {
                        FlexDirection = "column",
                        MinWidth = calc(token.controlHeight).mul(1.25).Equal(),
                        [$@"{componentCls}-tab"] = new CSSObject
                        {
                            Padding = verticalItemPadding,
                            TextAlign = "center",
                        },
                        [$@"{componentCls}-tab + {componentCls}-tab"] = new CSSObject
                        {
                            Margin = verticalItemMargin,
                        },
                        [$@"{componentCls}-nav-wrap"] = new CSSObject
                        {
                            FlexDirection = "column",
                            ["&::before, &::after"] = new CSSObject
                            {
                                Right = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = 0,
                                },
                                Left = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = 0,
                                },
                                Height = token.ControlHeight,
                            },
                            ["&::before"] = new CSSObject
                            {
                                Top = 0,
                                BoxShadow = token.BoxShadowTabsOverflowTop,
                            },
                            ["&::after"] = new CSSObject
                            {
                                Bottom = 0,
                                BoxShadow = token.BoxShadowTabsOverflowBottom,
                            },
                            [$@"{componentCls}-nav-wrap-ping-top::before"] = new CSSObject
                            {
                                Opacity = 1,
                            },
                            [$@"{componentCls}-nav-wrap-ping-bottom::after"] = new CSSObject
                            {
                                Opacity = 1,
                            },
                        },
                        [$@"{componentCls}-ink-bar"] = new CSSObject
                        {
                            Width = token.LineWidthBold,
                            ["&-animated"] = new CSSObject
                            {
                                Transition = $@"{token.MotionDurationSlow}, top {token.MotionDurationSlow}",
                            },
                        },
                        [$@"{componentCls}-nav-list, {componentCls}-nav-operations"] = new CSSObject
                        {
                            Flex = "1 0 auto",
                            FlexDirection = "column",
                        },
                    },
                },
                [$@"{componentCls}-left"] = new CSSObject
                {
                    [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                    {
                        [$@"{componentCls}-ink-bar"] = new CSSObject
                        {
                            Right = new CSSObject
                            {
                                _skip_check_ = true,
                                Value = 0,
                            },
                        },
                    },
                    [$@"{componentCls}-content-holder, > div > {componentCls}-content-holder"] = new CSSObject
                    {
                        MarginLeft = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = Unit(calc(token.lineWidth).mul(-1).Equal()),
                        },
                        BorderLeft = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                        },
                        [$@"{componentCls}-content > {componentCls}-tabpane"] = new CSSObject
                        {
                            PaddingLeft = new CSSObject
                            {
                                _skip_check_ = true,
                                Value = token.PaddingLG,
                            },
                        },
                    },
                },
                [$@"{componentCls}-right"] = new CSSObject
                {
                    [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                    {
                        Order = 1,
                        [$@"{componentCls}-ink-bar"] = new CSSObject
                        {
                            Left = new CSSObject
                            {
                                _skip_check_ = true,
                                Value = 0,
                            },
                        },
                    },
                    [$@"{componentCls}-content-holder, > div > {componentCls}-content-holder"] = new CSSObject
                    {
                        Order = 0,
                        MarginRight = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = calc(token.lineWidth).mul(-1).Equal(),
                        },
                        BorderRight = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                        },
                        [$@"{componentCls}-content > {componentCls}-tabpane"] = new CSSObject
                        {
                            PaddingRight = new CSSObject
                            {
                                _skip_check_ = true,
                                Value = token.PaddingLG,
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenSizeStyle(TabsToken token)
        {
            var componentCls = token.ComponentCls;
            var cardPaddingSM = token.CardPaddingSM;
            var cardPaddingLG = token.CardPaddingLG;
            var horizontalItemPaddingSM = token.HorizontalItemPaddingSM;
            var horizontalItemPaddingLG = token.HorizontalItemPaddingLG;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["&-small"] = new CSSObject
                    {
                        [$@"{componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab"] = new CSSObject
                            {
                                Padding = horizontalItemPaddingSM,
                                FontSize = token.TitleFontSizeSM,
                            },
                        },
                    },
                    ["&-large"] = new CSSObject
                    {
                        [$@"{componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab"] = new CSSObject
                            {
                                Padding = horizontalItemPaddingLG,
                                FontSize = token.TitleFontSizeLG,
                            },
                        },
                    },
                },
                [$@"{componentCls}-card"] = new CSSObject
                {
                    [$@"{componentCls}-small"] = new CSSObject
                    {
                        [$@"{componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab"] = new CSSObject
                            {
                                Padding = cardPaddingSM,
                            },
                        },
                        [$@"{componentCls}-bottom"] = new CSSObject
                        {
                            [$@"{componentCls}-nav {componentCls}-tab"] = new CSSObject
                            {
                                BorderRadius = $@"{Unit(token.BorderRadius)} {Unit(token.BorderRadius)}",
                            },
                        },
                        [$@"{componentCls}-top"] = new CSSObject
                        {
                            [$@"{componentCls}-nav {componentCls}-tab"] = new CSSObject
                            {
                                BorderRadius = $@"{Unit(token.BorderRadius)} {Unit(token.BorderRadius)} 0 0",
                            },
                        },
                        [$@"{componentCls}-right"] = new CSSObject
                        {
                            [$@"{componentCls}-nav {componentCls}-tab"] = new CSSObject
                            {
                                BorderRadius = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = $@"{Unit(token.BorderRadius)} {Unit(token.BorderRadius)} 0",
                                },
                            },
                        },
                        [$@"{componentCls}-left"] = new CSSObject
                        {
                            [$@"{componentCls}-nav {componentCls}-tab"] = new CSSObject
                            {
                                BorderRadius = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = $@"{Unit(token.BorderRadius)} 0 0 {Unit(token.BorderRadius)}",
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-large"] = new CSSObject
                    {
                        [$@"{componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab"] = new CSSObject
                            {
                                Padding = cardPaddingLG,
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenTabStyle(TabsToken token)
        {
            var componentCls = token.ComponentCls;
            var itemActiveColor = token.ItemActiveColor;
            var itemHoverColor = token.ItemHoverColor;
            var iconCls = token.IconCls;
            var tabsHorizontalItemMargin = token.TabsHorizontalItemMargin;
            var horizontalItemPadding = token.HorizontalItemPadding;
            var itemSelectedColor = token.ItemSelectedColor;
            var itemColor = token.ItemColor;
            var tabCls = $@"{componentCls}-tab";
            return new CSSObject
            {
                [tabCls] = new CSSObject
                {
                    Position = "relative",
                    WebkitTouchCallout = "none",
                    WebkitTapHighlightColor = "transparent",
                    Display = "inline-flex",
                    AlignItems = "center",
                    Padding = horizontalItemPadding,
                    FontSize = token.TitleFontSize,
                    Background = "transparent",
                    Border = 0,
                    Outline = "none",
                    Cursor = "pointer",
                    Color = itemColor,
                    ["&-btn, &-remove"] = new CSSObject
                    {
                        ["&:focus:not(:focus-visible), &:active"] = new CSSObject
                        {
                            Color = itemActiveColor,
                        },
                        ["..."] = GenFocusStyle(token),
                    },
                    ["&-btn"] = new CSSObject
                    {
                        Outline = "none",
                        Transition = $@"{token.MotionDurationSlow}",
                        [$@"{tabCls}-icon:not(:last-child)"] = new CSSObject
                        {
                            MarginInlineEnd = token.MarginSM,
                        },
                    },
                    ["&-remove"] = new CSSObject
                    {
                        Flex = "none",
                        MarginRight = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = token.calc(token.marginXXS).mul(-1).Equal(),
                        },
                        MarginLeft = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = token.MarginXS,
                        },
                        Color = token.ColorTextDescription,
                        FontSize = token.FontSizeSM,
                        Background = "transparent",
                        Border = "none",
                        Outline = "none",
                        Cursor = "pointer",
                        Transition = $@"{token.MotionDurationSlow}",
                        ["&:hover"] = new CSSObject
                        {
                            Color = token.ColorTextHeading,
                        },
                    },
                    ["&:hover"] = new CSSObject
                    {
                        Color = itemHoverColor,
                    },
                    [$@"{tabCls}-active {tabCls}-btn"] = new CSSObject
                    {
                        Color = itemSelectedColor,
                        TextShadow = token.TabsActiveTextShadow,
                    },
                    [$@"{tabCls}-disabled"] = new CSSObject
                    {
                        Color = token.ColorTextDisabled,
                        Cursor = "not-allowed",
                    },
                    [$@"{tabCls}-disabled {tabCls}-btn, &{tabCls}-disabled {componentCls}-remove"] = new CSSObject
                    {
                        ["&:focus, &:active"] = new CSSObject
                        {
                            Color = token.ColorTextDisabled,
                        },
                    },
                    [$@"{tabCls}-remove {iconCls}"] = new CSSObject
                    {
                        Margin = 0,
                    },
                    [$@"{iconCls}:not(:last-child)"] = new CSSObject
                    {
                        MarginRight = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = token.MarginSM,
                        },
                    },
                },
                [$@"{tabCls} + {tabCls}"] = new CSSObject
                {
                    Margin = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = tabsHorizontalItemMargin,
                    },
                },
            };
        }

        public static CSSObject GenRtlStyle(TabsToken token)
        {
            var componentCls = token.ComponentCls;
            var tabsHorizontalItemMarginRTL = token.TabsHorizontalItemMarginRTL;
            var iconCls = token.IconCls;
            var cardGutter = token.CardGutter;
            var calc = token.Calc;
            var rtlCls = $@"{componentCls}-rtl";
            return new CSSObject
            {
                [rtlCls] = new CSSObject
                {
                    Direction = "rtl",
                    [$@"{componentCls}-nav"] = new CSSObject
                    {
                        [$@"{componentCls}-tab"] = new CSSObject
                        {
                            Margin = new CSSObject
                            {
                                _skip_check_ = true,
                                Value = tabsHorizontalItemMarginRTL,
                            },
                            [$@"{componentCls}-tab:last-of-type"] = new CSSObject
                            {
                                MarginLeft = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = 0,
                                },
                            },
                            [iconCls] = new CSSObject
                            {
                                MarginRight = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = 0,
                                },
                                MarginLeft = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = Unit(token.MarginSM),
                                },
                            },
                            [$@"{componentCls}-tab-remove"] = new CSSObject
                            {
                                MarginRight = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = Unit(token.MarginXS),
                                },
                                MarginLeft = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = Unit(calc(token.marginXXS).mul(-1).Equal()),
                                },
                                [iconCls] = new CSSObject
                                {
                                    Margin = 0,
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-left"] = new CSSObject
                    {
                        [$@"{componentCls}-nav"] = new CSSObject
                        {
                            Order = 1,
                        },
                        [$@"{componentCls}-content-holder"] = new CSSObject
                        {
                            Order = 0,
                        },
                    },
                    [$@"{componentCls}-right"] = new CSSObject
                    {
                        [$@"{componentCls}-nav"] = new CSSObject
                        {
                            Order = 0,
                        },
                        [$@"{componentCls}-content-holder"] = new CSSObject
                        {
                            Order = 1,
                        },
                    },
                    [$@"{componentCls}-card{componentCls}-top, &{componentCls}-card{componentCls}-bottom"] = new CSSObject
                    {
                        [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                        {
                            [$@"{componentCls}-tab + {componentCls}-tab"] = new CSSObject
                            {
                                MarginRight = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = cardGutter,
                                },
                                MarginLeft = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = 0,
                                },
                            },
                        },
                    },
                },
                [$@"{componentCls}-dropdown-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                },
                [$@"{componentCls}-menu-item"] = new CSSObject
                {
                    [$@"{componentCls}-dropdown-rtl"] = new CSSObject
                    {
                        TextAlign = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = "right",
                        },
                    },
                },
            };
        }

        public static CSSObject GenTabsStyle(TabsToken token)
        {
            var componentCls = token.ComponentCls;
            var tabsCardPadding = token.TabsCardPadding;
            var cardHeight = token.CardHeight;
            var cardGutter = token.CardGutter;
            var itemHoverColor = token.ItemHoverColor;
            var itemActiveColor = token.ItemActiveColor;
            var colorBorderSecondary = token.ColorBorderSecondary;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "flex",
                    [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "flex",
                        Flex = "none",
                        AlignItems = "center",
                        [$@"{componentCls}-nav-wrap"] = new CSSObject
                        {
                            Position = "relative",
                            Display = "flex",
                            Flex = "auto",
                            AlignSelf = "stretch",
                            Overflow = "hidden",
                            WhiteSpace = "nowrap",
                            Transform = "translate(0)",
                            ["&::before, &::after"] = new CSSObject
                            {
                                Position = "absolute",
                                ZIndex = 1,
                                Opacity = 0,
                                Transition = $@"{token.MotionDurationSlow}",
                                Content = "''",
                                PointerEvents = "none",
                            },
                        },
                        [$@"{componentCls}-nav-list"] = new CSSObject
                        {
                            Position = "relative",
                            Display = "flex",
                            Transition = $@"{token.MotionDurationSlow}",
                        },
                        [$@"{componentCls}-nav-operations"] = new CSSObject
                        {
                            Display = "flex",
                            AlignSelf = "stretch",
                        },
                        [$@"{componentCls}-nav-operations-hidden"] = new CSSObject
                        {
                            Position = "absolute",
                            Visibility = "hidden",
                            PointerEvents = "none",
                        },
                        [$@"{componentCls}-nav-more"] = new CSSObject
                        {
                            Position = "relative",
                            Padding = tabsCardPadding,
                            Background = "transparent",
                            Border = 0,
                            Color = token.ColorText,
                            ["&::after"] = new CSSObject
                            {
                                Position = "absolute",
                                Right = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = 0,
                                },
                                Bottom = 0,
                                Left = new CSSObject
                                {
                                    _skip_check_ = true,
                                    Value = 0,
                                },
                                Height = token.calc(token.controlHeightLG).div(8).Equal(),
                                Transform = "translateY(100%)",
                                Content = "''",
                            },
                        },
                        [$@"{componentCls}-nav-add"] = new CSSObject
                        {
                            MinWidth = cardHeight,
                            MarginLeft = new CSSObject
                            {
                                _skip_check_ = true,
                                Value = cardGutter,
                            },
                            Padding = Unit(token.PaddingXS),
                            Background = "transparent",
                            Border = $@"{Unit(token.LineWidth)} {token.LineType} {colorBorderSecondary}",
                            BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)} 0 0",
                            Outline = "none",
                            Cursor = "pointer",
                            Color = token.ColorText,
                            Transition = $@"{token.MotionDurationSlow} {token.MotionEaseInOut}",
                            ["&:hover"] = new CSSObject
                            {
                                Color = itemHoverColor,
                            },
                            ["&:active, &:focus:not(:focus-visible)"] = new CSSObject
                            {
                                Color = itemActiveColor,
                            },
                            ["..."] = GenFocusStyle(token),
                        },
                    },
                    [$@"{componentCls}-extra-content"] = new CSSObject
                    {
                        Flex = "none",
                    },
                    [$@"{componentCls}-ink-bar"] = new CSSObject
                    {
                        Position = "absolute",
                        Background = token.InkBarColor,
                        PointerEvents = "none",
                    },
                    ["..."] = GenTabStyle(token),
                    [$@"{componentCls}-content"] = new CSSObject
                    {
                        Position = "relative",
                        Width = "100%",
                    },
                    [$@"{componentCls}-content-holder"] = new CSSObject
                    {
                        Flex = "auto",
                        MinWidth = 0,
                        MinHeight = 0,
                    },
                    [$@"{componentCls}-tabpane"] = new CSSObject
                    {
                        Outline = "none",
                        ["&-hidden"] = new CSSObject
                        {
                            Display = "none",
                        },
                    },
                },
                [$@"{componentCls}-centered"] = new CSSObject
                {
                    [$@"{componentCls}-nav, > div > {componentCls}-nav"] = new CSSObject
                    {
                        [$@"{componentCls}-nav-wrap"] = new CSSObject
                        {
                            [$@"{componentCls}-nav-wrap-ping']) > {componentCls}-nav-list"] = new CSSObject
                            {
                                Margin = "auto",
                            },
                        },
                    },
                },
            };
        }

        public static TabsToken PrepareComponentToken(TabsToken token)
        {
            var cardHeight = token.ControlHeightLG;
            return new TabsToken
            {
                ZIndexPopup = token.ZIndexPopupBase + 50,
                CardBg = token.ColorFillAlter,
                CardPadding = $@"{(cardHeight - Math.Round(token.FontSize * token.LineHeight)) / 2 - token.LineWidth}px {token.Padding}px",
                CardPaddingSM = $@"{token.PaddingXXS * 1.5}px {token.Padding}px",
                CardPaddingLG = $@"{token.PaddingXS}px {token.Padding}px {token.PaddingXXS * 1.5}px",
                TitleFontSize = token.FontSize,
                TitleFontSizeLG = token.FontSizeLG,
                TitleFontSizeSM = token.FontSize,
                InkBarColor = token.ColorPrimary,
                HorizontalMargin = $@"{token.Margin}px 0",
                HorizontalItemGutter = 32,
                HorizontalItemMargin = "",
                HorizontalItemMarginRTL = "",
                HorizontalItemPadding = $@"{token.PaddingSM}px 0",
                HorizontalItemPaddingSM = $@"{token.PaddingXS}px 0",
                HorizontalItemPaddingLG = $@"{token.Padding}px 0",
                VerticalItemPadding = $@"{token.PaddingXS}px {token.PaddingLG}px",
                VerticalItemMargin = $@"{token.Margin}px 0 0 0",
                ItemColor = token.ColorText,
                ItemSelectedColor = token.ColorPrimary,
                ItemHoverColor = token.ColorPrimaryHover,
                ItemActiveColor = token.ColorPrimaryActive,
                CardGutter = token.MarginXXS / 2,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Tabs", (TabsToken token) =>
            {
                var tabsToken = MergeToken(token, new object { TabsCardPadding = token.CardPadding, DropdownEdgeChildVerticalPadding = token.PaddingXXS, TabsActiveTextShadow = "0 0 0.25px currentcolor", TabsDropdownHeight = 200, TabsDropdownWidth = 120, TabsHorizontalItemMargin = $@"{Unit(token.HorizontalItemGutter)}", TabsHorizontalItemMarginRTL = $@"{Unit(token.HorizontalItemGutter)}", });
                return new object[]
                {
                    GenSizeStyle(tabsToken),
                    GenRtlStyle(tabsToken),
                    GenPositionStyle(tabsToken),
                    GenDropdownStyle(tabsToken),
                    GenCardStyle(tabsToken),
                    GenTabsStyle(tabsToken),
                    GenMotionStyle(tabsToken)
                };
            }, prepareComponentToken);
        }
    }
}