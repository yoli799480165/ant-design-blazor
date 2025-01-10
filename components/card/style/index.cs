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
    public partial class CardStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string HeaderBg { get; set; }
            public string HeaderFontSize { get; set; }
            public string HeaderFontSizeSM { get; set; }
            public string HeaderHeight { get; set; }
            public string HeaderHeightSM { get; set; }
            public double BodyPaddingSM { get; set; }
            public double HeaderPaddingSM { get; set; }
            public double BodyPadding { get; set; }
            public double HeaderPadding { get; set; }
            public string ActionsBg { get; set; }
            public string ActionsLiMargin { get; set; }
            public double TabsMarginBottom { get; set; }
            public string ExtraColor { get; set; }
        }

        public class CardToken : ComponentToken
        {
            public string CardShadow { get; set; }
            public double CardHeadPadding { get; set; }
            public double CardPaddingBase { get; set; }
            public double CardActionsIconSize { get; set; }
        }

        public static CSSObject GenCardHeadStyle(CardToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var headerHeight = token.HeaderHeight;
            var headerPadding = token.HeaderPadding;
            var tabsMarginBottom = token.TabsMarginBottom;
            return new CSSObject
            {
                Display = "flex",
                JustifyContent = "center",
                FlexDirection = "column",
                MinHeight = headerHeight,
                MarginBottom = -1,
                Padding = $@"{Unit(headerPadding)}",
                Color = token.ColorTextHeading,
                FontWeight = token.FontWeightStrong,
                FontSize = token.HeaderFontSize,
                Background = token.HeaderBg,
                BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorderSecondary}",
                BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)} 0 0",
                ["..."] = ClearFix(),
                ["&-wrapper"] = new CSSObject
                {
                    Width = "100%",
                    Display = "flex",
                    AlignItems = "center",
                },
                ["&-title"] = new CSSObject
                {
                    Display = "inline-block",
                    Flex = 1,
                    ["..."] = textEllipsis,
                    [$@"{componentCls}-typography,
          > {componentCls}-typography-edit-content
        "] = new CSSObject
                    {
                        InsetInlineStart = 0,
                        MarginTop = 0,
                        MarginBottom = 0,
                    },
                },
                [$@"{antCls}-tabs-top"] = new CSSObject
                {
                    Clear = "both",
                    MarginBottom = tabsMarginBottom,
                    Color = token.ColorText,
                    FontWeight = "normal",
                    FontSize = token.FontSize,
                    ["&-bar"] = new CSSObject
                    {
                        BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorderSecondary}",
                    },
                },
            };
        }

        public static CSSObject GenCardGridStyle(CardToken token)
        {
            var cardPaddingBase = token.CardPaddingBase;
            var colorBorderSecondary = token.ColorBorderSecondary;
            var cardShadow = token.CardShadow;
            var lineWidth = token.LineWidth;
            return new CSSObject
            {
                Width = "33.33%",
                Padding = cardPaddingBase,
                Border = 0,
                BorderRadius = 0,
                BoxShadow = $@"{Unit(lineWidth)} 0 0 0 {colorBorderSecondary},
      0 {Unit(lineWidth)} 0 0 {colorBorderSecondary},
      {Unit(lineWidth)} {Unit(lineWidth)} 0 0 {colorBorderSecondary},
      {Unit(lineWidth)} 0 0 0 {colorBorderSecondary} inset,
      0 {Unit(lineWidth)} 0 0 {colorBorderSecondary} inset;
    ",
                Transition = $@"{token.MotionDurationMid}",
                ["&-hoverable:hover"] = new CSSObject
                {
                    Position = "relative",
                    ZIndex = 1,
                    BoxShadow = cardShadow,
                },
            };
        }

        public static CSSObject GenCardActionsStyle(CardToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var actionsLiMargin = token.ActionsLiMargin;
            var cardActionsIconSize = token.CardActionsIconSize;
            var colorBorderSecondary = token.ColorBorderSecondary;
            var actionsBg = token.ActionsBg;
            return new CSSObject
            {
                Margin = 0,
                Padding = 0,
                ListStyle = "none",
                Background = actionsBg,
                BorderTop = $@"{Unit(token.LineWidth)} {token.LineType} {colorBorderSecondary}",
                Display = "flex",
                BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)}",
                ["..."] = ClearFix(),
                ["& > li"] = new CSSObject
                {
                    Margin = actionsLiMargin,
                    Color = token.ColorTextDescription,
                    TextAlign = "center",
                    ["> span"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "block",
                        MinWidth = token.Calc(token.CardActionsIconSize).Mul(2).Equal(),
                        FontSize = token.FontSize,
                        LineHeight = token.LineHeight,
                        Cursor = "pointer",
                        ["&:hover"] = new CSSObject
                        {
                            Color = token.ColorPrimary,
                            Transition = $@"{token.MotionDurationMid}",
                        },
                        [$@"{componentCls}-btn), > {iconCls}"] = new CSSObject
                        {
                            Display = "inline-block",
                            Width = "100%",
                            Color = token.ColorTextDescription,
                            LineHeight = Unit(token.FontHeight),
                            Transition = $@"{token.MotionDurationMid}",
                            ["&:hover"] = new CSSObject
                            {
                                Color = token.ColorPrimary,
                            },
                        },
                        [$@"{iconCls}"] = new CSSObject
                        {
                            FontSize = cardActionsIconSize,
                            LineHeight = Unit(token.Calc(cardActionsIconSize).Mul(token.LineHeight).Equal()),
                        },
                    },
                    ["&:not(:last-child)"] = new CSSObject
                    {
                        BorderInlineEnd = $@"{Unit(token.LineWidth)} {token.LineType} {colorBorderSecondary}",
                    },
                },
            };
        }

        public static CSSObject GenCardMetaStyle(CardToken token)
        {
            return new CSSObject
            {
                Margin = $@"{Unit(token.Calc(token.MarginXXS).Mul(-1).Equal())} 0",
                Display = "flex",
                ["..."] = ClearFix(),
                ["&-avatar"] = new CSSObject
                {
                    PaddingInlineEnd = token.Padding,
                },
                ["&-detail"] = new CSSObject
                {
                    Overflow = "hidden",
                    Flex = 1,
                    ["> div:not(:last-child)"] = new CSSObject
                    {
                        MarginBottom = token.MarginXS,
                    },
                },
                ["&-title"] = new CSSObject
                {
                    Color = token.ColorTextHeading,
                    FontWeight = token.FontWeightStrong,
                    FontSize = token.FontSizeLG,
                    ["..."] = textEllipsis,
                },
                ["&-description"] = new CSSObject
                {
                    Color = token.ColorTextDescription,
                },
            };
        }

        public static CSSObject GenCardTypeInnerStyle(CardToken token)
        {
            var componentCls = token.ComponentCls;
            var colorFillAlter = token.ColorFillAlter;
            var headerPadding = token.HeaderPadding;
            var bodyPadding = token.BodyPadding;
            return new CSSObject
            {
                [$@"{componentCls}-head"] = new CSSObject
                {
                    Padding = $@"{Unit(headerPadding)}",
                    Background = colorFillAlter,
                    ["&-title"] = new CSSObject
                    {
                        FontSize = token.FontSize,
                    },
                },
                [$@"{componentCls}-body"] = new CSSObject
                {
                    Padding = $@"{Unit(token.Padding)} {Unit(bodyPadding)}",
                },
            };
        }

        public static CSSObject GenCardLoadingStyle(CardToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                Overflow = "hidden",
                [$@"{componentCls}-body"] = new CSSObject
                {
                    UserSelect = "none",
                },
            };
        }

        public static CSSObject GenCardStyle(CardToken token)
        {
            var componentCls = token.ComponentCls;
            var cardShadow = token.CardShadow;
            var cardHeadPadding = token.CardHeadPadding;
            var colorBorderSecondary = token.ColorBorderSecondary;
            var boxShadowTertiary = token.BoxShadowTertiary;
            var bodyPadding = token.BodyPadding;
            var extraColor = token.ExtraColor;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "relative",
                    Background = token.ColorBgContainer,
                    BorderRadius = token.BorderRadiusLG,
                    [$@"{componentCls}-bordered)"] = new CSSObject
                    {
                        BoxShadow = boxShadowTertiary,
                    },
                    [$@"{componentCls}-head"] = GenCardHeadStyle(token),
                    [$@"{componentCls}-extra"] = new CSSObject
                    {
                        MarginInlineStart = "auto",
                        Color = extraColor,
                        FontWeight = "normal",
                        FontSize = token.FontSize,
                    },
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        Padding = bodyPadding,
                        BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)}",
                        ["..."] = ClearFix(),
                    },
                    [$@"{componentCls}-grid"] = GenCardGridStyle(token),
                    [$@"{componentCls}-cover"] = new CSSObject
                    {
                        ["> *"] = new CSSObject
                        {
                            Display = "block",
                            Width = "100%",
                            BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)} 0 0",
                        },
                    },
                    [$@"{componentCls}-actions"] = GenCardActionsStyle(token),
                    [$@"{componentCls}-meta"] = GenCardMetaStyle(token),
                },
                [$@"{componentCls}-bordered"] = new CSSObject
                {
                    Border = $@"{Unit(token.LineWidth)} {token.LineType} {colorBorderSecondary}",
                    [$@"{componentCls}-cover"] = new CSSObject
                    {
                        MarginTop = -1,
                        MarginInlineStart = -1,
                        MarginInlineEnd = -1,
                    },
                },
                [$@"{componentCls}-hoverable"] = new CSSObject
                {
                    Cursor = "pointer",
                    Transition = $@"{token.MotionDurationMid}, border-color {token.MotionDurationMid}",
                    ["&:hover"] = new CSSObject
                    {
                        BorderColor = "transparent",
                        BoxShadow = cardShadow,
                    },
                },
                [$@"{componentCls}-contain-grid"] = new CSSObject
                {
                    BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)} 0 0 ",
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        Display = "flex",
                        FlexWrap = "wrap",
                    },
                    [$@"{componentCls}-loading) {componentCls}-body"] = new CSSObject
                    {
                        MarginBlockStart = token.Calc(token.LineWidth).Mul(-1).Equal(),
                        MarginInlineStart = token.Calc(token.LineWidth).Mul(-1).Equal(),
                        Padding = 0,
                    },
                },
                [$@"{componentCls}-contain-tabs"] = new CSSObject
                {
                    [$@"{componentCls}-head"] = new CSSObject
                    {
                        MinHeight = 0,
                        [$@"{componentCls}-head-title, {componentCls}-extra"] = new CSSObject
                        {
                            PaddingTop = cardHeadPadding,
                        },
                    },
                },
                [$@"{componentCls}-type-inner"] = GenCardTypeInnerStyle(token),
                [$@"{componentCls}-loading"] = GenCardLoadingStyle(token),
                [$@"{componentCls}-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                },
            };
        }

        public static CSSObject GenCardSizeStyle(CardToken token)
        {
            var componentCls = token.ComponentCls;
            var bodyPaddingSM = token.BodyPaddingSM;
            var headerPaddingSM = token.HeaderPaddingSM;
            var headerHeightSM = token.HeaderHeightSM;
            var headerFontSizeSM = token.HeaderFontSizeSM;
            return new CSSObject
            {
                [$@"{componentCls}-small"] = new CSSObject
                {
                    [$@"{componentCls}-head"] = new CSSObject
                    {
                        MinHeight = headerHeightSM,
                        Padding = $@"{Unit(headerPaddingSM)}",
                        FontSize = headerFontSizeSM,
                        [$@"{componentCls}-head-wrapper"] = new CSSObject
                        {
                            [$@"{componentCls}-extra"] = new CSSObject
                            {
                                FontSize = token.FontSize,
                            },
                        },
                    },
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        Padding = bodyPaddingSM,
                    },
                },
                [$@"{componentCls}-small{componentCls}-contain-tabs"] = new CSSObject
                {
                    [$@"{componentCls}-head"] = new CSSObject
                    {
                        [$@"{componentCls}-head-title, {componentCls}-extra"] = new CSSObject
                        {
                            PaddingTop = 0,
                            Display = "flex",
                            AlignItems = "center",
                        },
                    },
                },
            };
        }

        public static CardToken PrepareComponentToken(CardToken token)
        {
            return new CardToken
            {
                HeaderBg = "transparent",
                HeaderFontSize = token.FontSizeLG,
                HeaderFontSizeSM = token.FontSize,
                HeaderHeight = token.FontSizeLG * token.LineHeightLG + token.Padding * 2,
                HeaderHeightSM = token.FontSize * token.LineHeight + token.PaddingXS * 2,
                ActionsBg = token.ColorBgContainer,
                ActionsLiMargin = $@"{token.PaddingSM}px 0",
                TabsMarginBottom = -token.Padding - token.LineWidth,
                ExtraColor = token.ColorText,
                BodyPaddingSM = 12,
                HeaderPaddingSM = 12,
                BodyPadding = token.PaddingLG,
                HeaderPadding = token.PaddingLG,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Card", (CardToken token) =>
            {
                var cardToken = MergeToken(token, new object { CardShadow = token.BoxShadowCard, CardHeadPadding = token.Padding, CardPaddingBase = token.PaddingLG, CardActionsIconSize = token.FontSize, });
                return new object[]
                {
                    GenCardStyle(cardToken),
                    GenCardSizeStyle(cardToken)
                };
            }, PrepareComponentToken);
        }
    }
}