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
    public partial class DatePickerStyle
    {
        public static CSSInterpolation GenSize(PickerToken token, string suffix)
        {
            var componentCls = token.ComponentCls;
            var controlHeight = token.ControlHeight;
            var suffixCls = suffix ? $@"{componentCls}-{suffix}" : "";
            var multipleSelectorUnit = GetMultipleSelectorUnit(token);
            return new object[]
            {
                new object
                {
                    [$@"{componentCls}-multiple{suffixCls}"] = new object
                    {
                        PaddingBlock = multipleSelectorUnit.ContainerPadding,
                        PaddingInlineStart = multipleSelectorUnit.BasePadding,
                        MinHeight = controlHeight,
                        [$@"{componentCls}-selection-item"] = new object
                        {
                            Height = multipleSelectorUnit.ItemHeight,
                            LineHeight = Unit(multipleSelectorUnit.ItemLineHeight),
                        },
                    },
                }
            };
        }

        public static CSSObject GenPickerMultipleStyle(DatePickerToken token)
        {
            var componentCls = token.ComponentCls;
            var calc = token.Calc;
            var lineWidth = token.LineWidth;
            var smallToken = MergeToken(token, new object { FontHeight = token.FontSize, SelectHeight = token.ControlHeightSM, MultipleSelectItemHeight = token.MultipleItemHeightSM, BorderRadius = token.BorderRadiusSM, BorderRadiusSM = token.BorderRadiusXS, ControlHeight = token.ControlHeightSM, });
            var largeToken = MergeToken(token, new object { FontHeight = calc(token.multipleItemHeightLG)
      .sub(calc(lineWidth).mul(2).equal()).Equal() as number, FontSize = token.FontSizeLG, SelectHeight = token.ControlHeightLG, MultipleSelectItemHeight = token.MultipleItemHeightLG, BorderRadius = token.BorderRadiusLG, BorderRadiusSM = token.BorderRadius, ControlHeight = token.ControlHeightLG, });
            return new object[]
            {
                GenSize(smallToken, "small"),
                GenSize(token),
                GenSize(largeToken, "large"),
                new object
                {
                    [$@"{componentCls}{componentCls}-multiple"] = new object
                    {
                        Width = "100%",
                        Cursor = "text",
                        [$@"{componentCls}-selector"] = new object
                        {
                            Flex = "auto",
                            Padding = 0,
                            Position = "relative",
                            ["&:after"] = new object
                            {
                                Margin = 0,
                            },
                            [$@"{componentCls}-selection-placeholder"] = new object
                            {
                                Position = "absolute",
                                Top = "50%",
                                InsetInlineStart = token.InputPaddingHorizontalBase,
                                InsetInlineEnd = 0,
                                Transform = "translateY(-50%)",
                                Transition = $@"{token.MotionDurationSlow}",
                                Overflow = "hidden",
                                WhiteSpace = "nowrap",
                                TextOverflow = "ellipsis",
                                Flex = 1,
                                Color = token.ColorTextPlaceholder,
                                PointerEvents = "none",
                            },
                        },
                        ["..."] = GenOverflowStyle(token),
                        [$@"{componentCls}-multiple-input"] = new object
                        {
                            Width = 0,
                            Height = 0,
                            Border = 0,
                            Visibility = "hidden",
                            Position = "absolute",
                            ZIndex = -1,
                        },
                    },
                }
            };
        }

        public static object MultipleDefault()
        {
            return genPickerMultipleStyle;
        }
    }
}