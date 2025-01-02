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
            var progressSize = token.calc(iconSize).add(token.calc(lineWidthBold).mul(4).equal()).Equal();
            var progressSizeSM = token
    .calc(iconSizeSM)
    .add(token.calc(token.lineWidth).mul(4).equal()).Equal();
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
                            InsetInlineStart = token.calc(iconSize).div(2).sub(lineWidth).add(paddingXXS).Equal(),
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
                        InsetInlineStart = token.calc(iconSizeSM).div(2).sub(lineWidth).add(paddingXXS).Equal(),
                    },
                    [$@"{componentCls}-label-vertical {componentCls}-item {componentCls}-item-tail"] = new CSSObject
                    {
                        Top = token.calc(iconSize).div(2).add(paddingXXS).Equal(),
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
                            Top = token.calc(iconSizeSM).div(2).add(paddingXXS).Equal(),
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
            return genStepsProgressStyle;
        }
    }
}