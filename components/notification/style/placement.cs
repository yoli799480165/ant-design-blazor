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
    public partial class NotificationStyle
    {
        public static CSSObject GenNotificationPlacementStyle(NotificationToken token)
        {
            var componentCls = token.ComponentCls;
            var notificationMarginEdge = token.NotificationMarginEdge;
            var animationMaxHeight = token.AnimationMaxHeight;
            var noticeCls = $@"{componentCls}-notice";
            var rightFadeIn = new Keyframes("antNotificationFadeIn", new object { ["0%"] = new object { Transform = "translate3d(100%, 0, 0)", Opacity = 0, }, ["100%"] = new object { Transform = "translate3d(0, 0, 0)", Opacity = 1, }, });
            var topFadeIn = new Keyframes("antNotificationTopFadeIn", new object { ["0%"] = new object { Top = -animationMaxHeight, Opacity = 0, }, ["100%"] = new object { Top = 0, Opacity = 1, }, });
            var bottomFadeIn = new Keyframes("antNotificationBottomFadeIn", new object { ["0%"] = new object { Bottom = token.Calc(animationMaxHeight).Mul(-1).Equal(), Opacity = 0, }, ["100%"] = new object { Bottom = 0, Opacity = 1, }, });
            var leftFadeIn = new Keyframes("antNotificationLeftFadeIn", new object { ["0%"] = new object { Transform = "translate3d(-100%, 0, 0)", Opacity = 0, }, ["100%"] = new object { Transform = "translate3d(0, 0, 0)", Opacity = 1, }, });
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    [$@"{componentCls}-top, &{componentCls}-bottom"] = new CSSObject
                    {
                        MarginInline = 0,
                        [noticeCls] = new CSSObject
                        {
                            MarginInline = "auto auto",
                        },
                    },
                    [$@"{componentCls}-top"] = new CSSObject
                    {
                        [$@"{componentCls}-fade-enter{componentCls}-fade-enter-active, {componentCls}-fade-appear{componentCls}-fade-appear-active"] = new CSSObject
                        {
                            AnimationName = topFadeIn,
                        },
                    },
                    [$@"{componentCls}-bottom"] = new CSSObject
                    {
                        [$@"{componentCls}-fade-enter{componentCls}-fade-enter-active, {componentCls}-fade-appear{componentCls}-fade-appear-active"] = new CSSObject
                        {
                            AnimationName = bottomFadeIn,
                        },
                    },
                    [$@"{componentCls}-topRight, &{componentCls}-bottomRight"] = new CSSObject
                    {
                        [$@"{componentCls}-fade-enter{componentCls}-fade-enter-active, {componentCls}-fade-appear{componentCls}-fade-appear-active"] = new CSSObject
                        {
                            AnimationName = rightFadeIn,
                        },
                    },
                    [$@"{componentCls}-topLeft, &{componentCls}-bottomLeft"] = new CSSObject
                    {
                        MarginRight = new CSSObject
                        {
                            Value = 0,
                            _skip_check_ = true,
                        },
                        MarginLeft = new CSSObject
                        {
                            Value = notificationMarginEdge,
                            _skip_check_ = true,
                        },
                        [noticeCls] = new CSSObject
                        {
                            MarginInlineEnd = "auto",
                            MarginInlineStart = 0,
                        },
                        [$@"{componentCls}-fade-enter{componentCls}-fade-enter-active, {componentCls}-fade-appear{componentCls}-fade-appear-active"] = new CSSObject
                        {
                            AnimationName = leftFadeIn,
                        },
                    },
                },
            };
        }

        public static object PlacementDefault()
        {
            return GenNotificationPlacementStyle;
        }
    }
}