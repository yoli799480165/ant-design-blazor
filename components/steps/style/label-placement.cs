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
        public static CSSObject GenStepsLabelPlacementStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var iconSize = token.IconSize;
            var lineHeight = token.LineHeight;
            var iconSizeSM = token.IconSizeSM;
            return new CSSObject
            {
                [$@"{componentCls}-label-vertical"] = new CSSObject
                {
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        Overflow = "visible",
                        ["&-tail"] = new CSSObject
                        {
                            MarginInlineStart = token.calc(iconSize).div(2).add(token.controlHeightLG).Equal(),
                            Padding = $@"{Unit(token.PaddingLG)}",
                        },
                        ["&-content"] = new CSSObject
                        {
                            Display = "block",
                            Width = token.calc(iconSize).div(2).add(token.controlHeightLG).mul(2).Equal(),
                            MarginTop = token.MarginSM,
                            TextAlign = "center",
                        },
                        ["&-icon"] = new CSSObject
                        {
                            Display = "inline-block",
                            MarginInlineStart = token.ControlHeightLG,
                        },
                        ["&-title"] = new CSSObject
                        {
                            PaddingInlineEnd = 0,
                            PaddingInlineStart = 0,
                            ["&::after"] = new CSSObject
                            {
                                Display = "none",
                            },
                        },
                        ["&-subtitle"] = new CSSObject
                        {
                            Display = "block",
                            MarginBottom = token.MarginXXS,
                            MarginInlineStart = 0,
                        },
                    },
                    [$@"{componentCls}-small:not({componentCls}-dot)"] = new CSSObject
                    {
                        [$@"{componentCls}-item"] = new CSSObject
                        {
                            ["&-icon"] = new CSSObject
                            {
                                MarginInlineStart = token
              .calc(iconSize)
              .sub(iconSizeSM)
              .div(2)
              .add(token.controlHeightLG).Equal(),
                            },
                        },
                    },
                },
            };
        }

        public static object LabelPlacementDefault()
        {
            return genStepsLabelPlacementStyle;
        }
    }
}