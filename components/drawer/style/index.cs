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
    public partial class DrawerStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ZIndexPopup { get; set; }
            public double FooterPaddingBlock { get; set; }
            public double FooterPaddingInline { get; set; }
        }

        public class DrawerToken : ComponentToken
        {
        }

        public static CSSObject GenDrawerStyle(DrawerToken token)
        {
            var borderRadiusSM = token.BorderRadiusSM;
            var componentCls = token.ComponentCls;
            var zIndexPopup = token.ZIndexPopup;
            var colorBgMask = token.ColorBgMask;
            var colorBgElevated = token.ColorBgElevated;
            var motionDurationSlow = token.MotionDurationSlow;
            var motionDurationMid = token.MotionDurationMid;
            var paddingXS = token.PaddingXS;
            var padding = token.Padding;
            var paddingLG = token.PaddingLG;
            var fontSizeLG = token.FontSizeLG;
            var lineHeightLG = token.LineHeightLG;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var colorSplit = token.ColorSplit;
            var marginXS = token.MarginXS;
            var colorIcon = token.ColorIcon;
            var colorIconHover = token.ColorIconHover;
            var colorBgTextHover = token.ColorBgTextHover;
            var colorBgTextActive = token.ColorBgTextActive;
            var colorText = token.ColorText;
            var fontWeightStrong = token.FontWeightStrong;
            var footerPaddingBlock = token.FooterPaddingBlock;
            var footerPaddingInline = token.FooterPaddingInline;
            var calc = token.Calc;
            var wrapperCls = $@"{componentCls}-content-wrapper";
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Position = "fixed",
                    Inset = 0,
                    ZIndex = zIndexPopup,
                    PointerEvents = "none",
                    Color = colorText,
                    ["&-pure"] = new CSSObject
                    {
                        Position = "relative",
                        Background = colorBgElevated,
                        Display = "flex",
                        FlexDirection = "column",
                        [$@"{componentCls}-left"] = new CSSObject
                        {
                            BoxShadow = token.BoxShadowDrawerLeft,
                        },
                        [$@"{componentCls}-right"] = new CSSObject
                        {
                            BoxShadow = token.BoxShadowDrawerRight,
                        },
                        [$@"{componentCls}-top"] = new CSSObject
                        {
                            BoxShadow = token.BoxShadowDrawerUp,
                        },
                        [$@"{componentCls}-bottom"] = new CSSObject
                        {
                            BoxShadow = token.BoxShadowDrawerDown,
                        },
                    },
                    ["&-inline"] = new CSSObject
                    {
                        Position = "absolute",
                    },
                    [$@"{componentCls}-mask"] = new CSSObject
                    {
                        Position = "absolute",
                        Inset = 0,
                        ZIndex = zIndexPopup,
                        Background = colorBgMask,
                        PointerEvents = "auto",
                    },
                    [wrapperCls] = new CSSObject
                    {
                        Position = "absolute",
                        ZIndex = zIndexPopup,
                        MaxWidth = "100vw",
                        Transition = $@"{motionDurationSlow}",
                        ["&-hidden"] = new CSSObject
                        {
                            Display = "none",
                        },
                    },
                    [$@"{wrapperCls}"] = new CSSObject
                    {
                        Top = 0,
                        Bottom = 0,
                        Left = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = 0,
                        },
                        BoxShadow = token.BoxShadowDrawerLeft,
                    },
                    [$@"{wrapperCls}"] = new CSSObject
                    {
                        Top = 0,
                        Right = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = 0,
                        },
                        Bottom = 0,
                        BoxShadow = token.BoxShadowDrawerRight,
                    },
                    [$@"{wrapperCls}"] = new CSSObject
                    {
                        Top = 0,
                        InsetInline = 0,
                        BoxShadow = token.BoxShadowDrawerUp,
                    },
                    [$@"{wrapperCls}"] = new CSSObject
                    {
                        Bottom = 0,
                        InsetInline = 0,
                        BoxShadow = token.BoxShadowDrawerDown,
                    },
                    [$@"{componentCls}-content"] = new CSSObject
                    {
                        Display = "flex",
                        FlexDirection = "column",
                        Width = "100%",
                        Height = "100%",
                        Overflow = "auto",
                        Background = colorBgElevated,
                        PointerEvents = "auto",
                    },
                    [$@"{componentCls}-header"] = new CSSObject
                    {
                        Display = "flex",
                        Flex = 0,
                        AlignItems = "center",
                        Padding = $@"{Unit(padding)} {Unit(paddingLG)}",
                        FontSize = fontSizeLG,
                        LineHeight = lineHeightLG,
                        BorderBottom = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                        ["&-title"] = new CSSObject
                        {
                            Display = "flex",
                            Flex = 1,
                            AlignItems = "center",
                            MinWidth = 0,
                            MinHeight = 0,
                        },
                    },
                    [$@"{componentCls}-extra"] = new CSSObject
                    {
                        Flex = "none",
                    },
                    [$@"{componentCls}-close"] = new CSSObject
                    {
                        Display = "inline-flex",
                        Width = calc(fontSizeLG).add(paddingXS).Equal(),
                        Height = calc(fontSizeLG).add(paddingXS).Equal(),
                        BorderRadius = borderRadiusSM,
                        JustifyContent = "center",
                        AlignItems = "center",
                        MarginInlineEnd = marginXS,
                        Color = colorIcon,
                        FontWeight = fontWeightStrong,
                        FontSize = fontSizeLG,
                        FontStyle = "normal",
                        LineHeight = 1,
                        TextAlign = "center",
                        TextTransform = "none",
                        TextDecoration = "none",
                        Background = "transparent",
                        Border = 0,
                        Cursor = "pointer",
                        Transition = $@"{motionDurationMid}",
                        TextRendering = "auto",
                        ["&:hover"] = new CSSObject
                        {
                            Color = colorIconHover,
                            BackgroundColor = colorBgTextHover,
                            TextDecoration = "none",
                        },
                        ["&:active"] = new CSSObject
                        {
                            BackgroundColor = colorBgTextActive,
                        },
                        ["..."] = GenFocusStyle(token),
                    },
                    [$@"{componentCls}-title"] = new CSSObject
                    {
                        Flex = 1,
                        Margin = 0,
                        FontWeight = token.FontWeightStrong,
                        FontSize = fontSizeLG,
                        LineHeight = lineHeightLG,
                    },
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        Flex = 1,
                        MinWidth = 0,
                        MinHeight = 0,
                        Padding = paddingLG,
                        Overflow = "auto",
                        [$@"{componentCls}-body-skeleton"] = new CSSObject
                        {
                            Width = "100%",
                            Height = "100%",
                            Display = "flex",
                            JustifyContent = "center",
                        },
                    },
                    [$@"{componentCls}-footer"] = new CSSObject
                    {
                        FlexShrink = 0,
                        Padding = $@"{Unit(footerPaddingBlock)} {Unit(footerPaddingInline)}",
                        BorderTop = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                    },
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                },
            };
        }

        public static DrawerToken PrepareComponentToken(DrawerToken token)
        {
            return new DrawerToken
            {
                ZIndexPopup = token.ZIndexPopupBase,
                FooterPaddingBlock = token.PaddingXS,
                FooterPaddingInline = token.Padding,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Drawer", (DrawerToken token) =>
            {
                var drawerToken = MergeToken(token, new object { });
                return new object[]
                {
                    GenDrawerStyle(drawerToken),
                    GenMotionStyle(drawerToken)
                };
            }, prepareComponentToken);
        }
    }
}