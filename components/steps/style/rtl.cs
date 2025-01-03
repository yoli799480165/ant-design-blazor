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
    public partial class StepsStyle
    {
        public static CSSObject GenStepsRTLStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        ["&-subtitle"] = new CSSObject
                        {
                            Float = "left",
                        },
                    },
                    [$@"{componentCls}-navigation"] = new CSSObject
                    {
                        [$@"{componentCls}-item::after"] = new CSSObject
                        {
                            Transform = "rotate(-45deg)",
                        },
                    },
                    [$@"{componentCls}-vertical"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            ["&::after"] = new CSSObject
                            {
                                Transform = "rotate(225deg)",
                            },
                            [$@"{componentCls}-item-icon"] = new CSSObject
                            {
                                Float = "right",
                            },
                        },
                    },
                    [$@"{componentCls}-dot"] = new CSSObject
                    {
                        [$@"{componentCls}-item-icon {componentCls}-icon-dot, &{componentCls}-small {componentCls}-item-icon {componentCls}-icon-dot"] = new CSSObject
                        {
                            Float = "right",
                        },
                    },
                },
            };
        }

        public static object RtlDefault()
        {
            return GenStepsRTLStyle;
        }
    }
}