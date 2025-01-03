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
        public static CSSObject GenHorizontalStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var stepsItemCls = $@"{componentCls}-item";
            return new CSSObject
            {
                [$@"{componentCls}-horizontal"] = new CSSObject
                {
                    [$@"{stepsItemCls}-tail"] = new CSSObject
                    {
                        Transform = "translateY(-50%)",
                    },
                },
            };
        }

        public static object HorizontalDefault()
        {
            return GenHorizontalStyle;
        }
    }
}