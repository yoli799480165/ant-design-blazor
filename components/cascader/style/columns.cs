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
    public partial class CascaderStyle
    {
        public static CSSInterpolation GetColumnsStyle(CascaderToken token)
        {
            var prefixCls = token.PrefixCls;
            var componentCls = token.ComponentCls;
            var cascaderMenuItemCls = $@"{componentCls}-menu-item";
            var iconCls = $@"{cascaderMenuItemCls}-expand {cascaderMenuItemCls}-expand-icon,
  {cascaderMenuItemCls}-loading-icon
";
            return new object[]
            {
                GetCheckboxStyle($@"{prefixCls}-checkbox", token),
                new object
                {
                    [componentCls] = new object
                    {
                        ["&-checkbox"] = new object
                        {
                            Top = 0,
                            MarginInlineEnd = token.PaddingXS,
                        },
                        ["&-menus"] = new object
                        {
                            Display = "flex",
                            FlexWrap = "nowrap",
                            AlignItems = "flex-start",
                            [$@"{componentCls}-menu-empty"] = new object
                            {
                                [$@"{componentCls}-menu"] = new object
                                {
                                    Width = "100%",
                                    Height = "auto",
                                    [cascaderMenuItemCls] = new object
                                    {
                                        Color = token.ColorTextDisabled,
                                    },
                                },
                            },
                        },
                        ["&-menu"] = new object
                        {
                            FlexGrow = 1,
                            FlexShrink = 0,
                            MinWidth = token.ControlItemWidth,
                            Height = token.DropdownHeight,
                            Margin = 0,
                            Padding = token.MenuPadding,
                            Overflow = "auto",
                            VerticalAlign = "top",
                            ListStyle = "none",
                            ["-ms-overflow-style"] = "-ms-autohiding-scrollbar",
                            ["&:not(:last-child)"] = new object
                            {
                                BorderInlineEnd = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                            },
                            ["&-item"] = new object
                            {
                                ["..."] = textEllipsis,
                                Display = "flex",
                                FlexWrap = "nowrap",
                                AlignItems = "center",
                                Padding = token.OptionPadding,
                                LineHeight = token.LineHeight,
                                Cursor = "pointer",
                                Transition = $@"{token.MotionDurationMid}",
                                BorderRadius = token.BorderRadiusSM,
                                ["&:hover"] = new object
                                {
                                    Background = token.ControlItemBgHover,
                                },
                                ["&-disabled"] = new object
                                {
                                    Color = token.ColorTextDisabled,
                                    Cursor = "not-allowed",
                                    ["&:hover"] = new object
                                    {
                                        Background = "transparent",
                                    },
                                    [iconCls] = new object
                                    {
                                        Color = token.ColorTextDisabled,
                                    },
                                },
                                [$@"{cascaderMenuItemCls}-disabled)"] = new object
                                {
                                    ["&, &:hover"] = new object
                                    {
                                        Color = token.OptionSelectedColor,
                                        FontWeight = token.OptionSelectedFontWeight,
                                        BackgroundColor = token.OptionSelectedBg,
                                    },
                                },
                                ["&-content"] = new object
                                {
                                    Flex = "auto",
                                },
                                [iconCls] = new object
                                {
                                    MarginInlineStart = token.PaddingXXS,
                                    Color = token.ColorTextDescription,
                                    FontSize = token.FontSizeIcon,
                                },
                                ["&-keyword"] = new object
                                {
                                    Color = token.ColorHighlight,
                                },
                            },
                        },
                    },
                }
            };
        }

        public static object ColumnsDefault()
        {
            return getColumnsStyle;
        }
    }
}