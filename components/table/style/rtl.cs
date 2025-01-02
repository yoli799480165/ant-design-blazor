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
        public static CSSObject GenStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                    ["table"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [$@"{componentCls}-pagination-left"] = new CSSObject
                    {
                        JustifyContent = "flex-end",
                    },
                    [$@"{componentCls}-pagination-right"] = new CSSObject
                    {
                        JustifyContent = "flex-start",
                    },
                    [$@"{componentCls}-row-expand-icon"] = new CSSObject
                    {
                        Float = "right",
                        ["&::after"] = new CSSObject
                        {
                            Transform = "rotate(-90deg)",
                        },
                        ["&-collapsed::before"] = new CSSObject
                        {
                            Transform = "rotate(180deg)",
                        },
                        ["&-collapsed::after"] = new CSSObject
                        {
                            Transform = "rotate(0deg)",
                        },
                    },
                    [$@"{componentCls}-container"] = new CSSObject
                    {
                        ["&::before"] = new CSSObject
                        {
                            InsetInlineStart = "unset",
                            InsetInlineEnd = 0,
                        },
                        ["&::after"] = new CSSObject
                        {
                            InsetInlineStart = 0,
                            InsetInlineEnd = "unset",
                        },
                        [$@"{componentCls}-row-indent"] = new CSSObject
                        {
                            Float = "right",
                        },
                    },
                },
            };
        }

        public static object RtlDefault()
        {
            return genStyle;
        }
    }
}