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
    public partial class FormStyle
    {
        public static CSSObject GenFormValidateMotionStyle(FormToken token)
        {
            var componentCls = token.ComponentCls;
            var helpCls = $@"{componentCls}-show-help";
            var helpItemCls = $@"{componentCls}-show-help-item";
            return new CSSObject
            {
                [helpCls] = new CSSObject
                {
                    Transition = $@"{token.MotionDurationFast} {token.MotionEaseInOut}",
                    ["&-appear, &-enter"] = new CSSObject
                    {
                        Opacity = 0,
                        ["&-active"] = new CSSObject
                        {
                            Opacity = 1,
                        },
                    },
                    ["&-leave"] = new CSSObject
                    {
                        Opacity = 1,
                        ["&-active"] = new CSSObject
                        {
                            Opacity = 0,
                        },
                    },
                    [helpItemCls] = new CSSObject
                    {
                        Overflow = "hidden",
                        Transition = $@"{token.MotionDurationFast} {token.MotionEaseInOut},
                     opacity {token.MotionDurationFast} {token.MotionEaseInOut},
                     transform {token.MotionDurationFast} {token.MotionEaseInOut} !important",
                        [$@"{helpItemCls}-appear, &{helpItemCls}-enter"] = new CSSObject
                        {
                            Transform = "translateY(-5px)",
                            Opacity = 0,
                            ["&-active"] = new CSSObject
                            {
                                Transform = "translateY(0)",
                                Opacity = 1,
                            },
                        },
                        [$@"{helpItemCls}-leave-active"] = new CSSObject
                        {
                            Transform = "translateY(-5px)",
                        },
                    },
                },
            };
        }

        public static object ExplainDefault()
        {
            return GenFormValidateMotionStyle;
        }
    }
}