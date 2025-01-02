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
    public partial class FlexStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
        }

        public class FlexToken : ComponentToken
        {
            public double FlexGapSM { get; set; }
            public double FlexGap { get; set; }
            public double FlexGapLG { get; set; }
        }

        public static CSSObject GenFlexStyle(FlexToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Display = "flex",
                    ["&-vertical"] = new CSSObject
                    {
                        FlexDirection = "column",
                    },
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    ["&:empty"] = new CSSObject
                    {
                        Display = "none",
                    },
                },
            };
        }

        public static CSSObject GenFlexGapStyle(FlexToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["&-gap-small"] = new CSSObject
                    {
                        Gap = token.FlexGapSM,
                    },
                    ["&-gap-middle"] = new CSSObject
                    {
                        Gap = token.FlexGap,
                    },
                    ["&-gap-large"] = new CSSObject
                    {
                        Gap = token.FlexGapLG,
                    },
                },
            };
        }

        public static CSSObject GenFlexWrapStyle(FlexToken token)
        {
            var componentCls = token.ComponentCls;
            var wrapStyle = new CSSInterpolation
            {
            };
            return wrapStyle;
        }

        public static CSSObject GenAlignItemsStyle(FlexToken token)
        {
            var componentCls = token.ComponentCls;
            var alignStyle = new CSSInterpolation
            {
            };
            return alignStyle;
        }

        public static CSSObject GenJustifyContentStyle(FlexToken token)
        {
            var componentCls = token.ComponentCls;
            var justifyStyle = new CSSInterpolation
            {
            };
            return justifyStyle;
        }

        public static FlexToken PrepareComponentToken()
        {
            return new FlexToken
            {
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Flex", (FlexToken token) =>
            {
                var paddingXS = token.PaddingXS;
                var padding = token.Padding;
                var paddingLG = token.PaddingLG;
                var flexToken = MergeToken(token, new object { FlexGapSM = paddingXS, FlexGap = padding, FlexGapLG = paddingLG, });
                return new object[]
                {
                    GenFlexStyle(flexToken),
                    GenFlexGapStyle(flexToken),
                    GenFlexWrapStyle(flexToken),
                    GenAlignItemsStyle(flexToken),
                    GenJustifyContentStyle(flexToken)
                };
            }, prepareComponentToken, new object { ResetStyle = false, });
        }
    }
}