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
    public partial class ModalStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string HeaderBg { get; set; }
            public string TitleLineHeight { get; set; }
            public double TitleFontSize { get; set; }
            public string TitleColor { get; set; }
            public string ContentBg { get; set; }
            public string FooterBg { get; set; }
            public string ContentPadding { get; set; }
            public string HeaderPadding { get; set; }
            public string HeaderBorderBottom { get; set; }
            public double HeaderMarginBottom { get; set; }
            public double BodyPadding { get; set; }
            public string FooterPadding { get; set; }
            public string FooterBorderTop { get; set; }
            public string FooterBorderRadius { get; set; }
            public string FooterMarginTop { get; set; }
            public string ConfirmBodyPadding { get; set; }
            public string ConfirmIconMarginInlineEnd { get; set; }
            public string ConfirmBtnsMarginTop { get; set; }
        }

        public class ModalToken : ComponentToken
        {
            public string ModalHeaderHeight { get; set; }
            public string ModalFooterBorderColorSplit { get; set; }
            public string ModalFooterBorderStyle { get; set; }
            public string ModalFooterBorderWidth { get; set; }
            public string ModalCloseIconColor { get; set; }
            public string ModalCloseIconHoverColor { get; set; }
            public string ModalCloseBtnSize { get; set; }
            public string ModalConfirmIconSize { get; set; }
            public string ModalTitleHeight { get; set; }
        }

        public static CSSObject GenModalMaskStyle(ModalToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            return new object[]
            {
                new object
                {
                    [$@"{componentCls}-root"] = new object
                    {
                        [$@"{componentCls}{antCls}-zoom-enter, {componentCls}{antCls}-zoom-appear"] = new object
                        {
                            Transform = "none",
                            Opacity = 0,
                            AnimationDuration = token.MotionDurationSlow,
                            UserSelect = "none",
                        },
                        [$@"{componentCls}{antCls}-zoom-leave {componentCls}-content"] = new object
                        {
                            PointerEvents = "none",
                        },
                        [$@"{componentCls}-mask"] = new object
                        {
                            ["..."] = Box("fixed"),
                            ZIndex = token.ZIndexPopupBase,
                            Height = "100%",
                            BackgroundColor = token.ColorBgMask,
                            PointerEvents = "none",
                            [$@"{componentCls}-hidden"] = new object
                            {
                                Display = "none",
                            },
                        },
                        [$@"{componentCls}-wrap"] = new object
                        {
                            ["..."] = Box("fixed"),
                            ZIndex = token.ZIndexPopupBase,
                            Overflow = "auto",
                            Outline = 0,
                            WebkitOverflowScrolling = "touch",
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}-root"] = InitFadeMotion(token),
                }
            };
        }

        public static CSSObject GenModalStyle(ModalToken token)
        {
            var componentCls = token.ComponentCls;
            return new object[]
            {
                new object
                {
                    [$@"{componentCls}-root"] = new object
                    {
                        [$@"{componentCls}-wrap-rtl"] = new object
                        {
                            Direction = "rtl",
                        },
                        [$@"{componentCls}-centered"] = new object
                        {
                            TextAlign = "center",
                            ["&::before"] = new object
                            {
                                Display = "inline-block",
                                Width = 0,
                                Height = "100%",
                                VerticalAlign = "middle",
                                Content = "\"\"",
                            },
                            [componentCls] = new object
                            {
                                Top = 0,
                                Display = "inline-block",
                                PaddingBottom = 0,
                                TextAlign = "start",
                                VerticalAlign = "middle",
                            },
                        },
                        [$@"{token.ScreenSMMax}px)"] = new object
                        {
                            [componentCls] = new object
                            {
                                MaxWidth = "calc(100vw - 16px)",
                                Margin = $@"{Unit(token.MarginXS)} auto",
                            },
                            [$@"{componentCls}-centered"] = new object
                            {
                                [componentCls] = new object
                                {
                                    Flex = 1,
                                },
                            },
                        },
                    },
                },
                new object
                {
                    [componentCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        PointerEvents = "none",
                        Position = "relative",
                        Top = 100,
                        Width = "auto",
                        MaxWidth = $@"{Unit(token.Calc(token.Margin).Mul(2).Equal())})",
                        Margin = "0 auto",
                        PaddingBottom = token.PaddingLG,
                        [$@"{componentCls}-title"] = new object
                        {
                            Margin = 0,
                            Color = token.TitleColor,
                            FontWeight = token.FontWeightStrong,
                            FontSize = token.TitleFontSize,
                            LineHeight = token.TitleLineHeight,
                            WordWrap = "break-word",
                        },
                        [$@"{componentCls}-content"] = new object
                        {
                            Position = "relative",
                            BackgroundColor = token.ContentBg,
                            BackgroundClip = "padding-box",
                            Border = 0,
                            BorderRadius = token.BorderRadiusLG,
                            BoxShadow = token.BoxShadow,
                            PointerEvents = "auto",
                            Padding = token.ContentPadding,
                        },
                        [$@"{componentCls}-close"] = new object
                        {
                            Position = "absolute",
                            Top = token.Calc(token.ModalHeaderHeight).Sub(token.ModalCloseBtnSize).Div(2).Equal(),
                            InsetInlineEnd = token.Calc(token.ModalHeaderHeight).Sub(token.ModalCloseBtnSize).Div(2).Equal(),
                            ZIndex = token.Calc(token.ZIndexPopupBase).Add(10).Equal(),
                            Padding = 0,
                            Color = token.ModalCloseIconColor,
                            FontWeight = token.FontWeightStrong,
                            LineHeight = 1,
                            TextDecoration = "none",
                            Background = "transparent",
                            BorderRadius = token.BorderRadiusSM,
                            Width = token.ModalCloseBtnSize,
                            Height = token.ModalCloseBtnSize,
                            Border = 0,
                            Outline = 0,
                            Cursor = "pointer",
                            Transition = $@"{token.MotionDurationMid}, background-color {token.MotionDurationMid}",
                            ["&-x"] = new object
                            {
                                Display = "flex",
                                FontSize = token.FontSizeLG,
                                FontStyle = "normal",
                                LineHeight = Unit(token.ModalCloseBtnSize),
                                JustifyContent = "center",
                                TextTransform = "none",
                                TextRendering = "auto",
                            },
                            ["&:disabled"] = new object
                            {
                                PointerEvents = "none",
                            },
                            ["&:hover"] = new object
                            {
                                Color = token.ModalCloseIconHoverColor,
                                BackgroundColor = token.ColorBgTextHover,
                                TextDecoration = "none",
                            },
                            ["&:active"] = new object
                            {
                                BackgroundColor = token.ColorBgTextActive,
                            },
                            ["..."] = GenFocusStyle(token),
                        },
                        [$@"{componentCls}-header"] = new object
                        {
                            Color = token.ColorText,
                            Background = token.HeaderBg,
                            BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)} 0 0",
                            MarginBottom = token.HeaderMarginBottom,
                            Padding = token.HeaderPadding,
                            BorderBottom = token.HeaderBorderBottom,
                        },
                        [$@"{componentCls}-body"] = new object
                        {
                            FontSize = token.FontSize,
                            LineHeight = token.LineHeight,
                            WordWrap = "break-word",
                            Padding = token.BodyPadding,
                            [$@"{componentCls}-body-skeleton"] = new object
                            {
                                Width = "100%",
                                Height = "100%",
                                Display = "flex",
                                JustifyContent = "center",
                                AlignItems = "center",
                                Margin = $@"{Unit(token.Margin)} auto",
                            },
                        },
                        [$@"{componentCls}-footer"] = new object
                        {
                            TextAlign = "end",
                            Background = token.FooterBg,
                            MarginTop = token.FooterMarginTop,
                            Padding = token.FooterPadding,
                            BorderTop = token.FooterBorderTop,
                            BorderRadius = token.FooterBorderRadius,
                            [$@"{token.AntCls}-btn + {token.AntCls}-btn"] = new object
                            {
                                MarginInlineStart = token.MarginXS,
                            },
                        },
                        [$@"{componentCls}-open"] = new object
                        {
                            Overflow = "hidden",
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}-pure-panel"] = new object
                    {
                        Top = "auto",
                        Padding = 0,
                        Display = "flex",
                        FlexDirection = "column",
                        [$@"{componentCls}-content,
          {componentCls}-body,
          {componentCls}-confirm-body-wrapper"] = new object
                        {
                            Display = "flex",
                            FlexDirection = "column",
                            Flex = "auto",
                        },
                        [$@"{componentCls}-confirm-body"] = new object
                        {
                            MarginBottom = "auto",
                        },
                    },
                }
            };
        }

        public static CSSObject GenRTLStyle(ModalToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-root"] = new CSSObject
                {
                    [$@"{componentCls}-wrap-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                        [$@"{componentCls}-confirm-body"] = new CSSObject
                        {
                            Direction = "rtl",
                        },
                    },
                },
            };
        }

        public static CSSObject GenResponsiveWidthStyle(ModalToken token)
        {
            var componentCls = token.ComponentCls;
            var gridMediaSizesMap = GetMediaSize(token);
            var responsiveStyles = Object.Keys(gridMediaSizesMap).Map((object key) =>
            {
                return new object
                {
                    [$@"{Unit(gridMediaSizesMap[key])})"] = new object
                    {
                        Width = $@"{componentCls.Replace(".", "")}-{key}-width)",
                    },
                };
            });
            return new CSSObject
            {
                [$@"{componentCls}-root"] = new CSSObject
                {
                    [componentCls] = new object[]
                    {
                        new object
                        {
                            Width = $@"{componentCls.Replace(".", "")}-xs-width)",
                        }
                    }.Union(responsiveStyles).ToArray(),
                },
            };
        }

        public static object PrepareToken(ModalToken token)
        {
            var headerPaddingVertical = token.Padding;
            var headerFontSize = token.FontSizeHeading5;
            var headerLineHeight = token.LineHeightHeading5;
            var modalToken = MergeToken(token, new object { ModalHeaderHeight = token.Calc(token.Calc(headerLineHeight).Mul(headerFontSize).Equal()).Add(token.Calc(headerPaddingVertical).Mul(2).Equal()).Equal(), ModalFooterBorderColorSplit = token.ColorSplit, ModalFooterBorderStyle = token.LineType, ModalFooterBorderWidth = token.LineWidth, ModalCloseIconColor = token.ColorIcon, ModalCloseIconHoverColor = token.ColorIconHover, ModalCloseBtnSize = token.ControlHeight, ModalConfirmIconSize = token.FontHeight, ModalTitleHeight = token.Calc(token.TitleFontSize).Mul(token.TitleLineHeight).Equal(), });
            return modalToken;
        }

        public static ModalToken PrepareComponentToken(GlobalToken token)
        {
            return new ModalToken
            {
                FooterBg = "transparent",
                HeaderBg = token.ColorBgElevated,
                TitleLineHeight = token.LineHeightHeading5,
                TitleFontSize = token.FontSizeHeading5,
                ContentBg = token.ColorBgElevated,
                TitleColor = token.ColorTextHeading,
                ContentPadding = token.Wireframe ? 0 : $@"{Unit(token.PaddingMD)} {Unit(token.PaddingContentHorizontalLG)}",
                HeaderPadding = token.Wireframe ? $@"{Unit(token.Padding)} {Unit(token.PaddingLG)}" : 0,
                HeaderBorderBottom = token.Wireframe ? $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}" : "none",
                HeaderMarginBottom = token.Wireframe ? 0 : token.MarginXS,
                BodyPadding = token.Wireframe ? token.PaddingLG : 0,
                FooterPadding = token.Wireframe ? $@"{Unit(token.PaddingXS)} {Unit(token.Padding)}" : 0,
                FooterBorderTop = token.Wireframe ? $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}" : "none",
                FooterBorderRadius = token.Wireframe ? $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)}" : 0,
                FooterMarginTop = token.Wireframe ? 0 : token.MarginSM,
                ConfirmBodyPadding = token.Wireframe ? $@"{Unit(token.Padding * 2)} {Unit(token.Padding * 2)} {Unit(token.PaddingLG)}" : 0,
                ConfirmIconMarginInlineEnd = token.Wireframe ? token.Margin : token.MarginSM,
                ConfirmBtnsMarginTop = token.Wireframe ? token.MarginLG : token.MarginSM,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Modal", (ModalToken token) =>
            {
                var modalToken = PrepareToken(token);
                return new object[]
                {
                    GenModalStyle(modalToken),
                    GenRTLStyle(modalToken),
                    GenModalMaskStyle(modalToken),
                    InitZoomMotion(modalToken, "zoom"),
                    GenResponsiveWidthStyle(modalToken)
                };
            }, PrepareComponentToken, new object { Unitless = new object { TitleLineHeight = true, }, });
        }
    }
}