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
    public partial class SelectStyle
    {
        public static CSSObject GenItemStyle(SelectToken token)
        {
            var optionHeight = token.OptionHeight;
            var optionFontSize = token.OptionFontSize;
            var optionLineHeight = token.OptionLineHeight;
            var optionPadding = token.OptionPadding;
            return new CSSObject
            {
                Position = "relative",
                Display = "block",
                MinHeight = optionHeight,
                Padding = optionPadding,
                Color = token.ColorText,
                FontWeight = "normal",
                FontSize = optionFontSize,
                LineHeight = optionLineHeight,
                BoxSizing = "border-box",
            };
        }

        public static CSSObject GenSingleStyle(SelectToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var selectItemCls = $@"{componentCls}-item";
            var slideUpEnterActive = $@"{antCls}-slide-up-enter{antCls}-slide-up-enter-active";
            var slideUpAppearActive = $@"{antCls}-slide-up-appear{antCls}-slide-up-appear-active";
            var slideUpLeaveActive = $@"{antCls}-slide-up-leave{antCls}-slide-up-leave-active";
            var dropdownPlacementCls = $@"{componentCls}-dropdown-placement-";
            return new object[]
            {
                new object
                {
                    [$@"{componentCls}-dropdown"] = new object
                    {
                        ["..."] = ResetComponent(token),
                        Position = "absolute",
                        Top = -9999,
                        ZIndex = token.ZIndexPopup,
                        BoxSizing = "border-box",
                        Padding = token.PaddingXXS,
                        Overflow = "hidden",
                        FontSize = token.FontSize,
                        FontVariant = "initial",
                        BackgroundColor = token.ColorBgElevated,
                        BorderRadius = token.BorderRadiusLG,
                        Outline = "none",
                        BoxShadow = token.BoxShadowSecondary,
                        [$@"{slideUpEnterActive}{dropdownPlacementCls}bottomLeft,
          {slideUpAppearActive}{dropdownPlacementCls}bottomLeft
        "] = new object
                        {
                            AnimationName = slideUpIn,
                        },
                        [$@"{slideUpEnterActive}{dropdownPlacementCls}topLeft,
          {slideUpAppearActive}{dropdownPlacementCls}topLeft,
          {slideUpEnterActive}{dropdownPlacementCls}topRight,
          {slideUpAppearActive}{dropdownPlacementCls}topRight
        "] = new object
                        {
                            AnimationName = slideDownIn,
                        },
                        [$@"{slideUpLeaveActive}{dropdownPlacementCls}bottomLeft"] = new object
                        {
                            AnimationName = slideUpOut,
                        },
                        [$@"{slideUpLeaveActive}{dropdownPlacementCls}topLeft,
          {slideUpLeaveActive}{dropdownPlacementCls}topRight
        "] = new object
                        {
                            AnimationName = slideDownOut,
                        },
                        ["&-hidden"] = new object
                        {
                            Display = "none",
                        },
                        [selectItemCls] = new object
                        {
                            ["..."] = GenItemStyle(token),
                            Cursor = "pointer",
                            Transition = $@"{token.MotionDurationSlow} ease",
                            BorderRadius = token.BorderRadiusSM,
                            ["&-group"] = new object
                            {
                                Color = token.ColorTextDescription,
                                FontSize = token.FontSizeSM,
                                Cursor = "default",
                            },
                            ["&-option"] = new object
                            {
                                Display = "flex",
                                ["&-content"] = new object
                                {
                                    Flex = "auto",
                                    ["..."] = textEllipsis,
                                },
                                ["&-state"] = new object
                                {
                                    Flex = "none",
                                    Display = "flex",
                                    AlignItems = "center",
                                },
                                [$@"{selectItemCls}-option-disabled)"] = new object
                                {
                                    BackgroundColor = token.OptionActiveBg,
                                },
                                [$@"{selectItemCls}-option-disabled)"] = new object
                                {
                                    Color = token.OptionSelectedColor,
                                    FontWeight = token.OptionSelectedFontWeight,
                                    BackgroundColor = token.OptionSelectedBg,
                                    [$@"{selectItemCls}-option-state"] = new object
                                    {
                                        Color = token.ColorPrimary,
                                    },
                                    [$@"{selectItemCls}-option-selected:not({selectItemCls}-option-disabled))"] = new object
                                    {
                                        BorderEndStartRadius = 0,
                                        BorderEndEndRadius = 0,
                                        [$@"{selectItemCls}-option-selected:not({selectItemCls}-option-disabled)"] = new object
                                        {
                                            BorderStartStartRadius = 0,
                                            BorderStartEndRadius = 0,
                                        },
                                    },
                                },
                                ["&-disabled"] = new object
                                {
                                    [$@"{selectItemCls}-option-selected"] = new object
                                    {
                                        BackgroundColor = token.ColorBgContainerDisabled,
                                    },
                                    Color = token.ColorTextDisabled,
                                    Cursor = "not-allowed",
                                },
                                ["&-grouped"] = new object
                                {
                                    PaddingInlineStart = token.Calc(token.ControlPaddingHorizontal).Mul(2).Equal(),
                                },
                            },
                            ["&-empty"] = new object
                            {
                                ["..."] = GenItemStyle(token),
                                Color = token.ColorTextDisabled,
                            },
                        },
                        ["&-rtl"] = new object
                        {
                            Direction = "rtl",
                        },
                    },
                },
                InitSlideMotion(token, "slide-up"),
                InitSlideMotion(token, "slide-down"),
                InitMoveMotion(token, "move-up"),
                InitMoveMotion(token, "move-down")
            };
        }

        public static object DropdownDefault()
        {
            return GenSingleStyle;
        }
    }
}