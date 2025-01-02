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
    public partial class ColorPickerStyle
    {
        public static CSSObject GenInputStyle(ColorPickerToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var fontSizeSM = token.FontSizeSM;
            var lineHeightSM = token.LineHeightSM;
            var colorPickerAlphaInputWidth = token.ColorPickerAlphaInputWidth;
            var marginXXS = token.MarginXXS;
            var paddingXXS = token.PaddingXXS;
            var controlHeightSM = token.ControlHeightSM;
            var marginXS = token.MarginXS;
            var fontSizeIcon = token.FontSizeIcon;
            var paddingXS = token.PaddingXS;
            var colorTextPlaceholder = token.ColorTextPlaceholder;
            var colorPickerInputNumberHandleWidth = token.ColorPickerInputNumberHandleWidth;
            var lineWidth = token.LineWidth;
            return new CSSObject
            {
                [$@"{componentCls}-input-container"] = new CSSObject
                {
                    Display = "flex",
                    [$@"{componentCls}-steppers{antCls}-input-number"] = new CSSObject
                    {
                        FontSize = fontSizeSM,
                        LineHeight = lineHeightSM,
                        [$@"{antCls}-input-number-input"] = new CSSObject
                        {
                            PaddingInlineStart = paddingXXS,
                            PaddingInlineEnd = 0,
                        },
                        [$@"{antCls}-input-number-handler-wrap"] = new CSSObject
                        {
                            Width = colorPickerInputNumberHandleWidth,
                        },
                    },
                    [$@"{componentCls}-steppers{componentCls}-alpha-input"] = new CSSObject
                    {
                        Flex = $@"{Unit(colorPickerAlphaInputWidth)}",
                        MarginInlineStart = marginXXS,
                    },
                    [$@"{componentCls}-format-select{antCls}-select"] = new CSSObject
                    {
                        MarginInlineEnd = marginXS,
                        Width = "auto",
                        ["&-single"] = new CSSObject
                        {
                            [$@"{antCls}-select-selector"] = new CSSObject
                            {
                                Padding = 0,
                                Border = 0,
                            },
                            [$@"{antCls}-select-arrow"] = new CSSObject
                            {
                                InsetInlineEnd = 0,
                            },
                            [$@"{antCls}-select-selection-item"] = new CSSObject
                            {
                                PaddingInlineEnd = token.calc(fontSizeIcon).add(marginXXS).Equal(),
                                FontSize = fontSizeSM,
                                LineHeight = Unit(controlHeightSM),
                            },
                            [$@"{antCls}-select-item-option-content"] = new CSSObject
                            {
                                FontSize = fontSizeSM,
                                LineHeight = lineHeightSM,
                            },
                            [$@"{antCls}-select-dropdown"] = new CSSObject
                            {
                                [$@"{antCls}-select-item"] = new CSSObject
                                {
                                    MinHeight = "auto",
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-input"] = new CSSObject
                    {
                        Gap = marginXXS,
                        AlignItems = "center",
                        Flex = 1,
                        Width = 0,
                        [$@"{componentCls}-hsb-input,{componentCls}-rgb-input"] = new CSSObject
                        {
                            Display = "flex",
                            Gap = marginXXS,
                            AlignItems = "center",
                        },
                        [$@"{componentCls}-steppers"] = new CSSObject
                        {
                            Flex = 1,
                        },
                        [$@"{componentCls}-hex-input{antCls}-input-affix-wrapper"] = new CSSObject
                        {
                            Flex = 1,
                            Padding = $@"{Unit(paddingXS)}",
                            [$@"{antCls}-input"] = new CSSObject
                            {
                                FontSize = fontSizeSM,
                                TextTransform = "uppercase",
                                LineHeight = Unit(token.calc(controlHeightSM).sub(token.calc(lineWidth).mul(2)).Equal()),
                            },
                            [$@"{antCls}-input-prefix"] = new CSSObject
                            {
                                Color = colorTextPlaceholder,
                            },
                        },
                    },
                },
            };
        }

        public static object InputDefault()
        {
            return genInputStyle;
        }
    }
}