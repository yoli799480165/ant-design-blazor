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
    public partial class BreadcrumbStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string ItemColor { get; set; }
            public double IconFontSize { get; set; }
            public string LinkColor { get; set; }
            public string LinkHoverColor { get; set; }
            public string LastItemColor { get; set; }
            public double SeparatorMargin { get; set; }
            public string SeparatorColor { get; set; }
        }

        public class BreadcrumbToken : ComponentToken
        {
        }

        public static CSSObject GenBreadcrumbStyle(BreadcrumbToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var calc = token.Calc;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Color = token.ItemColor,
                    FontSize = token.FontSize,
                    [iconCls] = new CSSObject
                    {
                        FontSize = token.IconFontSize,
                    },
                    ["ol"] = new CSSObject
                    {
                        Display = "flex",
                        FlexWrap = "wrap",
                        Margin = 0,
                        Padding = 0,
                        ListStyle = "none",
                    },
                    ["a"] = new CSSObject
                    {
                        Color = token.LinkColor,
                        Transition = $@"{token.MotionDurationMid}",
                        Padding = $@"{Unit(token.PaddingXXS)}",
                        BorderRadius = token.BorderRadiusSM,
                        Height = token.FontHeight,
                        Display = "inline-block",
                        MarginInline = Calc(token.MarginXXS).Mul(-1).Equal(),
                        ["&:hover"] = new CSSObject
                        {
                            Color = token.LinkHoverColor,
                            BackgroundColor = token.ColorBgTextHover,
                        },
                        ["..."] = GenFocusStyle(token),
                    },
                    ["li:last-child"] = new CSSObject
                    {
                        Color = token.LastItemColor,
                    },
                    [$@"{componentCls}-separator"] = new CSSObject
                    {
                        MarginInline = token.SeparatorMargin,
                        Color = token.SeparatorColor,
                    },
                    [$@"{componentCls}-link"] = new CSSObject
                    {
                        [$@"{iconCls} + span,
          > {iconCls} + a
        "] = new CSSObject
                        {
                            MarginInlineStart = token.MarginXXS,
                        },
                    },
                    [$@"{componentCls}-overlay-link"] = new CSSObject
                    {
                        BorderRadius = token.BorderRadiusSM,
                        Height = token.FontHeight,
                        Display = "inline-block",
                        Padding = $@"{Unit(token.PaddingXXS)}",
                        MarginInline = Calc(token.MarginXXS).Mul(-1).Equal(),
                        [$@"{iconCls}"] = new CSSObject
                        {
                            MarginInlineStart = token.MarginXXS,
                            FontSize = token.FontSizeIcon,
                        },
                        ["&:hover"] = new CSSObject
                        {
                            Color = token.LinkHoverColor,
                            BackgroundColor = token.ColorBgTextHover,
                            ["a"] = new CSSObject
                            {
                                Color = token.LinkHoverColor,
                            },
                        },
                        ["a"] = new CSSObject
                        {
                            ["&:hover"] = new CSSObject
                            {
                                BackgroundColor = "transparent",
                            },
                        },
                    },
                    [$@"{token.ComponentCls}-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                },
            };
        }

        public static BreadcrumbToken PrepareComponentToken(BreadcrumbToken token)
        {
            return new BreadcrumbToken
            {
                ItemColor = token.ColorTextDescription,
                LastItemColor = token.ColorText,
                IconFontSize = token.FontSize,
                LinkColor = token.ColorTextDescription,
                LinkHoverColor = token.ColorText,
                SeparatorColor = token.ColorTextDescription,
                SeparatorMargin = token.MarginXS,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Breadcrumb", (BreadcrumbToken token) =>
            {
                var breadcrumbToken = MergeToken(token, new object { });
                return GenBreadcrumbStyle(breadcrumbToken);
            }, PrepareComponentToken);
        }
    }
}