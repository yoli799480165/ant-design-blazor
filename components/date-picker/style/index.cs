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
    public partial class DatePickerStyle
    {
        public static CSSObject GenPickerPadding(PickerToken token, number inputHeight, number fontHeight, number paddingHorizontal)
        {
            var height = token.Calc(fontHeight).Add(2).Equal();
            var paddingTop = token.Max(token.Calc(inputHeight).Sub(height).Div(2).Equal(), 0);
            var paddingBottom = token.Max(token.Calc(inputHeight).Sub(height).Sub(paddingTop).Equal(), 0);
            return new CSSObject
            {
                Padding = $@"{Unit(paddingTop)} {Unit(paddingHorizontal)} {Unit(paddingBottom)}",
            };
        }

        public static CSSObject GenPickerStatusStyle(DatePickerToken token)
        {
            var componentCls = token.ComponentCls;
            var colorError = token.ColorError;
            var colorWarning = token.ColorWarning;
            return new CSSObject
            {
                [$@"{componentCls}:not({componentCls}-disabled):not([disabled])"] = new CSSObject
                {
                    [$@"{componentCls}-status-error"] = new CSSObject
                    {
                        [$@"{componentCls}-active-bar"] = new CSSObject
                        {
                            Background = colorError,
                        },
                    },
                    [$@"{componentCls}-status-warning"] = new CSSObject
                    {
                        [$@"{componentCls}-active-bar"] = new CSSObject
                        {
                            Background = colorWarning,
                        },
                    },
                },
            };
        }

        public static CSSObject GenPickerStyle(DatePickerToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var controlHeight = token.ControlHeight;
            var paddingInline = token.PaddingInline;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var colorBorder = token.ColorBorder;
            var borderRadius = token.BorderRadius;
            var motionDurationMid = token.MotionDurationMid;
            var colorTextDisabled = token.ColorTextDisabled;
            var colorTextPlaceholder = token.ColorTextPlaceholder;
            var controlHeightLG = token.ControlHeightLG;
            var fontSizeLG = token.FontSizeLG;
            var controlHeightSM = token.ControlHeightSM;
            var paddingInlineSM = token.PaddingInlineSM;
            var paddingXS = token.PaddingXS;
            var marginXS = token.MarginXS;
            var colorTextDescription = token.ColorTextDescription;
            var lineWidthBold = token.LineWidthBold;
            var colorPrimary = token.ColorPrimary;
            var motionDurationSlow = token.MotionDurationSlow;
            var zIndexPopup = token.ZIndexPopup;
            var paddingXXS = token.PaddingXXS;
            var sizePopupArrow = token.SizePopupArrow;
            var colorBgElevated = token.ColorBgElevated;
            var borderRadiusLG = token.BorderRadiusLG;
            var boxShadowSecondary = token.BoxShadowSecondary;
            var borderRadiusSM = token.BorderRadiusSM;
            var colorSplit = token.ColorSplit;
            var cellHoverBg = token.CellHoverBg;
            var presetsWidth = token.PresetsWidth;
            var presetsMaxWidth = token.PresetsMaxWidth;
            var boxShadowPopoverArrow = token.BoxShadowPopoverArrow;
            var fontHeight = token.FontHeight;
            var fontHeightLG = token.FontHeightLG;
            var lineHeightLG = token.LineHeightLG;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        ["..."] = GenPickerPadding(token, controlHeight, fontHeight, paddingInline),
                        Position = "relative",
                        Display = "inline-flex",
                        AlignItems = "center",
                        LineHeight = 1,
                        Transition = $@"{motionDurationMid}, box-shadow {motionDurationMid}, background {motionDurationMid}",
                        [$@"{componentCls}-prefix"] = new object
                        {
                            MarginInlineEnd = token.InputAffixPadding,
                        },
                        [$@"{componentCls}-input"] = new object
                        {
                            Position = "relative",
                            Display = "inline-flex",
                            AlignItems = "center",
                            Width = "100%",
                            ["> input"] = new object
                            {
                                Position = "relative",
                                Display = "inline-block",
                                Width = "100%",
                                Color = "inherit",
                                FontSize = token.FontSize,
                                LineHeight = token.LineHeight,
                                Transition = $@"{motionDurationMid}",
                                ["..."] = GenPlaceholderStyle(colorTextPlaceholder),
                                Flex = "auto",
                                MinWidth = 1,
                                Height = "auto",
                                Padding = 0,
                                Background = "transparent",
                                Border = 0,
                                FontFamily = "inherit",
                                ["&:focus"] = new object
                                {
                                    BoxShadow = "none",
                                    Outline = 0,
                                },
                                ["&[disabled]"] = new object
                                {
                                    Background = "transparent",
                                    Color = colorTextDisabled,
                                    Cursor = "not-allowed",
                                },
                            },
                            ["&-placeholder"] = new object
                            {
                                ["> input"] = new object
                                {
                                    Color = colorTextPlaceholder,
                                },
                            },
                        },
                        ["&-large"] = new object
                        {
                            ["..."] = GenPickerPadding(token, controlHeightLG, fontHeightLG, paddingInline),
                            [$@"{componentCls}-input > input"] = new object
                            {
                                FontSize = fontSizeLG,
                                LineHeight = lineHeightLG,
                            },
                        },
                        ["&-small"] = new object
                        {
                            ["..."] = GenPickerPadding(token, controlHeightSM, fontHeight, paddingInlineSM),
                        },
                        [$@"{componentCls}-suffix"] = new object
                        {
                            Display = "flex",
                            Flex = "none",
                            AlignSelf = "center",
                            MarginInlineStart = token.Calc(paddingXS).Div(2).Equal(),
                            Color = colorTextDisabled,
                            LineHeight = 1,
                            PointerEvents = "none",
                            Transition = $@"{motionDurationMid}, color {motionDurationMid}",
                            ["> *"] = new object
                            {
                                VerticalAlign = "top",
                                ["&:not(:last-child)"] = new object
                                {
                                    MarginInlineEnd = marginXS,
                                },
                            },
                        },
                        [$@"{componentCls}-clear"] = new object
                        {
                            Position = "absolute",
                            Top = "50%",
                            InsetInlineEnd = 0,
                            Color = colorTextDisabled,
                            LineHeight = 1,
                            Transform = "translateY(-50%)",
                            Cursor = "pointer",
                            Opacity = 0,
                            Transition = $@"{motionDurationMid}, color {motionDurationMid}",
                            ["> *"] = new object
                            {
                                VerticalAlign = "top",
                            },
                            ["&:hover"] = new object
                            {
                                Color = colorTextDescription,
                            },
                        },
                        ["&:hover"] = new object
                        {
                            [$@"{componentCls}-clear"] = new object
                            {
                                Opacity = 1,
                            },
                            [$@"{componentCls}-suffix:not(:last-child)"] = new object
                            {
                                Opacity = 0,
                            },
                        },
                        [$@"{componentCls}-separator"] = new object
                        {
                            Position = "relative",
                            Display = "inline-block",
                            Width = "1em",
                            Height = fontSizeLG,
                            Color = colorTextDisabled,
                            FontSize = fontSizeLG,
                            VerticalAlign = "top",
                            Cursor = "default",
                            [$@"{componentCls}-focused &"] = new object
                            {
                                Color = colorTextDescription,
                            },
                            [$@"{componentCls}-range-separator &"] = new object
                            {
                                [$@"{componentCls}-disabled &"] = new object
                                {
                                    Cursor = "not-allowed",
                                },
                            },
                        },
                        ["&-range"] = new object
                        {
                            Position = "relative",
                            Display = "inline-flex",
                            [$@"{componentCls}-active-bar"] = new object
                            {
                                Bottom = token.Calc(lineWidth).Mul(-1).Equal(),
                                Height = lineWidthBold,
                                Background = colorPrimary,
                                Opacity = 0,
                                Transition = $@"{motionDurationSlow} ease-out",
                                PointerEvents = "none",
                            },
                            [$@"{componentCls}-focused"] = new object
                            {
                                [$@"{componentCls}-active-bar"] = new object
                                {
                                    Opacity = 1,
                                },
                            },
                            [$@"{componentCls}-range-separator"] = new object
                            {
                                AlignItems = "center",
                                Padding = $@"{Unit(paddingXS)}",
                                LineHeight = 1,
                            },
                        },
                        ["&-range, &-multiple"] = new object
                        {
                            [$@"{componentCls}-clear"] = new object
                            {
                                InsetInlineEnd = paddingInline,
                            },
                            [$@"{componentCls}-small"] = new object
                            {
                                [$@"{componentCls}-clear"] = new object
                                {
                                    InsetInlineEnd = paddingInlineSM,
                                },
                            },
                        },
                        ["&-dropdown"] = new object
                        {
                            ["..."] = ResetComponent(token),
                            ["..."] = GenPanelStyle(token),
                            PointerEvents = "none",
                            Position = "absolute",
                            Top = -9999,
                            Left = new object
                            {
                                _skip_check_ = true,
                                Value = -9999,
                            },
                            ZIndex = zIndexPopup,
                            [$@"{componentCls}-dropdown-hidden"] = new object
                            {
                                Display = "none",
                            },
                            ["&-rtl"] = new object
                            {
                                Direction = "rtl",
                            },
                            [$@"{componentCls}-dropdown-placement-bottomLeft,
            &{componentCls}-dropdown-placement-bottomRight"] = new object
                            {
                                [$@"{componentCls}-range-arrow"] = new object
                                {
                                    Top = 0,
                                    Display = "block",
                                    Transform = "translateY(-100%)",
                                },
                            },
                            [$@"{componentCls}-dropdown-placement-topLeft,
            &{componentCls}-dropdown-placement-topRight"] = new object
                            {
                                [$@"{componentCls}-range-arrow"] = new object
                                {
                                    Bottom = 0,
                                    Display = "block",
                                    Transform = "translateY(100%) rotate(180deg)",
                                },
                            },
                            [$@"{antCls}-slide-up-enter{antCls}-slide-up-enter-active{componentCls}-dropdown-placement-topLeft,
          &{antCls}-slide-up-enter{antCls}-slide-up-enter-active{componentCls}-dropdown-placement-topRight,
          &{antCls}-slide-up-appear{antCls}-slide-up-appear-active{componentCls}-dropdown-placement-topLeft,
          &{antCls}-slide-up-appear{antCls}-slide-up-appear-active{componentCls}-dropdown-placement-topRight"] = new object
                            {
                                AnimationName = slideDownIn,
                            },
                            [$@"{antCls}-slide-up-enter{antCls}-slide-up-enter-active{componentCls}-dropdown-placement-bottomLeft,
          &{antCls}-slide-up-enter{antCls}-slide-up-enter-active{componentCls}-dropdown-placement-bottomRight,
          &{antCls}-slide-up-appear{antCls}-slide-up-appear-active{componentCls}-dropdown-placement-bottomLeft,
          &{antCls}-slide-up-appear{antCls}-slide-up-appear-active{componentCls}-dropdown-placement-bottomRight"] = new object
                            {
                                AnimationName = slideUpIn,
                            },
                            [$@"{antCls}-slide-up-leave {componentCls}-panel-container"] = new object
                            {
                                PointerEvents = "none",
                            },
                            [$@"{antCls}-slide-up-leave{antCls}-slide-up-leave-active{componentCls}-dropdown-placement-topLeft,
          &{antCls}-slide-up-leave{antCls}-slide-up-leave-active{componentCls}-dropdown-placement-topRight"] = new object
                            {
                                AnimationName = slideDownOut,
                            },
                            [$@"{antCls}-slide-up-leave{antCls}-slide-up-leave-active{componentCls}-dropdown-placement-bottomLeft,
          &{antCls}-slide-up-leave{antCls}-slide-up-leave-active{componentCls}-dropdown-placement-bottomRight"] = new object
                            {
                                AnimationName = slideUpOut,
                            },
                            [$@"{componentCls}-panel > {componentCls}-time-panel"] = new object
                            {
                                PaddingTop = paddingXXS,
                            },
                            [$@"{componentCls}-range-wrapper"] = new object
                            {
                                Display = "flex",
                                Position = "relative",
                            },
                            [$@"{componentCls}-range-arrow"] = new object
                            {
                                Position = "absolute",
                                ZIndex = 1,
                                Display = "none",
                                PaddingInline = token.Calc(paddingInline).Mul(1.5).Equal(),
                                BoxSizing = "content-box",
                                Transition = $@"{motionDurationSlow} ease-out",
                                ["..."] = GenRoundedArrow(token, colorBgElevated, boxShadowPopoverArrow),
                                ["&:before"] = new object
                                {
                                    InsetInlineStart = token.Calc(paddingInline).Mul(1.5).Equal(),
                                },
                            },
                            [$@"{componentCls}-panel-container"] = new object
                            {
                                Overflow = "hidden",
                                VerticalAlign = "top",
                                Background = colorBgElevated,
                                BorderRadius = borderRadiusLG,
                                BoxShadow = boxShadowSecondary,
                                Transition = $@"{motionDurationSlow}",
                                Display = "inline-block",
                                PointerEvents = "auto",
                                [$@"{componentCls}-panel-layout"] = new object
                                {
                                    Display = "flex",
                                    FlexWrap = "nowrap",
                                    AlignItems = "stretch",
                                },
                                [$@"{componentCls}-presets"] = new object
                                {
                                    Display = "flex",
                                    FlexDirection = "column",
                                    MinWidth = presetsWidth,
                                    MaxWidth = presetsMaxWidth,
                                    ["ul"] = new object
                                    {
                                        Height = 0,
                                        Flex = "auto",
                                        ListStyle = "none",
                                        Overflow = "auto",
                                        Margin = 0,
                                        Padding = paddingXS,
                                        BorderInlineEnd = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                                        ["li"] = new object
                                        {
                                            ["..."] = textEllipsis,
                                            BorderRadius = borderRadiusSM,
                                            PaddingInline = paddingXS,
                                            PaddingBlock = token.Calc(controlHeightSM).Sub(fontHeight).Div(2).Equal(),
                                            Cursor = "pointer",
                                            Transition = $@"{motionDurationSlow}",
                                            ["+ li"] = new object
                                            {
                                                MarginTop = marginXS,
                                            },
                                            ["&:hover"] = new object
                                            {
                                                Background = cellHoverBg,
                                            },
                                        },
                                    },
                                },
                                [$@"{componentCls}-panels"] = new object
                                {
                                    Display = "inline-flex",
                                    FlexWrap = "nowrap",
                                    ["&:last-child"] = new object
                                    {
                                        [$@"{componentCls}-panel"] = new object
                                        {
                                            BorderWidth = 0,
                                        },
                                    },
                                },
                                [$@"{componentCls}-panel"] = new object
                                {
                                    VerticalAlign = "top",
                                    Background = "transparent",
                                    BorderRadius = 0,
                                    BorderWidth = 0,
                                    [$@"{componentCls}-content, table"] = new object
                                    {
                                        TextAlign = "center",
                                    },
                                    ["&-focused"] = new object
                                    {
                                        BorderColor = colorBorder,
                                    },
                                },
                            },
                        },
                        ["&-dropdown-range"] = new object
                        {
                            Padding = $@"{Unit(token.Calc(sizePopupArrow).Mul(2).Div(3).Equal())} 0",
                            ["&-hidden"] = new object
                            {
                                Display = "none",
                            },
                        },
                        ["&-rtl"] = new object
                        {
                            Direction = "rtl",
                            [$@"{componentCls}-separator"] = new object
                            {
                                Transform = "rotate(180deg)",
                            },
                            [$@"{componentCls}-footer"] = new object
                            {
                                ["&-extra"] = new object
                                {
                                    Direction = "rtl",
                                },
                            },
                        },
                    },
                },
                InitSlideMotion(token, "slide-up"),
                InitSlideMotion(token, "slide-down"),
                InitMoveMotion(token, "move-up"),
                InitMoveMotion(token, "move-down")
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("DatePicker", (DatePickerToken token) =>
            {
                var pickerToken = MergeToken(InitInputToken(token), InitPickerPanelToken(token), new object { InputPaddingHorizontalBase = token.Calc(token.PaddingSM).Sub(1).Equal(), MultipleSelectItemHeight = token.MultipleItemHeight, SelectHeight = token.ControlHeight, });
                return new object[]
                {
                    GenPickerPanelStyle(pickerToken),
                    GenPickerStyle(pickerToken),
                    GenVariantsStyle(pickerToken),
                    GenPickerStatusStyle(pickerToken),
                    GenPickerMultipleStyle(pickerToken),
                    GenCompactItemStyle(token, new object { FocusElCls = $@"{token.ComponentCls}-focused", })
                };
            }, PrepareComponentToken);
        }
    }
}