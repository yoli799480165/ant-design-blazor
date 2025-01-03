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
    public partial class SliderStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ControlSize { get; set; }
            public double RailSize { get; set; }
            public double HandleSize { get; set; }
            public double HandleSizeHover { get; set; }
            public string HandleLineWidth { get; set; }
            public string HandleLineWidthHover { get; set; }
            public double DotSize { get; set; }
            public string RailBg { get; set; }
            public string RailHoverBg { get; set; }
            public string TrackBg { get; set; }
            public string TrackHoverBg { get; set; }
            public string HandleColor { get; set; }
            public string HandleActiveColor { get; set; }
            public string HandleActiveOutlineColor { get; set; }
            public string HandleColorDisabled { get; set; }
            public string DotBorderColor { get; set; }
            public string DotActiveBorderColor { get; set; }
            public string TrackBgDisabled { get; set; }
        }

        public class SliderToken : ComponentToken
        {
            public string MarginFull { get; set; }
            public string MarginPart { get; set; }
            public string MarginPartWithMark { get; set; }
        }

        public static CSSObject GenBaseStyle(SliderToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var controlSize = token.ControlSize;
            var dotSize = token.DotSize;
            var marginFull = token.MarginFull;
            var marginPart = token.MarginPart;
            var colorFillContentHover = token.ColorFillContentHover;
            var handleColorDisabled = token.HandleColorDisabled;
            var calc = token.Calc;
            var handleSize = token.HandleSize;
            var handleSizeHover = token.HandleSizeHover;
            var handleActiveColor = token.HandleActiveColor;
            var handleActiveOutlineColor = token.HandleActiveOutlineColor;
            var handleLineWidth = token.HandleLineWidth;
            var handleLineWidthHover = token.HandleLineWidthHover;
            var motionDurationMid = token.MotionDurationMid;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "relative",
                    Height = controlSize,
                    Margin = $@"{Unit(marginPart)} {Unit(marginFull)}",
                    Padding = 0,
                    Cursor = "pointer",
                    TouchAction = "none",
                    ["&-vertical"] = new CSSObject
                    {
                        Margin = $@"{Unit(marginFull)} {Unit(marginPart)}",
                    },
                    [$@"{componentCls}-rail"] = new CSSObject
                    {
                        Position = "absolute",
                        BackgroundColor = token.RailBg,
                        BorderRadius = token.BorderRadiusXS,
                        Transition = $@"{motionDurationMid}",
                    },
                    [$@"{componentCls}-track,{componentCls}-tracks"] = new CSSObject
                    {
                        Position = "absolute",
                        Transition = $@"{motionDurationMid}",
                    },
                    [$@"{componentCls}-track"] = new CSSObject
                    {
                        BackgroundColor = token.TrackBg,
                        BorderRadius = token.BorderRadiusXS,
                    },
                    [$@"{componentCls}-track-draggable"] = new CSSObject
                    {
                        BoxSizing = "content-box",
                        BackgroundClip = "content-box",
                        Border = "solid rgba(0,0,0,0)",
                    },
                    ["&:hover"] = new CSSObject
                    {
                        [$@"{componentCls}-rail"] = new CSSObject
                        {
                            BackgroundColor = token.RailHoverBg,
                        },
                        [$@"{componentCls}-track"] = new CSSObject
                        {
                            BackgroundColor = token.TrackHoverBg,
                        },
                        [$@"{componentCls}-dot"] = new CSSObject
                        {
                            BorderColor = colorFillContentHover,
                        },
                        [$@"{componentCls}-handle::after"] = new CSSObject
                        {
                            BoxShadow = $@"{Unit(handleLineWidth)} {token.ColorPrimaryBorderHover}",
                        },
                        [$@"{componentCls}-dot-active"] = new CSSObject
                        {
                            BorderColor = token.DotActiveBorderColor,
                        },
                    },
                    [$@"{componentCls}-handle"] = new CSSObject
                    {
                        Position = "absolute",
                        Width = handleSize,
                        Height = handleSize,
                        Outline = "none",
                        UserSelect = "none",
                        ["&-dragging-delete"] = new CSSObject
                        {
                            Opacity = 0,
                        },
                        ["&::before"] = new CSSObject
                        {
                            Content = "\"\"",
                            Position = "absolute",
                            InsetInlineStart = Calc(handleLineWidth).Mul(-1).Equal(),
                            InsetBlockStart = Calc(handleLineWidth).Mul(-1).Equal(),
                            Width = Calc(handleSize).Add(Calc(handleLineWidth).Mul(2)).Equal(),
                            Height = Calc(handleSize).Add(Calc(handleLineWidth).Mul(2)).Equal(),
                            BackgroundColor = "transparent",
                        },
                        ["&::after"] = new CSSObject
                        {
                            Content = "\"\"",
                            Position = "absolute",
                            InsetBlockStart = 0,
                            InsetInlineStart = 0,
                            Width = handleSize,
                            Height = handleSize,
                            BackgroundColor = token.ColorBgElevated,
                            BoxShadow = $@"{Unit(handleLineWidth)} {token.HandleColor}",
                            Outline = "0px solid transparent",
                            BorderRadius = "50%",
                            Cursor = "pointer",
                            Transition = $@"{motionDurationMid},
            inset-block-start {motionDurationMid},
            width {motionDurationMid},
            height {motionDurationMid},
            box-shadow {motionDurationMid},
            outline {motionDurationMid}
          ",
                        },
                        ["&:hover, &:active, &:focus"] = new CSSObject
                        {
                            ["&::before"] = new CSSObject
                            {
                                InsetInlineStart = Calc(handleSizeHover).Sub(handleSize).Div(2).Add(handleLineWidthHover).Mul(-1).Equal(),
                                InsetBlockStart = Calc(handleSizeHover).Sub(handleSize).Div(2).Add(handleLineWidthHover).Mul(-1).Equal(),
                                Width = Calc(handleSizeHover).Add(Calc(handleLineWidthHover).Mul(2)).Equal(),
                                Height = Calc(handleSizeHover).Add(Calc(handleLineWidthHover).Mul(2)).Equal(),
                            },
                            ["&::after"] = new CSSObject
                            {
                                BoxShadow = $@"{Unit(handleLineWidthHover)} {handleActiveColor}",
                                Outline = $@"{handleActiveOutlineColor}",
                                Width = handleSizeHover,
                                Height = handleSizeHover,
                                InsetInlineStart = token.Calc(handleSize).Sub(handleSizeHover).Div(2).Equal(),
                                InsetBlockStart = token.Calc(handleSize).Sub(handleSizeHover).Div(2).Equal(),
                            },
                        },
                    },
                    [$@"{componentCls}-handle"] = new CSSObject
                    {
                        ["&::before, &::after"] = new CSSObject
                        {
                            Transition = "none",
                        },
                    },
                    [$@"{componentCls}-mark"] = new CSSObject
                    {
                        Position = "absolute",
                        FontSize = token.FontSize,
                    },
                    [$@"{componentCls}-mark-text"] = new CSSObject
                    {
                        Position = "absolute",
                        Display = "inline-block",
                        Color = token.ColorTextDescription,
                        TextAlign = "center",
                        WordBreak = "keep-all",
                        Cursor = "pointer",
                        UserSelect = "none",
                        ["&-active"] = new CSSObject
                        {
                            Color = token.ColorText,
                        },
                    },
                    [$@"{componentCls}-step"] = new CSSObject
                    {
                        Position = "absolute",
                        Background = "transparent",
                        PointerEvents = "none",
                    },
                    [$@"{componentCls}-dot"] = new CSSObject
                    {
                        Position = "absolute",
                        Width = dotSize,
                        Height = dotSize,
                        BackgroundColor = token.ColorBgElevated,
                        Border = $@"{Unit(handleLineWidth)} solid {token.DotBorderColor}",
                        BorderRadius = "50%",
                        Cursor = "pointer",
                        Transition = $@"{token.MotionDurationSlow}",
                        PointerEvents = "auto",
                        ["&-active"] = new CSSObject
                        {
                            BorderColor = token.DotActiveBorderColor,
                        },
                    },
                    [$@"{componentCls}-disabled"] = new CSSObject
                    {
                        Cursor = "not-allowed",
                        [$@"{componentCls}-rail"] = new CSSObject
                        {
                            BackgroundColor = $@"{token.RailBg} !important",
                        },
                        [$@"{componentCls}-track"] = new CSSObject
                        {
                            BackgroundColor = $@"{token.TrackBgDisabled} !important",
                        },
                        [$@"{componentCls}-dot
        "] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgElevated,
                            BorderColor = token.TrackBgDisabled,
                            BoxShadow = "none",
                            Cursor = "not-allowed",
                        },
                        [$@"{componentCls}-handle::after"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgElevated,
                            Cursor = "not-allowed",
                            Width = handleSize,
                            Height = handleSize,
                            BoxShadow = $@"{Unit(handleLineWidth)} {handleColorDisabled}",
                            InsetInlineStart = 0,
                            InsetBlockStart = 0,
                        },
                        [$@"{componentCls}-mark-text,
          {componentCls}-dot
        "] = new CSSObject
                        {
                            Cursor = "not-allowed !important",
                        },
                    },
                    [$@"{antCls}-tooltip-inner"] = new CSSObject
                    {
                        MinWidth = "unset",
                    },
                },
            };
        }

        public static CSSObject GenDirectionStyle(SliderToken token, boolean horizontal)
        {
            var componentCls = token.ComponentCls;
            var railSize = token.RailSize;
            var handleSize = token.HandleSize;
            var dotSize = token.DotSize;
            var marginFull = token.MarginFull;
            var calc = token.Calc;
            var railPadding = horizontal ? "paddingBlock" : "paddingInline";
            var full = horizontal ? "width" : "height";
            var part = horizontal ? "height" : "width";
            var handlePos = horizontal ? "insetBlockStart" : "insetInlineStart";
            var markInset = horizontal ? "top" : "insetInlineStart";
            var handlePosSize = Calc(railSize).Mul(3).Sub(handleSize).Div(2).Equal();
            var draggableBorderSize = Calc(handleSize).Sub(railSize).Div(2).Equal();
            var draggableBorder = horizontal ? new object
            {
                BorderWidth = $@"{Unit(draggableBorderSize)} 0",
                Transform = $@"{Unit(Calc(draggableBorderSize).Mul(-1).Equal())})",
            }

            : new object
            {
                BorderWidth = $@"{Unit(draggableBorderSize)}",
                Transform = $@"{Unit(token.Calc(draggableBorderSize).Mul(-1).Equal())})",
            };
            return new CSSObject
            {
                [railPadding] = railSize,
                [part] = Calc(railSize).Mul(3).Equal(),
                [$@"{componentCls}-rail"] = new CSSObject
                {
                    [full] = "100%",
                    [part] = railSize,
                },
                [$@"{componentCls}-track,{componentCls}-tracks"] = new CSSObject
                {
                    [part] = railSize,
                },
                [$@"{componentCls}-track-draggable"] = new CSSObject
                {
                    ["..."] = draggableBorder,
                },
                [$@"{componentCls}-handle"] = new CSSObject
                {
                    [handlePos] = handlePosSize,
                },
                [$@"{componentCls}-mark"] = new CSSObject
                {
                    InsetInlineStart = 0,
                    Top = 0,
                    [markInset] = Calc(railSize).Mul(3).Add(horizontal ? 0 : marginFull).Equal(),
                    [full] = "100%",
                },
                [$@"{componentCls}-step"] = new CSSObject
                {
                    InsetInlineStart = 0,
                    Top = 0,
                    [markInset] = railSize,
                    [full] = "100%",
                    [part] = railSize,
                },
                [$@"{componentCls}-dot"] = new CSSObject
                {
                    Position = "absolute",
                    [handlePos] = Calc(railSize).Sub(dotSize).Div(2).Equal(),
                },
            };
        }

        public static CSSObject GenHorizontalStyle(SliderToken token)
        {
            var componentCls = token.ComponentCls;
            var marginPartWithMark = token.MarginPartWithMark;
            return new CSSObject
            {
                [$@"{componentCls}-horizontal"] = new CSSObject
                {
                    ["..."] = GenDirectionStyle(token, true),
                    [$@"{componentCls}-with-marks"] = new CSSObject
                    {
                        MarginBottom = marginPartWithMark,
                    },
                },
            };
        }

        public static CSSObject GenVerticalStyle(SliderToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-vertical"] = new CSSObject
                {
                    ["..."] = GenDirectionStyle(token, false),
                    Height = "100%",
                },
            };
        }

        public static SliderToken PrepareComponentToken(SliderToken token)
        {
            var increaseHandleWidth = 1;
            var controlSize = token.ControlHeightLG / 4;
            var controlSizeHover = token.ControlHeightSM / 2;
            var handleLineWidth = token.LineWidth + increaseHandleWidth;
            var handleLineWidthHover = token.LineWidth + increaseHandleWidth * 1.5;
            var handleActiveColor = token.ColorPrimary;
            var handleActiveOutlineColor = new TinyColor(handleActiveColor).SetAlpha(0.2).ToRgbString();
            return new SliderToken
            {
                RailSize = 4,
                HandleSize = controlSize,
                HandleSizeHover = controlSizeHover,
                DotSize = 8,
                RailBg = token.ColorFillTertiary,
                RailHoverBg = token.ColorFillSecondary,
                TrackBg = token.ColorPrimaryBorder,
                TrackHoverBg = token.ColorPrimaryBorderHover,
                HandleColor = token.ColorPrimaryBorder,
                HandleColorDisabled = new TinyColor(token.ColorTextDisabled).OnBackground(token.ColorBgContainer).ToHexShortString(),
                DotBorderColor = token.ColorBorderSecondary,
                DotActiveBorderColor = token.ColorPrimaryBorder,
                TrackBgDisabled = token.ColorBgContainerDisabled,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Slider", (SliderToken token) =>
            {
                var sliderToken = MergeToken(token, new object { MarginPart = token.Calc(token.ControlHeight).Sub(token.ControlSize).Div(2).Equal(), MarginFull = token.Calc(token.ControlSize).Div(2).Equal(), MarginPartWithMark = token.Calc(token.ControlHeightLG).Sub(token.ControlSize).Equal(), });
                return new object[]
                {
                    GenBaseStyle(sliderToken),
                    GenHorizontalStyle(sliderToken),
                    GenVerticalStyle(sliderToken)
                };
            }, PrepareComponentToken);
        }
    }
}