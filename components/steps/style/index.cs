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
    public partial class StepsStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double DescriptionMaxWidth { get; set; }
            public double CustomIconSize { get; set; }
            public double CustomIconTop { get; set; }
            public double CustomIconFontSize { get; set; }
            public double IconSize { get; set; }
            public double IconTop { get; set; }
            public double IconFontSize { get; set; }
            public double DotSize { get; set; }
            public double DotCurrentSize { get; set; }
            public string NavArrowColor { get; set; }
            public string NavContentMaxWidth { get; set; }
            public double IconSizeSM { get; set; }
            public string TitleLineHeight { get; set; }
            public string WaitIconColor { get; set; }
            public string WaitIconBgColor { get; set; }
            public string WaitIconBorderColor { get; set; }
            public string FinishIconBgColor { get; set; }
            public string FinishIconBorderColor { get; set; }
        }

        public class StepsToken : ComponentToken
        {
            public string ProcessTailColor { get; set; }
            public string ProcessIconColor { get; set; }
            public string ProcessTitleColor { get; set; }
            public string ProcessDescriptionColor { get; set; }
            public string ProcessIconBgColor { get; set; }
            public string ProcessIconBorderColor { get; set; }
            public string ProcessDotColor { get; set; }
            public string WaitTitleColor { get; set; }
            public string WaitDescriptionColor { get; set; }
            public string WaitTailColor { get; set; }
            public string WaitDotColor { get; set; }
            public string FinishIconColor { get; set; }
            public string FinishTitleColor { get; set; }
            public string FinishDescriptionColor { get; set; }
            public string FinishTailColor { get; set; }
            public string FinishDotColor { get; set; }
            public string ErrorIconColor { get; set; }
            public string ErrorTitleColor { get; set; }
            public string ErrorDescriptionColor { get; set; }
            public string ErrorTailColor { get; set; }
            public string ErrorIconBgColor { get; set; }
            public string ErrorIconBorderColor { get; set; }
            public string ErrorDotColor { get; set; }
            public string StepsNavActiveColor { get; set; }
            public double StepsProgressSize { get; set; }
            public double InlineDotSize { get; set; }
            public string InlineTitleColor { get; set; }
            public string InlineTailColor { get; set; }
        }

        public object STEP_ITEM_STATUS_WAIT = "wait";
        public object STEP_ITEM_STATUS_PROCESS = "process";
        public object STEP_ITEM_STATUS_FINISH = "finish";
        public object STEP_ITEM_STATUS_ERROR = "error";
        public static CSSObject GenStepsItemStatusStyle(StepItemStatus status, StepsToken token)
        {
            var prefix = $@"{token.ComponentCls}-item";
            var iconColorKey = $@"{status}IconColor";
            var titleColorKey = $@"{status}TitleColor";
            var descriptionColorKey = $@"{status}DescriptionColor";
            var tailColorKey = $@"{status}TailColor";
            var iconBgColorKey = $@"{status}IconBgColor";
            var iconBorderColorKey = $@"{status}IconBorderColor";
            var dotColorKey = $@"{status}DotColor";
            return new CSSObject
            {
                [$@"{prefix}-{status} {prefix}-icon"] = new CSSObject
                {
                    BackgroundColor = token[iconBgColorKey],
                    BorderColor = token[iconBorderColorKey],
                    [$@"{token.ComponentCls}-icon"] = new CSSObject
                    {
                        Color = token[iconColorKey],
                        [$@"{token.ComponentCls}-icon-dot"] = new CSSObject
                        {
                            Background = token[dotColorKey],
                        },
                    },
                },
                [$@"{prefix}-{status}{prefix}-custom {prefix}-icon"] = new CSSObject
                {
                    [$@"{token.ComponentCls}-icon"] = new CSSObject
                    {
                        Color = token[dotColorKey],
                    },
                },
                [$@"{prefix}-{status} > {prefix}-container > {prefix}-content > {prefix}-title"] = new CSSObject
                {
                    Color = token[titleColorKey],
                    ["&::after"] = new CSSObject
                    {
                        BackgroundColor = token[tailColorKey],
                    },
                },
                [$@"{prefix}-{status} > {prefix}-container > {prefix}-content > {prefix}-description"] = new CSSObject
                {
                    Color = token[descriptionColorKey],
                },
                [$@"{prefix}-{status} > {prefix}-container > {prefix}-tail::after"] = new CSSObject
                {
                    BackgroundColor = token[tailColorKey],
                },
            };
        }

        public static CSSObject GenStepsItemStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var stepsItemCls = $@"{componentCls}-item";
            var stepItemIconCls = $@"{stepsItemCls}-icon";
            return new CSSObject
            {
                [stepsItemCls] = new CSSObject
                {
                    Position = "relative",
                    Display = "inline-block",
                    Flex = 1,
                    Overflow = "hidden",
                    VerticalAlign = "top",
                    ["&:last-child"] = new CSSObject
                    {
                        Flex = "none",
                        [$@"{stepsItemCls}-container > {stepsItemCls}-tail, > {stepsItemCls}-container >  {stepsItemCls}-content > {stepsItemCls}-title::after"] = new CSSObject
                        {
                            Display = "none",
                        },
                    },
                },
                [$@"{stepsItemCls}-container"] = new CSSObject
                {
                    Outline = "none",
                    ["&:focus-visible"] = new CSSObject
                    {
                        [stepItemIconCls] = new CSSObject
                        {
                            ["..."] = GenFocusOutline(token),
                        },
                    },
                },
                [$@"{stepItemIconCls}, {stepsItemCls}-content"] = new CSSObject
                {
                    Display = "inline-block",
                    VerticalAlign = "top",
                },
                [stepItemIconCls] = new CSSObject
                {
                    Width = token.IconSize,
                    Height = token.IconSize,
                    MarginTop = 0,
                    MarginBottom = 0,
                    MarginInlineStart = 0,
                    MarginInlineEnd = token.MarginXS,
                    FontSize = token.IconFontSize,
                    FontFamily = token.FontFamily,
                    LineHeight = Unit(token.IconSize),
                    TextAlign = "center",
                    BorderRadius = token.IconSize,
                    Border = $@"{Unit(token.LineWidth)} {token.LineType} transparent",
                    Transition = $@"{motionDurationSlow}, border-color {motionDurationSlow}",
                    [$@"{componentCls}-icon"] = new CSSObject
                    {
                        Position = "relative",
                        Top = token.IconTop,
                        Color = token.ColorPrimary,
                        LineHeight = 1,
                    },
                },
                [$@"{stepsItemCls}-tail"] = new CSSObject
                {
                    Position = "absolute",
                    Top = token.calc(token.iconSize).div(2).Equal(),
                    InsetInlineStart = 0,
                    Width = "100%",
                    ["&::after"] = new CSSObject
                    {
                        Display = "inline-block",
                        Width = "100%",
                        Height = token.LineWidth,
                        Background = token.ColorSplit,
                        BorderRadius = token.LineWidth,
                        Transition = $@"{motionDurationSlow}",
                        Content = "\"\"",
                    },
                },
                [$@"{stepsItemCls}-title"] = new CSSObject
                {
                    Position = "relative",
                    Display = "inline-block",
                    PaddingInlineEnd = token.Padding,
                    Color = token.ColorText,
                    FontSize = token.FontSizeLG,
                    LineHeight = Unit(token.TitleLineHeight),
                    ["&::after"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = token.calc(token.titleLineHeight).div(2).Equal(),
                        InsetInlineStart = "100%",
                        Display = "block",
                        Width = 9999,
                        Height = token.LineWidth,
                        Background = token.ProcessTailColor,
                        Content = "\"\"",
                    },
                },
                [$@"{stepsItemCls}-subtitle"] = new CSSObject
                {
                    Display = "inline",
                    MarginInlineStart = token.MarginXS,
                    Color = token.ColorTextDescription,
                    FontWeight = "normal",
                    FontSize = token.FontSize,
                },
                [$@"{stepsItemCls}-description"] = new CSSObject
                {
                    Color = token.ColorTextDescription,
                    FontSize = token.FontSize,
                },
                ["..."] = GenStepsItemStatusStyle(STEP_ITEM_STATUS_WAIT, token),
                ["..."] = GenStepsItemStatusStyle(STEP_ITEM_STATUS_PROCESS, token),
                [$@"{stepsItemCls}-process > {stepsItemCls}-container > {stepsItemCls}-title"] = new CSSObject
                {
                    FontWeight = token.FontWeightStrong,
                },
                ["..."] = GenStepsItemStatusStyle(STEP_ITEM_STATUS_FINISH, token),
                ["..."] = GenStepsItemStatusStyle(STEP_ITEM_STATUS_ERROR, token),
                [$@"{stepsItemCls}{componentCls}-next-error > {componentCls}-item-title::after"] = new CSSObject
                {
                    Background = token.ColorError,
                },
                [$@"{stepsItemCls}-disabled"] = new CSSObject
                {
                    Cursor = "not-allowed",
                },
            };
        }

        public static CSSObject GenStepsClickableStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            return new CSSObject
            {
                [$@"{componentCls}-item"] = new CSSObject
                {
                    [$@"{componentCls}-item-active)"] = new CSSObject
                    {
                        [$@"{componentCls}-item-container[role='button']"] = new CSSObject
                        {
                            Cursor = "pointer",
                            [$@"{componentCls}-item"] = new CSSObject
                            {
                                [$@"{componentCls}-icon"] = new CSSObject
                                {
                                    Transition = $@"{motionDurationSlow}",
                                },
                            },
                            ["&:hover"] = new CSSObject
                            {
                                [$@"{componentCls}-item"] = new CSSObject
                                {
                                    ["&-title, &-subtitle, &-description"] = new CSSObject
                                    {
                                        Color = token.ColorPrimary,
                                    },
                                },
                            },
                        },
                        [$@"{componentCls}-item-process)"] = new CSSObject
                        {
                            [$@"{componentCls}-item-container[role='button']:hover"] = new CSSObject
                            {
                                [$@"{componentCls}-item"] = new CSSObject
                                {
                                    ["&-icon"] = new CSSObject
                                    {
                                        BorderColor = token.ColorPrimary,
                                        [$@"{componentCls}-icon"] = new CSSObject
                                        {
                                            Color = token.ColorPrimary,
                                        },
                                    },
                                },
                            },
                        },
                    },
                },
                [$@"{componentCls}-horizontal:not({componentCls}-label-vertical)"] = new CSSObject
                {
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        PaddingInlineStart = token.Padding,
                        WhiteSpace = "nowrap",
                        ["&:first-child"] = new CSSObject
                        {
                            PaddingInlineStart = 0,
                        },
                        [$@"{componentCls}-item-title"] = new CSSObject
                        {
                            PaddingInlineEnd = 0,
                        },
                        ["&-tail"] = new CSSObject
                        {
                            Display = "none",
                        },
                        ["&-description"] = new CSSObject
                        {
                            MaxWidth = token.DescriptionMaxWidth,
                            WhiteSpace = "normal",
                        },
                    },
                },
            };
        }

        public static CSSObject GenStepsStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "flex",
                    Width = "100%",
                    FontSize = 0,
                    TextAlign = "initial",
                    ["..."] = GenStepsItemStyle(token),
                    ["..."] = GenStepsClickableStyle(token),
                    ["..."] = GenStepsCustomIconStyle(token),
                    ["..."] = GenStepsSmallStyle(token),
                    ["..."] = GenStepsVerticalStyle(token),
                    ["..."] = GenStepsHorizontalStyle(token),
                    ["..."] = GenStepsLabelPlacementStyle(token),
                    ["..."] = GenStepsProgressDotStyle(token),
                    ["..."] = GenStepsNavStyle(token),
                    ["..."] = GenStepsRTLStyle(token),
                    ["..."] = GenStepsProgressStyle(token),
                    ["..."] = GenStepsInlineStyle(token),
                },
            };
        }

        public static StepsToken PrepareComponentToken(StepsToken token)
        {
            return new StepsToken
            {
                TitleLineHeight = token.ControlHeight,
                CustomIconSize = token.ControlHeight,
                CustomIconTop = 0,
                CustomIconFontSize = token.ControlHeightSM,
                IconSize = token.ControlHeight,
                IconTop = -0.5,
                IconFontSize = token.FontSize,
                IconSizeSM = token.FontSizeHeading3,
                DotSize = token.ControlHeight / 4,
                DotCurrentSize = token.ControlHeightLG / 4,
                NavArrowColor = token.ColorTextDisabled,
                NavContentMaxWidth = "auto",
                DescriptionMaxWidth = 140,
                WaitIconColor = token.Wireframe ? token.ColorTextDisabled : token.ColorTextLabel,
                WaitIconBgColor = token.Wireframe ? token.ColorBgContainer : token.ColorFillContent,
                WaitIconBorderColor = token.Wireframe ? token.ColorTextDisabled : "transparent",
                FinishIconBgColor = token.Wireframe ? token.ColorBgContainer : token.ControlItemBgActive,
                FinishIconBorderColor = token.Wireframe ? token.ColorPrimary : token.ControlItemBgActive,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Steps", (StepsToken token) =>
            {
                var colorTextDisabled = token.ColorTextDisabled;
                var controlHeightLG = token.ControlHeightLG;
                var colorTextLightSolid = token.ColorTextLightSolid;
                var colorText = token.ColorText;
                var colorPrimary = token.ColorPrimary;
                var colorTextDescription = token.ColorTextDescription;
                var colorTextQuaternary = token.ColorTextQuaternary;
                var colorError = token.ColorError;
                var colorBorderSecondary = token.ColorBorderSecondary;
                var colorSplit = token.ColorSplit;
                var stepsToken = MergeToken(token, new object { ProcessIconColor = colorTextLightSolid, ProcessTitleColor = colorText, ProcessDescriptionColor = colorText, ProcessIconBgColor = colorPrimary, ProcessIconBorderColor = colorPrimary, ProcessDotColor = colorPrimary, ProcessTailColor = colorSplit, WaitTitleColor = colorTextDescription, WaitDescriptionColor = colorTextDescription, WaitTailColor = colorSplit, WaitDotColor = colorTextDisabled, FinishIconColor = colorPrimary, FinishTitleColor = colorText, FinishDescriptionColor = colorTextDescription, FinishTailColor = colorPrimary, FinishDotColor = colorPrimary, ErrorIconColor = colorTextLightSolid, ErrorTitleColor = colorError, ErrorDescriptionColor = colorError, ErrorTailColor = colorSplit, ErrorIconBgColor = colorError, ErrorIconBorderColor = colorError, ErrorDotColor = colorError, StepsNavActiveColor = colorPrimary, StepsProgressSize = controlHeightLG, InlineDotSize = 6, InlineTitleColor = colorTextQuaternary, InlineTailColor = colorBorderSecondary, });
                return new object[]
                {
                    GenStepsStyle(stepsToken)
                };
            }, prepareComponentToken);
        }
    }
}