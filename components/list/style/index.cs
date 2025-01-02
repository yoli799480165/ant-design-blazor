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
    public partial class ListStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string ContentWidth { get; set; }
            public string ItemPaddingLG { get; set; }
            public string ItemPaddingSM { get; set; }
            public string ItemPadding { get; set; }
            public string HeaderBg { get; set; }
            public string FooterBg { get; set; }
            public string EmptyTextPadding { get; set; }
            public string MetaMarginBottom { get; set; }
            public string AvatarMarginRight { get; set; }
            public string TitleMarginBottom { get; set; }
            public double DescriptionFontSize { get; set; }
        }

        public class ListToken : ComponentToken
        {
            public string ListBorderedCls { get; set; }
            public string MinHeight { get; set; }
        }

        public static CSSObject GenBorderedStyle(ListToken token)
        {
            var listBorderedCls = token.ListBorderedCls;
            var componentCls = token.ComponentCls;
            var paddingLG = token.PaddingLG;
            var margin = token.Margin;
            var itemPaddingSM = token.ItemPaddingSM;
            var itemPaddingLG = token.ItemPaddingLG;
            var marginLG = token.MarginLG;
            var borderRadiusLG = token.BorderRadiusLG;
            return new CSSObject
            {
                [listBorderedCls] = new CSSObject
                {
                    Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                    BorderRadius = borderRadiusLG,
                    [$@"{componentCls}-header,{componentCls}-footer,{componentCls}-item"] = new CSSObject
                    {
                        PaddingInline = paddingLG,
                    },
                    [$@"{componentCls}-pagination"] = new CSSObject
                    {
                        Margin = $@"{Unit(margin)} {Unit(marginLG)}",
                    },
                },
                [$@"{listBorderedCls}{componentCls}-sm"] = new CSSObject
                {
                    [$@"{componentCls}-item,{componentCls}-header,{componentCls}-footer"] = new CSSObject
                    {
                        Padding = itemPaddingSM,
                    },
                },
                [$@"{listBorderedCls}{componentCls}-lg"] = new CSSObject
                {
                    [$@"{componentCls}-item,{componentCls}-header,{componentCls}-footer"] = new CSSObject
                    {
                        Padding = itemPaddingLG,
                    },
                },
            };
        }

        public static CSSObject GenResponsiveStyle(ListToken token)
        {
            var componentCls = token.ComponentCls;
            var screenSM = token.ScreenSM;
            var screenMD = token.ScreenMD;
            var marginLG = token.MarginLG;
            var marginSM = token.MarginSM;
            var margin = token.Margin;
            return new CSSObject
            {
                [$@"{screenMD}px)"] = new CSSObject
                {
                    [componentCls] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            [$@"{componentCls}-item-action"] = new CSSObject
                            {
                                MarginInlineStart = marginLG,
                            },
                        },
                    },
                    [$@"{componentCls}-vertical"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            [$@"{componentCls}-item-extra"] = new CSSObject
                            {
                                MarginInlineStart = marginLG,
                            },
                        },
                    },
                },
                [$@"{screenSM}px)"] = new CSSObject
                {
                    [componentCls] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            FlexWrap = "wrap",
                            [$@"{componentCls}-action"] = new CSSObject
                            {
                                MarginInlineStart = marginSM,
                            },
                        },
                    },
                    [$@"{componentCls}-vertical"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            FlexWrap = "wrap-reverse",
                            [$@"{componentCls}-item-main"] = new CSSObject
                            {
                                MinWidth = token.ContentWidth,
                            },
                            [$@"{componentCls}-item-extra"] = new CSSObject
                            {
                                Margin = $@"{Unit(margin)}",
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenBaseStyle(ListToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var controlHeight = token.ControlHeight;
            var minHeight = token.MinHeight;
            var paddingSM = token.PaddingSM;
            var marginLG = token.MarginLG;
            var padding = token.Padding;
            var itemPadding = token.ItemPadding;
            var colorPrimary = token.ColorPrimary;
            var itemPaddingSM = token.ItemPaddingSM;
            var itemPaddingLG = token.ItemPaddingLG;
            var paddingXS = token.PaddingXS;
            var margin = token.Margin;
            var colorText = token.ColorText;
            var colorTextDescription = token.ColorTextDescription;
            var motionDurationSlow = token.MotionDurationSlow;
            var lineWidth = token.LineWidth;
            var headerBg = token.HeaderBg;
            var footerBg = token.FooterBg;
            var emptyTextPadding = token.EmptyTextPadding;
            var metaMarginBottom = token.MetaMarginBottom;
            var avatarMarginRight = token.AvatarMarginRight;
            var titleMarginBottom = token.TitleMarginBottom;
            var descriptionFontSize = token.DescriptionFontSize;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "relative",
                    ["*"] = new CSSObject
                    {
                        Outline = "none",
                    },
                    [$@"{componentCls}-header"] = new CSSObject
                    {
                        Background = headerBg,
                    },
                    [$@"{componentCls}-footer"] = new CSSObject
                    {
                        Background = footerBg,
                    },
                    [$@"{componentCls}-header, {componentCls}-footer"] = new CSSObject
                    {
                        PaddingBlock = paddingSM,
                    },
                    [$@"{componentCls}-pagination"] = new CSSObject
                    {
                        MarginBlockStart = marginLG,
                        [$@"{antCls}-pagination-options"] = new CSSObject
                        {
                            TextAlign = "start",
                        },
                    },
                    [$@"{componentCls}-spin"] = new CSSObject
                    {
                        TextAlign = "center",
                    },
                    [$@"{componentCls}-items"] = new CSSObject
                    {
                        Margin = 0,
                        Padding = 0,
                        ListStyle = "none",
                    },
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        Display = "flex",
                        AlignItems = "center",
                        JustifyContent = "space-between",
                        Padding = itemPadding,
                        Color = colorText,
                        [$@"{componentCls}-item-meta"] = new CSSObject
                        {
                            Display = "flex",
                            Flex = 1,
                            AlignItems = "flex-start",
                            MaxWidth = "100%",
                            [$@"{componentCls}-item-meta-avatar"] = new CSSObject
                            {
                                MarginInlineEnd = avatarMarginRight,
                            },
                            [$@"{componentCls}-item-meta-content"] = new CSSObject
                            {
                                Flex = "1 0",
                                Width = 0,
                                Color = colorText,
                            },
                            [$@"{componentCls}-item-meta-title"] = new CSSObject
                            {
                                Margin = $@"{Unit(token.MarginXXS)} 0",
                                Color = colorText,
                                FontSize = token.FontSize,
                                LineHeight = token.LineHeight,
                                ["> a"] = new CSSObject
                                {
                                    Color = colorText,
                                    Transition = $@"{motionDurationSlow}",
                                    ["&:hover"] = new CSSObject
                                    {
                                        Color = colorPrimary,
                                    },
                                },
                            },
                            [$@"{componentCls}-item-meta-description"] = new CSSObject
                            {
                                Color = colorTextDescription,
                                FontSize = descriptionFontSize,
                                LineHeight = token.LineHeight,
                            },
                        },
                        [$@"{componentCls}-item-action"] = new CSSObject
                        {
                            Flex = "0 0 auto",
                            MarginInlineStart = token.MarginXXL,
                            Padding = 0,
                            FontSize = 0,
                            ListStyle = "none",
                            ["& > li"] = new CSSObject
                            {
                                Position = "relative",
                                Display = "inline-block",
                                Padding = $@"{Unit(paddingXS)}",
                                Color = colorTextDescription,
                                FontSize = token.FontSize,
                                LineHeight = token.LineHeight,
                                TextAlign = "center",
                                ["&:first-child"] = new CSSObject
                                {
                                    PaddingInlineStart = 0,
                                },
                            },
                            [$@"{componentCls}-item-action-split"] = new CSSObject
                            {
                                Position = "absolute",
                                InsetBlockStart = "50%",
                                InsetInlineEnd = 0,
                                Width = lineWidth,
                                Height = token.calc(token.fontHeight).sub(token.calc(token.marginXXS).mul(2)).Equal(),
                                Transform = "translateY(-50%)",
                                BackgroundColor = token.ColorSplit,
                            },
                        },
                    },
                    [$@"{componentCls}-empty"] = new CSSObject
                    {
                        Padding = $@"{Unit(padding)} 0",
                        Color = colorTextDescription,
                        FontSize = token.FontSizeSM,
                        TextAlign = "center",
                    },
                    [$@"{componentCls}-empty-text"] = new CSSObject
                    {
                        Padding = emptyTextPadding,
                        Color = token.ColorTextDisabled,
                        FontSize = token.FontSize,
                        TextAlign = "center",
                    },
                    [$@"{componentCls}-item-no-flex"] = new CSSObject
                    {
                        Display = "block",
                    },
                },
                [$@"{componentCls}-grid {antCls}-col > {componentCls}-item"] = new CSSObject
                {
                    Display = "block",
                    MaxWidth = "100%",
                    MarginBlockEnd = margin,
                    PaddingBlock = 0,
                    BorderBlockEnd = "none",
                },
                [$@"{componentCls}-vertical {componentCls}-item"] = new CSSObject
                {
                    AlignItems = "initial",
                    [$@"{componentCls}-item-main"] = new CSSObject
                    {
                        Display = "block",
                        Flex = 1,
                    },
                    [$@"{componentCls}-item-extra"] = new CSSObject
                    {
                        MarginInlineStart = marginLG,
                    },
                    [$@"{componentCls}-item-meta"] = new CSSObject
                    {
                        MarginBlockEnd = metaMarginBottom,
                        [$@"{componentCls}-item-meta-title"] = new CSSObject
                        {
                            MarginBlockStart = 0,
                            MarginBlockEnd = titleMarginBottom,
                            Color = colorText,
                            FontSize = token.FontSizeLG,
                            LineHeight = token.LineHeightLG,
                        },
                    },
                    [$@"{componentCls}-item-action"] = new CSSObject
                    {
                        MarginBlockStart = padding,
                        MarginInlineStart = "auto",
                        ["> li"] = new CSSObject
                        {
                            Padding = $@"{Unit(padding)}",
                            ["&:first-child"] = new CSSObject
                            {
                                PaddingInlineStart = 0,
                            },
                        },
                    },
                },
                [$@"{componentCls}-split {componentCls}-item"] = new CSSObject
                {
                    BorderBlockEnd = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                    ["&:last-child"] = new CSSObject
                    {
                        BorderBlockEnd = "none",
                    },
                },
                [$@"{componentCls}-split {componentCls}-header"] = new CSSObject
                {
                    BorderBlockEnd = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                },
                [$@"{componentCls}-split{componentCls}-empty {componentCls}-footer"] = new CSSObject
                {
                    BorderTop = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                },
                [$@"{componentCls}-loading {componentCls}-spin-nested-loading"] = new CSSObject
                {
                    MinHeight = controlHeight,
                },
                [$@"{componentCls}-split{componentCls}-something-after-last-item {antCls}-spin-container > {componentCls}-items > {componentCls}-item:last-child"] = new CSSObject
                {
                    BorderBlockEnd = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                },
                [$@"{componentCls}-lg {componentCls}-item"] = new CSSObject
                {
                    Padding = itemPaddingLG,
                },
                [$@"{componentCls}-sm {componentCls}-item"] = new CSSObject
                {
                    Padding = itemPaddingSM,
                },
                [$@"{componentCls}:not({componentCls}-vertical)"] = new CSSObject
                {
                    [$@"{componentCls}-item-no-flex"] = new CSSObject
                    {
                        [$@"{componentCls}-item-action"] = new CSSObject
                        {
                            Float = "right",
                        },
                    },
                },
            };
        }

        public static ListToken PrepareComponentToken(ListToken token)
        {
            return new ListToken
            {
                ContentWidth = 220,
                ItemPadding = $@"{Unit(token.PaddingContentVertical)} 0",
                ItemPaddingSM = $@"{Unit(token.PaddingContentVerticalSM)} {Unit(token.PaddingContentHorizontal)}",
                ItemPaddingLG = $@"{Unit(token.PaddingContentVerticalLG)} {Unit(token.PaddingContentHorizontalLG)}",
                HeaderBg = "transparent",
                FooterBg = "transparent",
                EmptyTextPadding = token.Padding,
                MetaMarginBottom = token.Padding,
                AvatarMarginRight = token.Padding,
                TitleMarginBottom = token.PaddingSM,
                DescriptionFontSize = token.FontSize,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("List", (ListToken token) =>
            {
                var listToken = MergeToken(token, new object { ListBorderedCls = $@"{token.ComponentCls}-bordered", MinHeight = token.ControlHeightLG, });
                return new object[]
                {
                    GenBaseStyle(listToken),
                    GenBorderedStyle(listToken),
                    GenResponsiveStyle(listToken)
                };
            }, prepareComponentToken);
        }
    }
}