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
    public partial class MenuStyle
    {
        public static CSSObject GetRTLStyle(object {
  componentCls,
  menuArrowOffset,
  calc,
})
        {
            return new CSSObject
            {
                [$@"{componentCls}-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                },
                [$@"{componentCls}-submenu-rtl"] = new CSSObject
                {
                    TransformOrigin = "100% 0",
                },
                [$@"{componentCls}-rtl{componentCls}-vertical,
    {componentCls}-submenu-rtl {componentCls}-vertical"] = new CSSObject
                {
                    [$@"{componentCls}-submenu-arrow"] = new CSSObject
                    {
                        ["&::before"] = new CSSObject
                        {
                            Transform = $@"{Unit(calc(menuArrowOffset).mul(-1).Equal())})",
                        },
                        ["&::after"] = new CSSObject
                        {
                            Transform = $@"{Unit(menuArrowOffset)})",
                        },
                    },
                },
            };
        }

        public static object RtlDefault()
        {
            return getRTLStyle;
        }
    }
}