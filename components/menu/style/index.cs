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
        public class ComponentToken : TokenWithCommonCls
        {
            public string DropdownWidth { get; set; }
            public double ZIndexPopup { get; set; }
            public string ColorGroupTitle { get; set; }
            public string GroupTitleColor { get; set; }
            public string GroupTitleLineHeight { get; set; }
            public double GroupTitleFontSize { get; set; }
            public double RadiusItem { get; set; }
            public double ItemBorderRadius { get; set; }
            public double RadiusSubMenuItem { get; set; }
            public double SubMenuItemBorderRadius { get; set; }
            public string ColorItemText { get; set; }
            public string ItemColor { get; set; }
            public string ColorItemTextHover { get; set; }
            public string ItemHoverColor { get; set; }
            public string ColorItemTextHoverHorizontal { get; set; }
            public string HorizontalItemHoverColor { get; set; }
            public string ColorItemTextSelected { get; set; }
            public string ItemSelectedColor { get; set; }
            public string ColorItemTextSelectedHorizontal { get; set; }
            public string HorizontalItemSelectedColor { get; set; }
            public string ColorItemTextDisabled { get; set; }
            public string ItemDisabledColor { get; set; }
            public string ColorDangerItemText { get; set; }
            public string DangerItemColor { get; set; }
            public string ColorDangerItemTextHover { get; set; }
            public string DangerItemHoverColor { get; set; }
            public string ColorDangerItemTextSelected { get; set; }
            public string DangerItemSelectedColor { get; set; }
            public string ColorDangerItemBgActive { get; set; }
            public string DangerItemActiveBg { get; set; }
            public string ColorDangerItemBgSelected { get; set; }
            public string DangerItemSelectedBg { get; set; }
            public string ColorItemBg { get; set; }
            public string ItemBg { get; set; }
            public string ColorItemBgHover { get; set; }
            public string ItemHoverBg { get; set; }
            public string ColorSubItemBg { get; set; }
            public string SubMenuItemBg { get; set; }
            public string ColorItemBgActive { get; set; }
            public string ItemActiveBg { get; set; }
            public string ColorItemBgSelected { get; set; }
            public string ItemSelectedBg { get; set; }
            public string ColorItemBgSelectedHorizontal { get; set; }
            public string HorizontalItemSelectedBg { get; set; }
            public string ColorActiveBarWidth { get; set; }
            public string ActiveBarWidth { get; set; }
            public double ColorActiveBarHeight { get; set; }
            public double ActiveBarHeight { get; set; }
            public double ColorActiveBarBorderSize { get; set; }
            public string ActiveBarBorderWidth { get; set; }
            public double ItemMarginInline { get; set; }
            public string HorizontalItemHoverBg { get; set; }
            public double HorizontalItemBorderRadius { get; set; }
            public string ItemHeight { get; set; }
            public string CollapsedWidth { get; set; }
            public string PopupBg { get; set; }
            public string ItemMarginBlock { get; set; }
            public string ItemPaddingInline { get; set; }
            public string HorizontalLineHeight { get; set; }
            public string IconMarginInlineEnd { get; set; }
            public double IconSize { get; set; }
            public double CollapsedIconSize { get; set; }
            public string DarkPopupBg { get; set; }
            public string DarkItemColor { get; set; }
            public string DarkDangerItemColor { get; set; }
            public string DarkItemBg { get; set; }
            public string DarkSubMenuItemBg { get; set; }
            public string DarkItemSelectedColor { get; set; }
            public string DarkItemSelectedBg { get; set; }
            public string DarkItemHoverBg { get; set; }
            public string DarkGroupTitleColor { get; set; }
            public string DarkItemHoverColor { get; set; }
            public string DarkItemDisabledColor { get; set; }
            public string DarkDangerItemSelectedBg { get; set; }
            public string DarkDangerItemHoverColor { get; set; }
            public string DarkDangerItemSelectedColor { get; set; }
            public string DarkDangerItemActiveBg { get; set; }
            public string ItemWidth { get; set; }
        }

        public class MenuToken : ComponentToken
        {
            public string MenuHorizontalHeight { get; set; }
            public string MenuArrowSize { get; set; }
            public string MenuArrowOffset { get; set; }
            public string MenuSubMenuBg { get; set; }
            public string DarkPopupBg { get; set; }
        }

        public static CSSObject GenMenuItemStyle(MenuToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var motionDurationMid = token.MotionDurationMid;
            var motionEaseInOut = token.MotionEaseInOut;
            var motionEaseOut = token.MotionEaseOut;
            var iconCls = token.IconCls;
            var iconSize = token.IconSize;
            var iconMarginInlineEnd = token.IconMarginInlineEnd;
            return new CSSObject
            {
                [$@"{componentCls}-item, {componentCls}-submenu-title"] = new CSSObject
                {
                    Position = "relative",
                    Display = "block",
                    Margin = 0,
                    WhiteSpace = "nowrap",
                    Cursor = "pointer",
                    Transition = new object[]
                    {
                        $@"{motionDurationSlow}",
                        $@"{motionDurationSlow}",
                        $@"{motionDurationSlow} + 0.1s) {motionEaseInOut}"
                    }.Join(","),
                    [$@"{componentCls}-item-icon, {iconCls}"] = new CSSObject
                    {
                        MinWidth = iconSize,
                        FontSize = iconSize,
                        Transition = new object[]
                        {
                            $@"{motionDurationMid} {motionEaseOut}",
                            $@"{motionDurationSlow} {motionEaseInOut}",
                            $@"{motionDurationSlow}"
                        }.Join(","),
                        ["+ span"] = new CSSObject
                        {
                            MarginInlineStart = iconMarginInlineEnd,
                            Opacity = 1,
                            Transition = new object[]
                            {
                                $@"{motionDurationSlow} {motionEaseInOut}",
                                $@"{motionDurationSlow}",
                                $@"{motionDurationSlow}"
                            }.Join(","),
                        },
                    },
                    [$@"{componentCls}-item-icon"] = new CSSObject
                    {
                        ["..."] = ResetIcon(),
                    },
                    [$@"{componentCls}-item-only-child"] = new CSSObject
                    {
                        [$@"{iconCls}, > {componentCls}-item-icon"] = new CSSObject
                        {
                            MarginInlineEnd = 0,
                        },
                    },
                },
                [$@"{componentCls}-item-disabled, {componentCls}-submenu-disabled"] = new CSSObject
                {
                    Background = "none !important",
                    Cursor = "not-allowed",
                    ["&::after"] = new CSSObject
                    {
                        BorderColor = "transparent !important",
                    },
                    ["a"] = new CSSObject
                    {
                        Color = "inherit !important",
                    },
                    [$@"{componentCls}-submenu-title"] = new CSSObject
                    {
                        Color = "inherit !important",
                        Cursor = "not-allowed",
                    },
                },
            };
        }

        public static CSSObject GenSubMenuArrowStyle(MenuToken token)
        {
            var componentCls = token.ComponentCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var motionEaseInOut = token.MotionEaseInOut;
            var borderRadius = token.BorderRadius;
            var menuArrowSize = token.MenuArrowSize;
            var menuArrowOffset = token.MenuArrowOffset;
            return new CSSObject
            {
                [$@"{componentCls}-submenu"] = new CSSObject
                {
                    ["&-expand-icon, &-arrow"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = "50%",
                        InsetInlineEnd = token.Margin,
                        Width = menuArrowSize,
                        Color = "currentcolor",
                        Transform = "translateY(-50%)",
                        Transition = $@"{motionDurationSlow} {motionEaseInOut}, opacity {motionDurationSlow}",
                    },
                    ["&-arrow"] = new CSSObject
                    {
                        ["&::before, &::after"] = new CSSObject
                        {
                            Position = "absolute",
                            Width = token.Calc(menuArrowSize).Mul(0.6).Equal(),
                            Height = token.Calc(menuArrowSize).Mul(0.15).Equal(),
                            BackgroundColor = "currentcolor",
                            Transition = new object[]
                            {
                                $@"{motionDurationSlow} {motionEaseInOut}",
                                $@"{motionDurationSlow} {motionEaseInOut}",
                                $@"{motionDurationSlow} {motionEaseInOut}",
                                $@"{motionDurationSlow} {motionEaseInOut}"
                            }.Join(","),
                            Content = "\"\"",
                        },
                        ["&::before"] = new CSSObject
                        {
                            Transform = $@"{Unit(token.Calc(menuArrowOffset).Mul(-1).Equal())})",
                        },
                        ["&::after"] = new CSSObject
                        {
                            Transform = $@"{Unit(menuArrowOffset)})",
                        },
                    },
                },
            };
        }

        public static CSSObject GetBaseStyle(MenuToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var fontSize = token.FontSize;
            var motionDurationSlow = token.MotionDurationSlow;
            var motionDurationMid = token.MotionDurationMid;
            var motionEaseInOut = token.MotionEaseInOut;
            var paddingXS = token.PaddingXS;
            var padding = token.Padding;
            var colorSplit = token.ColorSplit;
            var lineWidth = token.LineWidth;
            var zIndexPopup = token.ZIndexPopup;
            var borderRadiusLG = token.BorderRadiusLG;
            var subMenuItemBorderRadius = token.SubMenuItemBorderRadius;
            var menuArrowSize = token.MenuArrowSize;
            var menuArrowOffset = token.MenuArrowOffset;
            var lineType = token.LineType;
            var groupTitleLineHeight = token.GroupTitleLineHeight;
            var groupTitleFontSize = token.GroupTitleFontSize;
            return new object[]
            {
                new object
                {
                    [""] = new object
                    {
                        [componentCls] = new object
                        {
                            ["..."] = ClearFix(),
                            ["&-hidden"] = new object
                            {
                                Display = "none",
                            },
                        },
                    },
                    [$@"{componentCls}-submenu-hidden"] = new object
                    {
                        Display = "none",
                    },
                },
                new object
                {
                    [componentCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        ["..."] = ClearFix(),
                        MarginBottom = 0,
                        PaddingInlineStart = 0,
                        LineHeight = 0,
                        ListStyle = "none",
                        Outline = "none",
                        Transition = $@"{motionDurationSlow} cubic-bezier(0.2, 0, 0, 1) 0s",
                        ["ul, ol"] = new object
                        {
                            Margin = 0,
                            Padding = 0,
                            ListStyle = "none",
                        },
                        ["&-overflow"] = new object
                        {
                            Display = "flex",
                            [$@"{componentCls}-item"] = new object
                            {
                                Flex = "none",
                            },
                        },
                        [$@"{componentCls}-item, {componentCls}-submenu, {componentCls}-submenu-title"] = new object
                        {
                            BorderRadius = token.ItemBorderRadius,
                        },
                        [$@"{componentCls}-item-group-title"] = new object
                        {
                            Padding = $@"{Unit(paddingXS)} {Unit(padding)}",
                            FontSize = groupTitleFontSize,
                            LineHeight = groupTitleLineHeight,
                            Transition = $@"{motionDurationSlow}",
                        },
                        [$@"{componentCls}-submenu"] = new object
                        {
                            Transition = new object[]
                            {
                                $@"{motionDurationSlow} {motionEaseInOut}",
                                $@"{motionDurationSlow} {motionEaseInOut}"
                            }.Join(","),
                        },
                        [$@"{componentCls}-submenu, {componentCls}-submenu-inline"] = new object
                        {
                            Transition = new object[]
                            {
                                $@"{motionDurationSlow} {motionEaseInOut}",
                                $@"{motionDurationSlow} {motionEaseInOut}",
                                $@"{motionDurationMid} {motionEaseInOut}"
                            }.Join(","),
                        },
                        [$@"{componentCls}-submenu {componentCls}-sub"] = new object
                        {
                            Cursor = "initial",
                            Transition = new object[]
                            {
                                $@"{motionDurationSlow} {motionEaseInOut}",
                                $@"{motionDurationSlow} {motionEaseInOut}"
                            }.Join(","),
                        },
                        [$@"{componentCls}-title-content"] = new object
                        {
                            Transition = $@"{motionDurationSlow}",
                            ["&-with-extra"] = new object
                            {
                                Display = "inline-flex",
                                AlignItems = "center",
                                Width = "100%",
                            },
                            [$@"{antCls}-typography-ellipsis-single-line"] = new object
                            {
                                Display = "inline",
                                VerticalAlign = "unset",
                            },
                            [$@"{componentCls}-item-extra"] = new object
                            {
                                MarginInlineStart = "auto",
                                PaddingInlineStart = token.Padding,
                                FontSize = token.FontSizeSM,
                            },
                        },
                        [$@"{componentCls}-item a"] = new object
                        {
                            ["&::before"] = new object
                            {
                                Position = "absolute",
                                Inset = 0,
                                BackgroundColor = "transparent",
                                Content = "\"\"",
                            },
                        },
                        [$@"{componentCls}-item-divider"] = new object
                        {
                            Overflow = "hidden",
                            LineHeight = 0,
                            BorderColor = colorSplit,
                            BorderStyle = lineType,
                            BorderWidth = 0,
                            BorderTopWidth = lineWidth,
                            MarginBlock = lineWidth,
                            Padding = 0,
                            ["&-dashed"] = new object
                            {
                                BorderStyle = "dashed",
                            },
                        },
                        ["..."] = GenMenuItemStyle(token),
                        [$@"{componentCls}-item-group"] = new object
                        {
                            [$@"{componentCls}-item-group-list"] = new object
                            {
                                Margin = 0,
                                Padding = 0,
                                [$@"{componentCls}-item, {componentCls}-submenu-title"] = new object
                                {
                                    PaddingInline = $@"{Unit(token.Calc(fontSize).Mul(2).Equal())} {Unit(padding)}",
                                },
                            },
                        },
                        ["&-submenu"] = new object
                        {
                            ["&-popup"] = new object
                            {
                                Position = "absolute",
                                ZIndex = zIndexPopup,
                                BorderRadius = borderRadiusLG,
                                BoxShadow = "none",
                                TransformOrigin = "0 0",
                                [$@"{componentCls}-submenu"] = new object
                                {
                                    Background = "transparent",
                                },
                                ["&::before"] = new object
                                {
                                    Position = "absolute",
                                    Inset = 0,
                                    ZIndex = -1,
                                    Width = "100%",
                                    Height = "100%",
                                    Opacity = 0,
                                    Content = "\"\"",
                                },
                                [$@"{componentCls}"] = new object
                                {
                                    BorderRadius = borderRadiusLG,
                                    ["..."] = GenMenuItemStyle(token),
                                    ["..."] = GenSubMenuArrowStyle(token),
                                    [$@"{componentCls}-item, {componentCls}-submenu > {componentCls}-submenu-title"] = new object
                                    {
                                        BorderRadius = subMenuItemBorderRadius,
                                    },
                                    [$@"{componentCls}-submenu-title::after"] = new object
                                    {
                                        Transition = $@"{motionDurationSlow} {motionEaseInOut}",
                                    },
                                },
                            },
                            ["\n          &-placement-leftTop,\n          &-placement-bottomRight,\n          "] = new object
                            {
                                TransformOrigin = "100% 0",
                            },
                            ["\n          &-placement-leftBottom,\n          &-placement-topRight,\n          "] = new object
                            {
                                TransformOrigin = "100% 100%",
                            },
                            ["\n          &-placement-rightBottom,\n          &-placement-topLeft,\n          "] = new object
                            {
                                TransformOrigin = "0 100%",
                            },
                            ["\n          &-placement-bottomLeft,\n          &-placement-rightTop,\n          "] = new object
                            {
                                TransformOrigin = "0 0",
                            },
                            ["\n          &-placement-leftTop,\n          &-placement-leftBottom\n          "] = new object
                            {
                                PaddingInlineEnd = token.PaddingXS,
                            },
                            ["\n          &-placement-rightTop,\n          &-placement-rightBottom\n          "] = new object
                            {
                                PaddingInlineStart = token.PaddingXS,
                            },
                            ["\n          &-placement-topRight,\n          &-placement-topLeft\n          "] = new object
                            {
                                PaddingBottom = token.PaddingXS,
                            },
                            ["\n          &-placement-bottomRight,\n          &-placement-bottomLeft\n          "] = new object
                            {
                                PaddingTop = token.PaddingXS,
                            },
                        },
                        ["..."] = GenSubMenuArrowStyle(token),
                        [$@"{componentCls}-submenu-arrow,
        &-inline {componentCls}-submenu-arrow"] = new object
                        {
                            ["&::before"] = new object
                            {
                                Transform = $@"{Unit(menuArrowOffset)})",
                            },
                            ["&::after"] = new object
                            {
                                Transform = $@"{Unit(token.Calc(menuArrowOffset).Mul(-1).Equal())})",
                            },
                        },
                        [$@"{componentCls}-submenu-open{componentCls}-submenu-inline > {componentCls}-submenu-title > {componentCls}-submenu-arrow"] = new object
                        {
                            Transform = $@"{Unit(token.Calc(menuArrowSize).Mul(0.2).Mul(-1).Equal())})",
                            ["&::after"] = new object
                            {
                                Transform = $@"{Unit(token.Calc(menuArrowOffset).Mul(-1).Equal())})",
                            },
                            ["&::before"] = new object
                            {
                                Transform = $@"{Unit(menuArrowOffset)})",
                            },
                        },
                    },
                },
                new object
                {
                    [$@"{antCls}-layout-header"] = new object
                    {
                        [componentCls] = new object
                        {
                            LineHeight = "inherit",
                        },
                    },
                }
            };
        }

        public static MenuToken PrepareComponentToken(MenuToken token)
        {
            var colorPrimary = token.ColorPrimary;
            var colorError = token.ColorError;
            var colorTextDisabled = token.ColorTextDisabled;
            var colorErrorBg = token.ColorErrorBg;
            var colorText = token.ColorText;
            var colorTextDescription = token.ColorTextDescription;
            var colorBgContainer = token.ColorBgContainer;
            var colorFillAlter = token.ColorFillAlter;
            var colorFillContent = token.ColorFillContent;
            var lineWidth = token.LineWidth;
            var lineWidthBold = token.LineWidthBold;
            var controlItemBgActive = token.ControlItemBgActive;
            var colorBgTextHover = token.ColorBgTextHover;
            var controlHeightLG = token.ControlHeightLG;
            var lineHeight = token.LineHeight;
            var colorBgElevated = token.ColorBgElevated;
            var marginXXS = token.MarginXXS;
            var padding = token.Padding;
            var fontSize = token.FontSize;
            var controlHeightSM = token.ControlHeightSM;
            var fontSizeLG = token.FontSizeLG;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var colorErrorHover = token.ColorErrorHover;
            var activeBarWidth = 0;
            var activeBarBorderWidth = lineWidth;
            var itemMarginInline = token.MarginXXS;
            var colorTextDark = new TinyColor(colorTextLightSolid).SetAlpha(0.65).ToRgbString();
            return new MenuToken
            {
                DropdownWidth = 160,
                ZIndexPopup = token.ZIndexPopupBase + 50,
                RadiusItem = token.BorderRadiusLG,
                ItemBorderRadius = token.BorderRadiusLG,
                RadiusSubMenuItem = token.BorderRadiusSM,
                SubMenuItemBorderRadius = token.BorderRadiusSM,
                ColorItemText = colorText,
                ItemColor = colorText,
                ColorItemTextHover = colorText,
                ItemHoverColor = colorText,
                ColorItemTextHoverHorizontal = colorPrimary,
                HorizontalItemHoverColor = colorPrimary,
                ColorGroupTitle = colorTextDescription,
                GroupTitleColor = colorTextDescription,
                ColorItemTextSelected = colorPrimary,
                ItemSelectedColor = colorPrimary,
                ColorItemTextSelectedHorizontal = colorPrimary,
                HorizontalItemSelectedColor = colorPrimary,
                ColorItemBg = colorBgContainer,
                ItemBg = colorBgContainer,
                ColorItemBgHover = colorBgTextHover,
                ItemHoverBg = colorBgTextHover,
                ColorItemBgActive = colorFillContent,
                ItemActiveBg = controlItemBgActive,
                ColorSubItemBg = colorFillAlter,
                SubMenuItemBg = colorFillAlter,
                ColorItemBgSelected = controlItemBgActive,
                ItemSelectedBg = controlItemBgActive,
                ColorItemBgSelectedHorizontal = "transparent",
                HorizontalItemSelectedBg = "transparent",
                ColorActiveBarWidth = 0,
                ColorActiveBarHeight = lineWidthBold,
                ActiveBarHeight = lineWidthBold,
                ColorActiveBarBorderSize = lineWidth,
                ColorItemTextDisabled = colorTextDisabled,
                ItemDisabledColor = colorTextDisabled,
                ColorDangerItemText = colorError,
                DangerItemColor = colorError,
                ColorDangerItemTextHover = colorError,
                DangerItemHoverColor = colorError,
                ColorDangerItemTextSelected = colorError,
                DangerItemSelectedColor = colorError,
                ColorDangerItemBgActive = colorErrorBg,
                DangerItemActiveBg = colorErrorBg,
                ColorDangerItemBgSelected = colorErrorBg,
                DangerItemSelectedBg = colorErrorBg,
                HorizontalItemBorderRadius = 0,
                HorizontalItemHoverBg = "transparent",
                ItemHeight = controlHeightLG,
                GroupTitleLineHeight = lineHeight,
                CollapsedWidth = controlHeightLG * 2,
                PopupBg = colorBgElevated,
                ItemMarginBlock = marginXXS,
                ItemPaddingInline = padding,
                HorizontalLineHeight = $@"{controlHeightLG * 1.15}px",
                IconSize = fontSize,
                IconMarginInlineEnd = controlHeightSM - fontSize,
                CollapsedIconSize = fontSizeLG,
                GroupTitleFontSize = fontSize,
                DarkItemDisabledColor = new TinyColor(colorTextLightSolid).SetAlpha(0.25).ToRgbString(),
                DarkItemColor = colorTextDark,
                DarkDangerItemColor = colorError,
                DarkItemBg = "#001529",
                DarkPopupBg = "#001529",
                DarkSubMenuItemBg = "#000c17",
                DarkItemSelectedColor = colorTextLightSolid,
                DarkItemSelectedBg = colorPrimary,
                DarkDangerItemSelectedBg = colorError,
                DarkItemHoverBg = "transparent",
                DarkGroupTitleColor = colorTextDark,
                DarkItemHoverColor = colorTextLightSolid,
                DarkDangerItemHoverColor = colorErrorHover,
                DarkDangerItemSelectedColor = colorTextLightSolid,
                DarkDangerItemActiveBg = colorError,
                ItemWidth = activeBarWidth ? $@"{activeBarBorderWidth}px)" : $@"{itemMarginInline * 2}px)",
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return (string prefixCls, string rootCls, CSSObject injectStyle) =>
            {
                var useStyle = GenStyleHooks("Menu", (MenuToken token) =>
                {
                    var colorBgElevated = token.ColorBgElevated;
                    var controlHeightLG = token.ControlHeightLG;
                    var fontSize = token.FontSize;
                    var darkItemColor = token.DarkItemColor;
                    var darkDangerItemColor = token.DarkDangerItemColor;
                    var darkItemBg = token.DarkItemBg;
                    var darkSubMenuItemBg = token.DarkSubMenuItemBg;
                    var darkItemSelectedColor = token.DarkItemSelectedColor;
                    var darkItemSelectedBg = token.DarkItemSelectedBg;
                    var darkDangerItemSelectedBg = token.DarkDangerItemSelectedBg;
                    var darkItemHoverBg = token.DarkItemHoverBg;
                    var darkGroupTitleColor = token.DarkGroupTitleColor;
                    var darkItemHoverColor = token.DarkItemHoverColor;
                    var darkItemDisabledColor = token.DarkItemDisabledColor;
                    var darkDangerItemHoverColor = token.DarkDangerItemHoverColor;
                    var darkDangerItemSelectedColor = token.DarkDangerItemSelectedColor;
                    var darkDangerItemActiveBg = token.DarkDangerItemActiveBg;
                    var popupBg = token.PopupBg;
                    var darkPopupBg = token.DarkPopupBg;
                    var menuArrowSize = token.Calc(fontSize).Div(7).Mul(5).Equal();
                    var menuToken = MergeToken(token, new object { MenuHorizontalHeight = token.Calc(controlHeightLG).Mul(1.15).Equal(), MenuArrowOffset = token.Calc(menuArrowSize).Mul(0.25).Equal(), MenuSubMenuBg = colorBgElevated, Calc = token.Calc, });
                    var menuDarkToken = MergeToken(menuToken, new object { ItemColor = darkItemColor, ItemHoverColor = darkItemHoverColor, GroupTitleColor = darkGroupTitleColor, ItemSelectedColor = darkItemSelectedColor, ItemBg = darkItemBg, PopupBg = darkPopupBg, SubMenuItemBg = darkSubMenuItemBg, ItemActiveBg = "transparent", ItemSelectedBg = darkItemSelectedBg, ActiveBarHeight = 0, ActiveBarBorderWidth = 0, ItemHoverBg = darkItemHoverBg, ItemDisabledColor = darkItemDisabledColor, DangerItemColor = darkDangerItemColor, DangerItemHoverColor = darkDangerItemHoverColor, DangerItemSelectedColor = darkDangerItemSelectedColor, DangerItemActiveBg = darkDangerItemActiveBg, DangerItemSelectedBg = darkDangerItemSelectedBg, MenuSubMenuBg = darkSubMenuItemBg, HorizontalItemSelectedColor = darkItemSelectedColor, HorizontalItemSelectedBg = darkItemSelectedBg, });
                    return new object[]
                    {
                        GetBaseStyle(menuToken),
                        GetHorizontalStyle(menuToken),
                        GetVerticalStyle(menuToken),
                        GetThemeStyle(menuToken, "light"),
                        GetThemeStyle(menuDarkToken, "dark"),
                        GetRTLStyle(menuToken),
                        GenCollapseMotion(menuToken),
                        InitSlideMotion(menuToken, "slide-up"),
                        InitSlideMotion(menuToken, "slide-down"),
                        InitZoomMotion(menuToken, "zoom-big")
                    };
                }, PrepareComponentToken, new object { DeprecatedTokens = new object[] { new object[] { "colorGroupTitle", "groupTitleColor" }, new object[] { "radiusItem", "itemBorderRadius" }, new object[] { "radiusSubMenuItem", "subMenuItemBorderRadius" }, new object[] { "colorItemText", "itemColor" }, new object[] { "colorItemTextHover", "itemHoverColor" }, new object[] { "colorItemTextHoverHorizontal", "horizontalItemHoverColor" }, new object[] { "colorItemTextSelected", "itemSelectedColor" }, new object[] { "colorItemTextSelectedHorizontal", "horizontalItemSelectedColor" }, new object[] { "colorItemTextDisabled", "itemDisabledColor" }, new object[] { "colorDangerItemText", "dangerItemColor" }, new object[] { "colorDangerItemTextHover", "dangerItemHoverColor" }, new object[] { "colorDangerItemTextSelected", "dangerItemSelectedColor" }, new object[] { "colorDangerItemBgActive", "dangerItemActiveBg" }, new object[] { "colorDangerItemBgSelected", "dangerItemSelectedBg" }, new object[] { "colorItemBg", "itemBg" }, new object[] { "colorItemBgHover", "itemHoverBg" }, new object[] { "colorSubItemBg", "subMenuItemBg" }, new object[] { "colorItemBgActive", "itemActiveBg" }, new object[] { "colorItemBgSelectedHorizontal", "horizontalItemSelectedBg" }, new object[] { "colorActiveBarWidth", "activeBarWidth" }, new object[] { "colorActiveBarHeight", "activeBarHeight" }, new object[] { "colorActiveBarBorderSize", "activeBarBorderWidth" }, new object[] { "colorItemBgSelected", "itemSelectedBg" } }, Unitless = new object { GroupTitleLineHeight = true, }, });
                return UseStyle(prefixCls, rootCls);
            };
        }
    }
}