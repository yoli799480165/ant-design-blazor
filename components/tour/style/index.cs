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
    public partial class TourStyle
    {
        public class ComponentToken : TokenWithCommonCls : ArrowOffsetToken, ArrowToken
        {
            public double ZIndexPopup { get; set; }
            public double CloseBtnSize { get; set; }
            public string PrimaryPrevBtnBg { get; set; }
            public string PrimaryNextBtnHoverBg { get; set; }
        }

        public class TourToken : ComponentToken
        {
            public string IndicatorWidth { get; set; }
            public string IndicatorHeight { get; set; }
            public double TourBorderRadius { get; set; }
        }

        public static CSSObject GenBaseStyle(TourToken token)
        {
            var componentCls = token.ComponentCls;
            var padding = token.Padding;
            var paddingXS = token.PaddingXS;
            var borderRadius = token.BorderRadius;
            var borderRadiusXS = token.BorderRadiusXS;
            var colorPrimary = token.ColorPrimary;
            var colorFill = token.ColorFill;
            var indicatorHeight = token.IndicatorHeight;
            var indicatorWidth = token.IndicatorWidth;
            var boxShadowTertiary = token.BoxShadowTertiary;
            var zIndexPopup = token.ZIndexPopup;
            var colorBgElevated = token.ColorBgElevated;
            var fontWeightStrong = token.FontWeightStrong;
            var marginXS = token.MarginXS;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var tourBorderRadius = token.TourBorderRadius;
            var colorWhite = token.ColorWhite;
            var primaryNextBtnHoverBg = token.PrimaryNextBtnHoverBg;
            var closeBtnSize = token.CloseBtnSize;
            var motionDurationSlow = token.MotionDurationSlow;
            var antCls = token.AntCls;
            var primaryPrevBtnBg = token.PrimaryPrevBtnBg;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        Position = "absolute",
                        ZIndex = zIndexPopup,
                        MaxWidth = "fit-content",
                        Visibility = "visible",
                        Width = 520,
                        ["--antd-arrow-background-color"] = colorBgElevated,
                        ["&-pure"] = new object
                        {
                            MaxWidth = "100%",
                            Position = "relative",
                        },
                        [$@"{componentCls}-hidden"] = new object
                        {
                            Display = "none",
                        },
                        [$@"{componentCls}-content"] = new object
                        {
                            Position = "relative",
                        },
                        [$@"{componentCls}-inner"] = new object
                        {
                            TextAlign = "start",
                            TextDecoration = "none",
                            BorderRadius = tourBorderRadius,
                            BoxShadow = boxShadowTertiary,
                            Position = "relative",
                            BackgroundColor = colorBgElevated,
                            Border = "none",
                            BackgroundClip = "padding-box",
                            [$@"{componentCls}-close"] = new object
                            {
                                Position = "absolute",
                                Top = padding,
                                InsetInlineEnd = padding,
                                Color = token.ColorIcon,
                                Background = "none",
                                Border = "none",
                                Width = closeBtnSize,
                                Height = closeBtnSize,
                                BorderRadius = token.BorderRadiusSM,
                                Transition = $@"{token.MotionDurationMid}, color {token.MotionDurationMid}",
                                Display = "flex",
                                AlignItems = "center",
                                JustifyContent = "center",
                                Cursor = "pointer",
                                ["&:hover"] = new object
                                {
                                    Color = token.ColorIconHover,
                                    BackgroundColor = token.ColorBgTextHover,
                                },
                                ["&:active"] = new object
                                {
                                    BackgroundColor = token.ColorBgTextActive,
                                },
                                ["..."] = GenFocusStyle(token),
                            },
                            [$@"{componentCls}-cover"] = new object
                            {
                                TextAlign = "center",
                                Padding = $@"{Unit(token.calc(padding).add(closeBtnSize).add(paddingXS).Equal())} {Unit(padding)} 0",
                                ["img"] = new object
                                {
                                    Width = "100%",
                                },
                            },
                            [$@"{componentCls}-header"] = new object
                            {
                                Padding = $@"{Unit(padding)} {Unit(padding)} {Unit(paddingXS)}",
                                Width = $@"{Unit(closeBtnSize)})",
                                WordBreak = "break-word",
                                [$@"{componentCls}-title"] = new object
                                {
                                    FontWeight = fontWeightStrong,
                                },
                            },
                            [$@"{componentCls}-description"] = new object
                            {
                                Padding = $@"{Unit(padding)}",
                                WordWrap = "break-word",
                            },
                            [$@"{componentCls}-footer"] = new object
                            {
                                Padding = $@"{Unit(paddingXS)} {Unit(padding)} {Unit(padding)}",
                                TextAlign = "end",
                                BorderRadius = $@"{Unit(borderRadiusXS)} {Unit(borderRadiusXS)}",
                                Display = "flex",
                                [$@"{componentCls}-indicators"] = new object
                                {
                                    Display = "inline-block",
                                    [$@"{componentCls}-indicator"] = new object
                                    {
                                        Width = indicatorWidth,
                                        Height = indicatorHeight,
                                        Display = "inline-block",
                                        BorderRadius = "50%",
                                        Background = colorFill,
                                        ["&:not(:last-child)"] = new object
                                        {
                                            MarginInlineEnd = indicatorHeight,
                                        },
                                        ["&-active"] = new object
                                        {
                                            Background = colorPrimary,
                                        },
                                    },
                                },
                                [$@"{componentCls}-buttons"] = new object
                                {
                                    MarginInlineStart = "auto",
                                    [$@"{antCls}-btn"] = new object
                                    {
                                        MarginInlineStart = marginXS,
                                    },
                                },
                            },
                        },
                        [$@"{componentCls}-primary, &{componentCls}-primary"] = new object
                        {
                            ["--antd-arrow-background-color"] = colorPrimary,
                            [$@"{componentCls}-inner"] = new object
                            {
                                Color = colorTextLightSolid,
                                TextAlign = "start",
                                TextDecoration = "none",
                                BackgroundColor = colorPrimary,
                                BoxShadow = boxShadowTertiary,
                                [$@"{componentCls}-close"] = new object
                                {
                                    Color = colorTextLightSolid,
                                },
                                [$@"{componentCls}-indicators"] = new object
                                {
                                    [$@"{componentCls}-indicator"] = new object
                                    {
                                        Background = primaryPrevBtnBg,
                                        ["&-active"] = new object
                                        {
                                            Background = colorTextLightSolid,
                                        },
                                    },
                                },
                                [$@"{componentCls}-prev-btn"] = new object
                                {
                                    Color = colorTextLightSolid,
                                    BorderColor = primaryPrevBtnBg,
                                    BackgroundColor = colorPrimary,
                                    ["&:hover"] = new object
                                    {
                                        BackgroundColor = primaryPrevBtnBg,
                                        BorderColor = "transparent",
                                    },
                                },
                                [$@"{componentCls}-next-btn"] = new object
                                {
                                    Color = colorPrimary,
                                    BorderColor = "transparent",
                                    Background = colorWhite,
                                    ["&:hover"] = new object
                                    {
                                        Background = primaryNextBtnHoverBg,
                                    },
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-mask"] = new object
                    {
                        [$@"{componentCls}-placeholder-animated"] = new object
                        {
                            Transition = $@"{motionDurationSlow}",
                        },
                    },
                    [[
        '&-placement-left',
        '&-placement-leftTop',
        '&-placement-leftBottom',
        '&-placement-right',
        '&-placement-rightTop',
        '&-placement-rightBottom',
      ].Join(",")] = new object
                    {
                        [$@"{componentCls}-inner"] = new object
                        {
                            BorderRadius = token.Min(tourBorderRadius, MAX_VERTICAL_CONTENT_RADIUS),
                        },
                    },
                },
                GetArrowStyle(token, "var(--antd-arrow-background-color)")
            };
        }

        public static TourToken PrepareComponentToken(TourToken token)
        {
            return new TourToken
            {
                ZIndexPopup = token.ZIndexPopupBase + 70,
                CloseBtnSize = token.FontSize * token.LineHeight,
                PrimaryPrevBtnBg = new TinyColor(token.colorTextLightSolid).setAlpha(0.15).ToRgbString(),
                PrimaryNextBtnHoverBg = new TinyColor(token.colorBgTextHover)
    .onBackground(token.colorWhite).ToRgbString(),
                ["..."] = GetArrowOffsetToken(new object { ContentRadius = token.BorderRadiusLG, LimitVerticalRadius = true, }),
                ["..."] = GetArrowToken(token),
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Tour", (TourToken token) =>
            {
                var borderRadiusLG = token.BorderRadiusLG;
                var TourToken = MergeToken(token, new object { IndicatorWidth = 6, IndicatorHeight = 6, TourBorderRadius = borderRadiusLG, });
                return new object[]
                {
                    GenBaseStyle(TourToken)
                };
            }, prepareComponentToken);
        }
    }
}