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
    public partial class AnchorStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double LinkPaddingBlock { get; set; }
            public double LinkPaddingInlineStart { get; set; }
        }

        public class AnchorToken : ComponentToken
        {
            public double HolderOffsetBlock { get; set; }
            public string AnchorPaddingBlockSecondary { get; set; }
            public string AnchorBallSize { get; set; }
            public string AnchorTitleBlock { get; set; }
        }

        public static CSSObject GenSharedAnchorStyle(AnchorToken token)
        {
            var componentCls = token.ComponentCls;
            var holderOffsetBlock = token.HolderOffsetBlock;
            var motionDurationSlow = token.MotionDurationSlow;
            var lineWidthBold = token.LineWidthBold;
            var colorPrimary = token.ColorPrimary;
            var lineType = token.LineType;
            var colorSplit = token.ColorSplit;
            var calc = token.Calc;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    MarginBlockStart = Calc(holderOffsetBlock).Mul(-1).Equal(),
                    PaddingBlockStart = holderOffsetBlock,
                    [componentCls] = new CSSObject
                    {
                        ["..."] = ResetComponent(token),
                        Position = "relative",
                        PaddingInlineStart = lineWidthBold,
                        [$@"{componentCls}-link"] = new CSSObject
                        {
                            PaddingBlock = token.LinkPaddingBlock,
                            PaddingInline = $@"{Unit(token.LinkPaddingInlineStart)} 0",
                            ["&-title"] = new CSSObject
                            {
                                ["..."] = textEllipsis,
                                Position = "relative",
                                Display = "block",
                                MarginBlockEnd = token.AnchorTitleBlock,
                                Color = token.ColorText,
                                Transition = $@"{token.MotionDurationSlow}",
                                ["&:only-child"] = new CSSObject
                                {
                                    MarginBlockEnd = 0,
                                },
                            },
                            [$@"{componentCls}-link-title"] = new CSSObject
                            {
                                Color = token.ColorPrimary,
                            },
                            [$@"{componentCls}-link"] = new CSSObject
                            {
                                PaddingBlock = token.AnchorPaddingBlockSecondary,
                            },
                        },
                    },
                    [$@"{componentCls}-wrapper-horizontal)"] = new CSSObject
                    {
                        [componentCls] = new CSSObject
                        {
                            ["&::before"] = new CSSObject
                            {
                                Position = "absolute",
                                InsetInlineStart = 0,
                                Top = 0,
                                Height = "100%",
                                BorderInlineStart = $@"{Unit(lineWidthBold)} {lineType} {colorSplit}",
                                Content = "\" \"",
                            },
                            [$@"{componentCls}-ink"] = new CSSObject
                            {
                                Position = "absolute",
                                InsetInlineStart = 0,
                                Display = "none",
                                Transform = "translateY(-50%)",
                                Transition = $@"{motionDurationSlow} ease-in-out",
                                Width = lineWidthBold,
                                BackgroundColor = colorPrimary,
                                [$@"{componentCls}-ink-visible"] = new CSSObject
                                {
                                    Display = "inline-block",
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-fixed {componentCls}-ink {componentCls}-ink"] = new CSSObject
                    {
                        Display = "none",
                    },
                },
            };
        }

        public static CSSObject GenSharedAnchorHorizontalStyle(AnchorToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var lineWidthBold = token.LineWidthBold;
            var colorPrimary = token.ColorPrimary;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper-horizontal"] = new CSSObject
                {
                    Position = "relative",
                    ["&::before"] = new CSSObject
                    {
                        Position = "absolute",
                        Left = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = 0,
                        },
                        Right = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = 0,
                        },
                        Bottom = 0,
                        BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                        Content = "\" \"",
                    },
                    [componentCls] = new CSSObject
                    {
                        OverflowX = "scroll",
                        Position = "relative",
                        Display = "flex",
                        ScrollbarWidth = "none",
                        ["&::-webkit-scrollbar"] = new CSSObject
                        {
                            Display = "none",
                        },
                        [$@"{componentCls}-link:first-of-type"] = new CSSObject
                        {
                            PaddingInline = 0,
                        },
                        [$@"{componentCls}-ink"] = new CSSObject
                        {
                            Position = "absolute",
                            Bottom = 0,
                            Transition = $@"{motionDurationSlow} ease-in-out, width {motionDurationSlow} ease-in-out",
                            Height = lineWidthBold,
                            BackgroundColor = colorPrimary,
                        },
                    },
                },
            };
        }

        public static AnchorToken PrepareComponentToken(AnchorToken token)
        {
            return new AnchorToken
            {
                LinkPaddingBlock = token.PaddingXXS,
                LinkPaddingInlineStart = token.Padding,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Anchor", (AnchorToken token) =>
            {
                var fontSize = token.FontSize;
                var fontSizeLG = token.FontSizeLG;
                var paddingXXS = token.PaddingXXS;
                var calc = token.Calc;
                var anchorToken = MergeToken(token, new object { HolderOffsetBlock = paddingXXS, AnchorPaddingBlockSecondary = Calc(paddingXXS).Div(2).Equal(), AnchorTitleBlock = Calc(fontSize).Div(14).Mul(3).Equal(), AnchorBallSize = Calc(fontSizeLG).Div(2).Equal(), });
                return new object[]
                {
                    GenSharedAnchorStyle(anchorToken),
                    GenSharedAnchorHorizontalStyle(anchorToken)
                };
            }, PrepareComponentToken);
        }
    }
}