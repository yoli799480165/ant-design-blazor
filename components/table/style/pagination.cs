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
        public static CSSObject GenPaginationStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var margin = token.Margin;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-pagination{antCls}-pagination"] = new CSSObject
                    {
                        Margin = $@"{Unit(margin)} 0",
                    },
                    [$@"{componentCls}-pagination"] = new CSSObject
                    {
                        Display = "flex",
                        FlexWrap = "wrap",
                        RowGap = token.PaddingXS,
                        ["> *"] = new CSSObject
                        {
                            Flex = "none",
                        },
                        ["&-left"] = new CSSObject
                        {
                            JustifyContent = "flex-start",
                        },
                        ["&-center"] = new CSSObject
                        {
                            JustifyContent = "center",
                        },
                        ["&-right"] = new CSSObject
                        {
                            JustifyContent = "flex-end",
                        },
                    },
                },
            };
        }

        public static object PaginationDefault()
        {
            return GenPaginationStyle;
        }
    }
}