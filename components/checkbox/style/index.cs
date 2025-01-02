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
    public partial class CheckboxStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
        }

        public class CheckboxToken : ComponentToken
        {
            public string CheckboxCls { get; set; }
            public double CheckboxSize { get; set; }
        }

        public static CSSObject GenCheckboxStyle(CheckboxToken token)
        {
            var checkboxCls = token.CheckboxCls;
            var wrapperCls = $@"{checkboxCls}-wrapper";
            return new object[]
            {
                new object
                {
                    [$@"{checkboxCls}-group"] = new object
                    {
                        ["..."] = ResetComponent(token),
                        Display = "inline-flex",
                        FlexWrap = "wrap",
                        ColumnGap = token.MarginXS,
                        [$@"{token.AntCls}-row"] = new object
                        {
                            Flex = 1,
                        },
                    },
                    [wrapperCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        Display = "inline-flex",
                        AlignItems = "baseline",
                        Cursor = "pointer",
                        ["&:after"] = new object
                        {
                            Display = "inline-block",
                            Width = 0,
                            Overflow = "hidden",
                            Content = "'\\a0'",
                        },
                        [$@"{wrapperCls}"] = new object
                        {
                            MarginInlineStart = 0,
                        },
                        [$@"{wrapperCls}-in-form-item"] = new object
                        {
                            ["input[type=\"checkbox\"]"] = new object
                            {
                                Width = 14,
                                Height = 14,
                            },
                        },
                    },
                    [checkboxCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        Position = "relative",
                        WhiteSpace = "nowrap",
                        LineHeight = 1,
                        Cursor = "pointer",
                        BorderRadius = token.BorderRadiusSM,
                        AlignSelf = "center",
                        [$@"{checkboxCls}-input"] = new object
                        {
                            Position = "absolute",
                            Inset = 0,
                            ZIndex = 1,
                            Cursor = "pointer",
                            Opacity = 0,
                            Margin = 0,
                            [$@"{checkboxCls}-inner"] = new object
                            {
                                ["..."] = GenFocusOutline(token),
                            },
                        },
                        [$@"{checkboxCls}-inner"] = new object
                        {
                            BoxSizing = "border-box",
                            Display = "block",
                            Width = token.CheckboxSize,
                            Height = token.CheckboxSize,
                            Direction = "ltr",
                            BackgroundColor = token.ColorBgContainer,
                            Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                            BorderRadius = token.BorderRadiusSM,
                            BorderCollapse = "separate",
                            Transition = $@"{token.MotionDurationSlow}",
                            ["&:after"] = new object
                            {
                                BoxSizing = "border-box",
                                Position = "absolute",
                                Top = "50%",
                                InsetInlineStart = "25%",
                                Display = "table",
                                Width = token.calc(token.checkboxSize).div(14).mul(5).Equal(),
                                Height = token.calc(token.checkboxSize).div(14).mul(8).Equal(),
                                Border = $@"{Unit(token.LineWidthBold)} solid {token.ColorWhite}",
                                BorderTop = 0,
                                BorderInlineStart = 0,
                                Transform = "rotate(45deg) scale(0) translate(-50%,-50%)",
                                Opacity = 0,
                                Content = "\"\"",
                                Transition = $@"{token.MotionDurationFast} {token.MotionEaseInBack}, opacity {token.MotionDurationFast}",
                            },
                        },
                        ["& + span"] = new object
                        {
                            PaddingInlineStart = token.PaddingXS,
                            PaddingInlineEnd = token.PaddingXS,
                        },
                    },
                },
                new object
                {
                    [$@"{wrapperCls}:not({wrapperCls}-disabled),
        {checkboxCls}:not({checkboxCls}-disabled)
      "] = new object
                    {
                        [$@"{checkboxCls}-inner"] = new object
                        {
                            BorderColor = token.ColorPrimary,
                        },
                    },
                    [$@"{wrapperCls}:not({wrapperCls}-disabled)"] = new object
                    {
                        [$@"{checkboxCls}-checked:not({checkboxCls}-disabled) {checkboxCls}-inner"] = new object
                        {
                            BackgroundColor = token.ColorPrimaryHover,
                            BorderColor = "transparent",
                        },
                        [$@"{checkboxCls}-checked:not({checkboxCls}-disabled):after"] = new object
                        {
                            BorderColor = token.ColorPrimaryHover,
                        },
                    },
                },
                new object
                {
                    [$@"{checkboxCls}-checked"] = new object
                    {
                        [$@"{checkboxCls}-inner"] = new object
                        {
                            BackgroundColor = token.ColorPrimary,
                            BorderColor = token.ColorPrimary,
                            ["&:after"] = new object
                            {
                                Opacity = 1,
                                Transform = "rotate(45deg) scale(1) translate(-50%,-50%)",
                                Transition = $@"{token.MotionDurationMid} {token.MotionEaseOutBack} {token.MotionDurationFast}",
                            },
                        },
                    },
                    [$@"{wrapperCls}-checked:not({wrapperCls}-disabled),
        {checkboxCls}-checked:not({checkboxCls}-disabled)
      "] = new object
                    {
                        [$@"{checkboxCls}-inner"] = new object
                        {
                            BackgroundColor = token.ColorPrimaryHover,
                            BorderColor = "transparent",
                        },
                    },
                },
                new object
                {
                    [checkboxCls] = new object
                    {
                        ["&-indeterminate"] = new object
                        {
                            [$@"{checkboxCls}-inner"] = new object
                            {
                                BackgroundColor = $@"{token.ColorBgContainer} !important",
                                BorderColor = $@"{token.ColorBorder} !important",
                                ["&:after"] = new object
                                {
                                    Top = "50%",
                                    InsetInlineStart = "50%",
                                    Width = token.calc(token.fontSizeLG).div(2).Equal(),
                                    Height = token.calc(token.fontSizeLG).div(2).Equal(),
                                    BackgroundColor = token.ColorPrimary,
                                    Border = 0,
                                    Transform = "translate(-50%, -50%) scale(1)",
                                    Opacity = 1,
                                    Content = "\"\"",
                                },
                            },
                            [$@"{checkboxCls}-inner"] = new object
                            {
                                BackgroundColor = $@"{token.ColorBgContainer} !important",
                                BorderColor = $@"{token.ColorPrimary} !important",
                            },
                        },
                    },
                },
                new object
                {
                    [$@"{wrapperCls}-disabled"] = new object
                    {
                        Cursor = "not-allowed",
                    },
                    [$@"{checkboxCls}-disabled"] = new object
                    {
                        [$@"{checkboxCls}-input"] = new object
                        {
                            Cursor = "not-allowed",
                            PointerEvents = "none",
                        },
                        [$@"{checkboxCls}-inner"] = new object
                        {
                            Background = token.ColorBgContainerDisabled,
                            BorderColor = token.ColorBorder,
                            ["&:after"] = new object
                            {
                                BorderColor = token.ColorTextDisabled,
                            },
                        },
                        ["&:after"] = new object
                        {
                            Display = "none",
                        },
                        ["& + span"] = new object
                        {
                            Color = token.ColorTextDisabled,
                        },
                        [$@"{checkboxCls}-indeterminate {checkboxCls}-inner::after"] = new object
                        {
                            Background = token.ColorTextDisabled,
                        },
                    },
                }
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Checkbox", (CheckboxToken token, object { prefixCls }) =>
            {
                return new object[]
                {
                    GetStyle(prefixCls, token)
                };
            });
        }
    }
}