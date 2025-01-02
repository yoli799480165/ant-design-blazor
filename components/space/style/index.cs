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
    public partial class SpaceStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
        }

        public class SpaceToken : ComponentToken
        {
            public double SpaceGapSmallSize { get; set; }
            public double SpaceGapMiddleSize { get; set; }
            public double SpaceGapLargeSize { get; set; }
        }

        public static CSSObject GenSpaceStyle(SpaceToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Display = "inline-flex",
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    ["&-vertical"] = new CSSObject
                    {
                        FlexDirection = "column",
                    },
                    ["&-align"] = new CSSObject
                    {
                        FlexDirection = "column",
                        ["&-center"] = new CSSObject
                        {
                            AlignItems = "center",
                        },
                        ["&-start"] = new CSSObject
                        {
                            AlignItems = "flex-start",
                        },
                        ["&-end"] = new CSSObject
                        {
                            AlignItems = "flex-end",
                        },
                        ["&-baseline"] = new CSSObject
                        {
                            AlignItems = "baseline",
                        },
                    },
                    [$@"{componentCls}-item:empty"] = new CSSObject
                    {
                        Display = "none",
                    },
                    [$@"{componentCls}-item > {antCls}-badge-not-a-wrapper:only-child"] = new CSSObject
                    {
                        Display = "block",
                    },
                },
            };
        }

        public static CSSObject GenSpaceGapStyle(SpaceToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["&-gap-row-small"] = new CSSObject
                    {
                        RowGap = token.SpaceGapSmallSize,
                    },
                    ["&-gap-row-middle"] = new CSSObject
                    {
                        RowGap = token.SpaceGapMiddleSize,
                    },
                    ["&-gap-row-large"] = new CSSObject
                    {
                        RowGap = token.SpaceGapLargeSize,
                    },
                    ["&-gap-col-small"] = new CSSObject
                    {
                        ColumnGap = token.SpaceGapSmallSize,
                    },
                    ["&-gap-col-middle"] = new CSSObject
                    {
                        ColumnGap = token.SpaceGapMiddleSize,
                    },
                    ["&-gap-col-large"] = new CSSObject
                    {
                        ColumnGap = token.SpaceGapLargeSize,
                    },
                },
            };
        }

        public static SpaceToken PrepareComponentToken()
        {
            return new SpaceToken
            {
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Space", (SpaceToken token) =>
            {
                var spaceToken = MergeToken(token, new object { SpaceGapSmallSize = token.PaddingXS, SpaceGapMiddleSize = token.Padding, SpaceGapLargeSize = token.PaddingLG, });
                return new object[]
                {
                    GenSpaceStyle(spaceToken),
                    GenSpaceGapStyle(spaceToken),
                    GenSpaceCompactStyle(spaceToken)
                };
            }, () =>
            {
                return new object
                {
                };
            }, new object { ResetStyle = false, });
        }
    }
}