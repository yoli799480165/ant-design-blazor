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
    public partial class CollapseStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string HeaderPadding { get; set; }
            public string HeaderBg { get; set; }
            public string ContentPadding { get; set; }
            public string ContentBg { get; set; }
        }

        public class CollapseToken : ComponentToken
        {
            public string CollapseHeaderPaddingSM { get; set; }
            public string CollapseHeaderPaddingLG { get; set; }
            public double CollapsePanelBorderRadius { get; set; }
        }

        public static CSSObject GenBaseStyle(CollapseToken token)
        {
            var componentCls = token.ComponentCls;
            var contentBg = token.ContentBg;
            var padding = token.Padding;
            var headerBg = token.HeaderBg;
            var headerPadding = token.HeaderPadding;
            var collapseHeaderPaddingSM = token.CollapseHeaderPaddingSM;
            var collapseHeaderPaddingLG = token.CollapseHeaderPaddingLG;
            var collapsePanelBorderRadius = token.CollapsePanelBorderRadius;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var colorBorder = token.ColorBorder;
            var colorText = token.ColorText;
            var colorTextHeading = token.ColorTextHeading;
            var colorTextDisabled = token.ColorTextDisabled;
            var fontSizeLG = token.FontSizeLG;
            var lineHeight = token.LineHeight;
            var lineHeightLG = token.LineHeightLG;
            var marginSM = token.MarginSM;
            var paddingSM = token.PaddingSM;
            var paddingLG = token.PaddingLG;
            var paddingXS = token.PaddingXS;
            var motionDurationSlow = token.MotionDurationSlow;
            var fontSizeIcon = token.FontSizeIcon;
            var contentPadding = token.ContentPadding;
            var fontHeight = token.FontHeight;
            var fontHeightLG = token.FontHeightLG;
            var borderBase = $@"{Unit(lineWidth)} {lineType} {colorBorder}";
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    BackgroundColor = headerBg,
                    Border = borderBase,
                    BorderRadius = collapsePanelBorderRadius,
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        BorderBottom = borderBase,
                        ["&:last-child"] = new CSSObject
                        {
                            [$@"{componentCls}-header"] = new CSSObject
                            {
                                BorderRadius = $@"{Unit(collapsePanelBorderRadius)} {Unit(collapsePanelBorderRadius)}",
                            },
                        },
                        [$@"{componentCls}-header"] = new CSSObject
                        {
                            Position = "relative",
                            Display = "flex",
                            FlexWrap = "nowrap",
                            AlignItems = "flex-start",
                            Padding = headerPadding,
                            Color = colorTextHeading,
                            Cursor = "pointer",
                            Transition = $@"{motionDurationSlow}, visibility 0s",
                            [$@"{componentCls}-header-text"] = new CSSObject
                            {
                                Flex = "auto",
                            },
                            [$@"{componentCls}-expand-icon"] = new CSSObject
                            {
                                Height = fontHeight,
                                Display = "flex",
                                AlignItems = "center",
                                PaddingInlineEnd = marginSM,
                            },
                            [$@"{componentCls}-arrow"] = new CSSObject
                            {
                                ["..."] = ResetIcon(),
                                FontSize = fontSizeIcon,
                                Transition = $@"{motionDurationSlow}",
                                ["svg"] = new CSSObject
                                {
                                    Transition = $@"{motionDurationSlow}",
                                },
                            },
                            [$@"{componentCls}-header-text"] = new CSSObject
                            {
                                MarginInlineEnd = "auto",
                            },
                        },
                        [$@"{componentCls}-collapsible-header"] = new CSSObject
                        {
                            Cursor = "default",
                            [$@"{componentCls}-header-text"] = new CSSObject
                            {
                                Flex = "none",
                                Cursor = "pointer",
                            },
                        },
                        [$@"{componentCls}-collapsible-icon"] = new CSSObject
                        {
                            Cursor = "unset",
                            [$@"{componentCls}-expand-icon"] = new CSSObject
                            {
                                Cursor = "pointer",
                            },
                        },
                    },
                    [$@"{componentCls}-content"] = new CSSObject
                    {
                        Color = colorText,
                        BackgroundColor = contentBg,
                        BorderTop = borderBase,
                        [$@"{componentCls}-content-box"] = new CSSObject
                        {
                            Padding = contentPadding,
                        },
                        ["&-hidden"] = new CSSObject
                        {
                            Display = "none",
                        },
                    },
                    ["&-small"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            [$@"{componentCls}-header"] = new CSSObject
                            {
                                Padding = collapseHeaderPaddingSM,
                                PaddingInlineStart = paddingXS,
                                [$@"{componentCls}-expand-icon"] = new CSSObject
                                {
                                    MarginInlineStart = token.calc(paddingSM).sub(paddingXS).Equal(),
                                },
                            },
                            [$@"{componentCls}-content > {componentCls}-content-box"] = new CSSObject
                            {
                                Padding = paddingSM,
                            },
                        },
                    },
                    ["&-large"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            FontSize = fontSizeLG,
                            LineHeight = lineHeightLG,
                            [$@"{componentCls}-header"] = new CSSObject
                            {
                                Padding = collapseHeaderPaddingLG,
                                PaddingInlineStart = padding,
                                [$@"{componentCls}-expand-icon"] = new CSSObject
                                {
                                    Height = fontHeightLG,
                                    MarginInlineStart = token.calc(paddingLG).sub(padding).Equal(),
                                },
                            },
                            [$@"{componentCls}-content > {componentCls}-content-box"] = new CSSObject
                            {
                                Padding = paddingLG,
                            },
                        },
                    },
                    [$@"{componentCls}-item:last-child"] = new CSSObject
                    {
                        BorderBottom = 0,
                        [$@"{componentCls}-content"] = new CSSObject
                        {
                            BorderRadius = $@"{Unit(collapsePanelBorderRadius)} {Unit(collapsePanelBorderRadius)}",
                        },
                    },
                    [$@"{componentCls}-item-disabled > {componentCls}-header"] = new CSSObject
                    {
                        ["\n          &,\n          & > .arrow\n        "] = new CSSObject
                        {
                            Color = colorTextDisabled,
                            Cursor = "not-allowed",
                        },
                    },
                    [$@"{componentCls}-icon-position-end"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            [$@"{componentCls}-header"] = new CSSObject
                            {
                                [$@"{componentCls}-expand-icon"] = new CSSObject
                                {
                                    Order = 1,
                                    PaddingInlineEnd = 0,
                                    PaddingInlineStart = marginSM,
                                },
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenArrowStyle(CollapseToken token)
        {
            var componentCls = token.ComponentCls;
            var fixedSelector = $@"{componentCls}-item > {componentCls}-header {componentCls}-arrow";
            return new CSSObject
            {
                [$@"{componentCls}-rtl"] = new CSSObject
                {
                    [fixedSelector] = new CSSObject
                    {
                        Transform = "rotate(180deg)",
                    },
                },
            };
        }

        public static CSSObject GenBorderlessStyle(CollapseToken token)
        {
            var componentCls = token.ComponentCls;
            var headerBg = token.HeaderBg;
            var paddingXXS = token.PaddingXXS;
            var colorBorder = token.ColorBorder;
            return new CSSObject
            {
                [$@"{componentCls}-borderless"] = new CSSObject
                {
                    BackgroundColor = headerBg,
                    Border = 0,
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        BorderBottom = $@"{colorBorder}",
                    },
                    [$@"{componentCls}-item:last-child,
        > {componentCls}-item:last-child {componentCls}-header
      "] = new CSSObject
                    {
                        BorderRadius = 0,
                    },
                    [$@"{componentCls}-item:last-child"] = new CSSObject
                    {
                        BorderBottom = 0,
                    },
                    [$@"{componentCls}-item > {componentCls}-content"] = new CSSObject
                    {
                        BackgroundColor = "transparent",
                        BorderTop = 0,
                    },
                    [$@"{componentCls}-item > {componentCls}-content > {componentCls}-content-box"] = new CSSObject
                    {
                        PaddingTop = paddingXXS,
                    },
                },
            };
        }

        public static CSSObject GenGhostStyle(CollapseToken token)
        {
            var componentCls = token.ComponentCls;
            var paddingSM = token.PaddingSM;
            return new CSSObject
            {
                [$@"{componentCls}-ghost"] = new CSSObject
                {
                    BackgroundColor = "transparent",
                    Border = 0,
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        BorderBottom = 0,
                        [$@"{componentCls}-content"] = new CSSObject
                        {
                            BackgroundColor = "transparent",
                            Border = 0,
                            [$@"{componentCls}-content-box"] = new CSSObject
                            {
                                PaddingBlock = paddingSM,
                            },
                        },
                    },
                },
            };
        }

        public static CollapseToken PrepareComponentToken(CollapseToken token)
        {
            return new CollapseToken
            {
                HeaderPadding = $@"{token.PaddingSM}px {token.Padding}px",
                HeaderBg = token.ColorFillAlter,
                ContentPadding = $@"{token.Padding}px 16px",
                ContentBg = token.ColorBgContainer,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Collapse", (CollapseToken token) =>
            {
                var collapseToken = MergeToken(token, new object { CollapseHeaderPaddingSM = $@"{Unit(token.PaddingXS)} {Unit(token.PaddingSM)}", CollapseHeaderPaddingLG = $@"{Unit(token.Padding)} {Unit(token.PaddingLG)}", CollapsePanelBorderRadius = token.BorderRadiusLG, });
                return new object[]
                {
                    GenBaseStyle(collapseToken),
                    GenBorderlessStyle(collapseToken),
                    GenGhostStyle(collapseToken),
                    GenArrowStyle(collapseToken),
                    GenCollapseMotion(collapseToken)
                };
            }, prepareComponentToken);
        }
    }
}