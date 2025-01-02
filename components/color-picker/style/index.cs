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
        public class ComponentToken : TokenWithCommonCls
        {
        }

        public class ColorPickerToken : ComponentToken
        {
            public double ColorPickerWidth { get; set; }
            public string ColorPickerInsetShadow { get; set; }
            public double ColorPickerHandlerSize { get; set; }
            public double ColorPickerHandlerSizeSM { get; set; }
            public double ColorPickerSliderHeight { get; set; }
            public double ColorPickerPreviewSize { get; set; }
            public double ColorPickerAlphaInputWidth { get; set; }
            public double ColorPickerInputNumberHandleWidth { get; set; }
            public double ColorPickerPresetColorSize { get; set; }
        }

        public static CSSObject GenActiveStyle(ColorPickerToken token, string borderColor, string outlineColor)
        {
            return new CSSObject
            {
                BorderInlineEndWidth = token.LineWidth,
                BoxShadow = $@"{Unit(token.ControlOutlineWidth)} {outlineColor}",
                Outline = 0,
            };
        }

        public static CSSObject GenRtlStyle(ColorPickerToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                ["&-rtl"] = new CSSObject
                {
                    [$@"{componentCls}-presets-color"] = new CSSObject
                    {
                        ["&::after"] = new CSSObject
                        {
                            Direction = "ltr",
                        },
                    },
                    [$@"{componentCls}-clear"] = new CSSObject
                    {
                        ["&::after"] = new CSSObject
                        {
                            Direction = "ltr",
                        },
                    },
                },
            };
        }

        public static CSSObject GenClearStyle(ColorPickerToken token, number size, CSSObject extraStyle)
        {
            var componentCls = token.ComponentCls;
            var borderRadiusSM = token.BorderRadiusSM;
            var lineWidth = token.LineWidth;
            var colorSplit = token.ColorSplit;
            var colorBorder = token.ColorBorder;
            var red6 = token.Red6;
            return new CSSObject
            {
                [$@"{componentCls}-clear"] = new CSSObject
                {
                    Width = size,
                    Height = size,
                    BorderRadius = borderRadiusSM,
                    Border = $@"{Unit(lineWidth)} solid {colorSplit}",
                    Position = "relative",
                    Overflow = "hidden",
                    Cursor = "inherit",
                    Transition = $@"{token.MotionDurationFast}",
                    ["..."] = extraStyle,
                    ["&::after"] = new CSSObject
                    {
                        Content = "\"\"",
                        Position = "absolute",
                        InsetInlineEnd = token.calc(lineWidth).mul(-1).Equal(),
                        Top = token.calc(lineWidth).mul(-1).Equal(),
                        Display = "block",
                        Width = 40,
                        Height = 2,
                        TransformOrigin = "calc(100% - 1px) 1px",
                        Transform = "rotate(-45deg)",
                        BackgroundColor = red6,
                    },
                    ["&:hover"] = new CSSObject
                    {
                        BorderColor = colorBorder,
                    },
                },
            };
        }

        public static CSSObject GenStatusStyle(ColorPickerToken token)
        {
            var componentCls = token.ComponentCls;
            var colorError = token.ColorError;
            var colorWarning = token.ColorWarning;
            var colorErrorHover = token.ColorErrorHover;
            var colorWarningHover = token.ColorWarningHover;
            var colorErrorOutline = token.ColorErrorOutline;
            var colorWarningOutline = token.ColorWarningOutline;
            return new CSSObject
            {
                [$@"{componentCls}-status-error"] = new CSSObject
                {
                    BorderColor = colorError,
                    ["&:hover"] = new CSSObject
                    {
                        BorderColor = colorErrorHover,
                    },
                    [$@"{componentCls}-trigger-active"] = new CSSObject
                    {
                        ["..."] = GenActiveStyle(token, colorError, colorErrorOutline),
                    },
                },
                [$@"{componentCls}-status-warning"] = new CSSObject
                {
                    BorderColor = colorWarning,
                    ["&:hover"] = new CSSObject
                    {
                        BorderColor = colorWarningHover,
                    },
                    [$@"{componentCls}-trigger-active"] = new CSSObject
                    {
                        ["..."] = GenActiveStyle(token, colorWarning, colorWarningOutline),
                    },
                },
            };
        }

        public static CSSObject GenSizeStyle(ColorPickerToken token)
        {
            var componentCls = token.ComponentCls;
            var controlHeightLG = token.ControlHeightLG;
            var controlHeightSM = token.ControlHeightSM;
            var controlHeight = token.ControlHeight;
            var controlHeightXS = token.ControlHeightXS;
            var borderRadius = token.BorderRadius;
            var borderRadiusSM = token.BorderRadiusSM;
            var borderRadiusXS = token.BorderRadiusXS;
            var borderRadiusLG = token.BorderRadiusLG;
            var fontSizeLG = token.FontSizeLG;
            return new CSSObject
            {
                [$@"{componentCls}-lg"] = new CSSObject
                {
                    MinWidth = controlHeightLG,
                    MinHeight = controlHeightLG,
                    BorderRadius = borderRadiusLG,
                    [$@"{componentCls}-color-block, {componentCls}-clear"] = new CSSObject
                    {
                        Width = controlHeight,
                        Height = controlHeight,
                    },
                    [$@"{componentCls}-trigger-text"] = new CSSObject
                    {
                        FontSize = fontSizeLG,
                    },
                },
                [$@"{componentCls}-sm"] = new CSSObject
                {
                    MinWidth = controlHeightSM,
                    MinHeight = controlHeightSM,
                    BorderRadius = borderRadiusSM,
                    [$@"{componentCls}-color-block, {componentCls}-clear"] = new CSSObject
                    {
                        Width = controlHeightXS,
                        Height = controlHeightXS,
                        BorderRadius = borderRadiusXS,
                    },
                    [$@"{componentCls}-trigger-text"] = new CSSObject
                    {
                        LineHeight = Unit(controlHeightXS),
                    },
                },
            };
        }

        public static CSSObject GenColorPickerStyle(ColorPickerToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var colorPickerWidth = token.ColorPickerWidth;
            var colorPrimary = token.ColorPrimary;
            var motionDurationMid = token.MotionDurationMid;
            var colorBgElevated = token.ColorBgElevated;
            var colorTextDisabled = token.ColorTextDisabled;
            var colorText = token.ColorText;
            var colorBgContainerDisabled = token.ColorBgContainerDisabled;
            var borderRadius = token.BorderRadius;
            var marginXS = token.MarginXS;
            var marginSM = token.MarginSM;
            var controlHeight = token.ControlHeight;
            var controlHeightSM = token.ControlHeightSM;
            var colorBgTextActive = token.ColorBgTextActive;
            var colorPickerPresetColorSize = token.ColorPickerPresetColorSize;
            var colorPickerPreviewSize = token.ColorPickerPreviewSize;
            var lineWidth = token.LineWidth;
            var colorBorder = token.ColorBorder;
            var paddingXXS = token.PaddingXXS;
            var fontSize = token.FontSize;
            var colorPrimaryHover = token.ColorPrimaryHover;
            var controlOutline = token.ControlOutline;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        [$@"{componentCls}-inner"] = new object
                        {
                            ["&-content"] = new object
                            {
                                Display = "flex",
                                FlexDirection = "column",
                                Width = colorPickerWidth,
                                [$@"{antCls}-divider"] = new object
                                {
                                    Margin = $@"{Unit(marginSM)} 0 {Unit(marginXS)}",
                                },
                            },
                            [$@"{componentCls}-panel"] = new object
                            {
                                ["..."] = GenPickerStyle(token),
                            },
                            ["..."] = GenSliderStyle(token),
                            ["..."] = GenColorBlockStyle(token, colorPickerPreviewSize),
                            ["..."] = GenInputStyle(token),
                            ["..."] = GenPresetsStyle(token),
                            ["..."] = GenClearStyle(token, colorPickerPresetColorSize, new object { MarginInlineStart = "auto", }),
                            [$@"{componentCls}-operation"] = new object
                            {
                                Display = "flex",
                                JustifyContent = "space-between",
                                MarginBottom = marginXS,
                            },
                        },
                        ["&-trigger"] = new object
                        {
                            MinWidth = controlHeight,
                            MinHeight = controlHeight,
                            Border = $@"{Unit(lineWidth)} solid {colorBorder}",
                            Cursor = "pointer",
                            Display = "inline-flex",
                            AlignItems = "flex-start",
                            JustifyContent = "center",
                            Transition = $@"{motionDurationMid}",
                            Background = colorBgElevated,
                            Padding = token.calc(paddingXXS).sub(lineWidth).Equal(),
                            [$@"{componentCls}-trigger-text"] = new object
                            {
                                MarginInlineStart = marginXS,
                                MarginInlineEnd = token
              .calc(marginXS)
              .sub(token.calc(paddingXXS).sub(lineWidth)).Equal(),
                                Color = colorText,
                                AlignSelf = "center",
                                ["&-cell"] = new object
                                {
                                    ["&:not(:last-child):after"] = new object
                                    {
                                        Content = "\", \"",
                                    },
                                    ["&-inactive"] = new object
                                    {
                                        Color = colorTextDisabled,
                                    },
                                },
                            },
                            ["&:hover"] = new object
                            {
                                BorderColor = colorPrimaryHover,
                            },
                            [$@"{componentCls}-trigger-active"] = new object
                            {
                                ["..."] = GenActiveStyle(token, colorPrimary, controlOutline),
                            },
                            ["&-disabled"] = new object
                            {
                                Color = colorTextDisabled,
                                Background = colorBgContainerDisabled,
                                Cursor = "not-allowed",
                                ["&:hover"] = new object
                                {
                                    BorderColor = colorBgTextActive,
                                },
                                [$@"{componentCls}-trigger-text"] = new object
                                {
                                    Color = colorTextDisabled,
                                },
                            },
                            ["..."] = GenClearStyle(token, controlHeightSM),
                            ["..."] = GenColorBlockStyle(token, controlHeightSM),
                            ["..."] = GenStatusStyle(token),
                            ["..."] = GenSizeStyle(token),
                        },
                        ["..."] = GenRtlStyle(token),
                    },
                },
                GenCompactItemStyle(token, new object { FocusElCls = $@"{componentCls}-trigger-active", })
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("ColorPicker", (ColorPickerToken token) =>
            {
                var colorTextQuaternary = token.ColorTextQuaternary;
                var marginSM = token.MarginSM;
                var colorPickerSliderHeight = 8;
                var colorPickerToken = MergeToken(token, new object { ColorPickerWidth = 234, ColorPickerHandlerSize = 16, ColorPickerHandlerSizeSM = 12, ColorPickerAlphaInputWidth = 44, ColorPickerInputNumberHandleWidth = 16, ColorPickerPresetColorSize = 24, ColorPickerInsetShadow = $@"{colorTextQuaternary}", ColorPickerPreviewSize = token
      .calc(colorPickerSliderHeight)
      .mul(2)
      .add(marginSM).Equal() as number, });
                return new object[]
                {
                    GenColorPickerStyle(colorPickerToken)
                };
            });
        }
    }
}