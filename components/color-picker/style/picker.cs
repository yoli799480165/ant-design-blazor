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
        public static CSSObject GenPickerStyle(ColorPickerToken token)
        {
            var componentCls = token.ComponentCls;
            var controlHeightLG = token.ControlHeightLG;
            var borderRadiusSM = token.BorderRadiusSM;
            var colorPickerInsetShadow = token.ColorPickerInsetShadow;
            var marginSM = token.MarginSM;
            var colorBgElevated = token.ColorBgElevated;
            var colorFillSecondary = token.ColorFillSecondary;
            var lineWidthBold = token.LineWidthBold;
            var colorPickerHandlerSize = token.ColorPickerHandlerSize;
            return new CSSObject
            {
                UserSelect = "none",
                [$@"{componentCls}-select"] = new CSSObject
                {
                    [$@"{componentCls}-palette"] = new CSSObject
                    {
                        MinHeight = token.calc(controlHeightLG).mul(4).Equal(),
                        Overflow = "hidden",
                        BorderRadius = borderRadiusSM,
                    },
                    [$@"{componentCls}-saturation"] = new CSSObject
                    {
                        Position = "absolute",
                        BorderRadius = "inherit",
                        BoxShadow = colorPickerInsetShadow,
                        Inset = 0,
                    },
                    MarginBottom = marginSM,
                },
                [$@"{componentCls}-handler"] = new CSSObject
                {
                    Width = colorPickerHandlerSize,
                    Height = colorPickerHandlerSize,
                    Border = $@"{Unit(lineWidthBold)} solid {colorBgElevated}",
                    Position = "relative",
                    BorderRadius = "50%",
                    Cursor = "pointer",
                    BoxShadow = $@"{colorPickerInsetShadow}, 0 0 0 1px {colorFillSecondary}",
                },
            };
        }

        public static object PickerDefault()
        {
            return genPickerStyle;
        }
    }
}