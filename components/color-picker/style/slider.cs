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
        public static CSSObject GenSliderStyle(ColorPickerToken token)
        {
            var componentCls = token.ComponentCls;
            var colorPickerInsetShadow = token.ColorPickerInsetShadow;
            var colorBgElevated = token.ColorBgElevated;
            var colorFillSecondary = token.ColorFillSecondary;
            var lineWidthBold = token.LineWidthBold;
            var colorPickerHandlerSizeSM = token.ColorPickerHandlerSizeSM;
            var colorPickerSliderHeight = token.ColorPickerSliderHeight;
            var marginSM = token.MarginSM;
            var marginXS = token.MarginXS;
            var handleInnerSize = token.Calc(colorPickerHandlerSizeSM).Sub(token.Calc(lineWidthBold).Mul(2).Equal()).Equal();
            var handleHoverSize = token.Calc(colorPickerHandlerSizeSM).Add(token.Calc(lineWidthBold).Mul(2).Equal()).Equal();
            var activeHandleStyle = new object
            {
                ["&:after"] = new object
                {
                    Transform = "scale(1)",
                    BoxShadow = $@"{colorPickerInsetShadow}, 0 0 0 1px {token.ColorPrimaryActive}",
                },
            };
            return new CSSObject
            {
                [$@"{componentCls}-slider"] = new object[]
                {
                    GetTransBg(Unit(colorPickerSliderHeight), token.ColorFillSecondary),
                    new object
                    {
                        Margin = 0,
                        Padding = 0,
                        Height = colorPickerSliderHeight,
                        BorderRadius = token.Calc(colorPickerSliderHeight).Div(2).Equal(),
                        ["&-rail"] = new object
                        {
                            Height = colorPickerSliderHeight,
                            BorderRadius = token.Calc(colorPickerSliderHeight).Div(2).Equal(),
                            BoxShadow = colorPickerInsetShadow,
                        },
                        [$@"{componentCls}-slider-handle"] = new object
                        {
                            Width = handleInnerSize,
                            Height = handleInnerSize,
                            Top = 0,
                            BorderRadius = "100%",
                            ["&:before"] = new object
                            {
                                Display = "block",
                                Position = "absolute",
                                Background = "transparent",
                                Left = new object
                                {
                                    _skip_check_ = true,
                                    Value = "50%",
                                },
                                Top = "50%",
                                Transform = "translate(-50%, -50%)",
                                Width = handleHoverSize,
                                Height = handleHoverSize,
                                BorderRadius = "100%",
                            },
                            ["&:after"] = new object
                            {
                                Width = colorPickerHandlerSizeSM,
                                Height = colorPickerHandlerSizeSM,
                                Border = $@"{Unit(lineWidthBold)} solid {colorBgElevated}",
                                BoxShadow = $@"{colorPickerInsetShadow}, 0 0 0 1px {colorFillSecondary}",
                                Outline = "none",
                                InsetInlineStart = token.Calc(lineWidthBold).Mul(-1).Equal(),
                                Top = token.Calc(lineWidthBold).Mul(-1).Equal(),
                                Background = "transparent",
                                Transition = "none",
                            },
                            ["&:focus"] = activeHandleStyle,
                        },
                    }
                },
                [$@"{componentCls}-slider-container"] = new CSSObject
                {
                    Display = "flex",
                    Gap = marginSM,
                    MarginBottom = marginSM,
                    [$@"{componentCls}-slider-group"] = new CSSObject
                    {
                        Flex = 1,
                        FlexDirection = "column",
                        JustifyContent = "space-between",
                        Display = "flex",
                        ["&-disabled-alpha"] = new CSSObject
                        {
                            JustifyContent = "center",
                        },
                    },
                },
                [$@"{componentCls}-gradient-slider"] = new CSSObject
                {
                    MarginBottom = marginXS,
                    [$@"{componentCls}-slider-handle"] = new CSSObject
                    {
                        ["&:after"] = new CSSObject
                        {
                            Transform = "scale(0.8)",
                        },
                        ["&-active, &:focus"] = activeHandleStyle,
                    },
                },
            };
        }

        public static object SliderDefault()
        {
            return GenSliderStyle;
        }
    }
}