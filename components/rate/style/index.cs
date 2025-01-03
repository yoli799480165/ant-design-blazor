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
    public partial class RateStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string StarColor { get; set; }
            public double StarSize { get; set; }
            public string StarHoverScale { get; set; }
            public string StarBg { get; set; }
        }

        public class RateToken : ComponentToken
        {
        }

        public static CSSObject GenRateStarStyle(RateToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-star"] = new CSSObject
                {
                    Position = "relative",
                    Display = "inline-block",
                    Color = "inherit",
                    Cursor = "pointer",
                    ["&:not(:last-child)"] = new CSSObject
                    {
                        MarginInlineEnd = token.MarginXS,
                    },
                    ["> div"] = new CSSObject
                    {
                        Transition = $@"{token.MotionDurationMid}, outline 0s",
                        ["&:hover"] = new CSSObject
                        {
                            Transform = token.StarHoverScale,
                        },
                        ["&:focus"] = new CSSObject
                        {
                            Outline = 0,
                        },
                        ["&:focus-visible"] = new CSSObject
                        {
                            Outline = $@"{Unit(token.LineWidth)} dashed {token.StarColor}",
                            Transform = token.StarHoverScale,
                        },
                    },
                    ["&-first, &-second"] = new CSSObject
                    {
                        Color = token.StarBg,
                        Transition = $@"{token.MotionDurationMid}",
                        UserSelect = "none",
                    },
                    ["&-first"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = 0,
                        InsetInlineStart = 0,
                        Width = "50%",
                        Height = "100%",
                        Overflow = "hidden",
                        Opacity = 0,
                    },
                    [$@"{componentCls}-star-first, &-half {componentCls}-star-second"] = new CSSObject
                    {
                        Opacity = 1,
                    },
                    [$@"{componentCls}-star-first, &-full {componentCls}-star-second"] = new CSSObject
                    {
                        Color = "inherit",
                    },
                },
            };
        }

        public static CSSObject GenRateRtlStyle(RateToken token)
        {
            return new CSSObject
            {
                [$@"{token.ComponentCls}"] = new CSSObject
                {
                    Direction = "rtl",
                },
            };
        }

        public static CSSObject GenRateStyle(RateToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "inline-block",
                    Margin = 0,
                    Padding = 0,
                    Color = token.StarColor,
                    FontSize = token.StarSize,
                    LineHeight = 1,
                    ListStyle = "none",
                    Outline = "none",
                    [$@"{componentCls} {componentCls}-star"] = new CSSObject
                    {
                        Cursor = "default",
                        ["> div:hover"] = new CSSObject
                        {
                            Transform = "scale(1)",
                        },
                    },
                    ["..."] = GenRateStarStyle(token),
                    ["..."] = GenRateRtlStyle(token),
                },
            };
        }

        public static RateToken PrepareComponentToken(RateToken token)
        {
            return new RateToken
            {
                StarColor = token.Yellow6,
                StarSize = token.ControlHeightLG * 0.5,
                StarHoverScale = "scale(1.1)",
                StarBg = token.ColorFillContent,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Rate", (RateToken token) =>
            {
                var rateToken = MergeToken(token, new object { });
                return new object[]
                {
                    GenRateStyle(rateToken)
                };
            }, PrepareComponentToken);
        }
    }
}