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
    public partial class NotificationStyle
    {
        public object placementAlignProperty = new object
        {
            TopLeft = "left",
            TopRight = "right",
            BottomLeft = "left",
            BottomRight = "right",
            Top = "left",
            Bottom = "left",
        };
        public static CSSObject GenPlacementStackStyle(NotificationToken token, NotificationPlacement placement)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-{placement}"] = new CSSObject
                {
                    [$@"{componentCls}-stack > {componentCls}-notice-wrapper"] = new CSSObject
                    {
                        [placement.StartsWith("top") ? "top" : "bottom"] = 0,
                        [placementAlignProperty[placement]] = new CSSObject
                        {
                            Value = 0,
                            _skip_check_ = true,
                        },
                    },
                },
            };
        }

        public static CSSObject GenStackChildrenStyle(NotificationToken token)
        {
            var childrenStyle = new CSSObject
            {
            };
            for (var i = 1; i < token.NotificationStackLayer; i++)
            {
            }

            return new CSSObject
            {
                [$@"{token.NotificationStackLayer}))"] = new CSSObject
                {
                    Opacity = 0,
                    Overflow = "hidden",
                    Color = "transparent",
                    PointerEvents = "none",
                },
                ["..."] = childrenStyle,
            };
        }

        public static CSSObject GenStackedNoticeStyle(NotificationToken token)
        {
            var childrenStyle = new CSSObject
            {
            };
            for (var i = 1; i < token.NotificationStackLayer; i++)
            {
            }

            return new CSSObject
            {
                ["..."] = childrenStyle,
            };
        }

        public static CSSObject GenStackStyle(NotificationToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-stack"] = new CSSObject
                {
                    [$@"{componentCls}-notice-wrapper"] = new CSSObject
                    {
                        Transition = $@"{token.MotionDurationSlow}, backdrop-filter 0s",
                        Position = "absolute",
                        ["..."] = GenStackChildrenStyle(token),
                    },
                },
                [$@"{componentCls}-stack:not({componentCls}-stack-expanded)"] = new CSSObject
                {
                    [$@"{componentCls}-notice-wrapper"] = new CSSObject
                    {
                        ["..."] = GenStackedNoticeStyle(token),
                    },
                },
                [$@"{componentCls}-stack{componentCls}-stack-expanded"] = new CSSObject
                {
                    [$@"{componentCls}-notice-wrapper"] = new CSSObject
                    {
                        ["&:not(:nth-last-child(-n + 1))"] = new CSSObject
                        {
                            Opacity = 1,
                            Overflow = "unset",
                            Color = "inherit",
                            PointerEvents = "auto",
                            [$@"{token.ComponentCls}-notice"] = new CSSObject
                            {
                                Opacity = 1,
                            },
                        },
                        ["&:after"] = new CSSObject
                        {
                            Content = "\"\"",
                            Position = "absolute",
                            Height = token.Margin,
                            Width = "100%",
                            InsetInline = 0,
                            Bottom = token.calc(token.margin).mul(-1).Equal(),
                            Background = "transparent",
                            PointerEvents = "auto",
                        },
                    },
                },
                ["..."] = NotificationPlacements.map((placement) => genPlacementStackStyle(token, placement)).Reduce((object acc, object cur) =>
                {
                    return new object
                    {
                        ["..."] = acc,
                        ["..."] = cur,
                    };
                }, new object { }),
            };
        }

        public static object StackDefault()
        {
            return genStackStyle;
        }
    }
}