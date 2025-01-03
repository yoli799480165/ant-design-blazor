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
        public static CSSObject GenRtlStyle(UploadToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                },
            };
        }

        public static object RtlDefault()
        {
            return GenRtlStyle;
        }
    }
}