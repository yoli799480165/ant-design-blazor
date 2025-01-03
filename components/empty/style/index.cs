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
    public partial class EmptyStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
        }

        public class EmptyToken : ComponentToken
        {
            public string EmptyImgCls { get; set; }
            public string EmptyImgHeight { get; set; }
            public string EmptyImgHeightSM { get; set; }
            public string EmptyImgHeightMD { get; set; }
        }

        public static CSSObject GenSharedEmptyStyle(EmptyToken token)
        {
            var componentCls = token.ComponentCls;
            var margin = token.Margin;
            var marginXS = token.MarginXS;
            var marginXL = token.MarginXL;
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    MarginInline = marginXS,
                    TextAlign = "center",
                    [$@"{componentCls}-image"] = new CSSObject
                    {
                        Height = token.EmptyImgHeight,
                        MarginBottom = marginXS,
                        Opacity = token.OpacityImage,
                        ["img"] = new CSSObject
                        {
                            Height = "100%",
                        },
                        ["svg"] = new CSSObject
                        {
                            MaxWidth = "100%",
                            Height = "100%",
                            Margin = "auto",
                        },
                    },
                    [$@"{componentCls}-description"] = new CSSObject
                    {
                        Color = token.ColorTextDescription,
                    },
                    [$@"{componentCls}-footer"] = new CSSObject
                    {
                        MarginTop = margin,
                    },
                    ["&-normal"] = new CSSObject
                    {
                        MarginBlock = marginXL,
                        Color = token.ColorTextDescription,
                        [$@"{componentCls}-description"] = new CSSObject
                        {
                            Color = token.ColorTextDescription,
                        },
                        [$@"{componentCls}-image"] = new CSSObject
                        {
                            Height = token.EmptyImgHeightMD,
                        },
                    },
                    ["&-small"] = new CSSObject
                    {
                        MarginBlock = marginXS,
                        Color = token.ColorTextDescription,
                        [$@"{componentCls}-image"] = new CSSObject
                        {
                            Height = token.EmptyImgHeightSM,
                        },
                    },
                },
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Empty", (EmptyToken token) =>
            {
                var componentCls = token.ComponentCls;
                var controlHeightLG = token.ControlHeightLG;
                var calc = token.Calc;
                var emptyToken = MergeToken(token, new object { EmptyImgCls = $@"{componentCls}-img", EmptyImgHeight = Calc(controlHeightLG).Mul(2.5).Equal(), EmptyImgHeightMD = controlHeightLG, EmptyImgHeightSM = Calc(controlHeightLG).Mul(0.875).Equal(), });
                return new object[]
                {
                    GenSharedEmptyStyle(emptyToken)
                };
            });
        }
    }
}