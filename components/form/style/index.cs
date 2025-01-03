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
    public partial class FormStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string LabelRequiredMarkColor { get; set; }
            public string LabelColor { get; set; }
            public double LabelFontSize { get; set; }
            public string LabelHeight { get; set; }
            public double LabelColonMarginInlineStart { get; set; }
            public double LabelColonMarginInlineEnd { get; set; }
            public double ItemMarginBottom { get; set; }
            public double InlineItemMarginBottom { get; set; }
            public string VerticalLabelPadding { get; set; }
            public string VerticalLabelMargin { get; set; }
        }

        public class FormToken : ComponentToken
        {
            public string FormItemCls { get; set; }
            public string RootPrefixCls { get; set; }
        }

        public static CSSObject ResetForm(AliasToken token)
        {
            return new CSSObject
            {
                Legend = new CSSObject
                {
                    Display = "block",
                    Width = "100%",
                    MarginBottom = token.MarginLG,
                    Padding = 0,
                    Color = token.ColorTextDescription,
                    FontSize = token.FontSizeLG,
                    LineHeight = "inherit",
                    Border = 0,
                    BorderBottom = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                },
                ["input[type=\"search\"]"] = new CSSObject
                {
                    BoxSizing = "border-box",
                },
                ["input[type=\"radio\"], input[type=\"checkbox\"]"] = new CSSObject
                {
                    LineHeight = "normal",
                },
                ["input[type=\"file\"]"] = new CSSObject
                {
                    Display = "block",
                },
                ["input[type=\"range\"]"] = new CSSObject
                {
                    Display = "block",
                    Width = "100%",
                },
                ["select[multiple], select[size]"] = new CSSObject
                {
                    Height = "auto",
                },
                ["input[type='file']:focus,\n  input[type='radio']:focus,\n  input[type='checkbox']:focus"] = new CSSObject
                {
                    Outline = 0,
                    BoxShadow = $@"{Unit(token.ControlOutlineWidth)} {token.ControlOutline}",
                },
                Output = new CSSObject
                {
                    Display = "block",
                    PaddingTop = 15,
                    Color = token.ColorText,
                    FontSize = token.FontSize,
                    LineHeight = token.LineHeight,
                },
            };
        }

        public static CSSObject GenFormSize(FormToken token, number height)
        {
            var formItemCls = token.FormItemCls;
            return new CSSObject
            {
                [formItemCls] = new CSSObject
                {
                    [$@"{formItemCls}-label > label"] = new CSSObject
                    {
                    },
                    [$@"{formItemCls}-control-input"] = new CSSObject
                    {
                        MinHeight = height,
                    },
                },
            };
        }

        public static CSSObject GenFormStyle(FormToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [token.ComponentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    ["..."] = ResetForm(token),
                    [$@"{componentCls}-text"] = new CSSObject
                    {
                        Display = "inline-block",
                        PaddingInlineEnd = token.PaddingSM,
                    },
                    ["&-small"] = new CSSObject
                    {
                        ["..."] = GenFormSize(token, token.ControlHeightSM),
                    },
                    ["&-large"] = new CSSObject
                    {
                        ["..."] = GenFormSize(token, token.ControlHeightLG),
                    },
                },
            };
        }

        public static CSSObject GenFormItemStyle(FormToken token)
        {
            var formItemCls = token.FormItemCls;
            var iconCls = token.IconCls;
            var componentCls = token.ComponentCls;
            var rootPrefixCls = token.RootPrefixCls;
            var antCls = token.AntCls;
            var labelRequiredMarkColor = token.LabelRequiredMarkColor;
            var labelColor = token.LabelColor;
            var labelFontSize = token.LabelFontSize;
            var labelHeight = token.LabelHeight;
            var labelColonMarginInlineStart = token.LabelColonMarginInlineStart;
            var labelColonMarginInlineEnd = token.LabelColonMarginInlineEnd;
            var itemMarginBottom = token.ItemMarginBottom;
            return new CSSObject
            {
                [formItemCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    MarginBottom = itemMarginBottom,
                    VerticalAlign = "top",
                    ["&-with-help"] = new CSSObject
                    {
                        Transition = "none",
                    },
                    [$@"{antCls}-row"] = new CSSObject
                    {
                        Display = "none",
                    },
                    ["&-has-warning"] = new CSSObject
                    {
                        [$@"{formItemCls}-split"] = new CSSObject
                        {
                            Color = token.ColorError,
                        },
                    },
                    ["&-has-error"] = new CSSObject
                    {
                        [$@"{formItemCls}-split"] = new CSSObject
                        {
                            Color = token.ColorWarning,
                        },
                    },
                    [$@"{formItemCls}-label"] = new CSSObject
                    {
                        FlexGrow = 0,
                        Overflow = "hidden",
                        WhiteSpace = "nowrap",
                        TextAlign = "end",
                        VerticalAlign = "middle",
                        ["&-left"] = new CSSObject
                        {
                            TextAlign = "start",
                        },
                        ["&-wrap"] = new CSSObject
                        {
                            Overflow = "unset",
                            LineHeight = token.LineHeight,
                            WhiteSpace = "unset",
                        },
                        ["> label"] = new CSSObject
                        {
                            Position = "relative",
                            Display = "inline-flex",
                            AlignItems = "center",
                            MaxWidth = "100%",
                            Height = labelHeight,
                            Color = labelColor,
                            FontSize = labelFontSize,
                            [$@"{iconCls}"] = new CSSObject
                            {
                                FontSize = token.FontSize,
                                VerticalAlign = "top",
                            },
                            [$@"{formItemCls}-required:not({formItemCls}-required-mark-optional)::before"] = new CSSObject
                            {
                                Display = "inline-block",
                                MarginInlineEnd = token.MarginXXS,
                                Color = labelRequiredMarkColor,
                                FontSize = token.FontSize,
                                FontFamily = "SimSun, sans-serif",
                                LineHeight = 1,
                                Content = "\"*\"",
                                [$@"{componentCls}-hide-required-mark &"] = new CSSObject
                                {
                                    Display = "none",
                                },
                            },
                            [$@"{formItemCls}-optional"] = new CSSObject
                            {
                                Display = "inline-block",
                                MarginInlineStart = token.MarginXXS,
                                Color = token.ColorTextDescription,
                                [$@"{componentCls}-hide-required-mark &"] = new CSSObject
                                {
                                    Display = "none",
                                },
                            },
                            [$@"{formItemCls}-tooltip"] = new CSSObject
                            {
                                Color = token.ColorTextDescription,
                                Cursor = "help",
                                WritingMode = "horizontal-tb",
                                MarginInlineStart = token.MarginXXS,
                            },
                            ["&::after"] = new CSSObject
                            {
                                Content = "\":\"",
                                Position = "relative",
                                MarginBlock = 0,
                                MarginInlineStart = labelColonMarginInlineStart,
                                MarginInlineEnd = labelColonMarginInlineEnd,
                            },
                            [$@"{formItemCls}-no-colon::after"] = new CSSObject
                            {
                                Content = "\"\\a0\"",
                            },
                        },
                    },
                    [$@"{formItemCls}-control"] = new CSSObject
                    {
                        ["--ant-display" as any] = "flex",
                        FlexDirection = "column",
                        FlexGrow = 1,
                        [$@"{rootPrefixCls}-col-'"]):not([class*="' {rootPrefixCls}-col-'"])"] = new CSSObject
                        {
                            Width = "100%",
                        },
                        ["&-input"] = new CSSObject
                        {
                            Position = "relative",
                            Display = "flex",
                            AlignItems = "center",
                            MinHeight = token.ControlHeight,
                            ["&-content"] = new CSSObject
                            {
                                Flex = "auto",
                                MaxWidth = "100%",
                            },
                        },
                    },
                    [formItemCls] = new CSSObject
                    {
                        ["&-additional"] = new CSSObject
                        {
                            Display = "flex",
                            FlexDirection = "column",
                        },
                        ["&-explain, &-extra"] = new CSSObject
                        {
                            Clear = "both",
                            Color = token.ColorTextDescription,
                            FontSize = token.FontSize,
                            LineHeight = token.LineHeight,
                        },
                        ["&-explain-connected"] = new CSSObject
                        {
                            Width = "100%",
                        },
                        ["&-extra"] = new CSSObject
                        {
                            MinHeight = token.ControlHeightSM,
                            Transition = $@"{token.MotionDurationMid} {token.MotionEaseOut}",
                        },
                        ["&-explain"] = new CSSObject
                        {
                            ["&-error"] = new CSSObject
                            {
                                Color = token.ColorError,
                            },
                            ["&-warning"] = new CSSObject
                            {
                                Color = token.ColorWarning,
                            },
                        },
                    },
                    [$@"{formItemCls}-explain"] = new CSSObject
                    {
                        Height = "auto",
                        Opacity = 1,
                    },
                    [$@"{formItemCls}-feedback-icon"] = new CSSObject
                    {
                        FontSize = token.FontSize,
                        TextAlign = "center",
                        Visibility = "visible",
                        AnimationName = zoomIn,
                        AnimationDuration = token.MotionDurationMid,
                        AnimationTimingFunction = token.MotionEaseOutBack,
                        PointerEvents = "none",
                        ["&-success"] = new CSSObject
                        {
                            Color = token.ColorSuccess,
                        },
                        ["&-error"] = new CSSObject
                        {
                            Color = token.ColorError,
                        },
                        ["&-warning"] = new CSSObject
                        {
                            Color = token.ColorWarning,
                        },
                        ["&-validating"] = new CSSObject
                        {
                            Color = token.ColorPrimary,
                        },
                    },
                },
            };
        }

        public static CSSObject GenHorizontalStyle(FormToken token, string className)
        {
            var formItemCls = token.FormItemCls;
            return new CSSObject
            {
                [$@"{className}-horizontal"] = new CSSObject
                {
                    [$@"{formItemCls}-label"] = new CSSObject
                    {
                        FlexGrow = 0,
                    },
                    [$@"{formItemCls}-control"] = new CSSObject
                    {
                        Flex = "1 1 0",
                        MinWidth = 0,
                    },
                    [$@"{formItemCls}-label[class$='-24'], {formItemCls}-label[class*='-24 ']"] = new CSSObject
                    {
                        [$@"{formItemCls}-control"] = new CSSObject
                        {
                            MinWidth = "unset",
                        },
                    },
                },
            };
        }

        public static CSSObject GenInlineStyle(FormToken token)
        {
            var componentCls = token.ComponentCls;
            var formItemCls = token.FormItemCls;
            var inlineItemMarginBottom = token.InlineItemMarginBottom;
            return new CSSObject
            {
                [$@"{componentCls}-inline"] = new CSSObject
                {
                    Display = "flex",
                    FlexWrap = "wrap",
                    [formItemCls] = new CSSObject
                    {
                        Flex = "none",
                        MarginInlineEnd = token.Margin,
                        MarginBottom = inlineItemMarginBottom,
                        ["&-row"] = new CSSObject
                        {
                            FlexWrap = "nowrap",
                        },
                        [$@"{formItemCls}-label,
        > {formItemCls}-control"] = new CSSObject
                        {
                            Display = "inline-block",
                            VerticalAlign = "top",
                        },
                        [$@"{formItemCls}-label"] = new CSSObject
                        {
                            Flex = "none",
                        },
                        [$@"{componentCls}-text"] = new CSSObject
                        {
                            Display = "inline-block",
                        },
                        [$@"{formItemCls}-has-feedback"] = new CSSObject
                        {
                            Display = "inline-block",
                        },
                    },
                },
            };
        }

        public static CSSObject MakeVerticalLayoutLabel(FormToken token)
        {
            return new CSSObject
            {
                Padding = token.VerticalLabelPadding,
                Margin = token.VerticalLabelMargin,
                WhiteSpace = "initial",
                TextAlign = "start",
                ["> label"] = new CSSObject
                {
                    Margin = 0,
                    ["&::after"] = new CSSObject
                    {
                        Visibility = "hidden",
                    },
                },
            };
        }

        public static CSSObject MakeVerticalLayout(FormToken token)
        {
            var componentCls = token.ComponentCls;
            var formItemCls = token.FormItemCls;
            var rootPrefixCls = token.RootPrefixCls;
            return new CSSObject
            {
                [$@"{formItemCls} {formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                [$@"{componentCls}:not({componentCls}-inline)"] = new CSSObject
                {
                    [formItemCls] = new CSSObject
                    {
                        FlexWrap = "wrap",
                        [$@"{formItemCls}-label, {formItemCls}-control"] = new CSSObject
                        {
                            [$@"{rootPrefixCls}-col-xs"])"] = new CSSObject
                            {
                                Flex = "0 0 100%",
                                MaxWidth = "100%",
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenVerticalStyle(FormToken token)
        {
            var componentCls = token.ComponentCls;
            var formItemCls = token.FormItemCls;
            var antCls = token.AntCls;
            return new CSSObject
            {
                [$@"{componentCls}-vertical"] = new CSSObject
                {
                    [$@"{formItemCls}:not({formItemCls}-horizontal)"] = new CSSObject
                    {
                        [$@"{formItemCls}-row"] = new CSSObject
                        {
                            FlexDirection = "column",
                        },
                        [$@"{formItemCls}-label > label"] = new CSSObject
                        {
                            Height = "auto",
                        },
                        [$@"{formItemCls}-control"] = new CSSObject
                        {
                            Width = "100%",
                        },
                        [$@"{formItemCls}-label,
        {antCls}-col-24{formItemCls}-label,
        {antCls}-col-xl-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                    },
                },
                [$@"{Unit(token.ScreenXSMax)})"] = new object[]
                {
                    MakeVerticalLayout(token),
                    new object
                    {
                        [componentCls] = new object
                        {
                            [$@"{formItemCls}:not({formItemCls}-horizontal)"] = new object
                            {
                                [$@"{antCls}-col-xs-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                            },
                        },
                    }
                },
                [$@"{Unit(token.ScreenSMMax)})"] = new CSSObject
                {
                    [componentCls] = new CSSObject
                    {
                        [$@"{formItemCls}:not({formItemCls}-horizontal)"] = new CSSObject
                        {
                            [$@"{antCls}-col-sm-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                        },
                    },
                },
                [$@"{Unit(token.ScreenMDMax)})"] = new CSSObject
                {
                    [componentCls] = new CSSObject
                    {
                        [$@"{formItemCls}:not({formItemCls}-horizontal)"] = new CSSObject
                        {
                            [$@"{antCls}-col-md-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                        },
                    },
                },
                [$@"{Unit(token.ScreenLGMax)})"] = new CSSObject
                {
                    [componentCls] = new CSSObject
                    {
                        [$@"{formItemCls}:not({formItemCls}-horizontal)"] = new CSSObject
                        {
                            [$@"{antCls}-col-lg-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                        },
                    },
                },
            };
        }

        public static CSSObject GenItemVerticalStyle(FormToken token)
        {
            var formItemCls = token.FormItemCls;
            var antCls = token.AntCls;
            return new CSSObject
            {
                [$@"{formItemCls}-vertical"] = new CSSObject
                {
                    [$@"{formItemCls}-row"] = new CSSObject
                    {
                        FlexDirection = "column",
                    },
                    [$@"{formItemCls}-label > label"] = new CSSObject
                    {
                        Height = "auto",
                    },
                    [$@"{formItemCls}-control"] = new CSSObject
                    {
                        Width = "100%",
                    },
                },
                [$@"{formItemCls}-vertical {formItemCls}-label,
      {antCls}-col-24{formItemCls}-label,
      {antCls}-col-xl-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                [$@"{Unit(token.ScreenXSMax)})"] = new object[]
                {
                    MakeVerticalLayout(token),
                    new object
                    {
                        [formItemCls] = new object
                        {
                            [$@"{antCls}-col-xs-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                        },
                    }
                },
                [$@"{Unit(token.ScreenSMMax)})"] = new CSSObject
                {
                    [formItemCls] = new CSSObject
                    {
                        [$@"{antCls}-col-sm-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                    },
                },
                [$@"{Unit(token.ScreenMDMax)})"] = new CSSObject
                {
                    [formItemCls] = new CSSObject
                    {
                        [$@"{antCls}-col-md-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                    },
                },
                [$@"{Unit(token.ScreenLGMax)})"] = new CSSObject
                {
                    [formItemCls] = new CSSObject
                    {
                        [$@"{antCls}-col-lg-24{formItemCls}-label"] = MakeVerticalLayoutLabel(token),
                    },
                },
            };
        }

        public static FormToken PrepareComponentToken(FormToken token)
        {
            return new FormToken
            {
                LabelRequiredMarkColor = token.ColorError,
                LabelColor = token.ColorTextHeading,
                LabelFontSize = token.FontSize,
                LabelHeight = token.ControlHeight,
                LabelColonMarginInlineStart = token.MarginXXS / 2,
                LabelColonMarginInlineEnd = token.MarginXS,
                ItemMarginBottom = token.MarginLG,
                VerticalLabelPadding = $@"{token.PaddingXS}px",
                VerticalLabelMargin = 0,
                InlineItemMarginBottom = 0,
            };
        }

        public static object PrepareToken(FormToken token, object rootPrefixCls)
        {
            var formToken = MergeToken(token, new object { FormItemCls = $@"{token.ComponentCls}-item", });
            return formToken;
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Form", (FormToken token, object { rootPrefixCls }) =>
            {
                var formToken = PrepareToken(token, rootPrefixCls);
                return new object[]
                {
                    GenFormStyle(formToken),
                    GenFormItemStyle(formToken),
                    GenFormValidateMotionStyle(formToken),
                    GenHorizontalStyle(formToken, formToken.ComponentCls),
                    GenHorizontalStyle(formToken, formToken.FormItemCls),
                    GenInlineStyle(formToken),
                    GenVerticalStyle(formToken),
                    GenItemVerticalStyle(formToken),
                    GenCollapseMotion(formToken),
                    zoomIn
                };
            }, PrepareComponentToken, new object { Order = -1000, });
        }
    }
}