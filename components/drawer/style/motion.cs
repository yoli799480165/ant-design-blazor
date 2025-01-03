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
    public partial class DrawerStyle
    {
        public static object GetMoveTranslate(Direction direction)
        {
            var value = "100%";
            return direction[direction];
        }

        public static CSSObject GetEnterLeaveStyle(React.CSSProperties startStyle, React.CSSProperties endStyle)
        {
            return new CSSObject
            {
                ["&-enter, &-appear"] = new CSSObject
                {
                    ["..."] = startStyle,
                    ["&-active"] = endStyle,
                },
                ["&-leave"] = new CSSObject
                {
                    ["..."] = endStyle,
                    ["&-active"] = startStyle,
                },
            };
        }

        public static CSSObject GetFadeStyle(number from, string duration)
        {
            return new CSSObject
            {
                ["&-enter, &-appear, &-leave"] = new CSSObject
                {
                    ["&-start"] = new CSSObject
                    {
                        Transition = "none",
                    },
                    ["&-active"] = new CSSObject
                    {
                        Transition = $@"{duration}",
                    },
                },
                ["..."] = GetEnterLeaveStyle(new object { Opacity = from, }, new object { Opacity = 1, }),
            };
        }

        public static object GetPanelMotionStyles(Direction direction, string duration)
        {
            return new object[]
            {
                GetFadeStyle(0.7, duration),
                GetEnterLeaveStyle(new object { Transform = GetMoveTranslate(direction), }, new object { Transform = "none", })
            };
        }

        public static CSSObject GenMotionStyle(DrawerToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    [$@"{componentCls}-mask-motion"] = GetFadeStyle(0, motionDurationSlow),
                    [$@"{componentCls}-panel-motion"] = new object[]
                    {
                        "left",
                        "right",
                        "top",
                        "bottom"
                    }.Reduce((object obj, object direction) =>
                    {
                        return new object
                        {
                            ["..."] = obj,
                            [$@"{direction}"] = GetPanelMotionStyles(direction as Direction, motionDurationSlow),
                        };
                    }, new object { }),
                },
            };
        }

        public static object MotionDefault()
        {
            return GenMotionStyle;
        }
    }
}