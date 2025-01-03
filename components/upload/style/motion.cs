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
    public partial class UploadStyle
    {
        public static CSSObject GenMotionStyle(UploadToken token)
        {
            var componentCls = token.ComponentCls;
            var uploadAnimateInlineIn = new Keyframes("uploadAnimateInlineIn", new object { From = new object { Width = 0, Height = 0, Padding = 0, Opacity = 0, Margin = token.Calc(token.MarginXS).Div(-2).Equal(), }, });
            var uploadAnimateInlineOut = new Keyframes("uploadAnimateInlineOut", new object { ["to"] = new object { Width = 0, Height = 0, Padding = 0, Opacity = 0, Margin = token.Calc(token.MarginXS).Div(-2).Equal(), }, });
            var inlineCls = $@"{componentCls}-animate-inline";
            return new object[]
            {
                new object
                {
                    [$@"{componentCls}-wrapper"] = new object
                    {
                        [$@"{inlineCls}-appear, {inlineCls}-enter, {inlineCls}-leave"] = new object
                        {
                            AnimationDuration = token.MotionDurationSlow,
                            AnimationTimingFunction = token.MotionEaseInOutCirc,
                            AnimationFillMode = "forwards",
                        },
                        [$@"{inlineCls}-appear, {inlineCls}-enter"] = new object
                        {
                            AnimationName = uploadAnimateInlineIn,
                        },
                        [$@"{inlineCls}-leave"] = new object
                        {
                            AnimationName = uploadAnimateInlineOut,
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}-wrapper"] = InitFadeMotion(token),
                },
                uploadAnimateInlineIn,
                uploadAnimateInlineOut
            };
        }

        public static object MotionDefault()
        {
            return GenMotionStyle;
        }
    }
}