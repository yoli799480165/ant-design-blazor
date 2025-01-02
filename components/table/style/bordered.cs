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
        public static CSSObject GenBorderedStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var tableBorderColor = token.TableBorderColor;
            var tableHeaderBg = token.TableHeaderBg;
            var tablePaddingVertical = token.TablePaddingVertical;
            var tablePaddingHorizontal = token.TablePaddingHorizontal;
            var calc = token.Calc;
            var tableBorder = $@"{Unit(lineWidth)} {lineType} {tableBorderColor}";
            var getSizeBorderStyle = ( 'small' | 'middle'  size, number paddingVertical, number paddingHorizontal) =>
            {
                return new object
                {
                    [$@"{componentCls}-{size}"] = new object
                    {
                        [$@"{componentCls}-container"] = new object
                        {
                            [$@"{componentCls}-content, > {componentCls}-body"] = new object
                            {
                                ["\n            > table > tbody > tr > th,\n            > table > tbody > tr > td\n          "] = new object
                                {
                                    [$@"{componentCls}-expanded-row-fixed"] = new object
                                    {
                                        Margin = $@"{Unit(calc(paddingVertical).mul(-1).Equal())}
              {Unit(calc(calc(paddingHorizontal).add(lineWidth)).mul(-1).Equal())}",
                                    },
                                },
                            },
                        },
                    },
                };
            };
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}{componentCls}-bordered"] = new CSSObject
                    {
                        [$@"{componentCls}-title"] = new CSSObject
                        {
                            Border = tableBorder,
                            BorderBottom = 0,
                        },
                        [$@"{componentCls}-container"] = new CSSObject
                        {
                            BorderInlineStart = tableBorder,
                            BorderTop = tableBorder,
                            [$@"{componentCls}-content,
            > {componentCls}-header,
            > {componentCls}-body,
            > {componentCls}-summary
          "] = new CSSObject
                            {
                                ["> table"] = new CSSObject
                                {
                                    ["\n                > thead > tr > th,\n                > thead > tr > td,\n                > tbody > tr > th,\n                > tbody > tr > td,\n                > tfoot > tr > th,\n                > tfoot > tr > td\n              "] = new CSSObject
                                    {
                                        BorderInlineEnd = tableBorder,
                                    },
                                    ["> thead"] = new CSSObject
                                    {
                                        ["> tr:not(:last-child) > th"] = new CSSObject
                                        {
                                            BorderBottom = tableBorder,
                                        },
                                        ["> tr > th::before"] = new CSSObject
                                        {
                                            BackgroundColor = "transparent !important",
                                        },
                                    },
                                    ["\n                > thead > tr,\n                > tbody > tr,\n                > tfoot > tr\n              "] = new CSSObject
                                    {
                                        [$@"{componentCls}-cell-fix-right-first::after"] = new CSSObject
                                        {
                                            BorderInlineEnd = tableBorder,
                                        },
                                    },
                                    ["\n                > tbody > tr > th,\n                > tbody > tr > td\n              "] = new CSSObject
                                    {
                                        [$@"{componentCls}-expanded-row-fixed"] = new CSSObject
                                        {
                                            Margin = $@"{Unit(calc(tablePaddingVertical).mul(-1).Equal())} {Unit(calc(calc(tablePaddingHorizontal).add(lineWidth)).mul(-1).Equal())}",
                                            ["&::after"] = new CSSObject
                                            {
                                                Position = "absolute",
                                                Top = 0,
                                                InsetInlineEnd = lineWidth,
                                                Bottom = 0,
                                                BorderInlineEnd = tableBorder,
                                                Content = "\"\"",
                                            },
                                        },
                                    },
                                },
                            },
                        },
                        [$@"{componentCls}-scroll-horizontal"] = new CSSObject
                        {
                            [$@"{componentCls}-container > {componentCls}-body"] = new CSSObject
                            {
                                ["> table > tbody"] = new CSSObject
                                {
                                    [$@"{componentCls}-expanded-row,
                > tr{componentCls}-placeholder
              "] = new CSSObject
                                    {
                                        ["> th, > td"] = new CSSObject
                                        {
                                            BorderInlineEnd = 0,
                                        },
                                    },
                                },
                            },
                        },
                        ["..."] = GetSizeBorderStyle("middle", token.TablePaddingVerticalMiddle, token.TablePaddingHorizontalMiddle),
                        ["..."] = GetSizeBorderStyle("small", token.TablePaddingVerticalSmall, token.TablePaddingHorizontalSmall),
                        [$@"{componentCls}-footer"] = new CSSObject
                        {
                            Border = tableBorder,
                            BorderTop = 0,
                        },
                    },
                    [$@"{componentCls}-cell"] = new CSSObject
                    {
                        [$@"{componentCls}-container:first-child"] = new CSSObject
                        {
                            BorderTop = 0,
                        },
                        ["&-scrollbar:not([rowspan])"] = new CSSObject
                        {
                            BoxShadow = $@"{Unit(lineWidth)} 0 {Unit(lineWidth)} {tableHeaderBg}",
                        },
                    },
                    [$@"{componentCls}-bordered {componentCls}-cell-scrollbar"] = new CSSObject
                    {
                        BorderInlineEnd = tableBorder,
                    },
                },
            };
        }

        public static object BorderedDefault()
        {
            return genBorderedStyle;
        }
    }
}