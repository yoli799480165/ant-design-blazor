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
    public partial class TableStyle
    {
        public static CSSObject GenStickyStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var opacityLoading = token.OpacityLoading;
            var tableScrollThumbBg = token.TableScrollThumbBg;
            var tableScrollThumbBgHover = token.TableScrollThumbBgHover;
            var tableScrollThumbSize = token.TableScrollThumbSize;
            var tableScrollBg = token.TableScrollBg;
            var zIndexTableSticky = token.ZIndexTableSticky;
            var stickyScrollBarBorderRadius = token.StickyScrollBarBorderRadius;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var tableBorderColor = token.TableBorderColor;
            var tableBorder = $@"{Unit(lineWidth)} {lineType} {tableBorderColor}";
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-sticky"] = new CSSObject
                    {
                        ["&-holder"] = new CSSObject
                        {
                            Position = "sticky",
                            ZIndex = zIndexTableSticky,
                            Background = token.ColorBgContainer,
                        },
                        ["&-scroll"] = new CSSObject
                        {
                            Position = "sticky",
                            Bottom = 0,
                            Height = $@"{Unit(tableScrollThumbSize)} !important",
                            ZIndex = zIndexTableSticky,
                            Display = "flex",
                            AlignItems = "center",
                            Background = tableScrollBg,
                            BorderTop = tableBorder,
                            Opacity = opacityLoading,
                            ["&:hover"] = new CSSObject
                            {
                                TransformOrigin = "center bottom",
                            },
                            ["&-bar"] = new CSSObject
                            {
                                Height = tableScrollThumbSize,
                                BackgroundColor = tableScrollThumbBg,
                                BorderRadius = stickyScrollBarBorderRadius,
                                Transition = $@"{token.MotionDurationSlow}, transform none",
                                Position = "absolute",
                                Bottom = 0,
                                ["&:hover, &-active"] = new CSSObject
                                {
                                    BackgroundColor = tableScrollThumbBgHover,
                                },
                            },
                        },
                    },
                },
            };
        }

        public static object StickyDefault()
        {
            return GenStickyStyle;
        }
    }
}