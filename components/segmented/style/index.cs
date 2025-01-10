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
    public partial class SegmentedStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string ItemColor { get; set; }
            public string ItemHoverColor { get; set; }
            public string ItemHoverBg { get; set; }
            public string ItemActiveBg { get; set; }
            public string ItemSelectedBg { get; set; }
            public string ItemSelectedColor { get; set; }
            public string TrackPadding { get; set; }
            public string TrackBg { get; set; }
        }

        public class SegmentedToken : ComponentToken
        {
            public string SegmentedPaddingHorizontal { get; set; }
            public string SegmentedPaddingHorizontalSM { get; set; }
        }

        public object segmentedTextEllipsisCss = new object
        {
            Overflow = "hidden",
            ["..."] = textEllipsis,
        };
        public static CSSObject GenSegmentedStyle(SegmentedToken token)
        {
            var componentCls = token.ComponentCls;
            var labelHeight = token.Calc(token.ControlHeight).Sub(token.Calc(token.TrackPadding).Mul(2)).Equal();
            var labelHeightLG = token.Calc(token.ControlHeightLG).Sub(token.Calc(token.TrackPadding).Mul(2)).Equal();
            var labelHeightSM = token.Calc(token.ControlHeightSM).Sub(token.Calc(token.TrackPadding).Mul(2)).Equal();
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "inline-block",
                    Padding = token.TrackPadding,
                    Color = token.ItemColor,
                    Background = token.TrackBg,
                    BorderRadius = token.BorderRadius,
                    Transition = $@"{token.MotionDurationMid} {token.MotionEaseInOut}",
                    ["..."] = GenFocusStyle(token),
                    [$@"{componentCls}-group"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "flex",
                        AlignItems = "stretch",
                        JustifyItems = "flex-start",
                        FlexDirection = "row",
                        Width = "100%",
                    },
                    [$@"{componentCls}-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [$@"{componentCls}-vertical"] = new CSSObject
                    {
                        [$@"{componentCls}-group"] = new CSSObject
                        {
                            FlexDirection = "column",
                        },
                        [$@"{componentCls}-thumb"] = new CSSObject
                        {
                            Width = "100%",
                            Height = 0,
                            Padding = $@"{Unit(token.PaddingXXS)}",
                        },
                    },
                    [$@"{componentCls}-block"] = new CSSObject
                    {
                        Display = "flex",
                    },
                    [$@"{componentCls}-block {componentCls}-item"] = new CSSObject
                    {
                        Flex = 1,
                        MinWidth = 0,
                    },
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        Position = "relative",
                        TextAlign = "center",
                        Cursor = "pointer",
                        Transition = $@"{token.MotionDurationMid} {token.MotionEaseInOut}",
                        BorderRadius = token.BorderRadiusSM,
                        Transform = "translateZ(0)",
                        ["&-selected"] = new CSSObject
                        {
                            ["..."] = GetItemSelectedStyle(token),
                            Color = token.ItemSelectedColor,
                        },
                        ["&-focused"] = new CSSObject
                        {
                            ["..."] = GenFocusOutline(token),
                        },
                        ["&::after"] = new CSSObject
                        {
                            Content = "\"\"",
                            Position = "absolute",
                            ZIndex = -1,
                            Width = "100%",
                            Height = "100%",
                            Top = 0,
                            InsetInlineStart = 0,
                            BorderRadius = "inherit",
                            Transition = $@"{token.MotionDurationMid}",
                            PointerEvents = "none",
                        },
                        [$@"{componentCls}-item-selected):not({componentCls}-item-disabled)"] = new CSSObject
                        {
                            Color = token.ItemHoverColor,
                            ["&::after"] = new CSSObject
                            {
                                BackgroundColor = token.ItemHoverBg,
                            },
                        },
                        [$@"{componentCls}-item-selected):not({componentCls}-item-disabled)"] = new CSSObject
                        {
                            Color = token.ItemHoverColor,
                            ["&::after"] = new CSSObject
                            {
                                BackgroundColor = token.ItemActiveBg,
                            },
                        },
                        ["&-label"] = new CSSObject
                        {
                            MinHeight = labelHeight,
                            LineHeight = Unit(labelHeight),
                            Padding = $@"{Unit(token.SegmentedPaddingHorizontal)}",
                            ["..."] = segmentedTextEllipsisCss,
                        },
                        ["&-icon + *"] = new CSSObject
                        {
                            MarginInlineStart = token.Calc(token.MarginSM).Div(2).Equal(),
                        },
                        ["&-input"] = new CSSObject
                        {
                            Position = "absolute",
                            InsetBlockStart = 0,
                            InsetInlineStart = 0,
                            Width = 0,
                            Height = 0,
                            Opacity = 0,
                            PointerEvents = "none",
                        },
                    },
                    [$@"{componentCls}-thumb"] = new CSSObject
                    {
                        ["..."] = GetItemSelectedStyle(token),
                        Position = "absolute",
                        InsetBlockStart = 0,
                        InsetInlineStart = 0,
                        Width = 0,
                        Height = "100%",
                        Padding = $@"{Unit(token.PaddingXXS)} 0",
                        BorderRadius = token.BorderRadiusSM,
                        Transition = $@"{token.MotionDurationSlow} {token.MotionEaseInOut}, height {token.MotionDurationSlow} {token.MotionEaseInOut}",
                        [$@"{componentCls}-item:not({componentCls}-item-selected):not({componentCls}-item-disabled)::after"] = new CSSObject
                        {
                            BackgroundColor = "transparent",
                        },
                    },
                    [$@"{componentCls}-lg"] = new CSSObject
                    {
                        BorderRadius = token.BorderRadiusLG,
                        [$@"{componentCls}-item-label"] = new CSSObject
                        {
                            MinHeight = labelHeightLG,
                            LineHeight = Unit(labelHeightLG),
                            Padding = $@"{Unit(token.SegmentedPaddingHorizontal)}",
                            FontSize = token.FontSizeLG,
                        },
                        [$@"{componentCls}-item, {componentCls}-thumb"] = new CSSObject
                        {
                            BorderRadius = token.BorderRadius,
                        },
                    },
                    [$@"{componentCls}-sm"] = new CSSObject
                    {
                        BorderRadius = token.BorderRadiusSM,
                        [$@"{componentCls}-item-label"] = new CSSObject
                        {
                            MinHeight = labelHeightSM,
                            LineHeight = Unit(labelHeightSM),
                            Padding = $@"{Unit(token.SegmentedPaddingHorizontalSM)}",
                        },
                        [$@"{componentCls}-item, {componentCls}-thumb"] = new CSSObject
                        {
                            BorderRadius = token.BorderRadiusXS,
                        },
                    },
                    ["..."] = GetItemDisabledStyle($@"{componentCls}-item", token),
                    ["..."] = GetItemDisabledStyle($@"{componentCls}-item-disabled", token),
                    [$@"{componentCls}-thumb-motion-appear-active"] = new CSSObject
                    {
                        Transition = $@"{token.MotionDurationSlow} {token.MotionEaseInOut}, width {token.MotionDurationSlow} {token.MotionEaseInOut}",
                        WillChange = "transform, width",
                    },
                },
            };
        }

        public static SegmentedToken PrepareComponentToken(SegmentedToken token)
        {
            var colorTextLabel = token.ColorTextLabel;
            var colorText = token.ColorText;
            var colorFillSecondary = token.ColorFillSecondary;
            var colorBgElevated = token.ColorBgElevated;
            var colorFill = token.ColorFill;
            var lineWidthBold = token.LineWidthBold;
            var colorBgLayout = token.ColorBgLayout;
            return new SegmentedToken
            {
                TrackPadding = lineWidthBold,
                TrackBg = colorBgLayout,
                ItemColor = colorTextLabel,
                ItemHoverColor = colorText,
                ItemHoverBg = colorFillSecondary,
                ItemSelectedBg = colorBgElevated,
                ItemActiveBg = colorFill,
                ItemSelectedColor = colorText,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Segmented", (SegmentedToken token) =>
            {
                var lineWidth = token.LineWidth;
                var calc = token.Calc;
                var segmentedToken = MergeToken(token, new object { SegmentedPaddingHorizontal = Calc(token.ControlPaddingHorizontal).Sub(lineWidth).Equal(), SegmentedPaddingHorizontalSM = Calc(token.ControlPaddingHorizontalSM).Sub(lineWidth).Equal(), });
                return new object[]
                {
                    GenSegmentedStyle(segmentedToken)
                };
            }, PrepareComponentToken);
        }
    }
}