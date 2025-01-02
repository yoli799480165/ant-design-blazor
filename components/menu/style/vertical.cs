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
    public partial class MenuStyle
    {
        public static CSSObject GetVerticalInlineStyle(MenuToken token)
        {
            var componentCls = token.ComponentCls;
            var itemHeight = token.ItemHeight;
            var itemMarginInline = token.ItemMarginInline;
            var padding = token.Padding;
            var menuArrowSize = token.MenuArrowSize;
            var marginXS = token.MarginXS;
            var itemMarginBlock = token.ItemMarginBlock;
            var itemWidth = token.ItemWidth;
            var itemPaddingInline = token.ItemPaddingInline;
            var paddingWithArrow = token.calc(menuArrowSize).add(padding).add(marginXS).Equal();
            return new CSSObject
            {
                [$@"{componentCls}-item"] = new CSSObject
                {
                    Position = "relative",
                    Overflow = "hidden",
                },
                [$@"{componentCls}-item, {componentCls}-submenu-title"] = new CSSObject
                {
                    Height = itemHeight,
                    LineHeight = Unit(itemHeight),
                    PaddingInline = itemPaddingInline,
                    Overflow = "hidden",
                    TextOverflow = "ellipsis",
                    MarginInline = itemMarginInline,
                    MarginBlock = itemMarginBlock,
                    Width = itemWidth,
                },
                [$@"{componentCls}-item,
            > {componentCls}-submenu > {componentCls}-submenu-title"] = new CSSObject
                {
                    Height = itemHeight,
                    LineHeight = Unit(itemHeight),
                },
                [$@"{componentCls}-item-group-list {componentCls}-submenu-title,
            {componentCls}-submenu-title"] = new CSSObject
                {
                    PaddingInlineEnd = paddingWithArrow,
                },
            };
        }

        public static CSSObject GetVerticalStyle(MenuToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var itemHeight = token.ItemHeight;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var dropdownWidth = token.DropdownWidth;
            var controlHeightLG = token.ControlHeightLG;
            var motionEaseOut = token.MotionEaseOut;
            var paddingXL = token.PaddingXL;
            var itemMarginInline = token.ItemMarginInline;
            var fontSizeLG = token.FontSizeLG;
            var motionDurationFast = token.MotionDurationFast;
            var motionDurationSlow = token.MotionDurationSlow;
            var paddingXS = token.PaddingXS;
            var boxShadowSecondary = token.BoxShadowSecondary;
            var collapsedWidth = token.CollapsedWidth;
            var collapsedIconSize = token.CollapsedIconSize;
            var inlineItemStyle = new CSSObject
            {
                Height = itemHeight,
                LineHeight = Unit(itemHeight),
                ListStylePosition = "inside",
                ListStyleType = "disc",
            };
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        ["&-inline, &-vertical"] = new object
                        {
                            [$@"{componentCls}-root"] = new object
                            {
                                BoxShadow = "none",
                            },
                            ["..."] = GetVerticalInlineStyle(token),
                        },
                    },
                    [$@"{componentCls}-submenu-popup"] = new object
                    {
                        [$@"{componentCls}-vertical"] = new object
                        {
                            ["..."] = GetVerticalInlineStyle(token),
                            BoxShadow = boxShadowSecondary,
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}-submenu-popup {componentCls}-vertical{componentCls}-sub"] = new object
                    {
                        MinWidth = dropdownWidth,
                        MaxHeight = $@"{Unit(token.calc(controlHeightLG).mul(2.5).Equal())})",
                        Padding = "0",
                        Overflow = "hidden",
                        BorderInlineEnd = 0,
                        ["&:not([class*='-active'])"] = new object
                        {
                            OverflowX = "hidden",
                            OverflowY = "auto",
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}-inline"] = new object
                    {
                        Width = "100%",
                        [$@"{componentCls}-root"] = new object
                        {
                            [$@"{componentCls}-item, {componentCls}-submenu-title"] = new object
                            {
                                Display = "flex",
                                AlignItems = "center",
                                Transition = [
              `border-color ${motionDurationSlow}`,
              `background ${motionDurationSlow}`,
              `padding ${motionDurationFast} ${motionEaseOut}`,
            ].Join(","),
                                [$@"{componentCls}-title-content"] = new object
                                {
                                    Flex = "auto",
                                    MinWidth = 0,
                                    Overflow = "hidden",
                                    TextOverflow = "ellipsis",
                                },
                                ["> *"] = new object
                                {
                                    Flex = "none",
                                },
                            },
                        },
                        [$@"{componentCls}-sub{componentCls}-inline"] = new object
                        {
                            Padding = 0,
                            Border = 0,
                            BorderRadius = 0,
                            BoxShadow = "none",
                            [$@"{componentCls}-submenu > {componentCls}-submenu-title"] = inlineItemStyle,
                            [$@"{componentCls}-item-group-title"] = new object
                            {
                                PaddingInlineStart = paddingXL,
                            },
                        },
                        [$@"{componentCls}-item"] = inlineItemStyle,
                    },
                },
                new object
                {
                    [$@"{componentCls}-inline-collapsed"] = new object
                    {
                        Width = collapsedWidth,
                        [$@"{componentCls}-root"] = new object
                        {
                            [$@"{componentCls}-item, {componentCls}-submenu {componentCls}-submenu-title"] = new object
                            {
                                [$@"{componentCls}-inline-collapsed-noicon"] = new object
                                {
                                    FontSize = fontSizeLG,
                                    TextAlign = "center",
                                },
                            },
                        },
                        [$@"{componentCls}-item,
          > {componentCls}-item-group > {componentCls}-item-group-list > {componentCls}-item,
          > {componentCls}-item-group > {componentCls}-item-group-list > {componentCls}-submenu > {componentCls}-submenu-title,
          > {componentCls}-submenu > {componentCls}-submenu-title"] = new object
                        {
                            InsetInlineStart = 0,
                            PaddingInline = $@"{Unit(token.calc(collapsedIconSize).div(2).Equal())} - {Unit(itemMarginInline)})",
                            TextOverflow = "clip",
                            [$@"{componentCls}-submenu-arrow,
            {componentCls}-submenu-expand-icon
          "] = new object
                            {
                                Opacity = 0,
                            },
                            [$@"{componentCls}-item-icon, {iconCls}"] = new object
                            {
                                Margin = 0,
                                FontSize = collapsedIconSize,
                                LineHeight = Unit(itemHeight),
                                ["+ span"] = new object
                                {
                                    Display = "inline-block",
                                    Opacity = 0,
                                },
                            },
                        },
                        [$@"{componentCls}-item-icon, {iconCls}"] = new object
                        {
                            Display = "inline-block",
                        },
                        ["&-tooltip"] = new object
                        {
                            PointerEvents = "none",
                            [$@"{componentCls}-item-icon, {iconCls}"] = new object
                            {
                                Display = "none",
                            },
                            ["a, a:hover"] = new object
                            {
                                Color = colorTextLightSolid,
                            },
                        },
                        [$@"{componentCls}-item-group-title"] = new object
                        {
                            ["..."] = textEllipsis,
                            PaddingInline = paddingXS,
                        },
                    },
                }
            };
        }

        public static object VerticalDefault()
        {
            return getVerticalStyle;
        }
    }
}