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
    public partial class BadgeStyle
    {
        public static CSSObject GenRibbonStyle(BadgeToken token)
        {
            var antCls = token.AntCls;
            var badgeFontHeight = token.BadgeFontHeight;
            var marginXS = token.MarginXS;
            var badgeRibbonOffset = token.BadgeRibbonOffset;
            var calc = token.Calc;
            var ribbonPrefixCls = $@"{antCls}-ribbon";
            var ribbonWrapperPrefixCls = $@"{antCls}-ribbon-wrapper";
            var statusRibbonPreset = GenPresetColor(token, (object colorKey, object { darkColor }) =>
            {
                return new object
                {
                    [$@"{ribbonPrefixCls}-color-{colorKey}"] = new object
                    {
                        Background = darkColor,
                        Color = darkColor,
                    },
                };
            });
            return new CSSObject
            {
                [ribbonWrapperPrefixCls] = new CSSObject
                {
                    Position = "relative",
                },
                [ribbonPrefixCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "absolute",
                    Top = marginXS,
                    Padding = $@"{Unit(token.PaddingXS)}",
                    Color = token.ColorPrimary,
                    LineHeight = Unit(badgeFontHeight),
                    WhiteSpace = "nowrap",
                    BackgroundColor = token.ColorPrimary,
                    BorderRadius = token.BorderRadiusSM,
                    [$@"{ribbonPrefixCls}-text"] = new CSSObject
                    {
                        Color = token.BadgeTextColor,
                    },
                    [$@"{ribbonPrefixCls}-corner"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = "100%",
                        Width = badgeRibbonOffset,
                        Height = badgeRibbonOffset,
                        Color = "currentcolor",
                        Border = $@"{Unit(calc(badgeRibbonOffset).div(2).Equal())} solid",
                        Transform = token.BadgeRibbonCornerTransform,
                        TransformOrigin = "top",
                        Filter = token.BadgeRibbonCornerFilter,
                    },
                    ["..."] = statusRibbonPreset,
                    [$@"{ribbonPrefixCls}-placement-end"] = new CSSObject
                    {
                        InsetInlineEnd = calc(badgeRibbonOffset).mul(-1).Equal(),
                        BorderEndEndRadius = 0,
                        [$@"{ribbonPrefixCls}-corner"] = new CSSObject
                        {
                            InsetInlineEnd = 0,
                            BorderInlineEndColor = "transparent",
                            BorderBlockEndColor = "transparent",
                        },
                    },
                    [$@"{ribbonPrefixCls}-placement-start"] = new CSSObject
                    {
                        InsetInlineStart = calc(badgeRibbonOffset).mul(-1).Equal(),
                        BorderEndStartRadius = 0,
                        [$@"{ribbonPrefixCls}-corner"] = new CSSObject
                        {
                            InsetInlineStart = 0,
                            BorderBlockEndColor = "transparent",
                            BorderInlineStartColor = "transparent",
                        },
                    },
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                },
            };
        }

        public static object RibbonDefault()
        {
            return GenStyleHooks(new object[] { "Badge", "Ribbon" }, (BadgeToken token) =>
            {
                var badgeToken = PrepareToken(token);
                return GenRibbonStyle(badgeToken);
            }, prepareComponentToken);
        }
    }
}