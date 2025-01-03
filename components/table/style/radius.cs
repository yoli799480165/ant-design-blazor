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
        public static CSSObject GenRadiusStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var tableRadius = token.TableRadius;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [componentCls] = new CSSObject
                    {
                        [$@"{componentCls}-title, {componentCls}-header"] = new CSSObject
                        {
                            BorderRadius = $@"{Unit(tableRadius)} {Unit(tableRadius)} 0 0",
                        },
                        [$@"{componentCls}-title + {componentCls}-container"] = new CSSObject
                        {
                            BorderStartStartRadius = 0,
                            BorderStartEndRadius = 0,
                            [$@"{componentCls}-header, table"] = new CSSObject
                            {
                                BorderRadius = 0,
                            },
                            ["table > thead > tr:first-child"] = new CSSObject
                            {
                                ["th:first-child, th:last-child, td:first-child, td:last-child"] = new CSSObject
                                {
                                    BorderRadius = 0,
                                },
                            },
                        },
                        ["&-container"] = new CSSObject
                        {
                            BorderStartStartRadius = tableRadius,
                            BorderStartEndRadius = tableRadius,
                            ["table > thead > tr:first-child"] = new CSSObject
                            {
                                ["> *:first-child"] = new CSSObject
                                {
                                    BorderStartStartRadius = tableRadius,
                                },
                                ["> *:last-child"] = new CSSObject
                                {
                                    BorderStartEndRadius = tableRadius,
                                },
                            },
                        },
                        ["&-footer"] = new CSSObject
                        {
                            BorderRadius = $@"{Unit(tableRadius)} {Unit(tableRadius)}",
                        },
                    },
                },
            };
        }

        public static object RadiusDefault()
        {
            return GenRadiusStyle;
        }
    }
}