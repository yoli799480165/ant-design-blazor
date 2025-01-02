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
    public partial class TableStyle
    {
        public static CSSObject GenEmptyStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-tbody > tr{componentCls}-placeholder"] = new CSSObject
                    {
                        TextAlign = "center",
                        Color = token.ColorTextDisabled,
                        ["\n          &:hover > th,\n          &:hover > td,\n        "] = new CSSObject
                        {
                            Background = token.ColorBgContainer,
                        },
                    },
                },
            };
        }

        public static object EmptyDefault()
        {
            return genEmptyStyle;
        }
    }
}