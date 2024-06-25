using System;
using CssInCSharp;
using static AntDesign.GlobalStyle;
using static AntDesign.Theme;
using static AntDesign.StyleUtil;

namespace AntDesign
{
    public partial class AnchorToken : TokenWithCommonCls
    {
        public double LinkPaddingBlock
        {
            get => (double)_tokens["linkPaddingBlock"];
            set => _tokens["linkPaddingBlock"] = value;
        }

        public double LinkPaddingInlineStart
        {
            get => (double)_tokens["linkPaddingInlineStart"];
            set => _tokens["linkPaddingInlineStart"] = value;
        }

    }

    public partial class AnchorToken
    {
        public double HolderOffsetBlock
        {
            get => (double)_tokens["holderOffsetBlock"];
            set => _tokens["holderOffsetBlock"] = value;
        }

        public string AnchorPaddingBlockSecondary
        {
            get => (string)_tokens["anchorPaddingBlockSecondary"];
            set => _tokens["anchorPaddingBlockSecondary"] = value;
        }

        public string AnchorBallSize
        {
            get => (string)_tokens["anchorBallSize"];
            set => _tokens["anchorBallSize"] = value;
        }

        public string AnchorTitleBlock
        {
            get => (string)_tokens["anchorTitleBlock"];
            set => _tokens["anchorTitleBlock"] = value;
        }

    }

    public partial class Anchor
    {
        public CSSInterpolation GenSharedAnchorStyle(AnchorToken token)
        {
            var componentCls = token.ComponentCls;
            var holderOffsetBlock = token.HolderOffsetBlock;
            var motionDurationSlow = token.MotionDurationSlow;
            var lineWidthBold = token.LineWidthBold;
            var colorPrimary = token.ColorPrimary;
            var lineType = token.LineType;
            var colorSplit = token.ColorSplit;
            var calc = token.Calc;
            return new CSSObject()
            {
                [$"{componentCls}-wrapper"] = new CSSObject()
                {
                    MarginBlockStart = token.Calc(holderOffsetBlock).Mul(-1).Equal(),
                    PaddingBlockStart = holderOffsetBlock,
                    [componentCls] = new CSSObject()
                    {
                        ["..."] = ResetComponent(token),
                        Position = "relative",
                        PaddingInlineStart = lineWidthBold,
                        [$"{componentCls}-link"] = new CSSObject()
                        {
                            PaddingBlock = token.LinkPaddingBlock,
                            PaddingInline = @$"{Unit(token.LinkPaddingInlineStart)} 0",
                            ["&-title"] = new CSSObject()
                            {
                                ["..."] = TextEllipsis,
                                Position = "relative",
                                Display = "block",
                                MarginBlockEnd = token.AnchorTitleBlock,
                                Color = token.ColorText,
                                Transition = @$"all {token.MotionDurationSlow}",
                                ["&:only-child"] = new CSSObject()
                                {
                                    MarginBlockEnd = 0,
                                },
                            },
                            [$"&-active > {componentCls}-link-title"] = new CSSObject()
                            {
                                Color = token.ColorPrimary,
                            },
                            [$"{componentCls}-link"] = new CSSObject()
                            {
                                PaddingBlock = token.AnchorPaddingBlockSecondary,
                            },
                        },
                    },
                    [$"&:not({componentCls}-wrapper-horizontal)"] = new CSSObject()
                    {
                        [componentCls] = new CSSObject()
                        {
                            ["&::before"] = new CSSObject()
                            {
                                Position = "absolute",
                                InsetInlineStart = 0,
                                Top = 0,
                                Height = "100%",
                                BorderInlineStart = @$"{Unit(lineWidthBold)} {lineType} {colorSplit}",
                                Content = "\" \"",
                            },
                            [$"{componentCls}-ink"] = new CSSObject()
                            {
                                Position = "absolute",
                                InsetInlineStart = 0,
                                Display = "none",
                                Transform = "translateY(-50%)",
                                Transition = @$"top {motionDurationSlow} ease-in-out",
                                Width = lineWidthBold,
                                BackgroundColor = colorPrimary,
                                [$"&{componentCls}-ink-visible"] = new CSSObject()
                                {
                                    Display = "inline-block",
                                },
                            },
                        },
                    },
                    [$"{componentCls}-fixed {componentCls}-ink {componentCls}-ink"] = new CSSObject()
                    {
                        Display = "none",
                    },
                },
            };
        }

        public CSSInterpolation GenSharedAnchorHorizontalStyle(AnchorToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var lineWidthBold = token.LineWidthBold;
            var colorPrimary = token.ColorPrimary;
            return new CSSObject()
            {
                [$"{componentCls}-wrapper-horizontal"] = new CSSObject()
                {
                    Position = "relative",
                    ["&::before"] = new CSSObject()
                    {
                        Position = "absolute",
                        Left = new PropertySkip()
                        {
                            SkipCheck = true,
                            Value = 0,
                        },
                        Right = new PropertySkip()
                        {
                            SkipCheck = true,
                            Value = 0,
                        },
                        Bottom = 0,
                        BorderBottom = @$"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                        Content = "\" \"",
                    },
                    [componentCls] = new CSSObject()
                    {
                        OverflowX = "scroll",
                        Position = "relative",
                        Display = "flex",
                        ScrollbarWidth = "none",
                        ["&::-webkit-scrollbar"] = new CSSObject()
                        {
                            Display = "none",
                        },
                        [$"{componentCls}-link:first-of-type"] = new CSSObject()
                        {
                            PaddingInline = 0,
                        },
                        [$"{componentCls}-ink"] = new CSSObject()
                        {
                            Position = "absolute",
                            Bottom = 0,
                            Transition = @$"left {motionDurationSlow} ease-in-out, width {motionDurationSlow} ease-in-out",
                            Height = lineWidthBold,
                            BackgroundColor = colorPrimary,
                        },
                    },
                },
            };
        }

        public AnchorToken PrepareComponentToken(GlobalToken token)
        {
            return new AnchorToken()
            {
                LinkPaddingBlock = token.PaddingXXS,
                LinkPaddingInlineStart = token.Padding,
            };
        }

        protected override UseComponentStyleResult UseComponentStyle()
        {
            return GenStyleHooks(
                "Anchor",
                (token) =>
                {
                    var fontSize = token.FontSize;
                    var fontSizeLG = token.FontSizeLG;
                    var paddingXXS = token.PaddingXXS;
                    var calc = token.Calc;
                    var anchorToken = MergeToken(
                        token,
                        new AnchorToken()
                        {
                            HolderOffsetBlock = paddingXXS,
                            AnchorPaddingBlockSecondary = token.Calc(paddingXXS).Div(2).Equal(),
                            AnchorTitleBlock = token.Calc(fontSize).Div(14).Mul(3).Equal(),
                            AnchorBallSize = token.Calc(fontSizeLG).Div(2).Equal()
                        });
                    return new CSSInterpolation[]
                    {
                        GenSharedAnchorStyle(anchorToken),
                        GenSharedAnchorHorizontalStyle(anchorToken),
                    };
                },
                PrepareComponentToken);
        }

    }

}
