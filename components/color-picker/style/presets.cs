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
        public static CSSObject GenPresetsStyle(ColorPickerToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var colorTextQuaternary = token.ColorTextQuaternary;
            var paddingXXS = token.PaddingXXS;
            var colorPickerPresetColorSize = token.ColorPickerPresetColorSize;
            var fontSizeSM = token.FontSizeSM;
            var colorText = token.ColorText;
            var lineHeightSM = token.LineHeightSM;
            var lineWidth = token.LineWidth;
            var borderRadius = token.BorderRadius;
            var colorFill = token.ColorFill;
            var colorWhite = token.ColorWhite;
            var marginXXS = token.MarginXXS;
            var paddingXS = token.PaddingXS;
            var fontHeightSM = token.FontHeightSM;
            return new CSSObject
            {
                [$@"{componentCls}-presets"] = new CSSObject
                {
                    [$@"{antCls}-collapse-item > {antCls}-collapse-header"] = new CSSObject
                    {
                        Padding = 0,
                        [$@"{antCls}-collapse-expand-icon"] = new CSSObject
                        {
                            Height = fontHeightSM,
                            Color = colorTextQuaternary,
                            PaddingInlineEnd = paddingXXS,
                        },
                    },
                    [$@"{antCls}-collapse"] = new CSSObject
                    {
                        Display = "flex",
                        FlexDirection = "column",
                        Gap = marginXXS,
                    },
                    [$@"{antCls}-collapse-item > {antCls}-collapse-content > {antCls}-collapse-content-box"] = new CSSObject
                    {
                        Padding = $@"{Unit(paddingXS)} 0",
                    },
                    ["&-label"] = new CSSObject
                    {
                        FontSize = fontSizeSM,
                        Color = colorText,
                        LineHeight = lineHeightSM,
                    },
                    ["&-items"] = new CSSObject
                    {
                        Display = "flex",
                        FlexWrap = "wrap",
                        Gap = token.calc(marginXXS).mul(1.5).Equal(),
                        [$@"{componentCls}-presets-color"] = new CSSObject
                        {
                            Position = "relative",
                            Cursor = "pointer",
                            Width = colorPickerPresetColorSize,
                            Height = colorPickerPresetColorSize,
                            ["&::before"] = new CSSObject
                            {
                                Content = "\"\"",
                                PointerEvents = "none",
                                Width = token.calc(colorPickerPresetColorSize).add(token.calc(lineWidth).mul(4)).Equal(),
                                Height = token
              .calc(colorPickerPresetColorSize)
              .add(token.calc(lineWidth).mul(4)).Equal(),
                                Position = "absolute",
                                Top = token.calc(lineWidth).mul(-2).Equal(),
                                InsetInlineStart = token.calc(lineWidth).mul(-2).Equal(),
                                Border = $@"{Unit(lineWidth)} solid transparent",
                                Transition = $@"{token.MotionDurationMid} {token.MotionEaseInBack}",
                            },
                            ["&:hover::before"] = new CSSObject
                            {
                                BorderColor = colorFill,
                            },
                            ["&::after"] = new CSSObject
                            {
                                BoxSizing = "border-box",
                                Position = "absolute",
                                Top = "50%",
                                InsetInlineStart = "21.5%",
                                Display = "table",
                                Width = token.calc(colorPickerPresetColorSize).div(13).mul(5).Equal(),
                                Height = token.calc(colorPickerPresetColorSize).div(13).mul(8).Equal(),
                                Border = $@"{Unit(token.LineWidthBold)} solid {token.ColorWhite}",
                                BorderTop = 0,
                                BorderInlineStart = 0,
                                Transform = "rotate(45deg) scale(0) translate(-50%,-50%)",
                                Opacity = 0,
                                Content = "\"\"",
                                Transition = $@"{token.MotionDurationFast} {token.MotionEaseInBack}, opacity {token.MotionDurationFast}",
                            },
                            [$@"{componentCls}-presets-color-checked"] = new CSSObject
                            {
                                ["&::after"] = new CSSObject
                                {
                                    Opacity = 1,
                                    BorderColor = colorWhite,
                                    Transform = "rotate(45deg) scale(1) translate(-50%,-50%)",
                                    Transition = $@"{token.MotionDurationMid} {token.MotionEaseOutBack} {token.MotionDurationFast}",
                                },
                                [$@"{componentCls}-presets-color-bright"] = new CSSObject
                                {
                                    ["&::after"] = new CSSObject
                                    {
                                        BorderColor = "rgba(0, 0, 0, 0.45)",
                                    },
                                },
                            },
                        },
                    },
                    ["&-empty"] = new CSSObject
                    {
                        FontSize = fontSizeSM,
                        Color = colorTextQuaternary,
                    },
                },
            };
        }

        public static object PresetsDefault()
        {
            return genPresetsStyle;
        }
    }
}