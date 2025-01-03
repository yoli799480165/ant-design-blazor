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
    public partial class StepsStyle
    {
        public static CSSObject GenStepsProgressStyle(StepsToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var iconSize = token.IconSize;
            var iconSizeSM = token.IconSizeSM;
            var processIconColor = token.ProcessIconColor;
            var marginXXS = token.MarginXXS;
            var lineWidthBold = token.LineWidthBold;
            var lineWidth = token.LineWidth;
            var paddingXXS = token.PaddingXXS;
            var progressSize = token.Calc(iconSize).Add(token.Calc(lineWidthBold).Mul(4).Equal()).Equal();
            var progressSizeSM = token.Calc(iconSizeSM).Add(token.Calc(token.LineWidth).Mul(4).Equal()).Equal();
            return new CSSObject
            {
                [$@"{componentCls}-with-progress"] = new CSSObject
                {
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        PaddingTop = paddingXXS,
                        [$@"{componentCls}-item-container {componentCls}-item-icon {componentCls}-icon"] = new CSSObject
                        {
                            Color = processIconColor,
                        },
                    },
                    [$@"{componentCls}-vertical > {componentCls}-item "] = new CSSObject
                    {
                        PaddingInlineStart = paddingXXS,
                        [$@"{componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                        {
                            Top = marginXXS,
                            InsetInlineStart = token.Calc(iconSize).Div(2).Sub(lineWidth).Add(paddingXXS).Equal(),
                        },
                    },
                    [$@"{componentCls}-small"] = new CSSObject
                    {
                        [$@"{componentCls}-horizontal {componentCls}-item:first-child"] = new CSSObject
                        {
                            PaddingBottom = paddingXXS,
                            PaddingInlineStart = paddingXXS,
                        },
                    },
                    [$@"{componentCls}-small{componentCls}-vertical > {componentCls}-item > {componentCls}-item-container > {componentCls}-item-tail"] = new CSSObject
                    {
                        InsetInlineStart = token.Calc(iconSizeSM).Div(2).Sub(lineWidth).Add(paddingXXS).Equal(),
                    },
                    [$@"{componentCls}-label-vertical {componentCls}-item {componentCls}-item-tail"] = new CSSObject
                    {
                        Top = token.Calc(iconSize).Div(2).Add(paddingXXS).Equal(),
                    },
                    [$@"{componentCls}-item-icon"] = new CSSObject
                    {
                        Position = "relative",
                        [$@"{antCls}-progress"] = new CSSObject
                        {
                            Position = "absolute",
                            InsetInlineStart = "50%",
                            Top = "50%",
                            Transform = "translate(-50%, -50%)",
                            ["&-inner"] = new CSSObject
                            {
                                Width = $@"{Unit(progressSize)} !important",
                                Height = $@"{Unit(progressSize)} !important",
                            },
                        },
                    },
                    [$@"{componentCls}-small"] = new CSSObject
                    {
                        [$@"{componentCls}-label-vertical {componentCls}-item {componentCls}-item-tail"] = new CSSObject
                        {
                            Top = token.Calc(iconSizeSM).Div(2).Add(paddingXXS).Equal(),
                        },
                        [$@"{componentCls}-item-icon {antCls}-progress-inner"] = new CSSObject
                        {
                            Width = $@"{Unit(progressSizeSM)} !important",
                            Height = $@"{Unit(progressSizeSM)} !important",
                        },
                    },
                },
            };
        }

        public static object ProgressDefault()
        {
            return GenStepsProgressStyle;
        }
    }
}