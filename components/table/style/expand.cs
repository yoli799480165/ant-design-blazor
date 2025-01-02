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
        public static CSSObject GenExpandStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var lineWidth = token.LineWidth;
            var paddingXS = token.PaddingXS;
            var lineType = token.LineType;
            var tableBorderColor = token.TableBorderColor;
            var tableExpandIconBg = token.TableExpandIconBg;
            var tableExpandColumnWidth = token.TableExpandColumnWidth;
            var borderRadius = token.BorderRadius;
            var tablePaddingVertical = token.TablePaddingVertical;
            var tablePaddingHorizontal = token.TablePaddingHorizontal;
            var tableExpandedRowBg = token.TableExpandedRowBg;
            var paddingXXS = token.PaddingXXS;
            var expandIconMarginTop = token.ExpandIconMarginTop;
            var expandIconSize = token.ExpandIconSize;
            var expandIconHalfInner = token.ExpandIconHalfInner;
            var expandIconScale = token.ExpandIconScale;
            var calc = token.Calc;
            var tableBorder = $@"{Unit(lineWidth)} {lineType} {tableBorderColor}";
            var expandIconLineOffset = calc(paddingXXS).sub(lineWidth).Equal();
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-expand-icon-col"] = new CSSObject
                    {
                        Width = tableExpandColumnWidth,
                    },
                    [$@"{componentCls}-row-expand-icon-cell"] = new CSSObject
                    {
                        TextAlign = "center",
                        [$@"{componentCls}-row-expand-icon"] = new CSSObject
                        {
                            Display = "inline-flex",
                            Float = "none",
                            VerticalAlign = "sub",
                        },
                    },
                    [$@"{componentCls}-row-indent"] = new CSSObject
                    {
                        Height = 1,
                        Float = "left",
                    },
                    [$@"{componentCls}-row-expand-icon"] = new CSSObject
                    {
                        ["..."] = OperationUnit(token),
                        Position = "relative",
                        Float = "left",
                        Width = expandIconSize,
                        Height = expandIconSize,
                        Color = "inherit",
                        LineHeight = Unit(expandIconSize),
                        Background = tableExpandIconBg,
                        Border = tableBorder,
                        Transform = $@"{expandIconScale})",
                        ["&:focus, &:hover, &:active"] = new CSSObject
                        {
                            BorderColor = "currentcolor",
                        },
                        ["&::before, &::after"] = new CSSObject
                        {
                            Position = "absolute",
                            Background = "currentcolor",
                            Transition = $@"{motionDurationSlow} ease-out",
                            Content = "\"\"",
                        },
                        ["&::before"] = new CSSObject
                        {
                            Top = expandIconHalfInner,
                            InsetInlineEnd = expandIconLineOffset,
                            InsetInlineStart = expandIconLineOffset,
                            Height = lineWidth,
                        },
                        ["&::after"] = new CSSObject
                        {
                            Top = expandIconLineOffset,
                            Bottom = expandIconLineOffset,
                            InsetInlineStart = expandIconHalfInner,
                            Width = lineWidth,
                            Transform = "rotate(90deg)",
                        },
                        ["&-collapsed::before"] = new CSSObject
                        {
                            Transform = "rotate(-180deg)",
                        },
                        ["&-collapsed::after"] = new CSSObject
                        {
                            Transform = "rotate(0deg)",
                        },
                        ["&-spaced"] = new CSSObject
                        {
                            ["&::before, &::after"] = new CSSObject
                            {
                                Display = "none",
                                Content = "none",
                            },
                            Background = "transparent",
                            Border = 0,
                            Visibility = "hidden",
                        },
                    },
                    [$@"{componentCls}-row-indent + {componentCls}-row-expand-icon"] = new CSSObject
                    {
                        MarginTop = expandIconMarginTop,
                        MarginInlineEnd = paddingXS,
                    },
                    [$@"{componentCls}-expanded-row"] = new CSSObject
                    {
                        ["&, &:hover"] = new CSSObject
                        {
                            ["> th, > td"] = new CSSObject
                            {
                                Background = tableExpandedRowBg,
                            },
                        },
                        [$@"{antCls}-descriptions-view"] = new CSSObject
                        {
                            Display = "flex",
                            ["table"] = new CSSObject
                            {
                                Flex = "auto",
                                Width = "100%",
                            },
                        },
                    },
                    [$@"{componentCls}-expanded-row-fixed"] = new CSSObject
                    {
                        Position = "relative",
                        Margin = $@"{Unit(calc(tablePaddingVertical).mul(-1).Equal())} {Unit(calc(tablePaddingHorizontal).mul(-1).Equal())}",
                        Padding = $@"{Unit(tablePaddingVertical)} {Unit(tablePaddingHorizontal)}",
                    },
                },
            };
        }

        public static object ExpandDefault()
        {
            return genExpandStyle;
        }
    }
}