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
        public static CSSObject GenSelectionStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var iconCls = token.IconCls;
            var fontSizeIcon = token.FontSizeIcon;
            var padding = token.Padding;
            var paddingXS = token.PaddingXS;
            var headerIconColor = token.HeaderIconColor;
            var headerIconHoverColor = token.HeaderIconHoverColor;
            var tableSelectionColumnWidth = token.TableSelectionColumnWidth;
            var tableSelectedRowBg = token.TableSelectedRowBg;
            var tableSelectedRowHoverBg = token.TableSelectedRowHoverBg;
            var tableRowHoverBg = token.TableRowHoverBg;
            var tablePaddingHorizontal = token.TablePaddingHorizontal;
            var calc = token.Calc;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-selection-col"] = new CSSObject
                    {
                        Width = tableSelectionColumnWidth,
                        [$@"{componentCls}-selection-col-with-dropdown"] = new CSSObject
                        {
                            Width = Calc(tableSelectionColumnWidth).Add(fontSizeIcon).Add(Calc(padding).Div(4)).Equal(),
                        },
                    },
                    [$@"{componentCls}-bordered {componentCls}-selection-col"] = new CSSObject
                    {
                        Width = Calc(tableSelectionColumnWidth).Add(Calc(paddingXS).Mul(2)).Equal(),
                        [$@"{componentCls}-selection-col-with-dropdown"] = new CSSObject
                        {
                            Width = Calc(tableSelectionColumnWidth).Add(fontSizeIcon).Add(Calc(padding).Div(4)).Add(Calc(paddingXS).Mul(2)).Equal(),
                        },
                    },
                    [$@"{componentCls}-selection-column,
        table tr td{componentCls}-selection-column,
        {componentCls}-selection-column
      "] = new CSSObject
                    {
                        PaddingInlineEnd = token.PaddingXS,
                        PaddingInlineStart = token.PaddingXS,
                        TextAlign = "center",
                        [$@"{antCls}-radio-wrapper"] = new CSSObject
                        {
                            MarginInlineEnd = 0,
                        },
                    },
                    [$@"{componentCls}-selection-column{componentCls}-cell-fix-left"] = new CSSObject
                    {
                        ZIndex = Calc(token.ZIndexTableFixed).Add(1).Equal(new object { Unit = false, }),
                    },
                    [$@"{componentCls}-selection-column::after"] = new CSSObject
                    {
                        BackgroundColor = "transparent !important",
                    },
                    [$@"{componentCls}-selection"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "inline-flex",
                        FlexDirection = "column",
                    },
                    [$@"{componentCls}-selection-extra"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = 0,
                        ZIndex = 1,
                        Cursor = "pointer",
                        Transition = $@"{token.MotionDurationSlow}",
                        MarginInlineStart = "100%",
                        PaddingInlineStart = Unit(Calc(tablePaddingHorizontal).Div(4).Equal()),
                        [iconCls] = new CSSObject
                        {
                            Color = headerIconColor,
                            FontSize = fontSizeIcon,
                            VerticalAlign = "baseline",
                            ["&:hover"] = new CSSObject
                            {
                                Color = headerIconHoverColor,
                            },
                        },
                    },
                    [$@"{componentCls}-tbody"] = new CSSObject
                    {
                        [$@"{componentCls}-row"] = new CSSObject
                        {
                            [$@"{componentCls}-row-selected"] = new CSSObject
                            {
                                [$@"{componentCls}-cell"] = new CSSObject
                                {
                                    Background = tableSelectedRowBg,
                                    ["&-row-hover"] = new CSSObject
                                    {
                                        Background = tableSelectedRowHoverBg,
                                    },
                                },
                            },
                            [$@"{componentCls}-cell-row-hover"] = new CSSObject
                            {
                                Background = tableRowHoverBg,
                            },
                        },
                    },
                },
            };
        }

        public static object SelectionDefault()
        {
            return GenSelectionStyle;
        }
    }
}