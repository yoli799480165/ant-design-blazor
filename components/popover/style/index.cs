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
    public partial class PopoverStyle
    {
        public class ComponentToken : TokenWithCommonCls : ArrowToken, ArrowOffsetToken
        {
            public string Width { get; set; }
            public string MinWidth { get; set; }
            public string TitleMinWidth { get; set; }
            public double ZIndexPopup { get; set; }
            public double InnerPadding { get; set; }
            public string TitlePadding { get; set; }
            public double TitleMarginBottom { get; set; }
            public string TitleBorderBottom { get; set; }
            public string InnerContentPadding { get; set; }
        }

        public class PopoverToken : ComponentToken
        {
            public string PopoverBg { get; set; }
            public string PopoverColor { get; set; }
        }

        public static CSSObject GenBaseStyle(PopoverToken token)
        {
            var componentCls = token.ComponentCls;
            var popoverColor = token.PopoverColor;
            var titleMinWidth = token.TitleMinWidth;
            var fontWeightStrong = token.FontWeightStrong;
            var innerPadding = token.InnerPadding;
            var boxShadowSecondary = token.BoxShadowSecondary;
            var colorTextHeading = token.ColorTextHeading;
            var borderRadiusLG = token.BorderRadiusLG;
            var zIndexPopup = token.ZIndexPopup;
            var titleMarginBottom = token.TitleMarginBottom;
            var colorBgElevated = token.ColorBgElevated;
            var popoverBg = token.PopoverBg;
            var titleBorderBottom = token.TitleBorderBottom;
            var innerContentPadding = token.InnerContentPadding;
            var titlePadding = token.TitlePadding;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        Position = "absolute",
                        Top = 0,
                        Left = new object
                        {
                            _skip_check_ = true,
                            Value = 0,
                        },
                        ZIndex = zIndexPopup,
                        FontWeight = "normal",
                        WhiteSpace = "normal",
                        TextAlign = "start",
                        Cursor = "auto",
                        UserSelect = "text",
                        ["--valid-offset-x"] = "var(--arrow-offset-horizontal, var(--arrow-x))",
                        TransformOrigin = [`var(--valid-offset-x, 50%)`, `var(--arrow-y, 50%)`].Join(" "),
                        ["--antd-arrow-background-color"] = colorBgElevated,
                        Width = "max-content",
                        MaxWidth = "100vw",
                        ["&-rtl"] = new object
                        {
                            Direction = "rtl",
                        },
                        ["&-hidden"] = new object
                        {
                            Display = "none",
                        },
                        [$@"{componentCls}-content"] = new object
                        {
                            Position = "relative",
                        },
                        [$@"{componentCls}-inner"] = new object
                        {
                            BackgroundColor = popoverBg,
                            BackgroundClip = "padding-box",
                            BorderRadius = borderRadiusLG,
                            BoxShadow = boxShadowSecondary,
                            Padding = innerPadding,
                        },
                        [$@"{componentCls}-title"] = new object
                        {
                            MinWidth = titleMinWidth,
                            MarginBottom = titleMarginBottom,
                            Color = colorTextHeading,
                            FontWeight = fontWeightStrong,
                            BorderBottom = titleBorderBottom,
                            Padding = titlePadding,
                        },
                        [$@"{componentCls}-inner-content"] = new object
                        {
                            Color = popoverColor,
                            Padding = innerContentPadding,
                        },
                    },
                },
                GetArrowStyle(token, "var(--antd-arrow-background-color)"),
                new object
                {
                    [$@"{componentCls}-pure"] = new object
                    {
                        Position = "relative",
                        MaxWidth = "none",
                        Margin = token.SizePopupArrow,
                        Display = "inline-block",
                        [$@"{componentCls}-content"] = new object
                        {
                            Display = "inline-block",
                        },
                    },
                }
            };
        }

        public static CSSObject GenColorStyle(PopoverToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = PresetColors.Map((keyof PresetColorType  colorKey) =>
                {
                    var lightColor = token[$@"{colorKey}6"];
                    return new object
                    {
                        [$@"{componentCls}-{colorKey}"] = new object
                        {
                            ["--antd-arrow-background-color"] = lightColor,
                            [$@"{componentCls}-inner"] = new object
                            {
                                BackgroundColor = lightColor,
                            },
                            [$@"{componentCls}-arrow"] = new object
                            {
                                Background = "transparent",
                            },
                        },
                    };
                }),
            };
        }

        public static PopoverToken PrepareComponentToken(PopoverToken token)
        {
            var lineWidth = token.LineWidth;
            var controlHeight = token.ControlHeight;
            var fontHeight = token.FontHeight;
            var padding = token.Padding;
            var wireframe = token.Wireframe;
            var zIndexPopupBase = token.ZIndexPopupBase;
            var borderRadiusLG = token.BorderRadiusLG;
            var marginXS = token.MarginXS;
            var lineType = token.LineType;
            var colorSplit = token.ColorSplit;
            var paddingSM = token.PaddingSM;
            var titlePaddingBlockDist = controlHeight - fontHeight;
            var popoverTitlePaddingBlockTop = titlePaddingBlockDist / 2;
            var popoverTitlePaddingBlockBottom = titlePaddingBlockDist / 2 - lineWidth;
            var popoverPaddingHorizontal = padding;
            return new PopoverToken
            {
                TitleMinWidth = 177,
                ZIndexPopup = zIndexPopupBase + 30,
                ["..."] = GetArrowToken(token),
                ["..."] = GetArrowOffsetToken(new object { ContentRadius = borderRadiusLG, LimitVerticalRadius = true, }),
                InnerPadding = wireframe ? 0 : 12,
                TitleMarginBottom = wireframe ? 0 : marginXS,
                TitlePadding = wireframe ? $@"{popoverTitlePaddingBlockTop}px {popoverPaddingHorizontal}px {popoverTitlePaddingBlockBottom}px" : 0,
                TitleBorderBottom = wireframe ? $@"{lineWidth}px {lineType} {colorSplit}" : "none",
                InnerContentPadding = wireframe ? $@"{paddingSM}px {popoverPaddingHorizontal}px" : 0,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Popover", (PopoverToken token) =>
            {
                var colorBgElevated = token.ColorBgElevated;
                var colorText = token.ColorText;
                var popoverToken = MergeToken(token, new object { PopoverBg = colorBgElevated, PopoverColor = colorText, });
                return new object[]
                {
                    GenBaseStyle(popoverToken),
                    GenColorStyle(popoverToken),
                    InitZoomMotion(popoverToken, "zoom-big")
                };
            }, prepareComponentToken, new object { ResetStyle = false, DeprecatedTokens = new object[] { new object[] { "width", "titleMinWidth" }, new object[] { "minWidth", "titleMinWidth" } }, });
        }
    }
}