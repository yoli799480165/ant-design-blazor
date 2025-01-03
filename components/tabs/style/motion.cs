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
    public partial class TabsStyle
    {
        public static CSSObject GenMotionStyle(TabsToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        [$@"{componentCls}-switch"] = new object
                        {
                            ["&-appear, &-enter"] = new object
                            {
                                Transition = "none",
                                ["&-start"] = new object
                                {
                                    Opacity = 0,
                                },
                                ["&-active"] = new object
                                {
                                    Opacity = 1,
                                    Transition = $@"{motionDurationSlow}",
                                },
                            },
                            ["&-leave"] = new object
                            {
                                Position = "absolute",
                                Transition = "none",
                                Inset = 0,
                                ["&-start"] = new object
                                {
                                    Opacity = 1,
                                },
                                ["&-active"] = new object
                                {
                                    Opacity = 0,
                                    Transition = $@"{motionDurationSlow}",
                                },
                            },
                        },
                    },
                },
                new object[]
                {
                    InitSlideMotion(token, "slide-up"),
                    InitSlideMotion(token, "slide-down")
                }
            };
        }

        public static object MotionDefault()
        {
            return GenMotionStyle;
        }
    }
}