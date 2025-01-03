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
    public partial class CarouselStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string DotWidth { get; set; }
            public string DotHeight { get; set; }
            public double DotGap { get; set; }
            public double DotOffset { get; set; }
            public double DotWidthActive { get; set; }
            public string DotActiveWidth { get; set; }
            public double ArrowSize { get; set; }
            public double ArrowOffset { get; set; }
        }

        public class CarouselToken : ComponentToken
        {
        }

        public static CSSObject GenCarouselStyle(CarouselToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    [".slick-slider"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "block",
                        BoxSizing = "border-box",
                        TouchAction = "pan-y",
                        WebkitTouchCallout = "none",
                        WebkitTapHighlightColor = "transparent",
                        [".slick-track, .slick-list"] = new CSSObject
                        {
                            Transform = "translate3d(0, 0, 0)",
                            TouchAction = "pan-y",
                        },
                    },
                    [".slick-list"] = new CSSObject
                    {
                        Position = "relative",
                        Display = "block",
                        Margin = 0,
                        Padding = 0,
                        Overflow = "hidden",
                        ["&:focus"] = new CSSObject
                        {
                            Outline = "none",
                        },
                        ["&.dragging"] = new CSSObject
                        {
                            Cursor = "pointer",
                        },
                        [".slick-slide"] = new CSSObject
                        {
                            PointerEvents = "none",
                            [$@"{antCls}-radio-input, input{antCls}-checkbox-input"] = new CSSObject
                            {
                                Visibility = "hidden",
                            },
                            ["&.slick-active"] = new CSSObject
                            {
                                PointerEvents = "auto",
                                [$@"{antCls}-radio-input, input{antCls}-checkbox-input"] = new CSSObject
                                {
                                    Visibility = "visible",
                                },
                            },
                            ["> div > div"] = new CSSObject
                            {
                                VerticalAlign = "bottom",
                            },
                        },
                    },
                    [".slick-track"] = new CSSObject
                    {
                        Position = "relative",
                        Top = 0,
                        InsetInlineStart = 0,
                        Display = "block",
                        ["&::before, &::after"] = new CSSObject
                        {
                            Display = "table",
                            Content = "\"\"",
                        },
                        ["&::after"] = new CSSObject
                        {
                            Clear = "both",
                        },
                    },
                    [".slick-slide"] = new CSSObject
                    {
                        Display = "none",
                        Float = "left",
                        Height = "100%",
                        MinHeight = 1,
                        ["img"] = new CSSObject
                        {
                            Display = "block",
                        },
                        ["&.dragging img"] = new CSSObject
                        {
                            PointerEvents = "none",
                        },
                    },
                    [".slick-initialized .slick-slide"] = new CSSObject
                    {
                        Display = "block",
                    },
                    [".slick-vertical .slick-slide"] = new CSSObject
                    {
                        Display = "block",
                        Height = "auto",
                    },
                },
            };
        }

        public static CSSObject GenArrowsStyle(CarouselToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var arrowSize = token.ArrowSize;
            var arrowOffset = token.ArrowOffset;
            var arrowLength = token.Calc(arrowSize).Div(Math.SQRT2).Equal();
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        [".slick-prev, .slick-next"] = new object
                        {
                            Position = "absolute",
                            Top = "50%",
                            Width = arrowSize,
                            Height = arrowSize,
                            Transform = "translateY(-50%)",
                            Color = "#fff",
                            Opacity = 0.4,
                            Background = "transparent",
                            Padding = 0,
                            LineHeight = 0,
                            Border = 0,
                            Outline = "none",
                            Cursor = "pointer",
                            ZIndex = 1,
                            Transition = $@"{motionDurationSlow}",
                            ["&:hover, &:focus"] = new object
                            {
                                Opacity = 1,
                            },
                            ["&.slick-disabled"] = new object
                            {
                                PointerEvents = "none",
                                Opacity = 0,
                            },
                            ["&::after"] = new object
                            {
                                BoxSizing = "border-box",
                                Position = "absolute",
                                Top = token.Calc(arrowSize).Sub(arrowLength).Div(2).Equal(),
                                InsetInlineStart = token.Calc(arrowSize).Sub(arrowLength).Div(2).Equal(),
                                Display = "inline-block",
                                Width = arrowLength,
                                Height = arrowLength,
                                Border = "0 solid currentcolor",
                                BorderInlineWidth = "2px 0",
                                BorderBlockWidth = "2px 0",
                                BorderRadius = 1,
                                Content = "\"\"",
                            },
                        },
                        [".slick-prev"] = new object
                        {
                            InsetInlineStart = arrowOffset,
                            ["&::after"] = new object
                            {
                                Transform = "rotate(-45deg)",
                            },
                        },
                        [".slick-next"] = new object
                        {
                            InsetInlineEnd = arrowOffset,
                            ["&::after"] = new object
                            {
                                Transform = "rotate(135deg)",
                            },
                        },
                    },
                }
            };
        }

        public static CSSObject GenDotsStyle(CarouselToken token)
        {
            var componentCls = token.ComponentCls;
            var dotOffset = token.DotOffset;
            var dotWidth = token.DotWidth;
            var dotHeight = token.DotHeight;
            var dotGap = token.DotGap;
            var colorBgContainer = token.ColorBgContainer;
            var motionDurationSlow = token.MotionDurationSlow;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        [".slick-dots"] = new object
                        {
                            Position = "absolute",
                            InsetInlineEnd = 0,
                            Bottom = 0,
                            InsetInlineStart = 0,
                            ZIndex = 15,
                            Display = "flex !important",
                            JustifyContent = "center",
                            PaddingInlineStart = 0,
                            Margin = 0,
                            ListStyle = "none",
                            ["&-bottom"] = new object
                            {
                                Bottom = dotOffset,
                            },
                            ["&-top"] = new object
                            {
                                Top = dotOffset,
                                Bottom = "auto",
                            },
                            ["li"] = new object
                            {
                                Position = "relative",
                                Display = "inline-block",
                                Flex = "0 1 auto",
                                BoxSizing = "content-box",
                                Width = dotWidth,
                                Height = dotHeight,
                                MarginInline = dotGap,
                                Padding = 0,
                                TextAlign = "center",
                                TextIndent = -999,
                                VerticalAlign = "top",
                                Transition = $@"{motionDurationSlow}",
                                ["button"] = new object
                                {
                                    Position = "relative",
                                    Display = "block",
                                    Width = "100%",
                                    Height = dotHeight,
                                    Padding = 0,
                                    Color = "transparent",
                                    FontSize = 0,
                                    Background = colorBgContainer,
                                    Border = 0,
                                    BorderRadius = dotHeight,
                                    Outline = "none",
                                    Cursor = "pointer",
                                    Opacity = 0.2,
                                    Transition = $@"{motionDurationSlow}",
                                    ["&: hover, &:focus"] = new object
                                    {
                                        Opacity = 0.75,
                                    },
                                    ["&::after"] = new object
                                    {
                                        Position = "absolute",
                                        Inset = token.Calc(dotGap).Mul(-1).Equal(),
                                        Content = "\"\"",
                                    },
                                },
                                ["&.slick-active"] = new object
                                {
                                    Width = token.DotActiveWidth,
                                    ["& button"] = new object
                                    {
                                        Background = colorBgContainer,
                                        Opacity = 1,
                                    },
                                    ["&: hover, &:focus"] = new object
                                    {
                                        Opacity = 1,
                                    },
                                },
                            },
                        },
                    },
                }
            };
        }

        public static CSSObject GenCarouselVerticalStyle(CarouselToken token)
        {
            var componentCls = token.ComponentCls;
            var dotOffset = token.DotOffset;
            var arrowOffset = token.ArrowOffset;
            var marginXXS = token.MarginXXS;
            var reverseSizeOfDot = new object
            {
                Width = token.DotHeight,
                Height = token.DotWidth,
            };
            return new CSSObject
            {
                [$@"{componentCls}-vertical"] = new CSSObject
                {
                    [".slick-prev, .slick-next"] = new CSSObject
                    {
                        InsetInlineStart = "50%",
                        MarginBlockStart = "unset",
                        Transform = "translateX(-50%)",
                    },
                    [".slick-prev"] = new CSSObject
                    {
                        InsetBlockStart = arrowOffset,
                        InsetInlineStart = "50%",
                        ["&::after"] = new CSSObject
                        {
                            Transform = "rotate(45deg)",
                        },
                    },
                    [".slick-next"] = new CSSObject
                    {
                        InsetBlockStart = "auto",
                        InsetBlockEnd = arrowOffset,
                        ["&::after"] = new CSSObject
                        {
                            Transform = "rotate(-135deg)",
                        },
                    },
                    [".slick-dots"] = new CSSObject
                    {
                        Top = "50%",
                        Bottom = "auto",
                        FlexDirection = "column",
                        Width = token.DotHeight,
                        Height = "auto",
                        Margin = 0,
                        Transform = "translateY(-50%)",
                        ["&-left"] = new CSSObject
                        {
                            InsetInlineEnd = "auto",
                            InsetInlineStart = dotOffset,
                        },
                        ["&-right"] = new CSSObject
                        {
                            InsetInlineEnd = dotOffset,
                            InsetInlineStart = "auto",
                        },
                        ["li"] = new CSSObject
                        {
                            ["..."] = reverseSizeOfDot,
                            Margin = $@"{Unit(marginXXS)} 0",
                            VerticalAlign = "baseline",
                            ["button"] = reverseSizeOfDot,
                            ["&.slick-active"] = new CSSObject
                            {
                                ["..."] = reverseSizeOfDot,
                                ["button"] = reverseSizeOfDot,
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenCarouselRtlStyle(CarouselToken token)
        {
            var componentCls = token.ComponentCls;
            return new object[]
            {
                new object
                {
                    [$@"{componentCls}-rtl"] = new object
                    {
                        Direction = "rtl",
                        [".slick-dots"] = new object
                        {
                            [$@"{componentCls}-rtl&"] = new object
                            {
                                FlexDirection = "row-reverse",
                            },
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}-vertical"] = new object
                    {
                        [".slick-dots"] = new object
                        {
                            [$@"{componentCls}-rtl&"] = new object
                            {
                                FlexDirection = "column",
                            },
                        },
                    },
                }
            };
        }

        public static CarouselToken PrepareComponentToken(CarouselToken token)
        {
            var dotActiveWidth = 24;
            return new CarouselToken
            {
                ArrowSize = 16,
                ArrowOffset = token.MarginXS,
                DotWidth = 16,
                DotHeight = 3,
                DotGap = token.MarginXXS,
                DotOffset = 12,
                DotWidthActive = dotActiveWidth,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Carousel", (CarouselToken token) =>
            {
                return new object[]
                {
                    GenCarouselStyle(token),
                    GenArrowsStyle(token),
                    GenDotsStyle(token),
                    GenCarouselVerticalStyle(token),
                    GenCarouselRtlStyle(token)
                };
            }, PrepareComponentToken, new object { DeprecatedTokens = new object[] { new object[] { "dotWidthActive", "dotActiveWidth" } }, });
        }
    }
}