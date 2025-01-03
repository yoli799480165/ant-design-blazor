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
    public partial class SplitterStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ResizeSpinnerSize { get; set; }
            public double SplitBarDraggableSize { get; set; }
            public double SplitBarSize { get; set; }
            public double SplitTriggerSize { get; set; }
        }

        public class SplitterToken : ComponentToken
        {
        }

        public static CSSObject GenRtlStyle(SplitterToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-horizontal"] = new CSSObject
                {
                    [$@"{componentCls}-bar"] = new CSSObject
                    {
                        [$@"{componentCls}-bar-collapse-previous"] = new CSSObject
                        {
                            InsetInlineEnd = 0,
                            InsetInlineStart = "unset",
                        },
                        [$@"{componentCls}-bar-collapse-next"] = new CSSObject
                        {
                            InsetInlineEnd = "unset",
                            InsetInlineStart = 0,
                        },
                    },
                },
                [$@"{componentCls}-vertical"] = new CSSObject
                {
                    [$@"{componentCls}-bar"] = new CSSObject
                    {
                        [$@"{componentCls}-bar-collapse-previous"] = new CSSObject
                        {
                            InsetInlineEnd = "50%",
                            InsetInlineStart = "unset",
                        },
                        [$@"{componentCls}-bar-collapse-next"] = new CSSObject
                        {
                            InsetInlineEnd = "50%",
                            InsetInlineStart = "unset",
                        },
                    },
                },
            };
        }

        public object centerStyle = new object
        {
            Position = "absolute",
            Top = "50%",
            Left = new object
            {
                _skip_check_ = true,
                Value = "50%",
            },
            Transform = "translate(-50%, -50%)",
        };
        public static CSSObject GenSplitterStyle(SplitterToken token)
        {
            var componentCls = token.ComponentCls;
            var colorFill = token.ColorFill;
            var splitBarDraggableSize = token.SplitBarDraggableSize;
            var splitBarSize = token.SplitBarSize;
            var splitTriggerSize = token.SplitTriggerSize;
            var controlItemBgHover = token.ControlItemBgHover;
            var controlItemBgActive = token.ControlItemBgActive;
            var controlItemBgActiveHover = token.ControlItemBgActiveHover;
            var splitBarCls = $@"{componentCls}-bar";
            var splitMaskCls = $@"{componentCls}-mask";
            var splitPanelCls = $@"{componentCls}-panel";
            var halfTriggerSize = token.Calc(splitTriggerSize).Div(2).Equal();
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "flex",
                    Width = "100%",
                    Height = "100%",
                    AlignItems = "stretch",
                    [$@"{splitBarCls}"] = new CSSObject
                    {
                        Flex = "none",
                        Position = "relative",
                        UserSelect = "none",
                        [$@"{splitBarCls}-dragger"] = new CSSObject
                        {
                            ["..."] = centerStyle,
                            ZIndex = 1,
                            ["&::before"] = new CSSObject
                            {
                                Content = "\"\"",
                                Background = controlItemBgHover,
                                ["..."] = centerStyle,
                            },
                            ["&::after"] = new CSSObject
                            {
                                Content = "\"\"",
                                Background = colorFill,
                                ["..."] = centerStyle,
                            },
                            [$@"{splitBarCls}-dragger-active)"] = new CSSObject
                            {
                                ["&::before"] = new CSSObject
                                {
                                    Background = controlItemBgActive,
                                },
                            },
                            ["&-active"] = new CSSObject
                            {
                                ZIndex = 2,
                                ["&::before"] = new CSSObject
                                {
                                    Background = controlItemBgActiveHover,
                                },
                            },
                            [$@"{splitBarCls}-dragger"] = new CSSObject
                            {
                                ZIndex = 0,
                                ["&, &:hover, &-active"] = new CSSObject
                                {
                                    Cursor = "default",
                                    ["&::before"] = new CSSObject
                                    {
                                        Background = controlItemBgHover,
                                    },
                                },
                                ["&::after"] = new CSSObject
                                {
                                    Display = "none",
                                },
                            },
                        },
                        [$@"{splitBarCls}-collapse-bar"] = new CSSObject
                        {
                            ["..."] = centerStyle,
                            ZIndex = token.ZIndexPopupBase,
                            Background = controlItemBgHover,
                            FontSize = token.FontSizeSM,
                            BorderRadius = token.BorderRadiusXS,
                            Color = token.ColorText,
                            Cursor = "pointer",
                            Opacity = 0,
                            Display = "flex",
                            AlignItems = "center",
                            JustifyContent = "center",
                            ["&:hover"] = new CSSObject
                            {
                                Background = controlItemBgActive,
                            },
                            ["&:active"] = new CSSObject
                            {
                                Background = controlItemBgActiveHover,
                            },
                        },
                        ["&:hover, &:active"] = new CSSObject
                        {
                            [$@"{splitBarCls}-collapse-bar"] = new CSSObject
                            {
                                Opacity = 1,
                            },
                        },
                    },
                    [splitMaskCls] = new CSSObject
                    {
                        Position = "fixed",
                        ZIndex = token.ZIndexPopupBase,
                        Inset = 0,
                        ["&-horizontal"] = new CSSObject
                        {
                            Cursor = "col-resize",
                        },
                        ["&-vertical"] = new CSSObject
                        {
                            Cursor = "row-resize",
                        },
                    },
                    ["&-horizontal"] = new CSSObject
                    {
                        FlexDirection = "row",
                        [$@"{splitBarCls}"] = new CSSObject
                        {
                            Width = 0,
                            [$@"{splitBarCls}-dragger"] = new CSSObject
                            {
                                Cursor = "col-resize",
                                Height = "100%",
                                Width = splitTriggerSize,
                                ["&::before"] = new CSSObject
                                {
                                    Height = "100%",
                                    Width = splitBarSize,
                                },
                                ["&::after"] = new CSSObject
                                {
                                    Height = splitBarDraggableSize,
                                    Width = splitBarSize,
                                },
                            },
                            [$@"{splitBarCls}-collapse-bar"] = new CSSObject
                            {
                                Width = token.FontSizeSM,
                                Height = token.ControlHeightSM,
                                ["&-start"] = new CSSObject
                                {
                                    Left = new CSSObject
                                    {
                                        _skip_check_ = true,
                                        Value = "auto",
                                    },
                                    Right = new CSSObject
                                    {
                                        _skip_check_ = true,
                                        Value = halfTriggerSize,
                                    },
                                    Transform = "translateY(-50%)",
                                },
                                ["&-end"] = new CSSObject
                                {
                                    Left = new CSSObject
                                    {
                                        _skip_check_ = true,
                                        Value = halfTriggerSize,
                                    },
                                    Right = new CSSObject
                                    {
                                        _skip_check_ = true,
                                        Value = "auto",
                                    },
                                    Transform = "translateY(-50%)",
                                },
                            },
                        },
                    },
                    ["&-vertical"] = new CSSObject
                    {
                        FlexDirection = "column",
                        [$@"{splitBarCls}"] = new CSSObject
                        {
                            Height = 0,
                            [$@"{splitBarCls}-dragger"] = new CSSObject
                            {
                                Cursor = "row-resize",
                                Width = "100%",
                                Height = splitTriggerSize,
                                ["&::before"] = new CSSObject
                                {
                                    Width = "100%",
                                    Height = splitBarSize,
                                },
                                ["&::after"] = new CSSObject
                                {
                                    Width = splitBarDraggableSize,
                                    Height = splitBarSize,
                                },
                            },
                            [$@"{splitBarCls}-collapse-bar"] = new CSSObject
                            {
                                Height = token.FontSizeSM,
                                Width = token.ControlHeightSM,
                                ["&-start"] = new CSSObject
                                {
                                    Top = "auto",
                                    Bottom = halfTriggerSize,
                                    Transform = "translateX(-50%)",
                                },
                                ["&-end"] = new CSSObject
                                {
                                    Top = halfTriggerSize,
                                    Bottom = "auto",
                                    Transform = "translateX(-50%)",
                                },
                            },
                        },
                    },
                    [splitPanelCls] = new CSSObject
                    {
                        Overflow = "auto",
                        Padding = "0 1px",
                        ScrollbarWidth = "thin",
                        BoxSizing = "border-box",
                        ["&-hidden"] = new CSSObject
                        {
                            Padding = 0,
                            Overflow = "hidden",
                        },
                        [$@"{componentCls}:only-child)"] = new CSSObject
                        {
                            Overflow = "hidden",
                        },
                    },
                    ["..."] = GenRtlStyle(token),
                },
            };
        }

        public static SplitterToken PrepareComponentToken(SplitterToken token)
        {
            var splitBarSize = token.SplitBarSize ?? 2;
            var splitTriggerSize = token.SplitTriggerSize ?? 6;
            var resizeSpinnerSize = token.ResizeSpinnerSize ?? 20;
            var splitBarDraggableSize = resizeSpinnerSize;
            return new SplitterToken
            {
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Splitter", (SplitterToken token) =>
            {
                return new object[]
                {
                    GenSplitterStyle(token)
                };
            }, PrepareComponentToken);
        }
    }
}