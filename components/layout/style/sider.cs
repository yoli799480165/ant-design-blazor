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
    public partial class LayoutStyle
    {
        public static CSSObject GenSiderStyle(LayoutToken token)
        {
            var componentCls = token.ComponentCls;
            var siderBg = token.SiderBg;
            var motionDurationMid = token.MotionDurationMid;
            var motionDurationSlow = token.MotionDurationSlow;
            var antCls = token.AntCls;
            var triggerHeight = token.TriggerHeight;
            var triggerColor = token.TriggerColor;
            var triggerBg = token.TriggerBg;
            var headerHeight = token.HeaderHeight;
            var zeroTriggerWidth = token.ZeroTriggerWidth;
            var zeroTriggerHeight = token.ZeroTriggerHeight;
            var borderRadius = token.BorderRadius;
            var lightSiderBg = token.LightSiderBg;
            var lightTriggerColor = token.LightTriggerColor;
            var lightTriggerBg = token.LightTriggerBg;
            var bodyBg = token.BodyBg;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Position = "relative",
                    MinWidth = 0,
                    Background = siderBg,
                    Transition = $@"{motionDurationMid}, background 0s",
                    ["&-has-trigger"] = new CSSObject
                    {
                        PaddingBottom = triggerHeight,
                    },
                    ["&-right"] = new CSSObject
                    {
                        Order = 1,
                    },
                    [$@"{componentCls}-children"] = new CSSObject
                    {
                        Height = "100%",
                        MarginTop = -0.1,
                        PaddingTop = 0.1,
                        [$@"{antCls}-menu{antCls}-menu-inline-collapsed"] = new CSSObject
                        {
                            Width = "auto",
                        },
                    },
                    [$@"{componentCls}-trigger"] = new CSSObject
                    {
                        Position = "fixed",
                        Bottom = 0,
                        ZIndex = 1,
                        Height = triggerHeight,
                        Color = triggerColor,
                        LineHeight = Unit(triggerHeight),
                        TextAlign = "center",
                        Background = triggerBg,
                        Cursor = "pointer",
                        Transition = $@"{motionDurationMid}",
                    },
                    [$@"{antCls}-layout &-zero-width"] = new CSSObject
                    {
                        ["> *"] = new CSSObject
                        {
                            Overflow = "hidden",
                        },
                        ["&-trigger"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = headerHeight,
                            InsetInlineEnd = token.calc(zeroTriggerWidth).mul(-1).Equal(),
                            ZIndex = 1,
                            Width = zeroTriggerWidth,
                            Height = zeroTriggerHeight,
                            Color = triggerColor,
                            FontSize = token.FontSizeXL,
                            Display = "flex",
                            AlignItems = "center",
                            JustifyContent = "center",
                            Background = siderBg,
                            BorderStartStartRadius = 0,
                            BorderStartEndRadius = borderRadius,
                            BorderEndEndRadius = borderRadius,
                            BorderEndStartRadius = 0,
                            Cursor = "pointer",
                            Transition = $@"{motionDurationSlow} ease",
                            ["&::after"] = new CSSObject
                            {
                                Position = "absolute",
                                Inset = 0,
                                Background = "transparent",
                                Transition = $@"{motionDurationSlow}",
                                Content = "\"\"",
                            },
                            ["&:hover::after"] = new CSSObject
                            {
                                Background = "rgba(255, 255, 255, 0.2)",
                            },
                            ["&-right"] = new CSSObject
                            {
                                InsetInlineStart = token.calc(zeroTriggerWidth).mul(-1).Equal(),
                                BorderStartStartRadius = borderRadius,
                                BorderStartEndRadius = 0,
                                BorderEndEndRadius = 0,
                                BorderEndStartRadius = borderRadius,
                            },
                        },
                    },
                    ["&-light"] = new CSSObject
                    {
                        Background = lightSiderBg,
                        [$@"{componentCls}-trigger"] = new CSSObject
                        {
                            Color = lightTriggerColor,
                            Background = lightTriggerBg,
                        },
                        [$@"{componentCls}-zero-width-trigger"] = new CSSObject
                        {
                            Color = lightTriggerColor,
                            Background = lightTriggerBg,
                            Border = $@"{bodyBg}",
                            BorderInlineStart = 0,
                        },
                    },
                },
            };
        }

        public static object SiderDefault()
        {
            return GenStyleHooks(new object[] { "Layout", "Sider" }, (LayoutToken token) =>
            {
                return new object[]
                {
                    GenSiderStyle(token)
                };
            }, prepareComponentToken, new object { DeprecatedTokens = DEPRECATED_TOKENS, });
        }
    }
}