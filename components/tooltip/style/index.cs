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
    public partial class TooltipStyle
    {
        public class ComponentToken : TokenWithCommonCls : ArrowOffsetToken, ArrowToken
        {
            public double ZIndexPopup { get; set; }
        }

        public class TooltipToken : ComponentToken
        {
            public double TooltipMaxWidth { get; set; }
            public string TooltipColor { get; set; }
            public string TooltipBg { get; set; }
            public double TooltipBorderRadius { get; set; }
        }

        public static CSSObject GenTooltipStyle(TooltipToken token)
        {
            var calc = token.Calc;
            var componentCls = token.ComponentCls;
            var tooltipMaxWidth = token.TooltipMaxWidth;
            var tooltipColor = token.TooltipColor;
            var tooltipBg = token.TooltipBg;
            var tooltipBorderRadius = token.TooltipBorderRadius;
            var zIndexPopup = token.ZIndexPopup;
            var controlHeight = token.ControlHeight;
            var boxShadowSecondary = token.BoxShadowSecondary;
            var paddingSM = token.PaddingSM;
            var paddingXS = token.PaddingXS;
            var arrowOffsetHorizontal = token.ArrowOffsetHorizontal;
            var sizePopupArrow = token.SizePopupArrow;
            var edgeAlignMinWidth = calc(tooltipBorderRadius)
    .add(sizePopupArrow)
    .add(arrowOffsetHorizontal).Equal();
            var centerAlignMinWidth = calc(tooltipBorderRadius).mul(2).add(sizePopupArrow).Equal();
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        Position = "absolute",
                        ZIndex = zIndexPopup,
                        Display = "block",
                        Width = "max-content",
                        MaxWidth = tooltipMaxWidth,
                        Visibility = "visible",
                        ["--valid-offset-x"] = "var(--arrow-offset-horizontal, var(--arrow-x))",
                        TransformOrigin = [`var(--valid-offset-x, 50%)`, `var(--arrow-y, 50%)`].Join(" "),
                        ["&-hidden"] = new object
                        {
                            Display = "none",
                        },
                        ["--antd-arrow-background-color"] = tooltipBg,
                        [$@"{componentCls}-inner"] = new object
                        {
                            MinWidth = centerAlignMinWidth,
                            MinHeight = controlHeight,
                            Padding = $@"{Unit(token.calc(paddingSM).div(2).Equal())} {Unit(paddingXS)}",
                            Color = tooltipColor,
                            TextAlign = "start",
                            TextDecoration = "none",
                            WordWrap = "break-word",
                            BackgroundColor = tooltipBg,
                            BorderRadius = tooltipBorderRadius,
                            BoxShadow = boxShadowSecondary,
                            BoxSizing = "border-box",
                        },
                        [[
          `&-placement-topLeft`,
          `&-placement-topRight`,
          `&-placement-bottomLeft`,
          `&-placement-bottomRight`,
        ].Join(",")] = new object
                        {
                            MinWidth = edgeAlignMinWidth,
                        },
                        [[
          `&-placement-left`,
          `&-placement-leftTop`,
          `&-placement-leftBottom`,
          `&-placement-right`,
          `&-placement-rightTop`,
          `&-placement-rightBottom`,
        ].Join(",")] = new object
                        {
                            [$@"{componentCls}-inner"] = new object
                            {
                                BorderRadius = token.Min(tooltipBorderRadius, MAX_VERTICAL_CONTENT_RADIUS),
                            },
                        },
                        [$@"{componentCls}-content"] = new object
                        {
                            Position = "relative",
                        },
                        ["..."] = GenPresetColor(token, (object colorKey, object { darkColor }) =>
                        {
                            return new object
                            {
                                [$@"{componentCls}-{colorKey}"] = new object
                                {
                                    [$@"{componentCls}-inner"] = new object
                                    {
                                        BackgroundColor = darkColor,
                                    },
                                    [$@"{componentCls}-arrow"] = new object
                                    {
                                        ["--antd-arrow-background-color"] = darkColor,
                                    },
                                },
                            };
                        }),
                        ["&-rtl"] = new object
                        {
                            Direction = "rtl",
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
                    },
                }
            };
        }

        public static TooltipToken PrepareComponentToken(TooltipToken token)
        {
            return new TooltipToken
            {
                ZIndexPopup = token.ZIndexPopupBase + 70,
                ["..."] = GetArrowOffsetToken(new object { ContentRadius = token.BorderRadius, LimitVerticalRadius = true, }),
                ["..."] = GetArrowToken(MergeToken(token, new object { BorderRadiusOuter = Math.Min(token.BorderRadiusOuter, 4), })),
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return (string prefixCls, CSSObject injectStyle) =>
            {
                var useStyle = GenStyleHooks("Tooltip", (TooltipToken token) =>
                {
                    var borderRadius = token.BorderRadius;
                    var colorTextLightSolid = token.ColorTextLightSolid;
                    var colorBgSpotlight = token.ColorBgSpotlight;
                    var TooltipToken = MergeToken(token, new object { TooltipMaxWidth = 250, TooltipColor = colorTextLightSolid, TooltipBorderRadius = borderRadius, TooltipBg = colorBgSpotlight, });
                    return new object[]
                    {
                        GenTooltipStyle(TooltipToken),
                        InitZoomMotion(token, "zoom-big-fast")
                    };
                }, prepareComponentToken, new object { ResetStyle = false, });
                return UseStyle(prefixCls);
            };
        }
    }
}