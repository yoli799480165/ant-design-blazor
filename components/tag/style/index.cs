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
    public partial class TagStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string DefaultBg { get; set; }
            public string DefaultColor { get; set; }
        }

        public class TagToken : ComponentToken
        {
            public double TagFontSize { get; set; }
            public string TagLineHeight { get; set; }
            public string TagIconSize { get; set; }
            public double TagPaddingHorizontal { get; set; }
            public string TagBorderlessBg { get; set; }
        }

        public static CSSInterpolation GenBaseStyle(TagToken token)
        {
            var paddingXXS = token.PaddingXXS;
            var lineWidth = token.LineWidth;
            var tagPaddingHorizontal = token.TagPaddingHorizontal;
            var componentCls = token.ComponentCls;
            var calc = token.Calc;
            var paddingInline = Calc(tagPaddingHorizontal).Sub(lineWidth).Equal();
            var iconMarginInline = Calc(paddingXXS).Sub(lineWidth).Equal();
            return new CSSInterpolation
            {
                [componentCls] = new CSSInterpolation
                {
                    ["..."] = ResetComponent(token),
                    Display = "inline-block",
                    Height = "auto",
                    MarginInlineEnd = token.MarginXS,
                    FontSize = token.TagFontSize,
                    LineHeight = token.TagLineHeight,
                    WhiteSpace = "nowrap",
                    Background = token.DefaultBg,
                    Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                    BorderRadius = token.BorderRadiusSM,
                    Opacity = 1,
                    Transition = $@"{token.MotionDurationMid}",
                    TextAlign = "start",
                    Position = "relative",
                    [$@"{componentCls}-rtl"] = new CSSInterpolation
                    {
                        Direction = "rtl",
                    },
                    ["&, a, a:hover"] = new CSSInterpolation
                    {
                        Color = token.DefaultColor,
                    },
                    [$@"{componentCls}-close-icon"] = new CSSInterpolation
                    {
                        MarginInlineStart = iconMarginInline,
                        FontSize = token.TagIconSize,
                        Color = token.ColorTextDescription,
                        Cursor = "pointer",
                        Transition = $@"{token.MotionDurationMid}",
                        ["&:hover"] = new CSSInterpolation
                        {
                            Color = token.ColorTextHeading,
                        },
                    },
                    [$@"{componentCls}-has-color"] = new CSSInterpolation
                    {
                        BorderColor = "transparent",
                        [$@"{token.IconCls}-close, {token.IconCls}-close:hover"] = new CSSInterpolation
                        {
                            Color = token.ColorTextLightSolid,
                        },
                    },
                    ["&-checkable"] = new CSSInterpolation
                    {
                        BackgroundColor = "transparent",
                        BorderColor = "transparent",
                        Cursor = "pointer",
                        [$@"{componentCls}-checkable-checked):hover"] = new CSSInterpolation
                        {
                            Color = token.ColorPrimary,
                            BackgroundColor = token.ColorFillSecondary,
                        },
                        ["&:active, &-checked"] = new CSSInterpolation
                        {
                            Color = token.ColorTextLightSolid,
                        },
                        ["&-checked"] = new CSSInterpolation
                        {
                            BackgroundColor = token.ColorPrimary,
                            ["&:hover"] = new CSSInterpolation
                            {
                                BackgroundColor = token.ColorPrimaryHover,
                            },
                        },
                        ["&:active"] = new CSSInterpolation
                        {
                            BackgroundColor = token.ColorPrimaryActive,
                        },
                    },
                    ["&-hidden"] = new CSSInterpolation
                    {
                        Display = "none",
                    },
                    [$@"{token.IconCls} + span, > span + {token.IconCls}"] = new CSSInterpolation
                    {
                        MarginInlineStart = paddingInline,
                    },
                },
                [$@"{componentCls}-borderless"] = new CSSInterpolation
                {
                    BorderColor = "transparent",
                    Background = token.TagBorderlessBg,
                },
            };
        }

        public static object PrepareToken(TagToken token)
        {
            var lineWidth = token.LineWidth;
            var fontSizeIcon = token.FontSizeIcon;
            var calc = token.Calc;
            var tagFontSize = token.FontSizeSM;
            var tagToken = MergeToken(token, new object { TagLineHeight = Unit(Calc(token.LineHeightSM).Mul(tagFontSize).Equal()), TagIconSize = Calc(fontSizeIcon).Sub(Calc(lineWidth).Mul(2)).Equal(), TagPaddingHorizontal = 8, TagBorderlessBg = token.DefaultBg, });
            return tagToken;
        }

        public static TagToken PrepareComponentToken(TagToken token)
        {
            return new TagToken
            {
                DefaultBg = new FastColor(token.ColorFillQuaternary).OnBackground(token.ColorBgContainer).ToHexString(),
                DefaultColor = token.ColorText,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Tag", (TagToken token) =>
            {
                var tagToken = PrepareToken(token);
                return GenBaseStyle(tagToken);
            }, PrepareComponentToken);
        }
    }
}