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
        public static CSSObject GenSummaryStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var lineWidth = token.LineWidth;
            var tableBorderColor = token.TableBorderColor;
            var calc = token.Calc;
            var tableBorder = $@"{Unit(lineWidth)} {token.LineType} {tableBorderColor}";
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-summary"] = new CSSObject
                    {
                        Position = "relative",
                        ZIndex = token.ZIndexTableFixed,
                        Background = token.TableBg,
                        ["> tr"] = new CSSObject
                        {
                            ["> th, > td"] = new CSSObject
                            {
                                BorderBottom = tableBorder,
                            },
                        },
                    },
                    [$@"{componentCls}-summary"] = new CSSObject
                    {
                        BoxShadow = $@"{Unit(Calc(lineWidth).Mul(-1).Equal())} 0 {tableBorderColor}",
                    },
                },
            };
        }

        public static object SummaryDefault()
        {
            return GenSummaryStyle;
        }
    }
}