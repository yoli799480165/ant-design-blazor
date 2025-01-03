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
        public static CSSObject GenSorterStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var marginXXS = token.MarginXXS;
            var fontSizeIcon = token.FontSizeIcon;
            var headerIconColor = token.HeaderIconColor;
            var headerIconHoverColor = token.HeaderIconHoverColor;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-thead th{componentCls}-column-has-sorters"] = new CSSObject
                    {
                        Outline = "none",
                        Cursor = "pointer",
                        Transition = $@"{token.MotionDurationSlow}, left 0s",
                        ["&:hover"] = new CSSObject
                        {
                            Background = token.TableHeaderSortHoverBg,
                            ["&::before"] = new CSSObject
                            {
                                BackgroundColor = "transparent !important",
                            },
                        },
                        ["&:focus-visible"] = new CSSObject
                        {
                            Color = token.ColorPrimary,
                        },
                        [$@"{componentCls}-cell-fix-left:hover,
          &{componentCls}-cell-fix-right:hover
        "] = new CSSObject
                        {
                            Background = token.TableFixedHeaderSortActiveBg,
                        },
                    },
                    [$@"{componentCls}-thead th{componentCls}-column-sort"] = new CSSObject
                    {
                        Background = token.TableHeaderSortBg,
                        ["&::before"] = new CSSObject
                        {
                            BackgroundColor = "transparent !important",
                        },
                    },
                    [$@"{componentCls}-column-sort"] = new CSSObject
                    {
                        Background = token.TableBodySortBg,
                    },
                    [$@"{componentCls}-column-title"] = new CSSObject
                    {
                        Position = "relative",
                        ZIndex = 1,
                        Flex = 1,
                    },
                    [$@"{componentCls}-column-sorters"] = new CSSObject
                    {
                        Display = "flex",
                        Flex = "auto",
                        AlignItems = "center",
                        JustifyContent = "space-between",
                        ["&::after"] = new CSSObject
                        {
                            Position = "absolute",
                            Inset = 0,
                            Width = "100%",
                            Height = "100%",
                            Content = "\"\"",
                        },
                    },
                    [$@"{componentCls}-column-sorters-tooltip-target-sorter"] = new CSSObject
                    {
                        ["&::after"] = new CSSObject
                        {
                            Content = "none",
                        },
                    },
                    [$@"{componentCls}-column-sorter"] = new CSSObject
                    {
                        MarginInlineStart = marginXXS,
                        Color = headerIconColor,
                        FontSize = 0,
                        Transition = $@"{token.MotionDurationSlow}",
                        ["&-inner"] = new CSSObject
                        {
                            Display = "inline-flex",
                            FlexDirection = "column",
                            AlignItems = "center",
                        },
                        ["&-up, &-down"] = new CSSObject
                        {
                            FontSize = fontSizeIcon,
                            ["&.active"] = new CSSObject
                            {
                                Color = token.ColorPrimary,
                            },
                        },
                        [$@"{componentCls}-column-sorter-up + {componentCls}-column-sorter-down"] = new CSSObject
                        {
                            MarginTop = "-0.3em",
                        },
                    },
                    [$@"{componentCls}-column-sorters:hover {componentCls}-column-sorter"] = new CSSObject
                    {
                        Color = headerIconHoverColor,
                    },
                },
            };
        }

        public static object SorterDefault()
        {
            return GenSorterStyle;
        }
    }
}