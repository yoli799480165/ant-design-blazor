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
    public partial class DropdownStyle
    {
        public class ComponentToken : TokenWithCommonCls : ArrowToken, ArrowOffsetToken
        {
            public double ZIndexPopup { get; set; }
            public string PaddingBlock { get; set; }
        }

        public class DropdownToken : ComponentToken
        {
            public string DropdownArrowDistance { get; set; }
            public double DropdownEdgeChildPadding { get; set; }
            public string MenuCls { get; set; }
        }

        public static CSSObject GenBaseStyle(DropdownToken token)
        {
            var componentCls = token.ComponentCls;
            var menuCls = token.MenuCls;
            var zIndexPopup = token.ZIndexPopup;
            var dropdownArrowDistance = token.DropdownArrowDistance;
            var sizePopupArrow = token.SizePopupArrow;
            var antCls = token.AntCls;
            var iconCls = token.IconCls;
            var motionDurationMid = token.MotionDurationMid;
            var paddingBlock = token.PaddingBlock;
            var fontSize = token.FontSize;
            var dropdownEdgeChildPadding = token.DropdownEdgeChildPadding;
            var colorTextDisabled = token.ColorTextDisabled;
            var fontSizeIcon = token.FontSizeIcon;
            var controlPaddingHorizontal = token.ControlPaddingHorizontal;
            var colorBgElevated = token.ColorBgElevated;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        Position = "absolute",
                        Top = -9999,
                        Left = new object
                        {
                            _skip_check_ = true,
                            Value = -9999,
                        },
                        ZIndex = zIndexPopup,
                        Display = "block",
                        ["&::before"] = new object
                        {
                            Position = "absolute",
                            InsetBlock = token.Calc(sizePopupArrow).Div(2).Sub(dropdownArrowDistance).Equal(),
                            ZIndex = -9999,
                            Opacity = 0.0001,
                            Content = "\"\"",
                        },
                        ["&-menu-vertical"] = new object
                        {
                            MaxHeight = "100vh",
                            OverflowY = "auto",
                        },
                        [$@"{antCls}-btn"] = new object
                        {
                            [$@"{iconCls}-down, & > {antCls}-btn-icon > {iconCls}-down"] = new object
                            {
                                FontSize = fontSizeIcon,
                            },
                        },
                        [$@"{componentCls}-wrap"] = new object
                        {
                            Position = "relative",
                            [$@"{antCls}-btn > {iconCls}-down"] = new object
                            {
                                FontSize = fontSizeIcon,
                            },
                            [$@"{iconCls}-down::before"] = new object
                            {
                                Transition = $@"{motionDurationMid}",
                            },
                        },
                        [$@"{componentCls}-wrap-open"] = new object
                        {
                            [$@"{iconCls}-down::before"] = new object
                            {
                                Transform = "rotate(180deg)",
                            },
                        },
                        ["\n        &-hidden,\n        &-menu-hidden,\n        &-menu-submenu-hidden\n      "] = new object
                        {
                            Display = "none",
                        },
                        [$@"{antCls}-slide-down-enter{antCls}-slide-down-enter-active{componentCls}-placement-bottomLeft,
          &{antCls}-slide-down-appear{antCls}-slide-down-appear-active{componentCls}-placement-bottomLeft,
          &{antCls}-slide-down-enter{antCls}-slide-down-enter-active{componentCls}-placement-bottom,
          &{antCls}-slide-down-appear{antCls}-slide-down-appear-active{componentCls}-placement-bottom,
          &{antCls}-slide-down-enter{antCls}-slide-down-enter-active{componentCls}-placement-bottomRight,
          &{antCls}-slide-down-appear{antCls}-slide-down-appear-active{componentCls}-placement-bottomRight"] = new object
                        {
                            AnimationName = slideUpIn,
                        },
                        [$@"{antCls}-slide-up-enter{antCls}-slide-up-enter-active{componentCls}-placement-topLeft,
          &{antCls}-slide-up-appear{antCls}-slide-up-appear-active{componentCls}-placement-topLeft,
          &{antCls}-slide-up-enter{antCls}-slide-up-enter-active{componentCls}-placement-top,
          &{antCls}-slide-up-appear{antCls}-slide-up-appear-active{componentCls}-placement-top,
          &{antCls}-slide-up-enter{antCls}-slide-up-enter-active{componentCls}-placement-topRight,
          &{antCls}-slide-up-appear{antCls}-slide-up-appear-active{componentCls}-placement-topRight"] = new object
                        {
                            AnimationName = slideDownIn,
                        },
                        [$@"{antCls}-slide-down-leave{antCls}-slide-down-leave-active{componentCls}-placement-bottomLeft,
          &{antCls}-slide-down-leave{antCls}-slide-down-leave-active{componentCls}-placement-bottom,
          &{antCls}-slide-down-leave{antCls}-slide-down-leave-active{componentCls}-placement-bottomRight"] = new object
                        {
                            AnimationName = slideUpOut,
                        },
                        [$@"{antCls}-slide-up-leave{antCls}-slide-up-leave-active{componentCls}-placement-topLeft,
          &{antCls}-slide-up-leave{antCls}-slide-up-leave-active{componentCls}-placement-top,
          &{antCls}-slide-up-leave{antCls}-slide-up-leave-active{componentCls}-placement-topRight"] = new object
                        {
                            AnimationName = slideDownOut,
                        },
                    },
                },
                GetArrowStyle(token, colorBgElevated, new object { ArrowPlacement = new object { Top = true, Bottom = true, }, }),
                new object
                {
                    [$@"{componentCls} {menuCls}"] = new object
                    {
                        Position = "relative",
                        Margin = 0,
                    },
                    [$@"{menuCls}-submenu-popup"] = new object
                    {
                        Position = "absolute",
                        ZIndex = zIndexPopup,
                        Background = "transparent",
                        BoxShadow = "none",
                        TransformOrigin = "0 0",
                        ["ul, li"] = new object
                        {
                            ListStyle = "none",
                            Margin = 0,
                        },
                    },
                    [$@"{componentCls}, {componentCls}-menu-submenu"] = new object
                    {
                        ["..."] = ResetComponent(token),
                        [menuCls] = new object
                        {
                            Padding = dropdownEdgeChildPadding,
                            ListStyleType = "none",
                            BackgroundColor = colorBgElevated,
                            BackgroundClip = "padding-box",
                            BorderRadius = token.BorderRadiusLG,
                            Outline = "none",
                            BoxShadow = token.BoxShadowSecondary,
                            ["..."] = GenFocusStyle(token),
                            ["&:empty"] = new object
                            {
                                Padding = 0,
                                BoxShadow = "none",
                            },
                            [$@"{menuCls}-item-group-title"] = new object
                            {
                                Padding = $@"{Unit(paddingBlock!)} {Unit(controlPaddingHorizontal)}",
                                Color = token.ColorTextDescription,
                                Transition = $@"{motionDurationMid}",
                            },
                            [$@"{menuCls}-item"] = new object
                            {
                                Position = "relative",
                                Display = "flex",
                                AlignItems = "center",
                            },
                            [$@"{menuCls}-item-icon"] = new object
                            {
                                MinWidth = fontSize,
                                MarginInlineEnd = token.MarginXS,
                                FontSize = token.FontSizeSM,
                            },
                            [$@"{menuCls}-title-content"] = new object
                            {
                                Flex = "auto",
                                ["&-with-extra"] = new object
                                {
                                    Display = "inline-flex",
                                    AlignItems = "center",
                                    Width = "100%",
                                },
                                ["> a"] = new object
                                {
                                    Color = "inherit",
                                    Transition = $@"{motionDurationMid}",
                                    ["&:hover"] = new object
                                    {
                                        Color = "inherit",
                                    },
                                    ["&::after"] = new object
                                    {
                                        Position = "absolute",
                                        Inset = 0,
                                        Content = "\"\"",
                                    },
                                },
                                [$@"{menuCls}-item-extra"] = new object
                                {
                                    PaddingInlineStart = token.Padding,
                                    MarginInlineStart = "auto",
                                    FontSize = token.FontSizeSM,
                                    Color = token.ColorTextDescription,
                                },
                            },
                            [$@"{menuCls}-item, {menuCls}-submenu-title"] = new object
                            {
                                Display = "flex",
                                Margin = 0,
                                Padding = $@"{Unit(paddingBlock!)} {Unit(controlPaddingHorizontal)}",
                                Color = token.ColorText,
                                FontWeight = "normal",
                                LineHeight = token.LineHeight,
                                Cursor = "pointer",
                                Transition = $@"{motionDurationMid}",
                                BorderRadius = token.BorderRadiusSM,
                                ["&:hover, &-active"] = new object
                                {
                                    BackgroundColor = token.ControlItemBgHover,
                                },
                                ["..."] = GenFocusStyle(token),
                                ["&-selected"] = new object
                                {
                                    Color = token.ColorPrimary,
                                    BackgroundColor = token.ControlItemBgActive,
                                    ["&:hover, &-active"] = new object
                                    {
                                        BackgroundColor = token.ControlItemBgActiveHover,
                                    },
                                },
                                ["&-disabled"] = new object
                                {
                                    Color = colorTextDisabled,
                                    Cursor = "not-allowed",
                                    ["&:hover"] = new object
                                    {
                                        Color = colorTextDisabled,
                                        BackgroundColor = colorBgElevated,
                                        Cursor = "not-allowed",
                                    },
                                    ["a"] = new object
                                    {
                                        PointerEvents = "none",
                                    },
                                },
                                ["&-divider"] = new object
                                {
                                    Height = 1,
                                    Margin = $@"{Unit(token.MarginXXS)} 0",
                                    Overflow = "hidden",
                                    LineHeight = 0,
                                    BackgroundColor = token.ColorSplit,
                                },
                                [$@"{componentCls}-menu-submenu-expand-icon"] = new object
                                {
                                    Position = "absolute",
                                    InsetInlineEnd = token.PaddingXS,
                                    [$@"{componentCls}-menu-submenu-arrow-icon"] = new object
                                    {
                                        MarginInlineEnd = "0 !important",
                                        Color = token.ColorTextDescription,
                                        FontSize = fontSizeIcon,
                                        FontStyle = "normal",
                                    },
                                },
                            },
                            [$@"{menuCls}-item-group-list"] = new object
                            {
                                Margin = $@"{Unit(token.MarginXS)}",
                                Padding = 0,
                                ListStyle = "none",
                            },
                            [$@"{menuCls}-submenu-title"] = new object
                            {
                                PaddingInlineEnd = token.Calc(controlPaddingHorizontal).Add(token.FontSizeSM).Equal(),
                            },
                            [$@"{menuCls}-submenu-vertical"] = new object
                            {
                                Position = "relative",
                            },
                            [$@"{menuCls}-submenu{menuCls}-submenu-disabled {componentCls}-menu-submenu-title"] = new object
                            {
                                [$@"{componentCls}-menu-submenu-arrow-icon"] = new object
                                {
                                    Color = colorTextDisabled,
                                    BackgroundColor = colorBgElevated,
                                    Cursor = "not-allowed",
                                },
                            },
                            [$@"{menuCls}-submenu-selected {componentCls}-menu-submenu-title"] = new object
                            {
                                Color = token.ColorPrimary,
                            },
                        },
                    },
                },
                new object[]
                {
                    InitSlideMotion(token, "slide-up"),
                    InitSlideMotion(token, "slide-down"),
                    InitMoveMotion(token, "move-up"),
                    InitMoveMotion(token, "move-down"),
                    InitZoomMotion(token, "zoom-big")
                }
            };
        }

        public static DropdownToken PrepareComponentToken(DropdownToken token)
        {
            return new DropdownToken
            {
                ZIndexPopup = token.ZIndexPopupBase + 50,
                PaddingBlock = (token.ControlHeight - token.FontSize * token.LineHeight) / 2,
                ["..."] = GetArrowOffsetToken(new object { ContentRadius = token.BorderRadiusLG, LimitVerticalRadius = true, }),
                ["..."] = GetArrowToken(token),
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Dropdown", (DropdownToken token) =>
            {
                var marginXXS = token.MarginXXS;
                var sizePopupArrow = token.SizePopupArrow;
                var paddingXXS = token.PaddingXXS;
                var componentCls = token.ComponentCls;
                var dropdownToken = MergeToken(token, new object { MenuCls = $@"{componentCls}-menu", DropdownArrowDistance = token.Calc(sizePopupArrow).Div(2).Add(marginXXS).Equal(), DropdownEdgeChildPadding = paddingXXS, });
                return new object[]
                {
                    GenBaseStyle(dropdownToken),
                    GenStatusStyle(dropdownToken)
                };
            }, PrepareComponentToken, new object { ResetStyle = false, });
        }
    }
}