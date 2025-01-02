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
        public static object AccessibilityFocus(MenuToken token)
        {
            return new object
            {
                ["..."] = GenFocusOutline(token),
            };
        }

        public static CSSInterpolation GetThemeStyle(MenuToken token, string themeSuffix)
        {
            var componentCls = token.ComponentCls;
            var itemColor = token.ItemColor;
            var itemSelectedColor = token.ItemSelectedColor;
            var groupTitleColor = token.GroupTitleColor;
            var itemBg = token.ItemBg;
            var subMenuItemBg = token.SubMenuItemBg;
            var itemSelectedBg = token.ItemSelectedBg;
            var activeBarHeight = token.ActiveBarHeight;
            var activeBarWidth = token.ActiveBarWidth;
            var activeBarBorderWidth = token.ActiveBarBorderWidth;
            var motionDurationSlow = token.MotionDurationSlow;
            var motionEaseInOut = token.MotionEaseInOut;
            var motionEaseOut = token.MotionEaseOut;
            var itemPaddingInline = token.ItemPaddingInline;
            var motionDurationMid = token.MotionDurationMid;
            var itemHoverColor = token.ItemHoverColor;
            var lineType = token.LineType;
            var colorSplit = token.ColorSplit;
            var itemDisabledColor = token.ItemDisabledColor;
            var dangerItemColor = token.DangerItemColor;
            var dangerItemHoverColor = token.DangerItemHoverColor;
            var dangerItemSelectedColor = token.DangerItemSelectedColor;
            var dangerItemActiveBg = token.DangerItemActiveBg;
            var dangerItemSelectedBg = token.DangerItemSelectedBg;
            var popupBg = token.PopupBg;
            var itemHoverBg = token.ItemHoverBg;
            var itemActiveBg = token.ItemActiveBg;
            var menuSubMenuBg = token.MenuSubMenuBg;
            var horizontalItemSelectedColor = token.HorizontalItemSelectedColor;
            var horizontalItemSelectedBg = token.HorizontalItemSelectedBg;
            var horizontalItemBorderRadius = token.HorizontalItemBorderRadius;
            var horizontalItemHoverBg = token.HorizontalItemHoverBg;
            return new CSSInterpolation
            {
                [$@"{componentCls}-{themeSuffix}, {componentCls}-{themeSuffix} > {componentCls}"] = new CSSInterpolation
                {
                    Color = itemColor,
                    Background = itemBg,
                    [$@"{componentCls}-root:focus-visible"] = new CSSInterpolation
                    {
                        ["..."] = AccessibilityFocus(token),
                    },
                    [$@"{componentCls}-item"] = new CSSInterpolation
                    {
                        ["&-group-title, &-extra"] = new CSSInterpolation
                        {
                            Color = groupTitleColor,
                        },
                    },
                    [$@"{componentCls}-submenu-selected"] = new CSSInterpolation
                    {
                        [$@"{componentCls}-submenu-title"] = new CSSInterpolation
                        {
                            Color = itemSelectedColor,
                        },
                    },
                    [$@"{componentCls}-item, {componentCls}-submenu-title"] = new CSSInterpolation
                    {
                        Color = itemColor,
                        [$@"{componentCls}-item-disabled):focus-visible"] = new CSSInterpolation
                        {
                            ["..."] = AccessibilityFocus(token),
                        },
                    },
                    [$@"{componentCls}-item-disabled, {componentCls}-submenu-disabled"] = new CSSInterpolation
                    {
                        Color = $@"{itemDisabledColor} !important",
                    },
                    [$@"{componentCls}-item:not({componentCls}-item-selected):not({componentCls}-submenu-selected)"] = new CSSInterpolation
                    {
                        [$@"{componentCls}-submenu-title:hover"] = new CSSInterpolation
                        {
                            Color = itemHoverColor,
                        },
                    },
                    [$@"{componentCls}-horizontal)"] = new CSSInterpolation
                    {
                        [$@"{componentCls}-item:not({componentCls}-item-selected)"] = new CSSInterpolation
                        {
                            ["&:hover"] = new CSSInterpolation
                            {
                                BackgroundColor = itemHoverBg,
                            },
                            ["&:active"] = new CSSInterpolation
                            {
                                BackgroundColor = itemActiveBg,
                            },
                        },
                        [$@"{componentCls}-submenu-title"] = new CSSInterpolation
                        {
                            ["&:hover"] = new CSSInterpolation
                            {
                                BackgroundColor = itemHoverBg,
                            },
                            ["&:active"] = new CSSInterpolation
                            {
                                BackgroundColor = itemActiveBg,
                            },
                        },
                    },
                    [$@"{componentCls}-item-danger"] = new CSSInterpolation
                    {
                        Color = dangerItemColor,
                        [$@"{componentCls}-item:hover"] = new CSSInterpolation
                        {
                            [$@"{componentCls}-item-selected):not({componentCls}-submenu-selected)"] = new CSSInterpolation
                            {
                                Color = dangerItemHoverColor,
                            },
                        },
                        [$@"{componentCls}-item:active"] = new CSSInterpolation
                        {
                            Background = dangerItemActiveBg,
                        },
                    },
                    [$@"{componentCls}-item a"] = new CSSInterpolation
                    {
                        ["&, &:hover"] = new CSSInterpolation
                        {
                            Color = "inherit",
                        },
                    },
                    [$@"{componentCls}-item-selected"] = new CSSInterpolation
                    {
                        Color = itemSelectedColor,
                        [$@"{componentCls}-item-danger"] = new CSSInterpolation
                        {
                            Color = dangerItemSelectedColor,
                        },
                        ["a, a:hover"] = new CSSInterpolation
                        {
                            Color = "inherit",
                        },
                    },
                    [$@"{componentCls}-item-selected"] = new CSSInterpolation
                    {
                        BackgroundColor = itemSelectedBg,
                        [$@"{componentCls}-item-danger"] = new CSSInterpolation
                        {
                            BackgroundColor = dangerItemSelectedBg,
                        },
                    },
                    [$@"{componentCls}-submenu > {componentCls}"] = new CSSInterpolation
                    {
                        BackgroundColor = menuSubMenuBg,
                    },
                    [$@"{componentCls}-popup > {componentCls}"] = new CSSInterpolation
                    {
                        BackgroundColor = popupBg,
                    },
                    [$@"{componentCls}-submenu-popup > {componentCls}"] = new CSSInterpolation
                    {
                        BackgroundColor = popupBg,
                    },
                    [$@"{componentCls}-horizontal"] = new CSSInterpolation
                    {
                        ["..."] = (themeSuffix == "dark" ? new object
                        {
                            BorderBottom = 0,
                        }

                        : new object
                        {
                        }

                        ),
                        [$@"{componentCls}-item, > {componentCls}-submenu"] = new CSSInterpolation
                        {
                            Top = activeBarBorderWidth,
                            MarginTop = token.calc(activeBarBorderWidth).mul(-1).Equal(),
                            MarginBottom = 0,
                            BorderRadius = horizontalItemBorderRadius,
                            ["&::after"] = new CSSInterpolation
                            {
                                Position = "absolute",
                                InsetInline = itemPaddingInline,
                                Bottom = 0,
                                BorderBottom = $@"{Unit(activeBarHeight)} solid transparent",
                                Transition = $@"{motionDurationSlow} {motionEaseInOut}",
                                Content = "\"\"",
                            },
                            ["&:hover, &-active, &-open"] = new CSSInterpolation
                            {
                                Background = horizontalItemHoverBg,
                                ["&::after"] = new CSSInterpolation
                                {
                                    BorderBottomWidth = activeBarHeight,
                                    BorderBottomColor = horizontalItemSelectedColor,
                                },
                            },
                            ["&-selected"] = new CSSInterpolation
                            {
                                Color = horizontalItemSelectedColor,
                                BackgroundColor = horizontalItemSelectedBg,
                                ["&:hover"] = new CSSInterpolation
                                {
                                    BackgroundColor = horizontalItemSelectedBg,
                                },
                                ["&::after"] = new CSSInterpolation
                                {
                                    BorderBottomWidth = activeBarHeight,
                                    BorderBottomColor = horizontalItemSelectedColor,
                                },
                            },
                        },
                    },
                    [$@"{componentCls}-root"] = new CSSInterpolation
                    {
                        [$@"{componentCls}-inline, &{componentCls}-vertical"] = new CSSInterpolation
                        {
                            BorderInlineEnd = $@"{Unit(activeBarBorderWidth)} {lineType} {colorSplit}",
                        },
                    },
                    [$@"{componentCls}-inline"] = new CSSInterpolation
                    {
                        [$@"{componentCls}-sub{componentCls}-inline"] = new CSSInterpolation
                        {
                            Background = subMenuItemBg,
                        },
                        [$@"{componentCls}-item"] = new CSSInterpolation
                        {
                            Position = "relative",
                            ["&::after"] = new CSSInterpolation
                            {
                                Position = "absolute",
                                InsetBlock = 0,
                                InsetInlineEnd = 0,
                                BorderInlineEnd = $@"{Unit(activeBarWidth)} solid {itemSelectedColor}",
                                Transform = "scaleY(0.0001)",
                                Opacity = 0,
                                Transition = [
              `transform ${motionDurationMid} ${motionEaseOut}`,
              `opacity ${motionDurationMid} ${motionEaseOut}`,
            ].Join(","),
                                Content = "\"\"",
                            },
                            [$@"{componentCls}-item-danger"] = new CSSInterpolation
                            {
                                ["&::after"] = new CSSInterpolation
                                {
                                    BorderInlineEndColor = dangerItemSelectedColor,
                                },
                            },
                        },
                        [$@"{componentCls}-selected, {componentCls}-item-selected"] = new CSSInterpolation
                        {
                            ["&::after"] = new CSSInterpolation
                            {
                                Transform = "scaleY(1)",
                                Opacity = 1,
                                Transition = [
              `transform ${motionDurationMid} ${motionEaseInOut}`,
              `opacity ${motionDurationMid} ${motionEaseInOut}`,
            ].Join(","),
                            },
                        },
                    },
                },
            };
        }

        public static object ThemeDefault()
        {
            return getThemeStyle;
        }
    }
}