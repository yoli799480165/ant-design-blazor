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
    public partial class FloatButtonStyle
    {
        public static object FloatButtonGroupMotion(FloatButtonToken token)
        {
            var componentCls = token.ComponentCls;
            var floatButtonSize = token.FloatButtonSize;
            var motionDurationSlow = token.MotionDurationSlow;
            var motionEaseInOutCirc = token.MotionEaseInOutCirc;
            var calc = token.Calc;
            var moveTopIn = new Keyframes("antFloatButtonMoveTopIn", new object { ["0%"] = new object { Transform = $@"{Unit(floatButtonSize)}, 0)", TransformOrigin = "0 0", Opacity = 0, }, ["100%"] = new object { Transform = "translate3d(0, 0, 0)", TransformOrigin = "0 0", Opacity = 1, }, });
            var moveTopOut = new Keyframes("antFloatButtonMoveTopOut", new object { ["0%"] = new object { Transform = "translate3d(0, 0, 0)", TransformOrigin = "0 0", Opacity = 1, }, ["100%"] = new object { Transform = $@"{Unit(floatButtonSize)}, 0)", TransformOrigin = "0 0", Opacity = 0, }, });
            var moveRightIn = new Keyframes("antFloatButtonMoveRightIn", new object { ["0%"] = new object { Transform = $@"{Calc(floatButtonSize).Mul(-1).Equal()}, 0, 0)", TransformOrigin = "0 0", Opacity = 0, }, ["100%"] = new object { Transform = "translate3d(0, 0, 0)", TransformOrigin = "0 0", Opacity = 1, }, });
            var moveRightOut = new Keyframes("antFloatButtonMoveRightOut", new object { ["0%"] = new object { Transform = "translate3d(0, 0, 0)", TransformOrigin = "0 0", Opacity = 1, }, ["100%"] = new object { Transform = $@"{Calc(floatButtonSize).Mul(-1).Equal()}, 0, 0)", TransformOrigin = "0 0", Opacity = 0, }, });
            var moveBottomIn = new Keyframes("antFloatButtonMoveBottomIn", new object { ["0%"] = new object { Transform = $@"{Calc(floatButtonSize).Mul(-1).Equal()}, 0)", TransformOrigin = "0 0", Opacity = 0, }, ["100%"] = new object { Transform = "translate3d(0, 0, 0)", TransformOrigin = "0 0", Opacity = 1, }, });
            var moveBottomOut = new Keyframes("antFloatButtonMoveBottomOut", new object { ["0%"] = new object { Transform = "translate3d(0, 0, 0)", TransformOrigin = "0 0", Opacity = 1, }, ["100%"] = new object { Transform = $@"{Calc(floatButtonSize).Mul(-1).Equal()}, 0)", TransformOrigin = "0 0", Opacity = 0, }, });
            var moveLeftIn = new Keyframes("antFloatButtonMoveLeftIn", new object { ["0%"] = new object { Transform = $@"{Unit(floatButtonSize)}, 0, 0)", TransformOrigin = "0 0", Opacity = 0, }, ["100%"] = new object { Transform = "translate3d(0, 0, 0)", TransformOrigin = "0 0", Opacity = 1, }, });
            var moveLeftOut = new Keyframes("antFloatButtonMoveLeftOut", new object { ["0%"] = new object { Transform = "translate3d(0, 0, 0)", TransformOrigin = "0 0", Opacity = 1, }, ["100%"] = new object { Transform = $@"{Unit(floatButtonSize)}, 0, 0)", TransformOrigin = "0 0", Opacity = 0, }, });
            var groupPrefixCls = $@"{componentCls}-group";
            return new object[]
            {
                new object
                {
                    [groupPrefixCls] = new object
                    {
                        [$@"{groupPrefixCls}-top {groupPrefixCls}-wrap"] = InitMotion($@"{groupPrefixCls}-wrap", moveTopIn, moveTopOut, motionDurationSlow, true),
                        [$@"{groupPrefixCls}-bottom {groupPrefixCls}-wrap"] = InitMotion($@"{groupPrefixCls}-wrap", moveBottomIn, moveBottomOut, motionDurationSlow, true),
                        [$@"{groupPrefixCls}-left {groupPrefixCls}-wrap"] = InitMotion($@"{groupPrefixCls}-wrap", moveLeftIn, moveLeftOut, motionDurationSlow, true),
                        [$@"{groupPrefixCls}-right {groupPrefixCls}-wrap"] = InitMotion($@"{groupPrefixCls}-wrap", moveRightIn, moveRightOut, motionDurationSlow, true),
                    },
                },
                new object
                {
                    [$@"{groupPrefixCls}-wrap"] = new object
                    {
                        [$@"{groupPrefixCls}-wrap-enter, &{groupPrefixCls}-wrap-appear"] = new object
                        {
                            Opacity = 0,
                            AnimationTimingFunction = motionEaseInOutCirc,
                        },
                        [$@"{groupPrefixCls}-wrap-leave"] = new object
                        {
                            Opacity = 1,
                            AnimationTimingFunction = motionEaseInOutCirc,
                        },
                    },
                }
            };
        }

        public static object KeyframesDefault()
        {
            return floatButtonGroupMotion;
        }
    }
}