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
    public partial class StatisticStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double TitleFontSize { get; set; }
            public double ContentFontSize { get; set; }
        }

        public class StatisticToken : ComponentToken
        {
        }

        public static CSSObject GenStatisticStyle(StatisticToken token)
        {
            var componentCls = token.ComponentCls;
            var marginXXS = token.MarginXXS;
            var padding = token.Padding;
            var colorTextDescription = token.ColorTextDescription;
            var titleFontSize = token.TitleFontSize;
            var colorTextHeading = token.ColorTextHeading;
            var contentFontSize = token.ContentFontSize;
            var fontFamily = token.FontFamily;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    [$@"{componentCls}-title"] = new CSSObject
                    {
                        MarginBottom = marginXXS,
                        Color = colorTextDescription,
                        FontSize = titleFontSize,
                    },
                    [$@"{componentCls}-skeleton"] = new CSSObject
                    {
                        PaddingTop = padding,
                    },
                    [$@"{componentCls}-content"] = new CSSObject
                    {
                        Color = colorTextHeading,
                        FontSize = contentFontSize,
                        [$@"{componentCls}-content-value"] = new CSSObject
                        {
                            Display = "inline-block",
                            Direction = "ltr",
                        },
                        [$@"{componentCls}-content-prefix, {componentCls}-content-suffix"] = new CSSObject
                        {
                            Display = "inline-block",
                        },
                        [$@"{componentCls}-content-prefix"] = new CSSObject
                        {
                            MarginInlineEnd = marginXXS,
                        },
                        [$@"{componentCls}-content-suffix"] = new CSSObject
                        {
                            MarginInlineStart = marginXXS,
                        },
                    },
                },
            };
        }

        public static StatisticToken PrepareComponentToken(StatisticToken token)
        {
            var fontSizeHeading3 = token.FontSizeHeading3;
            var fontSize = token.FontSize;
            return new StatisticToken
            {
                TitleFontSize = fontSize,
                ContentFontSize = fontSizeHeading3,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Statistic", (StatisticToken token) =>
            {
                var statisticToken = MergeToken(token, new object { });
                return new object[]
                {
                    GenStatisticStyle(statisticToken)
                };
            }, PrepareComponentToken);
        }
    }
}