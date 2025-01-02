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
        public static CSSObject GenVirtualStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationMid = token.MotionDurationMid;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var tableBorderColor = token.TableBorderColor;
            var calc = token.Calc;
            var tableBorder = $@"{Unit(lineWidth)} {lineType} {tableBorderColor}";
            var rowCellCls = $@"{componentCls}-expanded-row-cell";
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-tbody-virtual"] = new CSSObject
                    {
                        [$@"{componentCls}-tbody-virtual-holder-inner"] = new CSSObject
                        {
                            [$@"{componentCls}-row, 
            & > div:not({componentCls}-row) > {componentCls}-row
          "] = new CSSObject
                            {
                                Display = "flex",
                                BoxSizing = "border-box",
                                Width = "100%",
                            },
                        },
                        [$@"{componentCls}-cell"] = new CSSObject
                        {
                            BorderBottom = tableBorder,
                            Transition = $@"{motionDurationMid}",
                        },
                        [$@"{componentCls}-expanded-row"] = new CSSObject
                        {
                            [$@"{rowCellCls}{rowCellCls}-fixed"] = new CSSObject
                            {
                                Position = "sticky",
                                InsetInlineStart = 0,
                                Overflow = "hidden",
                                Width = $@"{Unit(lineWidth)})",
                                BorderInlineEnd = "none",
                            },
                        },
                    },
                    [$@"{componentCls}-bordered"] = new CSSObject
                    {
                        [$@"{componentCls}-tbody-virtual"] = new CSSObject
                        {
                            ["&:after"] = new CSSObject
                            {
                                Content = "\"\"",
                                InsetInline = 0,
                                Bottom = 0,
                                BorderBottom = tableBorder,
                                Position = "absolute",
                            },
                            [$@"{componentCls}-cell"] = new CSSObject
                            {
                                BorderInlineEnd = tableBorder,
                                [$@"{componentCls}-cell-fix-right-first:before"] = new CSSObject
                                {
                                    Content = "\"\"",
                                    Position = "absolute",
                                    InsetBlock = 0,
                                    InsetInlineStart = calc(lineWidth).mul(-1).Equal(),
                                    BorderInlineStart = tableBorder,
                                },
                            },
                        },
                        [$@"{componentCls}-virtual"] = new CSSObject
                        {
                            [$@"{componentCls}-placeholder {componentCls}-cell"] = new CSSObject
                            {
                                BorderInlineEnd = tableBorder,
                                BorderBottom = tableBorder,
                            },
                        },
                    },
                },
            };
        }

        public static object VirtualDefault()
        {
            return genVirtualStyle;
        }
    }
}