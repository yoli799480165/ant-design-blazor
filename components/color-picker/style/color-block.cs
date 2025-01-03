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
        public static CSSObject GetTransBg(string size, string colorFill)
        {
            return new CSSObject
            {
                BackgroundImage = $@"{colorFill} 0 25%, transparent 0 50%, {colorFill} 0 75%, transparent 0)",
                BackgroundSize = $@"{size} {size}",
            };
        }

        public static CSSObject GenColorBlockStyle(ColorPickerToken token, number size)
        {
            var componentCls = token.ComponentCls;
            var borderRadiusSM = token.BorderRadiusSM;
            var colorPickerInsetShadow = token.ColorPickerInsetShadow;
            var lineWidth = token.LineWidth;
            var colorFillSecondary = token.ColorFillSecondary;
            return new CSSObject
            {
                [$@"{componentCls}-color-block"] = new CSSObject
                {
                    Position = "relative",
                    BorderRadius = borderRadiusSM,
                    Width = size,
                    Height = size,
                    BoxShadow = colorPickerInsetShadow,
                    Flex = "none",
                    ["..."] = GetTransBg("50%", token.ColorFillSecondary),
                    [$@"{componentCls}-color-block-inner"] = new CSSObject
                    {
                        Width = "100%",
                        Height = "100%",
                        BoxShadow = $@"{Unit(lineWidth)} {colorFillSecondary}",
                        BorderRadius = "inherit",
                    },
                },
            };
        }

        public static object ColorBlockDefault()
        {
            return GenColorBlockStyle;
        }
    }
}