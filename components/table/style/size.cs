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
        public static CSSObject GenSizeStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var tableExpandColumnWidth = token.TableExpandColumnWidth;
            var calc = token.Calc;
            var getSizeStyle = ( 'small' | 'middle'  size, number paddingVertical, number paddingHorizontal, number fontSize) =>
            {
                return new object
                {
                    [$@"{componentCls}{componentCls}-{size}"] = new object
                    {
                        [$@"{componentCls}-title,
        {componentCls}-footer,
        {componentCls}-cell,
        {componentCls}-thead > tr > th,
        {componentCls}-tbody > tr > th,
        {componentCls}-tbody > tr > td,
        tfoot > tr > th,
        tfoot > tr > td
      "] = new object
                        {
                            Padding = $@"{Unit(paddingVertical)} {Unit(paddingHorizontal)}",
                        },
                        [$@"{componentCls}-filter-trigger"] = new object
                        {
                            MarginInlineEnd = Unit(Calc(paddingHorizontal).Div(2).Mul(-1).Equal()),
                        },
                        [$@"{componentCls}-expanded-row-fixed"] = new object
                        {
                            Margin = $@"{Unit(Calc(paddingVertical).Mul(-1).Equal())} {Unit(Calc(paddingHorizontal).Mul(-1).Equal())}",
                        },
                        [$@"{componentCls}-tbody"] = new object
                        {
                            [$@"{componentCls}-wrapper:only-child {componentCls}"] = new object
                            {
                                MarginBlock = Unit(Calc(paddingVertical).Mul(-1).Equal()),
                                MarginInline = $@"{Unit(Calc(tableExpandColumnWidth).Sub(paddingHorizontal).Equal())} {Unit(Calc(paddingHorizontal).Mul(-1).Equal())}",
                            },
                        },
                        [$@"{componentCls}-selection-extra"] = new object
                        {
                            PaddingInlineStart = Unit(Calc(paddingHorizontal).Div(4).Equal()),
                        },
                    },
                };
            };
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    ["..."] = GetSizeStyle("middle", token.TablePaddingVerticalMiddle, token.TablePaddingHorizontalMiddle, token.TableFontSizeMiddle),
                    ["..."] = GetSizeStyle("small", token.TablePaddingVerticalSmall, token.TablePaddingHorizontalSmall, token.TableFontSizeSmall),
                },
            };
        }

        public static object SizeDefault()
        {
            return GenSizeStyle;
        }
    }
}